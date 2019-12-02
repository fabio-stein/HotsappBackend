// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// PayerInformation.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/+xaW2/buBJ+P79i4D6cBrAs22l70Ly16eVkizZBLrsP2cChxbE1W4pUyVEdddH/viAlXxTZ27ot3MXCLwE8Mx81Mxx+Qw7yZ+eyzLFz1MlFiXZEemJsJpiM7nQ7vwpLYqzwnci8SafbeYPl8scLdImlPBgfdS5ThLAIrCzS63Q7z6wVZfWVfrdzjkKealV2jiZCOfSCDwVZlAvBmTU5WiZ0naPrhX9CSovOtb0ak1Kkp6OlwdLJtq7tc20DtQ0YCy6lPF+VTYwF4aPLUPOPi8mxJT1th5QQl404akHbea8ALTL8Xqd0odTn7pc9M4VmW44SI7HpYVPR9vSaZyZKUmFFwmjh5OIUDgdPnkQD8JCbh7E0iYtJM05tKJ1YksWEY4uO43r5yNu6+AA4FQwkUTNNCB2wz0Vl4zfQ4tQX3+9Fv3+YjJVJ3n8oDGP4Xf1NHFujp5XknWE8qsTxqhwuV5b1nw6F8NqiYHhuiQVpIAcV0usr2Ovn9VpLEQgtQRtu2V69WWProHAogXSIi00eKfyICqTJ/Cf9flc1GdJQO9iDK4cBcHs8vG27fZySFjAzVskZ1bLEZLmwfn+h0InRbI1SKCG3lCA8PL46O4AMOTWyC2Oh30MirOyGYBJrnIvGxkq0wFZoJxK/ba7Oenw/7dsUKNvi2+pTkcZBozDnknZFTsg6Bq8HMwmJq497D14ZC3gnslxhF3SRjdF2wbFF5Cp6Z2BLcvuukIatkIZrQ3KYGC2/IiZXEKM/KSIXlj2r1WHuiEe0bxCKPoWTPnIsuGgy9waDdshzim4AoAL04By5sBolGK3KUPKhRTmYWJPBcys+kdpRyHlqdJMz55I1fdRrFoVHGq5f9gbDQ6j66s3DlDl3R3E8m816xEWPtOfJJL6Mzl8eR8E2Gvb7g/4wOolRH/TgrbijrMhAoZ5y6lnrcR8WdOx2lQPjWKh292jK1+Qj6AOXdWGWUhIi8OX9ifKK4nx1fyjoo1C+RcNlmVMilCrB1n7XhOdZ0XeMGXHqe/py5XAcdGOVC0S4XjFZZh51b0bvKUdJomfsNPa/4rNlHAc7Sqmv9GYy55I1PfhrWm2ALxptdfO5uggnKqTIZ32Zo2BgOMWV3Ppjt5Lz1eYA1GAlv4ukwSzoyuFymSO4fmanvsVrsY3TD8QcddCF6+qMb4UfB4gHHwst5HYfTwLEg0+0pO2w5BEBykKV20E9wkN/EbnQW0H/8AgPfYt3lJitsFmAePBlKkgJLbeCcw066PrKur7SxCjhwpu4rRYqnFhLco/64EhPFUbjknH3hMdevXo4a0H7bHqFPwTr+/Xt/0/fvhydno9+Oz1/c9uF29cnry5vv/Uusimem6+IaEyW05G8TzoN8bpHluUUZKCQigFCH65624lmtBq50t/vcWyMcj1CngSeTTlTsZ0kh4eHTx84DLQSPe49ObifscHTp/2o/ygaDG//8Y+jkIz/uvYjqR8tHknL6/yWj6UdRY+ZINUIey7ZHG+wWJZ8+/wOhv/b/aEND4ORf2U1wmmIN8dUPSt2+CZXYp23q9LNznqrXfqakZQK29425Zv9rex26XE9F5PN++pS2Pb1TJRnQkXCOZr6pwfqxJa5b2zVeOzkxa6uhkIVPJ/lrdwPV8WbU700+9Hu1tO10caR3hqLFffbyjUP4fsTPIksSLn97G4/u9vP7vazu/3sbj+728/u9rO7nzu7s5hQTqjXXN9bqnZivWLOFAtzEAyckltwx34KuZ9C7qeQ+ynkv2sK6YrJhO6ahDMX/c2TNpjsKuni7v7YYCHa7CKLOzh50YOLIs+N5Tl5LcYK839Cqa/24W6004BG7WJqyL8UWiixnxDfzef//AUAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The payer information.
    /// </summary>
    [DataContract]
    public class PayerInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PayerInformation() {}

        /// <summary>
        /// The billing address or shipping address for a payment.
        /// </summary>
        [DataMember(Name="billing_address", EmitDefaultValue = false)]
        public Address BillingAddress;

        /// <summary>
        /// The birth date of the payer, in [Internet date format](https://tools.ietf.org/html/rfc3339#section-5.6). For example, `1990-04-12`.
        /// </summary>
        [DataMember(Name="birth_date", EmitDefaultValue = false)]
        public string BirthDate;

        /// <summary>
        /// The payer's [two-character IS0-3166-1 country code](/docs/integration/direct/rest/country-codes/).
        /// </summary>
        [DataMember(Name="country_code", EmitDefaultValue = false)]
        public string CountryCode;

        /// <summary>
        /// The payer's email address. Maximum length is 127 characters.
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue = false)]
        public string Email;

        /// <summary>
        /// The payer's first name.
        /// </summary>
        [DataMember(Name="first_name", EmitDefaultValue = false)]
        public string FirstName;

        /// <summary>
        /// The payer's last name.
        /// </summary>
        [DataMember(Name="last_name", EmitDefaultValue = false)]
        public string LastName;

        /// <summary>
        /// The payer's middle name.
        /// </summary>
        [DataMember(Name="middle_name", EmitDefaultValue = false)]
        public string MiddleName;

        /// <summary>
        /// The PayPal-assigned encrypted payer ID.
        /// </summary>
        [DataMember(Name="payer_id", EmitDefaultValue = false)]
        public string PayerId;

        /// <summary>
        /// The payer's phone number. Maximum length is 20 characters.
        /// </summary>
        [DataMember(Name="phone", EmitDefaultValue = false)]
        public string Phone;

        /// <summary>
        /// The phone type.
        /// </summary>
        [DataMember(Name="phone_type", EmitDefaultValue = false)]
        public string PhoneType;

        /// <summary>
        /// The payer's salutation.
        /// </summary>
        [DataMember(Name="salutation", EmitDefaultValue = false)]
        public string Salutation;

        /// <summary>
        /// The extended address, which is used as the shipping address in a payment.
        /// </summary>
        [DataMember(Name="shipping_address", EmitDefaultValue = false)]
        public ShippingAddress ShippingAddress;

        /// <summary>
        /// The payer's suffix.
        /// </summary>
        [DataMember(Name="suffix", EmitDefaultValue = false)]
        public string Suffix;

        /// <summary>
        /// The payer's tax ID. Supported for the PayPal payment method only.
        /// </summary>
        [DataMember(Name="tax_id", EmitDefaultValue = false)]
        public string TaxId;

        /// <summary>
        /// The payer's tax ID type. Supported for the PayPal payment method only.
        /// </summary>
        [DataMember(Name="tax_id_type", EmitDefaultValue = false)]
        public string TaxIdType;
    }
}

