// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Message.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/7ySQWvVQBDH736KYb0o5CUPHgrmVvAiYhUtXmop+3YnyepmJ52ZbQ3S7y55Ce2LRT0ovQT2t5P8f//d/DBn44CmNu9QxLZoCvPZcrD7iKe2nzZMYd7ieL94jeI4DBoomdqcgMui1CNvgBh6ZNfZpJuBRNFDP38VGmLQDsEHGbJiaQpzwmzHOXxbmI9o/fsUR1M3NgpO4CoHRn8HPjANyBpQTH1+py3KIbUPrR0lxaQr+Xu27nDW4Z9bLC/+q3XKMd4Wf1WfQy/340r+mP5e/9gebjqCpcF09stdPFILDT1ezumrHmv+sIm3imCTh2mwgJDg/E1S5IS63pv+qd7qxbNOdZC6qpQoShlQm5K4rTrtY8WN2+12r54Kuilj86J8+byET+goeQHLCLx0hZsuRISG7WHSRpCjKRpmWH7J2+3O7SO5b1eZFA/r+elEmVI7k1NSrGdcHXOYOjK2OVoG/D4wigRKMDBdB48CbQ7eJoewzwqeUCCRAuNXdAo2Rgjp2sbgD4chi0/1q9D/uOOL2yc/AQAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// A customer- or merchant-posted message for the dispute.
    /// </summary>
    [DataContract]
    public class Message
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Message() {}

        /// <summary>
        /// The customer- or merchant-posted content.
        /// </summary>
        [DataMember(Name="content", EmitDefaultValue = false)]
        public string Content;

        /// <summary>
        /// The customer or merchant who posted the message.
        /// </summary>
        [DataMember(Name="posted_by", EmitDefaultValue = false)]
        public string PostedBy;

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name="time_posted", EmitDefaultValue = false)]
        public string TimePosted;
    }
}

