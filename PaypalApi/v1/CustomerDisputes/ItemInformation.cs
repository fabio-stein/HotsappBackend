// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// ItemInformation.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/7xXWW/jNhB+768YqC+7gI/tARQI0AfF1m7UxnIgKykWu4GWJscWUYlUh1Rct9j/XlC0fMS5jAb7ZIsccb75+M2hf4NsXWNwFsQWK4jVQlPFrNQq6AU3jCSbl5iwylkEveB3XO8exmg4ybo1PguyAkHuXoeFJrAFQt0QL5hBAdJ5kAoYCGnqxqIAS0wZxt0Lg6AXhERs7fG86wUpMjFV5To4W7DSoFv4q5GEYrtwRbpGshJNcPZpG8lEK1wfw984zVmlG2UPgjnaOg6NN0So+BqYEuDt2hAZLKRiiktWwh0rG+wTlszFtpBYigG81wT4N6vqEnswZyVTHEET1GxdobIgGny90I0lqZbHsXfoc64FHoR+f+c48k+2IMQ+LxgxbpEgnk37P//4wy87Tty7t2+GQnMzlMrikloNDIUk5HZIaOywM+47YzN8C7ZgFqRAZeVComnF0hmdxIil5h4hqinLr71nWWnv64CNbuWYhXanB6tC8gIquSwszPHsc/Pu3U+8Kdtf9E+l9E+hgpYLpFYom9BcpKX8E+HLb1cfv3gSGCEobcGua8lZWa5hQT4pWDnwhw67U+/5AIFcVqzcvvGwrywZ7/kyzVzIOylcTiqrwRa6MUwJW5iH3Q27CN9vkpo25INqqjkS6MUWSF0yjmaTGwcK6YFBhE+j/TUDfacncHq6fVNYW5uz4XC1Wg2k0QNNy6E0ulVb/1BAg8JW5dvX0MntC5TiSlcuxYFWdmvHaonHjhLHlLP6v/n9QjkrbdEcQOxWDgGGag3tDtSkvQxW0hbfGm7NyCqkfK8H3Kf4UZOnGN8zdt2m7UH+HDBr4+KDbG9t3zwegzRAaBtSKMCli/Jtq8Q7LGGOnDUGD870tcAUegVCLhZIrqjvHepTYbfljjMdMM7IfiO6CZlpu/qO3u3SMZ1+a9vEHei+52DTKwdw4yoiSPNkEfRPLmP98yRKRxdhMo5nUT5N81mU3sSjKE+mWZ5Goyi+icabkrN7x98Xb4zVFToqRVstCTnKO38ZFbohQwlp2t5qkO4kx6dr5wnQwlk+jmajND5/Hh5hrckaX20fxwYrZtowmAHR0j9HcRrg6yS8zi6maTx7OWmssYUm+c9uLuvS5jUoHKXROM5ayq7S6SiaPY6McNEo4TxxQiHtlo+aNEfj5sVOfF0Qp2EZX19dxqMwi/IsDZNZOMriafIImP0a4HAwEE1dSs7siQTEyWiaptEoy8PJ9DrJnrsW58wNVktXbVy54prcyLSZME9zfhV+nERJlp9/zKfZRZTmkyhMZs9BqJncUb1PhC1IN8sCtC1cmUOmzIlqCJNRdBmNXWZfp2mcfMjP48vLOPnwElrmKNVyS44fJ0wz3xYqJx1CNxQ4u0PgzMuJu1m7PDWtrtLp+WU0yf+Is4s8jSZxlrlAHsAcOrHOS6xA83Y62WukhJW01gE4zXt7cw/4mrpbeMF0tv8Jxua6sYfz2v0vNGS86Ep6V/TbLxxjNJftdwy6EcF9tNh1vZnhvF8GBeHi18/Bo4N/d6H9jQcz/H7zr+99+Vnuc+Dx38Ph93yIbMPDa/TK26/f/QcAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// The information for the purchased item in a disputed transaction.
    /// </summary>
    [DataContract]
    public class ItemInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public ItemInformation() {}

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="dispute_amount", EmitDefaultValue = false)]
        public Money DisputeAmount;

        /// <summary>
        /// The ID of the item.
        /// </summary>
        [DataMember(Name="item_id", EmitDefaultValue = false)]
        public string ItemId;

        /// <summary>
        /// Any notes provided with the item.
        /// </summary>
        [DataMember(Name="notes", EmitDefaultValue = false)]
        public string Notes;

        /// <summary>
        /// The ID of the transaction in the partner system. The partner transaction ID is returned at an item level because the partner might show different transactions for different items in the cart.
        /// </summary>
        [DataMember(Name="partner_transaction_id", EmitDefaultValue = false)]
        public string PartnerTransactionId;

        /// <summary>
        /// The reason for the item-level dispute. Value is:<ul><li><code>MERCHANDISE_OR_SERVICE_NOT_RECEIVED</code>. The customer did not receive the merchandise or service.</li><li><code>MERCHANDISE_OR_SERVICE_NOT_AS_DESCRIBED</code>. The customer reports that the merchandise or service was not as described.</li><li><code>UNAUTHORISED</code>. The customer did not authorize purchase of the merchandise or service.</li><li><code>CREDIT_NOT_PROCESSED</code>. The refund or credit was not processed for the customer.</li><li><code>DUPLICATE_TRANSACTION</code>. The transaction was a duplicate.</li><li><code>INCORRECT_AMOUNT</code>. The customer was charged an incorrect amount.</li><li><code>PAYMENT_BY_OTHER_MEANS</code>. The customer paid for the transaction through other means.</li><li><code>CANCELED_RECURRING_BILLING</code>. The customer was being charged for a subscription or recurring transaction that was canceled.</li><li><code>PROBLEM_WITH_REMITTANCE</code>. A problem occurred with the remittance.</li><li><code>OTHER</code>. Other.</li></ul>For information about the required information for each dispute reason and associated evidence type, see <a href="/docs/integration/direct/customer-disputes/#dispute-reason-codes">dispute reason codes</a>.
        /// </summary>
        [DataMember(Name="reason", EmitDefaultValue = false)]
        public string Reason;
    }
}

