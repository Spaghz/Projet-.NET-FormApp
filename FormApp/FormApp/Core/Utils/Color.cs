using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Utils
{
    public class Color
    {
        public static readonly int WHITE = StringUtils.hexToInt("ffffff");
        public static readonly int BLACK = StringUtils.hexToInt("000000");

        private int _colorCode;

        public Color(int colorCode)
        {
            _colorCode = colorCode;
        }

        public Color(byte R, byte G , byte B)
        {
            _colorCode = StringUtils.hexToInt(StringUtils.rgbToHex(R, G, B)); 
        }

        public Color()
        {
            // TODO: Complete member initialization
        }

        public int ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }

        public override string ToString()
        {
            return _colorCode.ToString();
        }

        public int[] intToRgb()
        {
            return StringUtils.intToRgb(_colorCode);
        }

    }
}
