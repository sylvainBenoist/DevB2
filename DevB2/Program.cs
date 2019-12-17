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
            // Ferme a Coordonnees
            Coordonnees Cork = new Coordonnees(51.89,-8.50,"Cork");
            Coordonnees Brest = new Coordonnees(48.40,-4.48,"Brest");
            Coordonnees Dakar = new Coordonnees(14.76,-17.13,"Dakar");
            Coordonnees Plymouth = new Coordonnees(50.37,-4.14,"Plymouth");
            Coordonnees LaRochelle = new Coordonnees(46.16,-1.16,"La Rochelle");
            Coordonnees StJohns = new Coordonnees(47.56,-52.70,"Cork");
            Coordonnees NewYork = new Coordonnees(40.70,-74.00,"NewYork");
            Coordonnees Miami = new Coordonnees(25.76,-80.20,"Miami");
            Coordonnees LaHavane = new Coordonnees(23.17,-82.17,"La Havane");
            Coordonnees CapVert = new Coordonnees(14.92,-23.49,"CapVert");
            Coordonnees Acores = new Coordonnees(37.81,-25.50,"Acores");
            Coordonnees PortoRico = new Coordonnees(18.44,-66.14,"Porto Rico");
            Coordonnees PortPrince = new Coordonnees(18.62,-72.32,"Port au Prince");

            List<Coordonnees> tbCoord = new List<Coordonnees>();

            tbCoord.Add(Cork);
            tbCoord.Add(Brest);
            tbCoord.Add(Dakar);
            tbCoord.Add(Plymouth);
            tbCoord.Add(LaRochelle);
            tbCoord.Add(StJohns);
            tbCoord.Add(NewYork);
            tbCoord.Add(Miami);
            tbCoord.Add(LaHavane);
            tbCoord.Add(CapVert);
            tbCoord.Add(Acores);
            tbCoord.Add(PortoRico);
            tbCoord.Add(PortPrince);

            List<String> tbDistances = new List<String>();

            //Console.WriteLine(tbCoord.Count);

            List<String> RecuPHP = new List<string>();
            var recupPhpTest = "Brest,10,-25";
            var recupPhpTest2 = "Cork,125,-248";
            RecuPHP.Add(recupPhpTest);
            RecuPHP.Add(recupPhpTest2);

            string x = RecuPHP[0];

            string[] info = x.Split(',');

            double iLat = Convert.ToDouble(info[1]);
            double iLon = Convert.ToDouble(info[2]);

            Coordonnees port1 = new Coordonnees(iLat,iLon,info[0]);
           // Coordonnees port2 = new Coordonnees();

            Console.Write(info[0]);

            for (int i = 0; i<RecuPHP.Count; i++)
            {

            }

            /*
            for(int i =0; i<tbCoord.Count-1; i++)
            {
                var Port = tbCoord[i];
                var k = i;

                for (int j = 0; j < tbCoord.Count - 1; j++)
                {
                    if(i == j)
                    {
                        j++;
                    }

                    var Port2 = tbCoord[j];

                    double b = Port.FormuleHaversine(Port, Port2);
                    double f = Port.CalculDistanceAngRadian(b);
                    double dist = Port.CalculDistanceTotal(f);
                    dist = Math.Round(dist,2);

                    string distances = Convert.ToString(dist);
                    tbDistances.Add(Port.getName()+" "+Port2.getName() + " " + distances);
                    j++;
                }
                i++;

                Console.WriteLine(tbDistances[i]);
               
            }
            */
            
            Console.Read();
            

        }
    }
}
