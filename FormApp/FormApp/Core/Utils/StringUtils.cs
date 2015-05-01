using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Utils
{
    public static class StringUtils
    {
        public static string implode(List<string> pieces,char glue)
        {
            string res="";

            foreach(string s in pieces)
            {
                res += s + glue;
            }

            return res.Substring(0, res.Length - 1);
        }

        /// <summary>
        /// Converts a string color into int.
        /// Example : WHITE color is "ffffff" and will become 16777215
        /// </summary>
        /// <param name="hexValue">string containing the hex value of the color (must be 6 characters long)</param>
        /// <returns></returns>
        public static int hexToInt(string hexValue)
        {
            if (hexValue.Length != 6)
                throw new ArgumentException("hexValue is not a color string value.");

            return int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
        }
    }
}
