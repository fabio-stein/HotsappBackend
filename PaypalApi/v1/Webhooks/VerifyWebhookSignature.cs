// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// VerifyWebhookSignature.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/9RX3W7bRhO9/55iwK8XMSBRAVKnie+E2E2EOrYgyWkLwzBH5IjcmtxlZpeS2SLvXix/JJG0Kqd21fSSM8vlnDN/h384szwl58T5RCwWOfxM80ipO5iKUKLJmJye8wlZ4DymC0zsSafn/ET55uGUtM8iNUJJ58QZwrK8aVXdpOubgOlzRtq4Ts8ZMmNefvllz5kQBpcyzp2TBcaarOFzJpiCtWHMKiU2grRzcr2OWRsWMuxGiJmJbjEOVSPUbWsz5llEYB0sTJSAidDAGPMxxpBp0mAUhCSJ0RCYiLYQoQzK47nKwEdpz9vjFQWNwy6c3RtG34CJhIYlxhnBglVSHPPGw1/Hw/P+8Gr2oT88f3/pAZNOldQEEWFA3INVJPwIhAYmn8SSAlgJExWv12RLZcRC+GiBfRXPhrMWzTKL4y+9vVz7xOY247hB9Zaxy/Qv7vHLt5Bm81j4cEc52NNl1OTCqVrJWGFQwNry1FQJDVeT84J5S7YwT+P73dlk1r+anP9X6DaMUidCa6HkrQgarHd9XfJHp6AWBYYPs9kYtl9x4Z2SBoWkAIRssDSbDC+mH0fT6ejyoj869SqO6qu2aYCEtMaQ/gU6tAh381E6u4SUjd6vGzwA1HmSkGHhb9fSME0JWf8lMdPR+2+UGSMS2k1N5e1yE9i+K2acSGhn3fQsKdcjaYglmdZLC8UJmpsXkTGpPhkMjFKxdgWZhas4HEQmiQe88F+9evX2/5p8+/H+sfv66HGMz0Yfzw5P+dmSpOkyXg2FW6rcG7bbnvbGrMdJ4X/OobJ/VfpMaKhbIE37vtJYRSQbg7GLBFaoobw1+Gcq5omy4pF9VSC7NfbQNl8Nc5euko9CKhgWYUhMwR7CDopnSWxb+QFIG88uVNWJulGfvBv/PpbWPty7Ag9G/rmQd7AVCVzOfyP/gRkSC3mnGyBqS2tmSEAbnkVSyeo+U1wssOsPw9nZ5XAKxas3LwaB8vUAUzGI0JBC3S8c7YZ5/fw6PGJaNMBUhm5OfJWkMVl9jRySsRLPhZmCBO9KzV2D8zGOe/b4XMjSk5CJ1FqbCV3ALifM1WQEhpI0LvTj4+bK6+MfXh65MJJ+nAXlF7zvvB54L7xeMaS8Iw/8CK2yJNb2WkiZ+ikrn7QWMnTBIvIsVs/KR3uFlbl1WixWJdfzoEgG4JqCEmOJB0Fnc23zK01hPlAjlZw2Urc2dZNXKIIqDVx93aryB5N3IARMzT+S8rkb+7WlvwzQ9qUd4HtL5Pjtmzfr1fP9Uf2noImXpAE1oLRDxlYGFuktE51JTOYizFSm4xyCIpQ5lfWhKUFphK/r0WRfc2FKBNfF8JhUEepNdKvVyhUosYgNtRWrCUmjB/bdfg2p/ejeWxjPsy1vthKhdkw0Jq0y9qmVjbWxm5La+U2uyzq4rgJoe7rAJG5U9Bpk3RtG7dyeJdoDAdRZkiDnDWgbW1u5Vp6qmsvdZuverNVBI0fwo2Kge7STrgfeEFLMbc0CZiZSLH7vSEXXe+5C3QW8FuktEdEwP0ZM2NiVXIgw4/JHOlcZwyktKbZRwVixwRjQ91X2lVnd8Wdy8+V/fwIAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Webhooks
{
    /// <summary>
    /// A verify webhook signature request.
    /// </summary>
    [DataContract]
    public class VerifyWebhookSignature<T>
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public VerifyWebhookSignature() {}

        /// <summary>
        /// REQUIRED
        /// The algorithm that PayPal uses to generate the signature and that you can use to verify the signature. Extract this value from the `PAYPAL-AUTH-ALGO` response header, which is received with the webhook notification.
        /// </summary>
        [DataMember(Name="auth_algo", EmitDefaultValue = false)]
        public string AuthAlgo;

        /// <summary>
        /// REQUIRED
        /// The X.509 public key certificate. Download the certificate from this URL and use it to verify the signature. Extract this value from the `PAYPAL-CERT-URL` response header, which is received with the webhook notification.
        /// </summary>
        [DataMember(Name="cert_url", EmitDefaultValue = false)]
        public string CertUrl;

        /// <summary>
        /// REQUIRED
        /// The ID of the HTTP transmission. Contained in the `PAYPAL-TRANSMISSION-ID` header of the notification message.
        /// </summary>
        [DataMember(Name="transmission_id", EmitDefaultValue = false)]
        public string TransmissionId;

        /// <summary>
        /// REQUIRED
        /// The PayPal-generated asymmetric signature. Appears in the `PAYPAL-TRANSMISSION-SIG` header of the notification message.
        /// </summary>
        [DataMember(Name="transmission_sig", EmitDefaultValue = false)]
        public string TransmissionSig;

        /// <summary>
        /// REQUIRED
        /// The date and time of the HTTP transmission, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Appears in the `PAYPAL-TRANSMISSION-TIME` header of the notification message.
        /// </summary>
        [DataMember(Name="transmission_time", EmitDefaultValue = false)]
        public string TransmissionTime;

        /// <summary>
        /// REQUIRED
        /// A webhook event notification.
        /// </summary>
        [DataMember(Name="webhook_event", EmitDefaultValue = false)]
        public Event<T> WebhookEvent;

        /// <summary>
        /// REQUIRED
        /// The ID of the webhook as configured in your Developer Portal account.
        /// </summary>
        [DataMember(Name="webhook_id", EmitDefaultValue = false)]
        public string WebhookId;
    }
}

