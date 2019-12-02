// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// CreditCardList.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xaX3PbuBF/76fYUfoQeSTKss/JxW+O3d65l8QeW76HuhkLIlYiziDAAKBkptPv3lmAlERSjq2rq9508pKJFrvA/sPit0v/szMqMuwcd04NcuFOmeEfhHWdXudXZgSbSPzEUlrv9Dq/YLH6cYY2NiJzQqvOcecEpLAO9BRivw/EzHAbdXqdE2NYEc7Y73WukPELJYvO8ZRJi0T4kguDfEm4NDpD4wTazvFtQzsg9dqqCYeprelXURpKKmCkTUNN0JPfMHZNbd/8fm2vRZpJhEttHZNwwrlBa9t6T4SUQs3u2JJhZUF7relwGw7JwiElHyyESyDWzFjszwwTCjlMBUpuIzjToLSD3CJMtQGmQCiHRjHac7VHBDclx4TF9wvyUKzTjDkxEVK4ArSSBe2G1u8Xa+WYUJAlWuHLhdw6I9Ss7bVYuKLmqpJQ988oQaAFUCzdTiln8oZOKpfyX72nFdO5cqa4izXHuoL1hbait26h+3HCDIsdGji/voDD4Zs3/SGQyOfXA65jO6BgzYwP1oALg7EbGLRuUG7fJ1476IJLmAPBUTkxFWjBkSsCD2gDBmdCq+gf+f7+YTyROr7/kmuH/nf4N7bOaDULlE/a4XEgD9bpMFrblo72GfOTQebgvRE+I4SFIEnrQeyn9+VeKxIwxX0iNXlvftnAayl/OQjl7XI660ucowSuUzqSwm29Kt4NpYIhpUlgfHowbqt9mgjFYKGN5AtR0nzOG4ov5Ipy3GgpkUNmRIzw+vTmsgspukTzHkyYuve1pOeNiY22tj/RhqMBZ5iyLKaw2dLrg6bbd5KfUigc1hKzorQzciqMdUDrVCzJccvi8FdtAB8YFZ8eqDydoOmBdQbRBeutBq2inZl00DLpoGXSRRZKXOSz1mKsFX+GdTYXDnvAMmZcisotzf19Zm4od8+0MxT5dmWp09thLB8HWu/BIhFxQneSDP4qspD+ZO+XXMyZROUiGBWZiJmUBZhS7/Iy0I2hauIfGLa+M4S3ZH2Xa0S4vVyxfH6dOJfZ48EAVbQQ9yJDLlikzWxAvwaXKzu6O3KpdczVnVlRNtTn55RhL74swv6BhZtr8GTw9QjXfOQZtEtwzbcRXK37fL1wgKjlKUVRKNDLBLa42uYYbk/MjMq/Ytso/YpVUt0e3L437KuQW8lPvAgJnzLF+HaHx16EhM8VF9vJCpLwoo7JYjtRkiDRv7GMqa1EfyMJEv2IDyLWW8mmXoSERwkTkim+lbgrhbo9yqzbGyUccrgmFrvVRrll3Qg+sgeR5ilIVDPnS8QP+2CFmknsTwqHsMQm9kVu5+fnoClCEnjnRNoAUzV6+65yum5Un4kDFgkGoDBnuSQfreP+BbMQtuM9uk635x4Oo2tsMtUmZW5Vw5zW0kYC3dRXsMSlcmCm8eHh4btXFv2F7R9Fb7qN12R8sD982x8O+/tHo+Hh8fDo+HD/7+MdlTt8yITBu1Qrl9T82VhoO1Qr7IPTQBiVi5lw4HlXrvW+DNvYXngflAaJjAs1g69odNMRwzGl7Xh4sGPrC2Rmk/ElfQMM0rkpjSaezTZvCvPuDPMNnLwjhe4Eb1jXWmybWDHJop8ZPRccOZyfVbho7brs3KLcOp2iedyqGsPWlpXS/qldJDqlHPdDjJecYDzTaA+376h3qZlaIz8G0ml5Q7gg0ZKj2VTcD45euqA/bWEjiI+EbBWeDfW6QrCFziFmys8xnIZprjgBUlYQRN+ROZJtitc6tW0crT4VrZfV/oNQ97CmCFz4SdfGPureNvuo+29P0Kg/QOv6BiW9oHD788noLxcn1+BFKxTCMjHQczRzgYvBq4Q51Mz2PUv35QZuj4UpMTitmVUSNsyKNFVvh+AIBTu4ufoQwUhDyu7D4KAyk5qjHrFPqH2klTAECA+fS4T1DgiA4ubqHBymGYk+F0a8OXq7343gXMUy5+XQ4s/jHoxfj0PjOe6O1+6vr1+ZQapxMVpCbaHLHZOt46rfu8cCqgCRrVpRE+JnJD4YwJYuCDZWjZ7NJ5YirZwn7+h+BZ/WQrcktYP382h0WYVh2ba6R4K3IwsMypr64feG3pLcHxSkG+qKDJ9MkaN3P/64RJo/dKvCaNHM0QKz1I6fn5U9qN/fBzpXLJ2IWa5zKwvgXpVJOSC0mDLlRGyr4kRiZSPvy8hVqaFdabdYLCLBVOjjmbVipqgE2wHJ9iuTmj+jBzKju7NGIkUTJ0y5Jo6o07/1FlWcfwioEEZQNUuWpA1lbe2JCWwR/Mqk4DBnMkeqDgzCUWStylM0Il4vLxWetxmL0RJuz3IVu9wHM4KPufVfAKi4+SuneS516J0oiwLoWF7KSQHC2ZpalPER7F0hpxP9ZNegzbSyaKO9Hc3XWNEGmmvE5reXXIkvuU8Rf7EqRBLuQDDesPg+9Au06uEM1dj1z07GQxi2sTetqtcK2MCI3pbzM39SgjIjHjbXgpM6yqEqP+PQptpAKqz/X+OTHJwyBRPqbouQAz2weZz4qgE3N+dnPdrAeKDipwuYMrH2bWhvz+shLEyQsoZjZjBmZeSmbK5NdW/Gm6D6GLIQnyLa2/vjjfrKcV0boBHMJHuFss7kO4SadD9qypeEb192f6t2o2Ce8Y2Tmjr9P57UhO3+/yc1cyrPd7lyog4g6vRnu3PdjROMdYoWcpVb/2Fraugxq5z+X3KtB6Nr2o8hY4al6NBQGVHaBQRCnRELaMRPVgIgCsMmUqNAZsJujy5DKmaJo/JGeM9/AwxeqJ9PljVC3hzqkCs+6TnSkwkH+8N3MMndI1uRFRex08Q6fOuSnhd4cYDz4t1co2b0bYaxmIr4eyv3vZX73sp9b+X+Z62c/3TlO5omFtKOybv233vV6e3I+PWyASKveM4Xzp4nlM7YDDcpXdGfVtpzvpCv//RvAAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Vault
{
    /// <summary>
    /// A list of credit cards.
    /// </summary>
    [DataContract]
    public class CreditCardList
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public CreditCardList() {}

        /// <summary>
        /// An array of credit card objects.
        /// </summary>
        [DataMember(Name="items", EmitDefaultValue = false)]
        public List<CreditCard> Items;

        /// <summary>
        /// The credit card-specific [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// The total number of items.
        /// </summary>
        [DataMember(Name="total_items", EmitDefaultValue = false)]
        public int? TotalItems;

        /// <summary>
        /// The total number of pages.
        /// </summary>
        [DataMember(Name="total_pages", EmitDefaultValue = false)]
        public int? TotalPages;
    }
}

