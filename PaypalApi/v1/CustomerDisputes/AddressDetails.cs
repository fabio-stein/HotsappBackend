// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// AddressDetails.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/7xVTW/kNgy991cQPnvcFL3NLU1QFG2RBmnaS1uMaYueISqLXkqaxFjkvy/kj5k4M8EiyCI3iZREvkfy6XN233eUrbNLY5S8h2sKyNZnefY3KmNl6QbbdCDLs9+oP26uydfKXWBx2Tq73xE4catONKRLgMZw8qFNy+FpMz4NYYcBUAm8tBS4JQ+OyJCBRhRqaTvL6GrKQdn/n4MoSNiRgq/JobJ4eNiREjTsaLVVZHeIwa4RbTFFhpa3uwAVTa8XcCMBDgk+cNilYK04CDtWAx1q6AGdAenIeYlaUwF3ZKIz6MJ8YwhM1vgCfhYFesS2s5RDOeWwmUMUs8Gyo80PJbCH6CNa2wOm0BW7MVNpjrcnlgoflChsXGwr0nJIq5xt2NLSEvqOyiLLs0tV7MeSXuTZHaH5w9k+WzdoPSXDp8hK5mC4VelIA5PP1v8cmsEHZbc97YEqsjXstkMGi4Z46Vl2xyUkswEr9QB46gGlTsmTC2lP0Cm17KmAvw4kzc8O91MjjHTA0CfWUj3TNx/0Y5Vwruzy3ouK/RsvLn6sazE0rOhKcU8OfpHoR0v9/dH5XnZdtPYp/yrFhizvSfuNJ91zvWT5jPN0DOdDMB0q4FZ8AGkargkqecyhwu3EyDBd3TN/IuyDoD7r5gXKpf0U4OgfM4Vfow9QXmvUvgR20xJ+R/f+gXgjjoHQs0hmz+tYxvb80HyTZpzLdrK/mmvyp5FLIzuJ1ksl/HM4WeZQDnXIofxJoqU9qkmbK4mavEnBvIC4jwIeq80sFEvkS8cp9IbVh5WoIQVygUMPFVl5AJyU7SBUogeVOytyPlarM0Ln2W0tHZ9JKpa+tTfIXAFX6NJ3h9BYDDn4IEp9Do0V0RxUpB3GHdNH15IL34T2/56++wIAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// The non-portable additional address details that are sometimes needed for compliance, risk, or other scenarios where fine-grain address information might be needed. Not portable with common third party and opensource. Redundant with core fields. For example, `address_portable.address_line_1` is usually a combination of `address_details.street_number` and `street_name` and `street_type`.
    /// </summary>
    [DataContract]
    public class AddressDetails
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public AddressDetails() {}

        /// <summary>
        /// A named locations that represents the premise. Usually a building name or number or collection of buildings with a common name or number. For example, <code>Craven House</code>.
        /// </summary>
        [DataMember(Name="building_name", EmitDefaultValue = false)]
        public string BuildingName;

        /// <summary>
        /// The delivery service. Post office box, bag number, or post office name.
        /// </summary>
        [DataMember(Name="delivery_service", EmitDefaultValue = false)]
        public string DeliveryService;

        /// <summary>
        /// The street name. Just `Drury` in `Drury Lane`.
        /// </summary>
        [DataMember(Name="street_name", EmitDefaultValue = false)]
        public string StreetName;

        /// <summary>
        /// The street number.
        /// </summary>
        [DataMember(Name="street_number", EmitDefaultValue = false)]
        public string StreetNumber;

        /// <summary>
        /// The street type of the address. For example, `Street`, `Lane`, `Boulevard`, `Court`, and so on.
        /// </summary>
        [DataMember(Name="street_type", EmitDefaultValue = false)]
        public string StreetType;

        /// <summary>
        /// The first-order entity below a named building or location that represents the sub-premise. Usually a single building within a collection of buildings with a common name. Can be a flat, storey, floor, room, or apartment.
        /// </summary>
        [DataMember(Name="sub_building", EmitDefaultValue = false)]
        public string SubBuilding;
    }
}

