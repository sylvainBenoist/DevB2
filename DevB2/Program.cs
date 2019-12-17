using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;

namespace DevB2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double latt1 = 51.8900000;
            double lon1 = -8.4980000;

            double latt2 = 50.3698056;
            double lon2 = -4.1479444;

            //string[][] tbDistance = new string [][]; 
            string[,] tbDistance;
            Coordonnees p1 = new Coordonnees(latt1, lon1, "portTest1");
            Coordonnees p2 = new Coordonnees(latt2, lon2, "portTest2");

            double a = p1.FormuleHaversine(p1, p2);

            double c = p1.CalculDistanceAngRadian(a);

            var d = p1.CalculDistanceTotal(c);

            Console.Write(d);
            var distance = d.ToString();
            //tbDistance[0,0] = p1.nom,  distance;

            Console.Read();
            
            /*
            var test = new Coordonnees(1, 1, "yo");
            test.testFlo();
            */
            Console.Read();
            

        }
    }
}
