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
            // Déclaration variables
            List<Coordonnees> tbCoord = new List<Coordonnees>();
            List<String> tbDistances = new List<String>();
            List<String> RecuPHP = new List<string>();
            List<String> info2 = new List<string>();

            string retourPhp = "";


            // TEST de ARGS
            /*
            string fake1 = "Miami,5.5,-9";
            string fake2 = "Porto,8,-15";
            string fake3 = "Bordeaux,5,-95";
            string fake4 = "London,10,15";
            List<String> fakeArgs = new List<string>();

            fakeArgs.Add(fake1);
            fakeArgs.Add(fake2);
            fakeArgs.Add(fake3);
            fakeArgs.Add(fake4);

            string[] fakeArrayArgs = fakeArgs.ToArray();
            */

            // Fin declaration test

            string[] recupArgs;

            if (args.Length != 0)
            {
                string recu = args[0];
                recupArgs = recu.Split('/');
                for (int i = 0; i < recupArgs.Length; i++)
                {
                    RecuPHP.Add(recupArgs[i]);
                }

            }
            // Création des obj coordonnees
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

            // Calcul et incrementation de la string de retour
            for (int i = 0; i < tbCoord.Count; i++)
            {
                var i_coordonnees = tbCoord[i];

                for (int j = i + 1; j < tbCoord.Count; j++)
                {
                    var j_coordonnes = tbCoord[j];
                    double b = j_coordonnes.FormuleHaversine(i_coordonnees);
                    double f = j_coordonnes.CalculDistanceAngRadian(b);
                    double dist = j_coordonnes.CalculDistanceTotal(f);
                    dist = Math.Round(dist, 2);

                    string distances = Convert.ToString(dist);
                    retourPhp += i_coordonnees.getName() + "-" + j_coordonnes.getName() + "," + distances + ";";
                }
            }

            TestAffichage.Afficher(retourPhp);
        }
    }
}
