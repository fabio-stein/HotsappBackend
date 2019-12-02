// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// AuctionInformation.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7yTT4vUQBDF736Kor0oxIwwKJjbwlwGRWUZvSxL6ElXpwv7T6yuuATZ7y6dmf07GxCUvaWr3nv945H+rXbTgKpRZ2MnlCJso00cdPlWlfqumfTe42cdikhV6iNOd4cN5o5pmMWN2jkEfYyhu5haVeqMWU+Hm95W6hy1+RL9pBqrfcYy+DkSo7kdfOU0IAthVs3FLWMWptifYh0vbffjhNySeYD5xPIUe7uBZEEcwiyDK5cg6B+Y59kwcud0RqA4n4+RNewc5eIN1DuBPYIha5ExClhO4WDWJXC7gYHTLzJowCa+2QSM8q/9xNH76+qvS+p8yhT71mjBJ4t6JDgtqyxARwNCAeHK4YNWoPgxV6Wsi20U5IjyyHP4Ny5fOZEhN6uVpORzTSi2TtyvnAS/Ytut1+sPLzPOsW/e1e9fP3NVJBjaTAs93d8uP4QigG/nn54ZfZF6ETjqgDeP4D78fwG/vH7xBwAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Sync
{
    /// <summary>
    /// The auction information.
    /// </summary>
    [DataContract]
    public class AuctionInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public AuctionInformation() {}

        /// <summary>
        /// The ID of the buyer who makes the purchase in the auction. This ID might be different from the payer ID provided for the payment.
        /// </summary>
        [DataMember(Name="auction_buyer_id", EmitDefaultValue = false)]
        public string AuctionBuyerId;

        /// <summary>
        /// The date and time when the auction closes, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="auction_closing_date", EmitDefaultValue = false)]
        public string AuctionClosingDate;

        /// <summary>
        /// The auction site URL.
        /// </summary>
        [DataMember(Name="auction_item_site", EmitDefaultValue = false)]
        public string AuctionItemSite;

        /// <summary>
        /// The name of the auction site.
        /// </summary>
        [DataMember(Name="auction_site", EmitDefaultValue = false)]
        public string AuctionSite;
    }
}

