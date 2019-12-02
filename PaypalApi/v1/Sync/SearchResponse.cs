// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// SearchResponse.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Sync
{
    /// <summary>
    /// The search response information.
    /// </summary>
    [DataContract]
    public class SearchResponse
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public SearchResponse() {}

        /// <summary>
        /// The merchant account number.
        /// </summary>
        [DataMember(Name="account_number", EmitDefaultValue = false)]
        public string AccountNumber;

        /// <summary>
        /// The end date and time or the last date when the data can be served, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="end_date", EmitDefaultValue = false)]
        public string EndDate;

        /// <summary>
        /// The date and time when the data was last refreshed, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="last_refreshed_datetime", EmitDefaultValue = false)]
        public string LastRefreshedDatetime;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescription> Links;

        /// <summary>
        /// A zero-relative index of transactions.
        /// </summary>
        [DataMember(Name="page", EmitDefaultValue = false)]
        public int? Page;

        /// <summary>
        /// The start date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="start_date", EmitDefaultValue = false)]
        public string StartDate;

        /// <summary>
        /// The total number of transactions as an integer beginning with the specified `page` in the full result and not just in this response.
        /// </summary>
        [DataMember(Name="total_items", EmitDefaultValue = false)]
        public int? TotalItems;

        /// <summary>
        /// The total number of pages, as an `integer`, when the `total_items` is divided into pages of the specified `page_size`.
        /// </summary>
        [DataMember(Name="total_pages", EmitDefaultValue = false)]
        public int? TotalPages;

        /// <summary>
        /// An array of transaction detail objects.
        /// </summary>
        [DataMember(Name="transaction_details", EmitDefaultValue = false)]
        public List<TransactionDetails> TransactionDetails;
    }
}

