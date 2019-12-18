using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevB2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ferme a Coordonnees
            Coordonnees Cork = new Coordonnees(51.89, -8.50, "Cork");
            Coordonnees Brest = new Coordonnees(48.40, -4.48, "Brest");
            Coordonnees Dakar = new Coordonnees(14.76, -17.13, "Dakar");
            Coordonnees Plymouth = new Coordonnees(50.37, -4.14, "Plymouth");
            Coordonnees LaRochelle = new Coordonnees(46.16, -1.16, "La Rochelle");
            Coordonnees StJohns = new Coordonnees(47.56, -52.70, "Cork");
            Coordonnees NewYork = new Coordonnees(40.70, -74.00, "NewYork");
            Coordonnees Miami = new Coordonnees(25.76, -80.20, "Miami");
            Coordonnees LaHavane = new Coordonnees(23.17, -82.17, "La Havane");
            Coordonnees CapVert = new Coordonnees(14.92, -23.49, "CapVert");
            Coordonnees Acores = new Coordonnees(37.81, -25.50, "Acores");
            Coordonnees PortoRico = new Coordonnees(18.44, -66.14, "Porto Rico");
            Coordonnees PortPrince = new Coordonnees(18.62, -72.32, "Port au Prince");

            List<Coordonnees> tbCoord = new List<Coordonnees>();
            /*
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
            */
            List<String> tbDistances = new List<String>();

            //Console.WriteLine(tbCoord.Count);

            List<String> RecuPHP = new List<string>();
            /*
            var recupPhpTest = "Brest,10.5,-25";
            var recupPhpTest2 = "Cork,125,-248";
            var recupPhpTest3 = "Miami,25,-80";
            var recupPhpTest4 = "Miami,25,-80";
            var recupPhpTest5 = "Miami,25,-80";
            var recupPhpTest6 = "Miami,25,-80";
            var recupPhpTest7 = "Miami,25,-80";
            var recupPhpTest8 = "Miami,25,-80";
            var recupPhpTest9 = "Miami,25,-80";
            var recupPhpTest10 = "Miami,25,-80";
            var recupPhpTest11 = "Miami,25,-80";
            */
            // Test de la reception string arg 

            string argString = "Miami,10.5,-25/NewYork,125,-248/Cork,56,-20";
            /*
            if(args != null)
            {
                string argPhp = args[0];
            }
            */
            //List<String> parseStringArg = new List<string>();

            string[] parseStringArg = argString.Split('/');

            for (int i = 0; i < parseStringArg.Length; i++)
            {
                RecuPHP.Add(parseStringArg[i]);
            }

            // RecuPHP.Add(recupPhpTest);

            // RecuPHP.Add(recupPhpTest2);
            /*
            RecuPHP.Add(recupPhpTest3);
            RecuPHP.Add(recupPhpTest4);
            RecuPHP.Add(recupPhpTest5);
            RecuPHP.Add(recupPhpTest6);
            RecuPHP.Add(recupPhpTest7);
            RecuPHP.Add(recupPhpTest8);
            RecuPHP.Add(recupPhpTest9);
            RecuPHP.Add(recupPhpTest10);
            RecuPHP.Add(recupPhpTest11);
            */




            // Coordonnees port2 = new Coordonnees();

            List<String> info2 = new List<string>();

            for (int i = 0; i < RecuPHP.Count; i++)
            {
                string donnees = RecuPHP[i];

                string[] info = donnees.Split(',');

                // Permet de split le string en decimal (car on utilise des "." pour separateur et que double.parse est "," par def en FR )
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-EN");

                double iLat = Double.Parse(info[1]);

                double iLon = Convert.ToDouble(info[2]);

                Coordonnees port1 = new Coordonnees(iLat, iLon, info[0]);
                tbCoord.Add(port1);
            }

            string retourPhp = "";

            for (int i = 0; i < tbCoord.Count;)
            {
                var i_coordonnees = tbCoord[i];

                for (int j = 0; j < tbCoord.Count;)
                {

                    if (j == i)
                    {
                        j++;
                    }
                    if (j == tbCoord.Count)
                    {
                        break;
                    }

                    var j_coordonnes = tbCoord[j];
                    double b = j_coordonnes.FormuleHaversine(i_coordonnees, j_coordonnes);
                    double f = j_coordonnes.CalculDistanceAngRadian(b);
                    double dist = j_coordonnes.CalculDistanceTotal(f);
                    dist = Math.Round(dist, 2);

                    string distances = Convert.ToString(dist);
                    retourPhp += i_coordonnees.getName() + "-" + j_coordonnes.getName() + "," + distances + ";";
                    j++;
                }
                i++;
            }

            /*
            for (int i = 0; i < tbDistances.Count; i++)
            {
                var t_est = tbDistances[i];
                Console.WriteLine(t_est);
            }
            */

            Console.Write(retourPhp);

            Console.Write(tbDistances.Count);
            /*
            var testt1 = tbCoord[0];
            var testt2 = tbCoord[1];
            var testt3 = tbCoord[2];

            Console.Write(testt1.getName() + testt2.getName() + testt3.getName());
            */

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
