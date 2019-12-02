// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PaymentTerm.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6yS0WsUMRDG3/0rhviiy96ucCi4b0IRilSLLL6U0uY2k+7AJlknkytR+r9Ltrq940Af7FvyfTOT/L7kp+rzjKpTlzo79AI9slO1+qaZ9G7Cz9oVV9XqE+anzRnGgWkWCl51qh8R5t/9guwgWJARgfw+0IANnFvIIUGccSCb4bYU3Uie8bZejEF7H+TJNwlvjJZia29gTwPCHjnqRtXqA7POj7d+U6uvqM0XP2XVWT1FLML3RIxmFS45zMhCGFV3tfJGYfJ3p6R/jj4iPhBPyYsB9yP6Q+Y1D4pgEjbQj2VVSl2KAjsEDTZJ4scBDZwVzwZ2emmqcs652lQXF9WmMqaC6kdVg45g0JJHA+Th6twLskdZmtueHMLHZcL1q1Fk7tpWQphiQyi2CXzXjuKmlu2w3W7fv4w4FIzN2+bd6/8N1qdpeqj/me768EfxHqqn+S4/apfhfqRh/FvGz4Fw/fDiFwAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// The payment term of the invoice. If you specify `term_type`, you cannot specify `due_date`, and vice versa.
    /// </summary>
    [DataContract]
    public class PaymentTerm
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PaymentTerm() {}

        /// <summary>
        /// The date when the invoice payment is due. This date must be a future date. Date format is *yyyy*-*MM*-*dd* *z*, as defined in [Internet Date/Time Format](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="due_date", EmitDefaultValue = false)]
        public string DueDate;

        /// <summary>
        /// The term by which the invoice payment is due.
        /// </summary>
        [DataMember(Name="term_type", EmitDefaultValue = false)]
        public string TermType;
    }
}

