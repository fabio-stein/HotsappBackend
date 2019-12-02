// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Sale.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xZT2/buBK/v08xcN+hCWQpfenf3IL2LRpstwmSdC/ZIB6LI4sbilTJURxj0e++oCjJkeW2aZs1ioVPBodDemZ+wx+Ho79G54uSRgejM1Q0ika/o5U4VfQeCy8dRaNfabEcvCGXWlmyNHp0MDoEh4qALWqHqRfGo2h0aC0uwq570eiUUBxrtRgdZKgcecHHSloSneDEmpIsS3Kjg4vOnsPCVJqHFmErX9rVifrWnecEJS4K0gxBJYK55BwEMUrlHs5Wx1bq2dDWtLKWdLroWXtHOLT3gnNLNE5ztJgyWTg6Ox4//d+TF9Aug9QIunycCJO6RGqmmUW/QSKkpZQTS46TVnnslV2yE8MJLk5QgTDkQBsGV5WlsQyoVLu1pG8LCdtqJSK6UupT1IXlpAl+gBLehLAPwyS6iWWUlrJhkFAI6Yfen6AGODUVAw8Q/+cxnsmMr+YWy575d6VDB/ws+FnIiGL4DW9lURWgSM84B+ngyR50KeAimOcyzUHqVFWC3MEf1d7eflqp+pfCSMkwOqMb0iDkTLKDKWXGUh0WQaksUEFppOY4rEnaRf0tzr9RfW7a/8PMp+w9/y5pHfhBiFaS7nM45aiFknp2lRH1oFqZGKLVKmzB8iYH3iABmQmrG2Zpz11BnBsBRqtFvBlkpXaVRZ32Yb0rHWLazW5B7YHqYfsyshsC1eWyLMPMEtM7wiGk7eQW0Y1xahvyKyFdOijL1s1+GTZoNbcn8uejWVdN2TCqPsZL4Rpom8mmFutckUyFi+Eoq0eWPlbkuIMSlNSNTgScSwdlMHbhs2B31za+7O5uT/lGgGe87WEexkO4GW+3iDwAIpf3wWRwEj9/DHtn0EMxIwFs2tcSEUwX3cDG8IuxYCmrtHARWCotOdLsapVmF86R76xvtNtNjZUzqQNZ+Q23OfGjb+r7pERqCZmuWBb9QrgvH6aHQCZALcBrwDwn3dCyM5VNCeboIOwhIpAaLo40k9XEKyszYwvky8c5c+kOkoSNUS6WxFls7CzJuVCJzdL9/f1XjxzV3aLxs/j5zqZeCaL/PBBrg3H0Bky4lh66s7Vi5jupr+HO/8Px9E9K1/S7lNTX/dZIK1npxWlAb563v7lSx5aUhw0u3h6e///48AzqpW3zCEuZmBuyN5LmyaMcmQy6ca2yCsrzh++b5Jay/js8CIaYpKYoFbG/YOyMGD6cvovh3ECB19SkanAzRaUirz71FYSfaaqkuutXlxLeu5DFH06PgKko/dL75u7zZy/2dmI4CkRV/8Pkv5MIJo8nUX0QJjuTO8RWFzylpXFpTUrOST2LwXs08b5OPBH6La5pAS1A3lejqaXYGgzALgTBx+AP+vrKeaQ9raNSGzpIIaY96DrRELy35+cnLQxt5ebvibXgbcgDS/2rM4zXNGN9+IOB/oTyoqSvpsizVy9fdvT2dKe92xzZG3KADlB7kvGZgTW8AehKYzGVs8pUTi1A1KZMKeSHowI1y9S11OSXxXBGBBc1jZw2FrqldfP5PJaosbYNnZMz7Z8NLvFrx61Lq8P41rvxMIx8nyvLMXLVJ7dOtOY5UU9tiJ9fL7v0q6XX8j8HvcTh3NCNKTpadvNNTfshH5SCTGrUqUQFN6gq6hg8k6SEC7UZ3aJngwimqFCnFHWPQlFR4CFn4CG/xXzt+8ZrI+jf+Y3j+0mmxq8XlFay5oNG83WqKj017r7f/XzB6ahEi2xs5MlEUCY1iVCWNVH81rh1z3Is/UPbSn8h9pCIN1TBVqVYW8H25d9XwSp0DGGjn7iMvfz0n78BAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// A sale transaction.
    /// </summary>
    [DataContract]
    public class Sale
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Sale() {}

        /// <summary>
        /// The payment amount, with details.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Amount Amount;

        /// <summary>
        /// The date and time when the resource was created, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="create_time", EmitDefaultValue = false)]
        public string CreateTime;

        /// <summary>
        /// The ID of the sale transaction.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// The status of the sale transaction.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string Status;

        /// <summary>
        /// The base currency object for all financial value-related fields. For example, balance, payment due, and so on.
        /// </summary>
        [DataMember(Name="transaction_fee", EmitDefaultValue = false)]
        public Currency TransactionFee;

        /// <summary>
        /// The date and time when the resource was last updated, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="update_time", EmitDefaultValue = false)]
        public string UpdateTime;
    }
}

