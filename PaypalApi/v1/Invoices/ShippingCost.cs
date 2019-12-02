// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// ShippingCost.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+yVT2sbPRCH7++nGHR6C4tx2kKxb61zCYWkNCaXksNYmrWnaCV1NFu8lHz3Iv/bbDellJoeSk5GP9nW88xo0Dez7BKZubndcEoc1rCIWU1l7lAYV56usSnbpjLvqesXl5StcFKOwczNckOQj39gY9YKMANCIrEUFNcEUQCb2AaFr+hbmpjKvBXBbn/8tDIfCd1N8J2Z1+gzleBLy0LuFHyQmEiUKZv5pxP4ohWhYLsx8/68AfkpGvK/w0wQV5/JKtSF1HuoOWCwjH4PDEIelRzUTN5l+H+FHoOlChJ2DQUF11IFpHby4mxuWYXDemxmD86L6GjgZ/tiDA1fgSdVEjh+A2x0VLrkqOZADlYdXN3ewOuXF2/+tDmh9f6h+qXFrq4D/GMyZD/cmzaBRrgGx2tWwLrY6IbAkeUGfYZMCQW19K/X4nDS2rW2/AJTkpiEUWlYj98SV2mf8r5/ZL7E7Vhbd2EvvV//MFC4BQ51lAZL8jwtz9Py70/Lz8zZDbR3y/H7I5RjK5bg6vIvdSSUj8dkh2DMpriFsnmOivVcoW1WJGOuw6s7QOuzp+kElSZwh57dYYI5Qy2xgelkOr0od2k2m8xms/M0/f7hv+8AAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// The shipping cost, as a percentage or amount value.
    /// </summary>
    [DataContract]
    public class ShippingCost
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public ShippingCost() {}

        /// <summary>
        /// Base object for all financial value related fields (balance, payment due, etc.)
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Currency Amount;

        /// <summary>
        /// Tax information.
        /// </summary>
        [DataMember(Name="tax", EmitDefaultValue = false)]
        public Tax Tax;
    }
}

