// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// JsonPatch.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/7STwYrbQAyG730KMWcTevat0FMLSWlDL6U0yliJJ4xHU42cYkrefZlJ4uA1y7Kb3eP8ksz3Ifm/WQ+RTG0OicOfiGpbU5mfKA63npbY5ZqpzFcabo/PlKy4qI6Dqc26JfjyY7WEMg28PZBVUAaM0Q8QUdShhz42qJRyQShxL5bSwlTmkwgOZ4iPlflO2KyCH0y9Q58oB397J9SMwTfhSKKOkql/jfhJxYX9HH0n3E3wL8FTCuyCkmRIbQkUZU8KDdu+o6Dg2WIegfwV+Nc62+bWjo9U+o/oe1rAlRl2LCXf5I4NZPAyf6936L0/Vc/Kc5yol+dcfKTKKpa76EnpRYQq/esAI2o7QbwEd24H9babq1CZeK8FnG9+7lfuYSJ4TeaGpTL+NgvI2Ubo0eVAw5QgsIKc+QAvV/cWRr9PHx4AAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The JSON patch object to apply partial updates to resources.
    /// </summary>
    [DataContract]
    public class JsonPatch<T>
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public JsonPatch() {}

        /// <summary>
        /// The JSON pointer to the target document location from which to move the value. Required for the `move` operation.
        /// </summary>
        [DataMember(Name="from", EmitDefaultValue = false)]
        public string From;

        /// <summary>
        /// REQUIRED
        /// The operation to complete.
        /// </summary>
        [DataMember(Name="op", EmitDefaultValue = false)]
        public string Op;

        /// <summary>
        /// The JSON pointer to the target document location at which to complete the operation.
        /// </summary>
        [DataMember(Name="path", EmitDefaultValue = false)]
        public string Path;

        /// <summary>
        /// The value to apply. The `remove` operation does not require a value.
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue = false)]
        public T Value;
    }
}

