using FormApp.Core.Forms;
using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using FormApp.UI;

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
            Triangle T2 = new Triangle(B, A, C);
            Triangle T3 = new Triangle(C, A, B);
            Triangle T4 = new Triangle(C, B, A);

            List<string> test = new List<string>();
            test.Add("Loredane");
            test.Add("Daniel");
            test.Add("Tocman");
            Console.WriteLine(StringUtils.implode(test, ','));


            string DanielGrosPd = T1.ToJson();
            Group G = new Group();
            G.AddForm(T1);
           // G.AddForm(T2);
            Group G2 = new Group();
            string ContinuezABoufferDuChocolatCommeDesPorcs = G.ToJson();
            
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Triangle));
            ser.WriteObject(stream1, T1);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            Console.Write("JSON form of Person object: ");
            Console.WriteLine(sr.ReadToEnd());


            Console.WriteLine(T1.ToString());
            Console.ReadLine();
            Console.WriteLine("T'es trop chouchou");
            
            FormAppGUI formAppGUI = new FormAppGUI();
            formAppGUI.Show();
        }
    }
}
