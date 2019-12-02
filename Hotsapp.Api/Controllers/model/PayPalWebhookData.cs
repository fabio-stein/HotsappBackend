using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.Api.Controllers.model
{
    public class ShippingAmount
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }

    public class Name
    {
        public string given_name { get; set; }
        public string surname { get; set; }
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
        public Address address { get; set; }
    }

    public class Subscriber
    {
        public Name name { get; set; }
        public string email_address { get; set; }
        public ShippingAddress shipping_address { get; set; }
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
        public int current_pricing_scheme_version { get; set; }
    }

    public class BillingInfo
    {
        public OutstandingBalance outstanding_balance { get; set; }
        public List<CycleExecution> cycle_executions { get; set; }
        public DateTime next_billing_time { get; set; }
        public int failed_payments_count { get; set; }
    }

    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }
    }

    public class Resource
    {
        public ShippingAmount shipping_amount { get; set; }
        public DateTime start_time { get; set; }
        public DateTime update_time { get; set; }
        public string quantity { get; set; }
        public Subscriber subscriber { get; set; }
        public BillingInfo billing_info { get; set; }
        public DateTime create_time { get; set; }
        public List<Link> links { get; set; }
        public string id { get; set; }
        public string plan_id { get; set; }
        public string status { get; set; }
        public DateTime status_update_time { get; set; }
    }

    public class Link2
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }
    }

    public class PayPalWebhookData
    {
        public string id { get; set; }
        public string event_version { get; set; }
        public DateTime create_time { get; set; }
        public string resource_type { get; set; }
        public string resource_version { get; set; }
        public string event_type { get; set; }
        public string summary { get; set; }
        public Resource resource { get; set; }
        public List<Link2> links { get; set; }
    }
}
