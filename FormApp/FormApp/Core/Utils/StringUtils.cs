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
    }
}
