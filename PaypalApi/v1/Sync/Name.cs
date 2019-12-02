// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Name.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7xUwY7TMBC98xUjX/YSrTjntoIbEiC0cEFoNU0m7WidcfBMgAjtv6PY2aRpWjiw6q1+fh2/9/yc3+5+6MiV7j225Ar3BSPjzlNals4V7h0Ny+ItaRW5Mw7iSnd/IBBsCUIDdiDoMNpw6wp3FyMOefDrwn0irD+IH1zZoFcage89R6pn4GMMHUVjUld+nSWpRZb9VhR6oyho9ND03j9IVr7oPL+/lZ7k3ijM/GTmFt6gwI4AYdcrC6kmvADh6jH/ChFQBgh2oJgTsAMaVCgSbPyvdp4NWCxAw1GtAI9q0/xn+9CMc5ZTkp7M+c8Mpff+qfhnkHv+QbLNbwVfji3RUhaTxRN3fFQKYAWEjqIGuZK5luva09bdGr9sL/MmU5+VAL0GsABqIRK0vTfuPB3zFFgq39cs+8m6xSBDy1WOCce+3Gixmn2dNLpIDf9aBTFDZzJIW0m0sXkqRt/LZV5Rt/bNqe4Z2urOW+ld2dFVXlVv3DRuwS63beLkmrTsp5Dhbizdo4SfAqjJ1LkPycWn9rfiTkeelrZdl7YNz6Wd+C8S5LenV38AAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Sync
{
    /// <summary>
    /// The name of the party.
    /// </summary>
    [DataContract]
    public class Name
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Name() {}

        /// <summary>
        /// The party's alternate name. Can be a business name, nickname, or any other name that cannot be split into first, last name. Required for a business party name.
        /// </summary>
        [DataMember(Name="alternate_full_name", EmitDefaultValue = false)]
        public string AlternateFullName;

        /// <summary>
        /// The party's given, or first, name. Required if the party is a person.
        /// </summary>
        [DataMember(Name="given_name", EmitDefaultValue = false)]
        public string GivenName;

        /// <summary>
        /// The party's middle name. Use also to store multiple middle names including the patronymic, or father's, middle name.
        /// </summary>
        [DataMember(Name="middle_name", EmitDefaultValue = false)]
        public string MiddleName;

        /// <summary>
        /// The prefix, or title, to the party name.
        /// </summary>
        [DataMember(Name="prefix", EmitDefaultValue = false)]
        public string Prefix;

        /// <summary>
        /// The suffix for the party's name.
        /// </summary>
        [DataMember(Name="suffix", EmitDefaultValue = false)]
        public string Suffix;

        /// <summary>
        /// The party's surname or family name. Also known as the last name. Required if the party is a person. Use also to store multiple surnames including the matronymic, or mother's, surname.
        /// </summary>
        [DataMember(Name="surname", EmitDefaultValue = false)]
        public string Surname;
    }
}

