// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// FundingInstrument.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/8xaX3PbuBF/76fY0XWmsUeibOdPr+6TYzuJm8vZ48jX6bgZa0WsRZxBgAFAyUznvntnAUoiTaWJEp96Lx5xsQvuLvbPb0H/pzeqCuod9l6VWkg9hTPtvC1z0r7X7/2CVuJE0c+YM0+v33tL1erhhFxqZeGl0b3D3igjuK13kctdQJBHqVwCRzqQUacE5hZ8Jh24NKMcQTqYoZIC5C2gFmC0qvi39JGOnhzgFFke6B5Tryowut6HHIEri8JYTwIKawqyXpJLev3ekbVYRRP3+r1LQnGuVdU7vEXliAkfS2lJLAkXS+ne4fXSOceWhPRwjFZ0vZKGxZs0Lq4c1Ka3fXV9cnpxeXp8NDo9+QDsuMgMzLzy2L9MCSlqKB1FdzXc6k1wNiAUWDElgStHq8e4FQsQisfzxJEQlpzremEilZJ6eoNLhpUnumvdyKl5oOYBqZumHaOGCQHde9KCBNwaCy6TRdEQeTwjnbdST9ectPRV+4gjoWsNL4DGnL5XKV0q9Vv/y5qZUntb3aRGUFvD9kJb0yO49nMzSDO0mHqycPb+HJ7uv3gx2AcW+PBkKEzqhlJ7mlpkqaGQllI/tOT8sN58wLxuuAM+Qw9SkPbyVpLj1ISaB4wFS1NpdPLvcm/vaTpRJr37WBpP4Tn+TZ23Rk8j5Wfj6TCSh016zJd6W351iIbXltDDSys9Ss0FJUryehR7/bLea0UKtUYb3+G9eruG13EeckoFu7wpBopmpECYnF/Jp+2CKsENtYIxK1lgfHww7qp9nEmNMDdWibmsaanJC7R8ulDq1GhvjVKhssmU4Mnx1cUO5OQzI/owQX0XUr0fjEmtcW4wMVaQBW9RO0z52Fzt9eFDt28Snt6W3xadSmrab4XlgrKmg0jrPPB6XdyX6Q2vjOXinxeK+qDLfEK2D85bIh+tdwaMTrZm0kHHpIOOSefhB6okRK2j1GjxFda5UnrqAxZofajmC3O/zcxvLyza2ByV/BSS/8Z59GW7tn+GoXuwi8LeEoAokMAl+dJqqls/Z0GBFVkHt9bk8NLiJ6m2ZHKRGd0uogtK16iwsjwcqeH6NNk/eMoG5Og/PMm8L9zhcDifzxPpy0RqLp3pcDS4PD0eBN7Bwd7e/t7B4GxIeieBd3gv8zIHRXrqMy5kz/dgWaHdtnxgnEfVbSdt+hp/hPVQ3vowz2QaLOA4/ySLWPU4zD+WcoYqdPZRVcgUlarA1nrXNZALJTeRufQZQ4HVzrwF6tYu74ng+mLFsvI86WQu72RBQmJi7HTIT8OLlR07W3IpR3rbmQtK143XX9N9g/iy97LTEK7eh4wKLmKvr3wUGIzPqOFbTruGz5v9gtF3ozxBAJ9tyL3c5hCuj+yUu77GTZT+ARdSO324jjm+kfwkiLDwMWoUm708DSIsfKaF3ExWskQQ9aiqzURZgkX/gQXqjUR/ZQkWfUf3MjUbyeZBhIVHGUqFWmwk7muhnT5H1vWVljxqvWcWt9FGpcO1Re7ZHjipp4oGk8rT9gvems72Fb2s7l7bUdHzclPBmtBVjxc4T9dji/Gb83enN+eXN/88v3w77sP49dmr0fixocWHr5laZrM2hqoJayzKLNEgDL2mtAMhp4thub4fYCzBIfbIZxFimmxXdbovpKWb3GiftUx4sNA1JTBEhQNTbHDagCIMdyefyJoEfkFVEmdGAEDj/TEbP94/GD8uvv2SgRWhXWdfTV+D31fn07CU2bcDzMP8cMPDWEvtFnnNvM6hlBklyP7F1TPIFsd3het0blK/pDLz/h4a/yT1HTReDueTXyn1aweiO/dwILrrls8jDcjqcX1ixEfODywp5H5y/eZodHp+9B6C6KKvYCGHZkZ2Jmk+/CFDTwbdILA8xG4vHv/OJ7N02zKrJqw5EMP11RN4xjUeri5/SmBkIMe7eAOwMJPhbp/ZJzwH8kqc5mMlCBd9bF2cJ64uz8BTXrBoZ6zwxiiXSPK3AdpmPldDe5u+eP7XvZ0EznSqSlHfPvyZK/2TusyPd8aNFhvHLUuDwpqUHPfhOK6O2dbxAsHfUQWLA2JbjQ73kBn6eF6ASxdEGxfQ3ZUTxycdLiXVtsa46NPW0S1J3cN7MxpdLI5hOYj4zxzeliywpFrqx+c10wK7PyrIGcrd/4sh8vxvP/74g6MA9gfPdhbDmiM7IwfoeMA6O6mnirB/OOhSYz6R09KUTlUggiqT+qbPUY7ay9QtrjZYrB7NQhm5rDV0D+Zi1HEyQ+fkVOekvRuy7GBh0sPH5J7N2NkaTonzffvaY0FaUwcaV/mRrdHNdZmTlWkz+8KNxwIEuAJTcgyyi1KnvgwGJ/CudB5So7kAcFiGomFEqUzI5xpHLwN3UgFhmrVU4bBIYPeSBL833GNacoXRjlyyu5Xe/PUItqv40oPjmXTIxSxH58kyCz8J6VLuEuMwoYwxp/tHgUrN+Gh8BoKRuSP9Pz8G3fiaZe0noeXqGrDLK/ITF5vv/yr0+38UadgkP/sFLC51bT074WrROu7wEYFnK2NX1+0XWF2gghmWym8XAf/RIf73DzH/L4z/fXj5WQcrP1urbEDGrDEEjZfdqY6vNdV6S1esWJF9mDEN4sNPdaWWH8uQMCFDqroKxKYZuoC3mN7BPCMdVoOBDMoaFtbZFNKI62QZPhmHx7YvGABKx2/jl2SkCg5OnBkpWBPtSccPG2ELYyGXLvxqJbNrbzMhQF3xyF5SUHFuSiVAScZYhk0xqWScWwNhAoezgLms6IMr0ywgE7i6Ojvp84ttGHlCxaccpVrdeOzuLq82lw75rLHh3w5gvHD+GObILVhOpQ4304U1MymaWy028e1elezu/tHugh6pk0YpB2iJg0iZOQs4+jsIEz6hxm5EjuLxxqFCSFcorB4JqH347U//BQAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The funding instrument details. An instance of this schema is valid if and only if it validates against exactly one of these supported properties.
    /// </summary>
    [DataContract]
    public class FundingInstrument
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public FundingInstrument() {}

        /// <summary>
        /// [DEPRECATED] The credit card details. You can use this instrument to fund a payment. Use a payment card instead.
        /// </summary>
        [DataMember(Name="credit_card", EmitDefaultValue = false)]
        public CreditCard CreditCard;

        /// <summary>
        /// The tokenized credit card details. You can use this instrument to fund a payment.
        /// </summary>
        [DataMember(Name="credit_card_token", EmitDefaultValue = false)]
        public CreditCardToken CreditCardToken;
    }
}

