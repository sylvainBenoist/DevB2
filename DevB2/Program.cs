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

            decimal latt1 = 5153240m;
            decimal latt2 = 5022113m;
            decimal lon1 = -829528m;
            decimal lon2 = -408526m;

            Coordonnees p1 = new Coordonnees(latt1, lon1, "portTest1");
            Coordonnees p2 = new Coordonnees(latt2, lon2, "portTest2");

            decimal a = p1.FormuleHaversine(p1, p2);

            double c = p1.CalculDistanceAngRadian(a);

            var d = p1.CalculDistanceTotal(a);

            Console.Write(d);

            Console.Read();

        }
    }
}
