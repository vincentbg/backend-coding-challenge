using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Helper
{
    public static class FloatExtension
    {    
        public static float ParseFloat(this string value)
        {
         
           return float.Parse(value, CultureInfo.InvariantCulture);
        }

        public static float? ParseNullableFloat(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            string temp = value;
           
            if (temp.Contains("."))
            {
                temp = temp.Replace(".", "");
                if (temp.Contains("-"))
                {
                    temp = temp.Replace("-", "");

                }

                if (temp.All(char.IsDigit))
                {
                    return value.ParseFloat();
                }
            }
            return float.MinValue;       
        }    
    }
}
