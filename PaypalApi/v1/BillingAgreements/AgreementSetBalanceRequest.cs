// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// AgreementSetBalanceRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/6yV0W/bNhDG3/dXHPi0AbLYFgUG6K1oVtQdEntzMGAIgvZMnixuFKkcT3GFIP/7QEl27WRAUSCv59NHfr/vjn5QV9iSqhTumKilIGUiWWzRYzCkCnVBybDrxMWgKrUhSSANwdwAdWTAAMevC9gOsLwoYRnGvk+b1RUw3fWUBLbRDgWkjoyrhzMZ0zNTMAPI0BFgsHCPvqdSFeqPnnhYI2NLQpxUdXNbqI+Elvhp9UPk9mltjdKc1R7U9dBlx0nYhZ0q1F/IDreenpL47Kwq1O80zD88o3HdECwvINajl+N3I5R940wDEiGRAB6MZkPvmHGY7vCqUH8S2lXwg6pq9Ily4a53TFZVwj0Vas2xIxZHSVWh9/7xduqhJJPI0dBlDDQT3DtpvkE10RLc9ehd7WhG+9z3of3M80nx3Pu76aAxf++hdgGDcegn9QWTRyELtSNvUwkfIgN9xbbzVBxgFNDhMAKzPRVj6ilCDD8EaS6cUvp+xD9mNcd8Iw0TLUyDjEaIYblZLd6+ef3rOeXbnxuRLlVaW7onn+9Udjh06EsTW22jSdoFoR1jFtfWMRnRTEn0QWiRhZL+5SVmpfguisMwfONwqDyHcLQ6LSdcul0jsM0LC6Mr4nEg5j5HCbz7l+DLp/XfX0AaFEAmCFHy8DiD3g9QZ6AuBvSQZwkm0J1HQ2DJuBb9sef/1a+vLk7UU7+17t5ZsvlOEaSJfcJgpZnHMO8qz+Ag9O2WOK/w4azx5DQN9nm4BSQiuFluVpCTn7KutN7v96VLsYy80y5F3cSWdBIMFtmmY66fx1zLRtoXifb2MTelLoZEk0wuF+p9DEJhfhsUdp13Zhq2f1IMqlAfRbpLkiZaVan1anOtpldSVUrfv9bzTia9dd67sFsc37WkH07fxkd9/k/x29eOjJDdCEqf3kdLqnrz6u3jT/8BAAD//w==
// DO NOT EDIT
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BraintreeHttp;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// Sets the balance for an agreement, by ID. In the JSON request body, specify the balance currency type and value.
    /// </summary>
    public class AgreementSetBalanceRequest : HttpRequest
    {
        public AgreementSetBalanceRequest(string AgreementId) : base("/v1/payments/billing-agreements/{agreement_id}/set-balance?", HttpMethod.Post, typeof(void))
        {
            try {
                this.Path = this.Path.Replace("{agreement_id}", Uri.EscapeDataString(Convert.ToString(AgreementId) ));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
        public AgreementSetBalanceRequest RequestBody(MoneyTypeWithCurrencyCodeQualifiedValue Currency)
        {
            this.Body = Currency;
            return this;
        }
    }
}
