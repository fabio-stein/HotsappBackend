// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// AgreementDetails.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xWTW/cNhC991cM1EsDaKW13SbN3gwEBdwicdAYBVrDWM+So9WgFKmQI9tCkf9eUNrVWpECJG1a++CjOMPhvPfmQ38lF21NySo53XqiiqyAJkE2IUmT39Azbgy9wSq6JGnyC7WHj1cUlOda2NlklVyUBPhxkCxJk1Pvse1fWabJr4T63Jo2WRVoAsWD9w170sPBW+9q8sIUktXlkF8Qz3Y7TUq1ylBYK1fVhoT0KMkZ4zRp21Qb8uAKqLHtku+vwXANCudBSg4HgP8WmG2M+ZB+LjpPFbLtPSbo7hu/AN1w7eHQFciG9HqX2Fq5xsoI4SccpijFCZp7WPuLe8jhASGyRTMA0Cg0BjhnnsLr3AYBoxug1SBc0Qy0FNjC5ZkV8pZm3CuUq+9KkTqs8lycMyFjkiJzfpuXUpncF+rk5OTlt4FUTGLxQ/b8WQY/OQ90h7EnUrg+Xh69WCxfLo5PLpY/rpbL1XL5x/VXJvW1s9SCtDXBLUsJqvGerGpBOU3wvkHDBZOGGzQNTbk3GGTgFqtJdc3bx+yf9s9HktGYTgirGE3/5sKTwW5AMBkdPuJogwatovQgXENpp0Rw4Oz/MBt3fI2nxuFwWmiXUnqihSrRoxLycPbufPH98dGLMfeH8tF0QybmlNXY1mgy5apcOxVytkJbjzF4rtmTktxTkHwfaBEDhfzZF9EgvvlnfbgvkQMP+5MpCQPUziWD17wtBTaxiaBDRb4riJ0fUwDDfxJc//z292uQEgXQE1gnsXhYoTEtFJFQdrGPYy1BT3RtUBFoUlyhGXzmo1+8eXUvemg2mm9Yk445OZDSNQGtlnJXhlIS+B1x9ybj/q3u5X4w4ljcFAIRXJ69O4eofK/1Ks9vb28zDq4bExxcXrqK8iBoNXodBl3Xna5ZKdVXkfbqM8QdNfJkxs5Zp6JHr0c3YZ8vjo7/0wn7KUYt3cl6w8aw3U4ZnbPO/HnQncDO6zHtrKPHvLNcI11LRWZ3+2NE/bz9aWc97aynnfWIdtbVh2/+BgAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// The agreement details.
    /// </summary>
    [DataContract]
    public class AgreementDetails
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public AgreementDetails() {}

        /// <summary>
        /// The number of payment cycles completed for this agreement.
        /// </summary>
        [DataMember(Name="cycles_completed", EmitDefaultValue = false)]
        public string CyclesCompleted;

        /// <summary>
        /// The number of payment cycles remaining for this agreement.
        /// </summary>
        [DataMember(Name="cycles_remaining", EmitDefaultValue = false)]
        public string CyclesRemaining;

        /// <summary>
        /// The total number of failed payments for this agreement.
        /// </summary>
        [DataMember(Name="failed_payment_count", EmitDefaultValue = false)]
        public string FailedPaymentCount;

        /// <summary>
        /// The final payment date and time for this agreement, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). For example, `2017-09-23T08:00:00Z`.
        /// </summary>
        [DataMember(Name="final_payment_date", EmitDefaultValue = false)]
        public string FinalPaymentDate;

        /// <summary>
        /// A type for all financial value-related fields. For example, balance, payment due, and so on.
        /// </summary>
        [DataMember(Name="last_payment_amount", EmitDefaultValue = false)]
        public MoneyTypeWithCurrencyCodeQualifiedValue LastPaymentAmount;

        /// <summary>
        /// The last payment date and time for this agreement, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). For example, `2016-12-23T08:00:00Z`.
        /// </summary>
        [DataMember(Name="last_payment_date", EmitDefaultValue = false)]
        public string LastPaymentDate;

        /// <summary>
        /// The next billing date and time for this agreement, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). For example, `2017-01-23T08:00:00Z`.
        /// </summary>
        [DataMember(Name="next_billing_date", EmitDefaultValue = false)]
        public string NextBillingDate;

        /// <summary>
        /// A type for all financial value-related fields. For example, balance, payment due, and so on.
        /// </summary>
        [DataMember(Name="outstanding_balance", EmitDefaultValue = false)]
        public MoneyTypeWithCurrencyCodeQualifiedValue OutstandingBalance;
    }
}

