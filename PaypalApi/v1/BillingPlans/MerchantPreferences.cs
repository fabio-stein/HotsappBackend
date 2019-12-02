// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// MerchantPreferences.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/8xY328UtxN///4Vo335Fulym/6QKuUNBSqlhSSCgIQouszZs7cuXnvxjBNWFf97Ze/u3S13VwiFiKfEY+94fnzmM+P7u7jqWipOiqcUVI1O4DJQRYGcIi5mxUsMBpeWzrFJp4pZ8Qd1m8UjYhVMK8a74qS4qgmaUU+70QOVD4DQWnRzOHPKRk0Mtb+FJqoajIDyLAzigUkgtiA1Aa4CUUNOZnn54tkThtuaAuWliiy+oQAKHWDbBn9D4PNSkd2noMH3pokNuNgsKYCvAK31t6ShQmNJQ4tdOg0oQk0rPEvXSU0BLrG7RAsYxTcoRqG1HSyNtZw1+ygs6LRxK1iiTRaAcXnL0XvJJ9Oe6pSlGaDTvX0qxQ1MNXHo/wzGGTFo1wYl+3hezIqHIWDXJ+x4Vjwj1BfOdsVJhZYpCd5FE0ivBZfBtxTEEBcnr9epZgnGrXaTi0pRK6QXw70LSee3M37oxC4MRtPTgRQkFMCQXO4VZERIbXgARXLlyDvb5eAEYgo3w6kqSgwEkem/RsBFaz/MPh2GKH6RUrbAxkcn0wjsbk6dP3PaKBTibwKeOVwd+qTXJl7SXdm2DHHXpUq8MT6y7Uaks6pJxy3M8xxeoo1Jzcmf8fj4ZxVt/kv9yprtlfK6/4/OL3pJuRHNR4e1JwbnZY/n0wo+EIU5PKIKo5Xk2+dcPEimth6y/NXj54dNP5SrT5q814QxlPcD354AFzHYCXAn4t16ffHsySFy3ceodypFCfELXakxLJimFbgl3HUjbaISCrmRfMckM1D8IhXkQCWLvh9MnP3XY7vu37GjfFnNn16cX52dv3i8p3yutjECgRo0jrNVN7Ruex93256rDANqTToNAQcJ4azKpXk0cqJhIJeiqmdfmWa3qOd6dPj6bgxz+vD89PGTnSiNhqpAuU1M6gqWURJ0GYwwsKAkSoeWesOjE9NX4scJVZYwcI7Q4e1+DhqVbV1Kyjc0JuqgkgyaQzoMD0RBen+Yyim6ltart++iF9qWsgTvVgPFe6EBmOW2HF75mIkpcs9W10wS20VFdA03GdHIEwcGiCVkBbNaDfx9fbi41pn+2Mr7IYcG3w9GDZPohBP27e6Zw+867U4xf3ydpl+j6v6zxCBVihcd/Px+QuO8mKrb6W4T8Wd3N5PnE1OZRDtpRJ3W4i3yUKX6+2oegSQGtxOEifhOLX58P33DHn8aQ3oMdrverKt34sy2dNeXJTKBX/5Fqu/yaC1UxqFTqd4zCRwFspifGoas5hlwemsij+w/W0NYx+FRxh68+/bvLDWEYpGawnS22QRp1+fXUgeio82Ic/b84uiXn378FcbPICl880Mt0vJJWWq6IZsMm7fYtWjnyjel9opL44RWAZPyUptASspALOWo6Cgp4vLBPeE552sSiFGyZ8Ibfc1H5vDUrOrUwQAdZLcoZEQM5wwxWPOW4PfLV5tnaHqVSNcOQ0IVetZHC/l3Ck3KNGjX8r36rs4fbfRxXGpzY9L4YlweYHxkdFpqnsNvvu83YYjUFiWPN7UWNz+TTLI5AyaC12fPLyClepPc29vbuWE/92FVGvZl7Rsq84SDQXM5wRjPa2kefI16fvPhzYf//QMAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingPlans
{
    /// <summary>
    /// The merchant preferences for a plan. Includes how much it costs to set up the agreement, the URLs where the customer can approve or cancel the agreement, the maximum number of allowed failed payment attempts, whether PayPal automatically bills the outstanding balance in the next billing cycle, and the action if the customer's initial payment fails.
    /// </summary>
    [DataContract]
    public class MerchantPreferences
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public MerchantPreferences() {}

        /// <summary>
        /// The payment types that are accepted for this plan. Read-only and reserved for future use.
        /// </summary>
        [DataMember(Name="accepted_payment_type", EmitDefaultValue = false)]
        public string AcceptedPaymentType;

        /// <summary>
        /// Indicates whether PayPal automatically bills the outstanding balance in the next billing cycle. The outstanding balance is the total amount of any previously failed scheduled payments. Value is:<ul><li><code>NO</code>. PayPal does not automatically bill the customer the outstanding balance. Default is <code>NO</code>.</li><li><code>YES</code>. PayPal automatically bills the customer the outstanding balance.</li><ul>
        /// </summary>
        [DataMember(Name="auto_bill_amount", EmitDefaultValue = false)]
        public string AutoBillAmount;

        /// <summary>
        /// REQUIRED
        /// The URL where the customer can cancel the agreement.
        /// </summary>
        [DataMember(Name="cancel_url", EmitDefaultValue = false)]
        public string CancelUrl;

        /// <summary>
        /// The character set for this plan. Read-only and reserved for future use.
        /// </summary>
        [DataMember(Name="char_set", EmitDefaultValue = false)]
        public string CharSet;

        /// <summary>
        /// The action if the customer's initial payment fails. Value is:<ul><li><code>CONTINUE</code>. The agreement remains active and the failed payment amount is added to the outstanding balance. If auto-billing is enabled, PayPal automatically bills the outstanding balance in the next billing cycle. Default is `CONTINUE`.</li><li><code>CANCEL</code> PayPal creates the agreement but sets its state to pending until the initial payment clears. If the initial payment clears, the pending agreement becomes active. If the initial payment fails, the pending agreement is canceled.</li></ul><blockquote><strong>Note:</strong> You can use the `setup_fee` value as the initial amount to trigger the `initial_fail_amount_action`.</blockquote>
        /// </summary>
        [DataMember(Name="initial_fail_amount_action", EmitDefaultValue = false)]
        public string InitialFailAmountAction;

        /// <summary>
        /// The maximum number of allowed failed payment attempts. Default is `0`, which allows infinite failed payment attempts.
        /// </summary>
        [DataMember(Name="max_fail_attempts", EmitDefaultValue = false)]
        public string MaxFailAttempts;

        /// <summary>
        /// The URL where the customer is notified that the agreement was created. Read-only and reserved for future use.
        /// </summary>
        [DataMember(Name="notify_url", EmitDefaultValue = false)]
        public string NotifyUrl;

        /// <summary>
        /// REQUIRED
        /// The URL where the customer can approve the agreement.
        /// </summary>
        [DataMember(Name="return_url", EmitDefaultValue = false)]
        public string ReturnUrl;

        /// <summary>
        /// The base object for all financial value-related fields, such as balance, payment due, and so on.
        /// </summary>
        [DataMember(Name="setup_fee", EmitDefaultValue = false)]
        public Currency SetupFee;
    }
}

