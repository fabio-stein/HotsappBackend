// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Payer.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xc727jtrL/fp9i4F6gm4X/JNk/7eZ+SpO09W23CRKnxUXuIqalscWGIrUkZcd7cIDzGuf1zpMcDCnJkiV3413X3QPoyyIacqT5zZDzj1z/rTNaJtg56VyxJepOt/Mr05xNBP7CYiJ3up2fcLl6OEcTaJ5YrmTnpDOKEBJi7EPxJ0xTGRqw/jlGafudbudUa7b0nzrsdq6RhZdSLDsnUyYMEuF9yjWGBeFKqwS15Wg6J3eFkN+nMuRyBkNprE7p3XWJp37OPS/mmAqI5vEqrlMJjAQGNQUGhsuZQMgYYcUIU6Ud0CDVmp5zwPArEzwEJcUSmAxBZ/BWDBpDbiFgOsyZIEYbqdBr0n89To0FLgORhgjIbYQaGIw98z0xj0HpCuHeqgeUY1CT3zGwfRhO3ff8+wIlLePSQKw0go2YBCWxBKhbNhtwAyEGgksM10z4+tNNeOaRnzEd1m1XAlKxWZVetdXd+cXV9cXZ6eji/J3TXVm3IVrGhenD/6kUAiYhNQScm7IVrXK2Bbay363B1aN/FTEgC3e3mE/DUKMxdS1MuBC0QlkxYaWJ+lh9R2ZzIJsDXJahnTEJEwR8tCjDbEmaiCdJiWV3II3VXM4aLM3tsmpiT6ijoQGQLMbPFUqmQvy9+3HJVCqtXt4HKsSqhNWBNY8Bd3ahekHENAssahjeXMKLo9eve0dADO+eDUIVmAGXFmeaEdcg5BoDO9Bo7CB7eY/mmsEBbU4LPERp+ZSjd6fZHNryGmdcyf7/p4eHL4KJUMHD+1RZdM/+38BYreTMU35RFk88eVCm+/2SvZY+7VbDDxqZhe80J2dBXsBz0rhn++G77F0rknNzUtna3NufGuYa2oe0pRwuq5KewDkKCFVMnyRrm8xXMpsL6HclMYzPjsd1sc8iLhkslBbhgme0QMUJ02RdSCW5P62EwBASzQOEZ2e3VweZ3+3ChMkHt9W7DkyglTG9idIharCaScMCMpvJtD5YV/s2y9Pq9NNWJ3njo8qyzCn1nTPl2ligcYpjLgxk2xu+VxrwkcWJwC7INJ6g7oKxGtF69EaBkv29QTquQTquQbp0fzDhI6TBQMnwCehMyi12gSVMW+fNc7ifBvPTHYtUOmaCf3Cb/95YZtOqb98woW7Y3LFXGMAz9OEabaolZukH7QKXlxmYahXDd5p94GJPkJNIyaoTzSkNeSSNFMbhEu4u+kfHLwhAzOy7Z5G1iTkZDBaLRZ/btM8luc5gMOpdX5z13Nze8eHh0eFxbzhAedCHt+yRx2kMAuXMRuTIXh1C4aHNvnSgjGWiHk6q9AZ9uHHn3rqwiHjgENA6/8AT7/Vomb9P+ZwJF9lHy4QHTIhlNd/0jpKCyILbiFKB1ZvpFUxW3nKDCHdXqykrzaPsL/gDTzDkrK/0bEBPg6sVjoM9qZRWelWZOaWuxrunRF/HXsReUhqD2xu3o5yKSOsrHbkJymXjhW5p25Vz/FK8AF5xT+CST5d4e79lcPWaE7g71TOK+pJtI/RXLOc66MKd3+Nb8U8cCzGfMcnC7T4eOBZiHsqQb8fLicOxWiaW27ESB7H+L0uY3Ir1d+Ig1rf4yAO1FW/sWIh5FDEumAy3YrcZ00GXVtbdreQWQ7ihKWarF6WGNTq5l4dZxdqbLC3u3+E1RLYnxLIseu1HREvDZQEzQl08GnBdgMbcYvzj5duL+8vr+98ur38ad2H8w/D70XjXqcW7p1Qt83k1h8oIDYgijdhzRa9KdS/ks7xYnjPBQ59L0BLbsS3cmm5qMeFjwjXex0raqAJhbaAOxU3wArtJPsBJBQKZa9V8QK1cMyZF2hkuARofjQn8+Oh4vNv89mMAl8h0E76M3pC/r+xTQkrT95OYu/rhnoqxagOtTG6o12kpRUqEqL82WQ2yx/JdsCaZy9SPiUxz/wyJf+byAUofh0vXo2ssiB7MekH08MddSsr40NieRsEontz9eDq6uDy9AceaxxWW8IGao55zXAy+iphFxUzPTTnYXYtvk2kijdMKrIzQYBBF/tUiWMprLNxe/9yHkYKYPfgOQA6T0t0uTZ9QHUgjvpr3nsA1+gidrydur4dgMU6ItVZWWKWE6XO0U5faRjYWAz0NXr/65vCgD8OsCeu6D/9Nnv5Z5ubHB+NSiPXllsZeolWAhuKwL1fHhHWcZ/APuITcQIRVSdeHjJj19gJWqMBjzFN3k04MWdo1JcW+yjiv04rpClLdeD+ORle5GYpCxG4w3p4QaBQV8f1zQ7VA6vcC0g6l6P/RJfLqzbfffmXQJfu9lwd5sWZQz9EAM1RgDc+zqsK93xk6lSye8FmqUiOWEDpRJlmnz2DMpOWByVsbxJaVZs6NXGcSmrW6mElfmTFj+Ey6w40B8fZySOuP/UeCcbC3PMXX99W2R05q8AOlVr6fVormMo1R86C8+1zHI08CTMICNJRkJ6kMbOoA9+FtaiwESpIDoGXpnIYKU6Hcfs7y6GLhTpaALIgqotCy6MPzawzpu66PqdEkSho0/ed7ic1Pz2DrghcaHM+5YeTMYmYsaneg1IVxyE1AUWLsKpQxi/FxJ6lSeX2UjoFgpB5Q/uFhkD/V2nQkVIw2JLs0wj+Qs/n8U6E//1CkhIlvPAHzQ3Wsw3PyFhVzu0MEqq2UXrXbr9jyigmYs1TY/WbAX3qK//lFzF+V439evvyyliu/bBTWZcYkMTiJi+iUra8Gb72nFitbol7fMSXi+lFdKvn71G0Yt0OWmRfwQdNFAatZ8ACLCKUbdQApKSshzHaT20bkJ1N3ZOweq7qgBJAb+hp9JEKR0OJkc8VDkkRalP5gw71CaYi5cX9VNrOpvmaCwOSSSvYUnYgLlYoQBKccSxEUFXDKc7NEGMGwucu5dNgFkwaRy0zg9nZ43qUPa1fyOI+PMeNi1fF4/rxobRYK2QgW+BQYjHPlj2HBKATzGZeuM51oNedh+VX5S9auRfSfP//SekE7iqSeywDTSItIqAUxGPwfCJU7QvXRCA168/qiIuQmEWy5o0StHIrdzR8YSl8REdxNG0xOVdMW8+QNN4OAr17c3p1o7060dyfauxPt3Yn27kR7d6K9O9HenWjvTrR3J9q7E+3difbuxF94d2LCtY3uw3W/WCE3VYraRhA6LzfN/99EHn6H0qKWaP34E88aX7x48aY4SHrVf32wrrGjN28Oe4cve7vva+62oCuK/69NvbQ77BWl3aoI2bLE2xN61wirtnMzyma8a82zuos5Ov5m/37l065y5Jj+Iy5x5ML+Wdc3Nh6O8zAUWJe2St8sr5+3T4m3a5ePiiOjnm+QYwgoA71MKPb6Ht/w/EssijIFl4ujpg15/FcUNiTTfS2UVsibyjzXet5TOsJEavOecCklKZM3K341bcfi3uQt141t4Lwp29gHbhisg1hv6xaHxm17t23vtu3dtr3btnfb9m7b3m3bu19We1djwBOOsqF8qg3VFUsDucsopgOz/nLcjg6420Z126huG9Vto7ptVG/bqDbpdMofq0rPSX9Qhrsp+1I6e1zvLBWkDSL+6x//NGDZIwzP+3CTJonStvRTSdl15eqvJLkEbq+Q6s2aKv3j4LI7g3tH+O5pLUH69n3D//SpDTUirfyCVXEtMkP2GxMCi1/HyspJ7/IgxAm3zktmhPId0C/Rl/khchf5BstQssBF+B3Z7L/+DQAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The payer. The payer funds the payment.
    /// </summary>
    [DataContract]
    public class Payer
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Payer() {}

        /// <summary>
        /// An array of a single funding instrument for the current payment. Valid only and required for the credit card payment method. The array must include either a `credit_card` or `credit_card_token` object. If the array contains more than one instrument, the payment is declined.
        /// </summary>
        [DataMember(Name="funding_instruments", EmitDefaultValue = false)]
        public List<FundingInstrument> FundingInstruments;

        /// <summary>
        /// The payer information.
        /// </summary>
        [DataMember(Name="payer_info", EmitDefaultValue = false)]
        public PayerInformation PayerInfo;

        /// <summary>
        /// The payment method. Value is PayPal Wallet payment, bank direct debit, or direct credit card.
        /// </summary>
        [DataMember(Name="payment_method", EmitDefaultValue = false)]
        public string PaymentMethod;

        /// <summary>
        /// The status of payer's PayPal account.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string Status;
    }
}

