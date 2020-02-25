using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CoveoApiVbg.Helper
{
    public static class DoubleExtension
    {    
        public static double DoubleParse(this string value)
        {
         
           return double.Parse(value, CultureInfo.InvariantCulture);
        }

        public static double? ParseNullableDouble(this string value)
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
                    return value.DoubleParse();
                }
            }
            return double.MinValue;       
        }    
    }
}
