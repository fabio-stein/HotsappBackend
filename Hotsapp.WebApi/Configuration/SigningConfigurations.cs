using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Hotsapp.WebApi.Configuration
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {

                /*
                             var pubKey = provider.ExportParameters(true);

                             string pubKeyString;
                             {
                                 //we need some buffer
                                 var sw = new System.IO.StringWriter();
                                 //we need a serializer
                                 var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                                 //serialize the key into the stream
                                 xs.Serialize(sw, pubKey);
                                 //get the string from the stream
                                 pubKeyString = sw.ToString();
                             }

                             Console.WriteLine(pubKeyString);*/
                var signKey = File.ReadAllText("Configuration/signkey.xml");
                RSAParameters pubKey;
                //converting it back
                {
                    //get a stream from the string
                    var sr = new System.IO.StringReader(signKey);
                    //we need a deserializer
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    //get the object back from the stream
                    pubKey = (RSAParameters)xs.Deserialize(sr);
                }

                Key = new RsaSecurityKey(pubKey);
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
