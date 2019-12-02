// This class was generated on Tue, 30 Jan 2018 11:02:39 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// UserInfo.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/8RYTW/jNhC991cM1EMvsuNefQviS9BNd7FNCxhFodDiyJqWIlVylK226H8vSH1EtOw0QL3aU8I3Q/q9GXI41N/JY1tjsk0ahzYjXZgkTX4RlsRB4Y+i8qYkTX7A9mWwQ5dbqpmMTrbJ+xo13O/gzmiNOYNfCPxCthLeZS1N3lSoOYzekf5jWzLX25sbU6MmudbIN67G3PXAKu9WWh2Eo3z1fbZZl1ypb39ioaWw8k4JqlySJrfWirajv0mTjyjke63aZFsI5dADfzZkUY7AB2tqtEzoku2vo3DHlvRxrlrkuWk0Z+zdphE4McTRuNWAuqnQBrVgCuASoZ8Cfopb/0/qulHqnzROnJDSonNnVIyGiYARi7k/lgioZcjgdw5qiwVaixL6CesvHvMQJdtGbF+wOdveduWIXmKnTC4UcUxvAp7hR9yCsTA4LUS0No6FynIj450b43O6n6kGb/SUO98wXIi1xaOnMiU8QnOujgVjCrU1z6Tz8B8WmHNjMfX8u6kLUXdsETk7d9hmprmUolEKOr/xqMGd0EA6V43EUEJK0zgE3VQHtCC0HCZoUV0nQb+9Qac4YmaFPp4UxAk6VzfUvtIoGeqKOCIE94WScyDLpRQck56ir5bB3rFNgTQ87ff7/erhYbXbPUF3xa3BT2hRWHi43cMB4Wmz2WyeUvhUUl4CaUm5YHTApeCQy+BMDkxFzCjX8GjAYm3RoWYwWrWjW+pphFH46fFHlwkdVoJUFLYBeePNgSvvf60L5IT1wRiFQl+gnT2jpYJQzvlPTbGQ+zFZn0rkEm0I/UQaTvX4HA5LLZSRQlSk2syf+khXjJ8pl431tlAalXBd3fAD/9elQ6MyKF1IzRG1RBsJGaFXd1jntRRLekY9D3kEz9kGc4h3QdZxGkf8KwU8NCI4b2D+swp2XguxrEhKhfOIx/icb2fvA/1V4jujfJHrJLbh/g+kSYMkVyvR+jVDre+bANJHEINbLSy7NXwwztFBtUOf4ICJFbquPWiKgv5CB85Y9j18nhsblmFzWtS65IZpXelGnV/9nXKxWRWtf3nGZXoCzkN3vzt9VwX3pfiWRmPWNWIx59jwxhuSUWGY2fd2S6mg0CrHAkZszv3nj+9Oj1SQYQpSCP3Mpbrt5hC32GF87s47/I45+/1SmPgmh74TI+eaxWLefWKJN/oL9to+X4T2xXZqaHGy/rhFAs4Y50oGp/HA+tdbs1SF+Ww09l+2XnhPwFdPKlOF4J2v9Mj65l8AAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Identity
{
    /// <summary>
    /// Open ID Connect user information.documentationLink:http://openid.net/specs/openid-connect-basic-1_0.html#StandardClaims
    /// </summary>
    [DataContract]
    public class UserInfo
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public UserInfo() {}

        /// <summary>
        /// An enumeration of the account types.
        /// </summary>
        [DataMember(Name="account_type", EmitDefaultValue = false)]
        public string AccountType;

        /// <summary>
        /// The end user's preferred address.
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue = false)]
        public UserAddress Address;

        /// <summary>
        /// The account holder's age range.
        /// </summary>
        [DataMember(Name="age_range", EmitDefaultValue = false)]
        public string AgeRange;

        /// <summary>
        /// The end user's birthday, in `YYYY-MM-DD` format. The year MAY be `0000`, which indicates that the year is omitted. To represent only the year, use the `YYYY` format.
        /// </summary>
        [DataMember(Name="birthdate", EmitDefaultValue = false)]
        public string Birthdate;

        /// <summary>
        /// The end user's preferred e-mail address.
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue = false)]
        public string Email;

        /// <summary>
        /// Indicates whether the end user's email address is verified.
        /// </summary>
        [DataMember(Name="email_verified", EmitDefaultValue = false)]
        public bool? EmailVerified;

        /// <summary>
        /// The surname, or last name or names, of the end user.
        /// </summary>
        [DataMember(Name="family_name", EmitDefaultValue = false)]
        public string FamilyName;

        /// <summary>
        /// The end user's gender.
        /// </summary>
        [DataMember(Name="gender", EmitDefaultValue = false)]
        public string Gender;

        /// <summary>
        /// The given, or first, name or names of the end user.
        /// </summary>
        [DataMember(Name="given_name", EmitDefaultValue = false)]
        public string GivenName;

        /// <summary>
        /// The end user's locale.
        /// </summary>
        [DataMember(Name="locale", EmitDefaultValue = false)]
        public string Locale;

        /// <summary>
        /// The middle name of the end user.
        /// </summary>
        [DataMember(Name="middle_name", EmitDefaultValue = false)]
        public string MiddleName;

        /// <summary>
        /// The end user's full name in displayable form including all name parts. Possibly includes titles and suffixes sorted according to the end user's locale and preferences.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;

        /// <summary>
        /// The ID of the account payer.
        /// </summary>
        [DataMember(Name="payer_id", EmitDefaultValue = false)]
        public string PayerId;

        /// <summary>
        /// The end user's preferred telephone number.
        /// </summary>
        [DataMember(Name="phone_number", EmitDefaultValue = false)]
        public string PhoneNumber;

        /// <summary>
        /// The URL of the end user's profile picture.
        /// </summary>
        [DataMember(Name="picture", EmitDefaultValue = false)]
        public string Picture;

        /// <summary>
        /// The subject ID for the end user at the issuer.
        /// </summary>
        [DataMember(Name="sub", EmitDefaultValue = false)]
        public string Sub;

        /// <summary>
        /// The ID of the end user at the issuer.
        /// </summary>
        [DataMember(Name="user_id", EmitDefaultValue = false)]
        public string UserId;

        /// <summary>
        /// The verified account status.
        /// </summary>
        [DataMember(Name="verified_account", EmitDefaultValue = false)]
        public bool? VerifiedAccount;

        /// <summary>
        /// The end user's time zone.
        /// </summary>
        [DataMember(Name="zoneinfo", EmitDefaultValue = false)]
        public string Zoneinfo;
    }
}

