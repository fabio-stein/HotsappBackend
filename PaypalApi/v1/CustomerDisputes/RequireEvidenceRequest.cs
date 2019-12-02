// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// RequireEvidenceRequest.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/6RSwWqDQBC99yuGOS+hZ29psy3SYIKxKaWUuOoYFzau3V0LUvLvZaMxSQO95OY8n/PeG98PJl1DGGBMX600BPxbFlTnBB4g65DhWhgpMkWR2HkmMnyh7jTMyOZGNk7qGgOcguk/BKehbQrhCFxFYJ1/0iUIKKRtWkcMsg7CGfNEkq4iA+nbNEzC6HnztIg3D6/vPN7EfLVcRCuegv7zfsXn83PCBJJK2kEor0S9JaDaG7fH/d5I1nZk/DJLSnlMg22znXRAx+il7qmD0QmE5WFORe5TpiAtpL09vg5nPHrkKesZB/XU5zxbMNzBeq3/Io5Cvc5Bhg0xbxO6uhUynBojuv7v3zOMSRSLWnUYlEJZYsdCFCOwNLoh4yRZDD7G3lhnZL29bkkf4aIrI3TZmOQU2GnI9a5R5OhWh3Wr1P5zf/cLAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// A request to update the state of a dispute, by ID, to either `WAITING_FOR_BUYER_RESPONSE` or `WAITING_FOR_SELLER_RESPONSE`. This state change enables either the buyer or seller to submit evidence for the dispute. If the `action` is `BUYER_EVIDENCE`, the `state` of the dispute updates to `WAITING_FOR_BUYER_RESPONSE`. If the action is `,SELLER_EVIDENCE`, the `state` of the dispute updates to `WAITING_FOR_SELLER_RESPONSE`.
    /// </summary>
    [DataContract]
    public class RequireEvidenceRequest
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public RequireEvidenceRequest() {}

        /// <summary>
        /// The action to complete.
        /// </summary>
        [DataMember(Name="action", EmitDefaultValue = false)]
        public string Action;
    }
}

