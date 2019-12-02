// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PayerInformation.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7xXQW/bOBO9f79ioO+wNSBbabvowbc0xRbdoo3RJHvxBumYHFuzoUiFHNVRF/vfF6QU24qDblwEuRjwcN7wzczjkPo7O29ryqbZDFvy8MEuna9Q2Nksz/5Az7gw9Bmr6JLl2Udqt3/eUVCe6+Q8zXaggAvXCEhJoJogriI/yfLs2Htsu+2O8uwLoT61ps2mSzSBouGmYU96Y5h5V5MXppBN5xuiZ1zVhmDmgqCBY609hbBPdsHGsF1d4cZhy31/bZjKMYRuk7rbpPeDNUsJyqEPNF55ZEsalkxGhwm8c2CdQBMIls4DWmAr5G0qyDbGBC56jwWq6zV6DcpVNQov2LC04KxpYzQKKZ5yVpAt1KWz9HRFDOLZrvarpljaQal6w7A+57GxkazF6jBS4pt7nGxjzD/5fxNzjRXfXimnaUhwuLBPdC5rN1YlelQSFX52Cq9fvnkzfgkRcvmi0E6FIjZr5VOzCs2elBSeghR9+HH0DcUIpEQB1mSFl0yh03jnA86DpxU7O/mzOTp6rRbGqeubxgml/92vCuKdXXWWz05o2pmLXTuc74SNWyfFvPeEAm89J0VwgA4Z1zvY+7d9rK0J0OokpPu+Fx8f8A1RvxrYprzE1WND38iAdlXcMrY7JCqpDD3BTtIR8PXk1dd92iclW4S180avubclzfvYX2hs1Lh3xpCG2rMieHFyMRtBRVI6ncMC7TUo9DpPySjvQhgvnNfkQTzagCq2LfRVL+6X/Vn0adjSy4Ew7yz7ilyyDwJxHdwyFW4zHH5zHugW4/DJwTbVgnwOQTyRdNkHB85Oni2lV3spvdpL6bTuRtwkqTaQclY/IrvQsFAOWKOXiqxs0v25NB8Yd4/Msxvy+5NlaN9vY385xPUc1iWrMp7JmPB3rjv5x3xvGv6GhqxM4LytWaExLfied38Y4omJ0yRdMLgbGbq7ZDfKGRHMZ1uXyxelSB2mRUF2suZrrkkzTpxfFfFfMdvmMXqmkgZBGRbzzvLAfH7MGE7wzRBOFyxcnEEyQ5pHtFOj5OCkpJ3aTuDLbs13BwfwQKexi2zBbQQcaBtmCvNjv4rj3+IhpP+Pd6hRDvO3Hr+zOQi/SJAIPkGL+rDNVYJE8Aer+TAsR0SCCpr2MGhEROjvWKM9CPpXREToJ7pl5Q7CVgkSweclskGrD4JLDxrlUVnzC8tCGs6iSzgoUBNwNIFPeMtVU4Ehu5I0In49gsB2ZWi8aIVg8zYJT3I6Lx9xPqlCNoPzeWd54KHXv+B/CZCcNuP8eUZJuiyv4stjwHdg/iHp7rY9+KX684wNPkR41/pDvtHxOenW8cPvivXw7tsa98nOsJ2hGWMIvIqfQB/e9W/Cp/vc65X8v38BAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// Information about the customer.
    /// </summary>
    [DataContract]
    public class PayerInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PayerInformation() {}

        /// <summary>
        /// A simple postal address with coarse-grained fields. Do not use for an international address. Use for backward compatibility only. Does not contain phone.
        /// </summary>
        [DataMember(Name="billing_address", EmitDefaultValue = false)]
        public SimplePostalAddress BillingAddress;

        /// <summary>
        /// The customer's email address.
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue = false)]
        public string Email;

        /// <summary>
        /// The customer's first name.
        /// </summary>
        [DataMember(Name="first_name", EmitDefaultValue = false)]
        public string FirstName;

        /// <summary>
        /// The customer's last name.
        /// </summary>
        [DataMember(Name="last_name", EmitDefaultValue = false)]
        public string LastName;

        /// <summary>
        /// The PayPal-assigned ID for the customer.
        /// </summary>
        [DataMember(Name="payer_id", EmitDefaultValue = false)]
        public string PayerId;
    }
}

