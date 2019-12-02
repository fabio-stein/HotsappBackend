// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// EventTypeList.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7zSwUoDMRAG4LtPMcx5FU8e9lbQk6IixYsUmbpTN5gm22SiBNl3l3FL3bhCQaWnJf9Oki/DvOM8d4w1XryyE9AFXJkoWOE9BUNLy9e01gKs8JLz1+Kc41MwnRjvsEbdA34Fb7xsvX8B1uPiCVY4C4HycMlphXdMzY2zGesV2cgabJIJ3OyC2+A7DmI4Yv3wA28q+7zrUXLHsUCWeemdOSCF7TWf/d4cJRj3PPU2I8nYW+bfvNCmNbnjwNToUTAq1jdIy4P/ry13ydq+2vsGp58xfhuU6nnLkJzZpC0OtOpAwigkqRyIXTRVDr+0k1TOw79oF/2iP/oAAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Webhooks
{
    /// <summary>
    /// List of webhook events.
    /// </summary>
    [DataContract]
    public class EventTypeList
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public EventTypeList() {}

        /// <summary>
        /// An array of webhook events.
        /// </summary>
        [DataMember(Name="event_types", EmitDefaultValue = false)]
        public List<EventType> EventTypes;
    }
}

