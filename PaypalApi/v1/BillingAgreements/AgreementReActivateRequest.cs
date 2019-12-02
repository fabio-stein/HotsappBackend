// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// AgreementReActivateRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/6RUwW7bMAy97ysInt24G3byLWg2NBvWZE2wy1CktMXEKhzJpehuRpB/Hxy7TuIAHYZdbOiJIvneo7TDO9oyJkgbYd6y05HwFWVqX0gZI5xwyMSWar3DBO+PewEIQhVKdoYNpLYorNtAnyaCtIbpZARTB5ozfFnM7kD4ueKgkHpTR2BdVlSGgRw89udWQUl5ZbqyXh7Bp0+cKfyymrcfAueVQXNSaANTDocqwhS8g7WXbvnarvUOyJkD2tcC2vqq+TkDWSXCLqtHGOH3iqWek9CWlSVg8vMhwlsmwzJEP3vZDrE5aX6G7XBZl43IQcW6DUb4g8RSWvBQ/JU1GOFXrruNCwOWOcN0An49YKL+hCw3JMYiVLd1ryO8ZzIzV9SYrKkI3ADPlRU2mKhUHOFcfMmilgMmriqK/UMbw0HbJD2JcV900VgFk96qt4gNbT2j+WbYuQBjMMf1qw6teQqH0xfi/JMaHXAqx9/9a8bxjFAHXHo3GNCjgW3rWU5uw//bcOvfvokKpXeB2zwNHOGNd8quMxWpLAubHe5H/BS8wwhvVctvrLk3mOB8tlhiO9KYYPzyPi6pbhoOcXflr3oOId6dDvI+Pn9JPv0uOVM2zdRU4cYbxuTD9cf9uz8AAAD//w==
// DO NOT EDIT
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BraintreeHttp;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// Re-activates a suspended billing agreement, by ID. In the JSON request body, include an `agreement_state_descriptor` object with with a note that describes the reason for the re-activation and the agreement amount and currency.
    /// </summary>
    public class AgreementReActivateRequest : HttpRequest
    {
        public AgreementReActivateRequest(string AgreementId) : base("/v1/payments/billing-agreements/{agreement_id}/re-activate?", HttpMethod.Post, typeof(void))
        {
            try {
                this.Path = this.Path.Replace("{agreement_id}", Uri.EscapeDataString(Convert.ToString(AgreementId) ));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
        public AgreementReActivateRequest RequestBody(AgreementStateDescriptor AgreementStateDescriptor)
        {
            this.Body = AgreementStateDescriptor;
            return this;
        }
    }
}
