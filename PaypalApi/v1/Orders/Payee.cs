// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Payee.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7xVXWvbShB9v79i0EtuwJLs3EsKfit1HkxJa9LQPoRgxrtja2E1q86u4oqS/15W8kdkJ6S0Jo86c3Z2zpmd0c/ktqkoGSczbIiSQfIVxeDC0icsI5wMko/U7D8m5JWYKhjHyTi5LQiqeBDWhQMhReaBPISCYFmz9oCsYVnbpbG2g51okiwZJO9FsOnuHg6SG0L9mW2TjJdoPUXge22E9A6YiatIgiGfjO92VfsghlfHZVOJxvZq3yLHAtoIoNZC3gN675TBQBrWJhRt0a3EMw8zbGZoAZVyNYcMpssuLO7BaNIHmYwHduEoIXJzkGiwvwQUMji2zdbMLfUbWkshkkri4DOYGCEVQAlpE0Ch6F0QUAg0sSENuiYIrosrV1bWICsC6eztcv1lN7i29nHwaktKElUgh7nRvcb08Wfaw0qaKtrXdw2mE1g62Xt3Yh3tQMDE+MpiA9cUUGPAY13t3XPd8eblnreX+CLlWO2GlLZvYMs8rc7Xp2chyHrO8eOpjB78/CKQMw+L2huOAxCZJ27Kth2zwvEz22prcbUJ72s/jLywx848tAzguly8xaJqn7I0c+V0v+CDwHG9d2HtUlWgoAokMP0yTP8bXV6mI9gchXj0/t8ihMqP81zTA9lYWlZhU6HNlCtz7ZTPDQdaCcbcuW7XSi7kQ77Jk8Y8Pj8Ht+xtw034jdZH15CeRTvo2BzD6daFp/0cgGG4u8pGl/9vEMMrqCxyHLESw96u9XqdmVBnhqMbKr9Nb64+pO3R9GI4Go5G6fT8JNrvf0P9n//Pnq4OyeAaf5iyLsESr0IR/1Gji3ewe0b+RIruH//5BQAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The payee who receives the funds and fulfills the order.
    /// </summary>
    [DataContract]
    public class Payee
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Payee() {}

        /// <summary>
        /// The email address associated with the payee's PayPal account. If the provided email address is not associated with any PayPal account, the payee can only receive PayPal Wallet payments. Direct credit card payments are denied due to card compliance requirements.
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue = false)]
        public string Email;

        /// <summary>
        /// The encrypted PayPal account ID for the payee.
        /// </summary>
        [DataMember(Name="merchant_id", EmitDefaultValue = false)]
        public string MerchantId;

        /// <summary>
        /// The display-only metadata for the payee.
        /// </summary>
        [DataMember(Name="payee_display_metadata", EmitDefaultValue = false)]
        public PayeeDisplayMetadata PayeeDisplayMetadata;
    }
}

