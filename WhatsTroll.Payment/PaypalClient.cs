using BraintreeHttp;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WhatsTroll.Payment
{
    public class PaypalClient
    {
        /**
            Set up PayPal environment with sandbox credentials.
            In production, use LiveEnvironment.
         */
        public static PayPalEnvironment environment()
        {
            return new SandboxEnvironment("ARnf-tKM_M-ehARaSDnjzn2Ioy4yZ4O7PfSCHtRhzn5Wk71eDR7Syqk4FejMg7fa3Zx4vpFPJPTzcn0U", "ECUFmjajJo0-ktBqiVp_NkDCGI-A2ftFRK1ZufTJzPZCe2Y-bUQqr2rlqSovg2Cfei2NIfp9eLHKHTYL");
        }

        public static HttpClient client()
        {
            return new PayPalHttpClient(environment());
        }

        public static HttpClient client(string refreshToken)
        {
            return new PayPalHttpClient(environment(), refreshToken);
        }

        public static String ObjectToJSONString(Object serializableObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(
                        memoryStream, Encoding.UTF8, true, true, "  ");
            DataContractJsonSerializer ser = new DataContractJsonSerializer(serializableObject.GetType(), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
            ser.WriteObject(writer, serializableObject);
            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }

        public async static Task<HttpResponse> GetOrder(string orderId, bool debug = false)
        {
            OrdersGetRequest request = new OrdersGetRequest(orderId);
            //3. Call PayPal to get the transaction
            var response = await client().Execute(request);
            //4. Save the transaction in your database. Implement logic to save transaction to your database for future reference.
            var result = response.Result<Order>();
            Console.WriteLine("Retrieved Order Status");
            Console.WriteLine("Status: {0}", result.Status);
            Console.WriteLine("Order Id: {0}", result.Id);
            //Console.WriteLine("Intent: {0}", result.Intent);
            Console.WriteLine("Links:");
            foreach (LinkDescription link in result.Links)
            {
                Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
            }
            AmountWithBreakdown amount = result.PurchaseUnits[0].AmountWithBreakdown;
            Console.WriteLine("Total Amount: {0} {1}", amount.CurrencyCode, amount.Value);

            return response;
        }

        public async static Task<HttpResponse> CaptureOrder(string OrderId, bool debug = false)
        {
            var request = new OrdersCaptureRequest(OrderId);
            request.Prefer("return=representation");
            request.RequestBody(new OrderActionRequest());
            //3. Call PayPal to capture an order
            var response = await client().Execute(request);
            //4. Save the capture ID to your database. Implement logic to save capture to your database for future reference.
            if (debug)
            {
                var result = response.Result<Order>();
                Console.WriteLine("Status: {0}", result.Status);
                Console.WriteLine("Order Id: {0}", result.Id);
                //Console.WriteLine("Intent: {0}", result.Intent);
                Console.WriteLine("Links:");
                foreach (LinkDescription link in result.Links)
                {
                    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                }
                Console.WriteLine("Capture Ids: ");
                foreach (PurchaseUnit purchaseUnit in result.PurchaseUnits)
                {
                    foreach (Capture capture in purchaseUnit.Payments.Captures)
                    {
                        Console.WriteLine("\t {0}", capture.Id);
                    }
                }
                AmountWithBreakdown amount = result.PurchaseUnits[0].AmountWithBreakdown;
                Console.WriteLine("Buyer:");
                Console.WriteLine("\tEmail Address: {0}\n\tName: {1}\n\tPhone Number: {2}{3}\nAmount: {4}", result.Payer.Email, result.Payer.Name.FullName, result.Payer.PhoneWithType.PhoneType, result.Payer.PhoneWithType.PhoneNumber, amount.Value);
            }

            return response;
        }
    }
}