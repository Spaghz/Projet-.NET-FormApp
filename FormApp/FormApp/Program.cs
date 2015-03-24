using FormApp.Core.Forms;
using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(0.6, 41);
            Point B = new Point(1, 1);
            Point C = new Point(5.6, -8);
            Triangle T1 = new Triangle(A,B,C);

            Console.WriteLine(T1.ToString());
            Console.ReadLine();
            Console.WriteLine("T'es trop chouchou");

        }
    }
}
