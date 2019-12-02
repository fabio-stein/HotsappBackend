// This class was generated on Tue, 30 Jan 2018 11:02:39 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// UserAddress.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7zTQUsrMRAH8Pv7FMNc3mV5vPPeRG+CihQvIiVN/tsG0iROEmGVfndJt912WcGD0tvmP5PsL4T54EUfwS2XBFkqYwQpccNPSqxaOdypba1yw7foT4sbJC02Zhs8t7zYgOAN1TP+JoqCDiIwdDjvHzd8JaL64V//G36EMvfe9dx2yiXU4LVYgRmDBwkRki0St8+jMmWxfj336VB8ln7CPGVz7aH2U5gvzu2ab3UuaOVsnvLOwi98NvcUhI5NF4LGkLJySx0MJtZpPue+20i1WMlD7355IbVgXSnn4DGaW1NWGQ1FCW/W6/0XOuhcBE31D1svRE9ZgHw2d6crzErzq3TFORr6xlGja+XJeu2KAeUNaBNKAvmyXUFIeXPc4NX2dx7oZffnEwAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Identity
{
    /// <summary>
    /// The end user's preferred address.
    /// </summary>
    [DataContract]
    public class UserAddress
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public UserAddress() {}

        /// <summary>
        /// The country.
        /// </summary>
        [DataMember(Name="country", EmitDefaultValue = false)]
        public string Country;

        /// <summary>
        /// The city or locality.
        /// </summary>
        [DataMember(Name="locality", EmitDefaultValue = false)]
        public string Locality;

        /// <summary>
        /// The zip code or postal code.
        /// </summary>
        [DataMember(Name="postal_code", EmitDefaultValue = false)]
        public string PostalCode;

        /// <summary>
        /// The state, province, prefecture, or region.
        /// </summary>
        [DataMember(Name="region", EmitDefaultValue = false)]
        public string Region;

        /// <summary>
        /// The full street address. Can include the house number and street name.
        /// </summary>
        [DataMember(Name="street_address", EmitDefaultValue = false)]
        public string StreetAddress;
    }
}

