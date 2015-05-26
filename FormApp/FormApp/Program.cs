using FormApp.Core.Shapes;
using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using FormApp.Core.DAO;
using FormApp.Core.Shapes.COR;

namespace FormApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
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

            Segment S1 = new Segment("S1", A, B);
            Segment S2 = new Segment("S2", A, B);

            Circle C1 = new Circle("C1", A, 2.0);
            Group G1 = new Group("G1");
            G1.AddForm(C1);
            Group G2 = new Group("G2");
            G2.AddForm(G1);
            G2.AddForm(T1);

            string jSon = "{" + S1.ToJson() + "}";
            */

            /*
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
            */


            /*
             * JONATHAN : UPLOAD PHP
             * 
             */
            /*
            Point A = new Point(0.6, 41);
            Point B = new Point(1, 1);
            Point C = new Point(5.6, -8);
            Point D = new Point(3, 6);
            Triangle T1 = new Triangle("T1", A, B, C);
            Triangle T2 = new Triangle("T2", B, A, C);
            Rectangle R1 = new Rectangle("R1", A, D);
            Polygon P1 = new Polygon("P1");
            P1.AddPoint(A);
            P1.AddPoint(B);
            P1.AddPoint(C);
            P1.AddPoint(D);
            P1.AddPoint(new Point(45, 21));
            string jSon = "{" + R1.ToJson() + "}";
            DAOFormMySQL.Instance.Save(R1);
            Shape s = (DAOFormMySQL.Instance.Load(2));
            */




            /*
             * 
             * LOREDANE : GUI
             * 
             */
           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Form1());




            /*
           * DANI : AIRE
           * 
           

            Point A = new Point(0, 0);
            Point B = new Point(5, 0);
            Point C = new Point(5, 5);
            Point D = new Point(0, 5);
            Point E = new Point(3, 8);
         
            Polygon P1 = new Polygon("P1");
            P1.AddPoint(A);
            P1.AddPoint(B);
            P1.AddPoint(C);
            P1.AddPoint(D);
            //P1.AddPoint(new Point(3, 8));
        */


          /*  Triangle T1 = new Triangle("T1");
            T1.AddPoint(C);
            T1.AddPoint(D);
            T1.AddPoint(E);
            */

            /*
            Rectangle R1 = new Rectangle("R1");
            R1.AddPoint(A);
            R1.AddPoint(B);
            R1.AddPoint(C);
            R1.AddPoint(D);


            Circle C1 = new Circle("C1", new Point(2.0, 2.0), 1);
            System.Console.WriteLine(C1);

            Circle C2 = new Circle("C2", new Point(2.0,2.0),1);
            
            System.Console.WriteLine(C1.Translation(new Vector(1, 1)));
            System.Console.WriteLine(C1.Homothetie(2.0));
            System.Console.WriteLine(C2.Homothetie(new Point(1.0, 1.0), 2.0));


            System.Console.WriteLine(new Triangle("T1", new Point(-2.0, 0.0), new Point(0.0, 2.0), new Point(1.0, 0.0)).Homothetie(2.0));


            System.Console.WriteLine(R1.Area);
            System.Console.ReadLine();
             * */
        }
    }
}
