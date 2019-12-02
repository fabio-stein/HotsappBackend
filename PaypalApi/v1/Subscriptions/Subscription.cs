using System;
using System.Collections.Generic;
using System.Text;

namespace PayPal.v1.Subscriptions
{
    public class ShippingAmount
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }

    public class Name
    {
        public string full_name { get; set; }
    }

    public class Address
    {
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string admin_area_2 { get; set; }
        public string admin_area_1 { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
    }

    public class ShippingAddress
    {
        public Name name { get; set; }
        public Address address { get; set; }
    }

    public class Name2
    {
        public string given_name { get; set; }
        public string surname { get; set; }
    }

    public class Subscriber
    {
        public ShippingAddress shipping_address { get; set; }
        public Name2 name { get; set; }
        public string email_address { get; set; }
    }

    public class OutstandingBalance
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }

    public class CycleExecution
    {
        public string tenure_type { get; set; }
        public int sequence { get; set; }
        public int cycles_completed { get; set; }
        public int cycles_remaining { get; set; }
        public int total_cycles { get; set; }
    }

    public class Amount
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }

    public class LastPayment
    {
        public Amount amount { get; set; }
        public string time { get; set; }
    }

    public class BillingInfo
    {
        public OutstandingBalance outstanding_balance { get; set; }
        public List<CycleExecution> cycle_executions { get; set; }
        public LastPayment last_payment { get; set; }
        public string next_billing_time { get; set; }
        public int failed_payments_count { get; set; }
    }

    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }
    }

    public class Subscription
    {
        public string id { get; set; }
        public string plan_id { get; set; }
        public string start_time { get; set; }
        public string quantity { get; set; }
        public ShippingAmount shipping_amount { get; set; }
        public Subscriber subscriber { get; set; }
        public BillingInfo billing_info { get; set; }
        public string create_time { get; set; }
        public string update_time { get; set; }
        public List<Link> links { get; set; }
        public string status { get; set; }
        public string status_update_time { get; set; }
    }
}
