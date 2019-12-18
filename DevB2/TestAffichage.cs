using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevB2
{

    public class TestAffichage
    {
        private static string fakeAff = null;
        public static string Fake { set { fakeAff = value; } }

        public static void Afficher(string retour)
        {
            if(fakeAff != null)
            {
                Console.Write("OK");
            }
            else
            {
                Console.Write(retour);
            }
        }
    }
}
