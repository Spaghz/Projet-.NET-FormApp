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

        /// <summary>
        /// Converts a int color into RGB.
        /// Example : WHITE color is "16777215" and will become : 255, 255, 255
        /// </summary>
        /// <param name="intValue">int containing the color value (must be 6 characters long)</param>
        /// <returns></returns>
        public static int[] intToRgb(int intValue)
        {
             //if (intValue.ToString().Length != 6)
               //  throw new ArgumentException("hexValue is not a color string value.");
            
            string hexValue = intValue.ToString("X6");
            int[] rgb = new int[3];
            rgb[0] = int.Parse(hexValue.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            rgb[1] = int.Parse(hexValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            rgb[2] = int.Parse(hexValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

             return rgb;
        }


        /// <summary>
        /// Converts a RGB to Hexa.
        /// </summary>
        public static String rgbToHex(byte R, byte G, byte B)
        {
            return (R.ToString("X2") + G.ToString("X2") + B.ToString("X2"));
        }
    }
}
