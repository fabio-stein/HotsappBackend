using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.ServiceManager.Util
{
    public class NumberInfo {
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string Number { get; set; }
        public bool IsNineDigits { get; set; }

        public string GetFullNumber()
        {
            return CountryCode + AreaCode + Number;
        }

        public static NumberInfo ParseNumber(string number)
        {
            if (number.Length < 12 || number.Length > 13)
                return null;
            var data = new NumberInfo();
            data.IsNineDigits = number.Length == 13;
            data.CountryCode = number.Substring(0, 2);
            data.AreaCode = number.Substring(2, 2);
            data.Number = number.Substring(2, data.IsNineDigits ? 9 : 8);
            return data;
        }

        public NumberInfo GetAlternativeNumber()
        {
            return GetAlternativeNumber(this);
        }

        public static NumberInfo GetAlternativeNumber(NumberInfo number)
        {
            if (number.IsNineDigits)
                number.Number = number.Number.Substring(1, 8);
            else
                number.Number = "9" + number.Number;
            return number;
        }
    }
}
