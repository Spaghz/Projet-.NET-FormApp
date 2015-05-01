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

namespace FormApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(0.6, 41);
            Point B = new Point(1, 1);
            Point C = new Point(5.6, -8);
            Triangle T1 = new Triangle("T1",A,B,C);
            Triangle T2 = new Triangle("T2",B, A, C);
            Triangle T3 = new Triangle("T3",C, A, B);
            Triangle T4 = new Triangle("T4",C, B, A);

            Point rectA = new Point(0,0);
            Point rectB = new Point(0,1);
            Point rectC = new Point(1,0);
            Point rectD = new Point(1,1);

            Rectangle R1 = new Rectangle("R1", rectA, rectB, rectC, rectD);

            Segment S1 = new Segment("S1", A, B);
            Segment S2 = new Segment("S2", A, B);

            Circle C1 = new Circle("C1", A, 2.0);

            List<string> test = new List<string>();
            test.Add("Loredane");
            test.Add("Daniel");
            test.Add("Tocman");
            Console.WriteLine(StringUtils.implode(test, ','));
            Console.WriteLine(T1.Name);


            string DanielGrosPd = T1.ToJson();
            Group G = new Group("g1");
            G.AddForm(T1);
            G.AddForm(T2);
            G.AddForm(R1);
            G.AddForm(S1);
            G.AddForm(C1);
            Group G2 = new Group("g2");
            G2.AddForm(S2);
            G.AddForm(G2);
            string ContinuezABoufferDuChocolatCommeDesPorcs = "{" + G.ToJson() + "}";

           // MemoryStream stream1 = new MemoryStream();
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Form));
            //ser.WriteObject(stream1, T1);

            Console.WriteLine(T1.ToString());
            Console.ReadLine();
            Console.WriteLine("T'es trop chouchou");

        }
    }
}
