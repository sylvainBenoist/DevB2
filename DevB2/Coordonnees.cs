using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevB2
{
    public class Coordonnees
    {
        public decimal lattitude;
        public decimal longitude;
        public string nom;

        public const double radiusEarth = 6371;



        public Coordonnees(decimal lat, decimal longi, string titre)
        {
            this.lattitude = lat;
            this.longitude = longi;
            this.nom = titre;
        }

        public decimal TranslateLatToRadius(decimal lat)
        {
            double lat1 = Convert.ToDouble(lat);
            var a = (lat1 * Math.PI)  / 180;
            decimal a2 = Convert.ToDecimal(a);
            return a2;
        }

        public decimal CalculToRadius(decimal lat1, decimal lat2)
        {
            decimal r = lat1 - lat2;
            TranslateLatToRadius(r);
            return r;
        }

        public decimal FormuleHaversine(Coordonnees p1, Coordonnees p2)
        {
            // Recup des coordonnees
            var lat1 = p1.lattitude;
            var lat2 = p2.lattitude;

            var lon1 = p1.longitude;
            var lon2 = p2.longitude;

            // Calcul
            var retourCalculRadiusLat = p1.CalculToRadius(lat1, lat2);
            var retourDoubleLat = Convert.ToDouble(retourCalculRadiusLat);
            
            var retourCalculRadiusLon = p2.CalculToRadius(lon1, lon2);
            var retourDoubleLong = Convert.ToDouble(retourCalculRadiusLon);

            var lat1Radius = TranslateLatToRadius(lat1);
            var lat1RDouble = Convert.ToDouble(lat1Radius);

            var lat2Radius = TranslateLatToRadius(lat2);
            var lat2RDouble = Convert.ToDouble(lat2Radius);

            /*
            var a = Math.Sin(retourDoubleLat / 2) * Math.Sin(retourDoubleLat / 2) + Math.Cos(lat1RDouble) *
                Math.Cos(lat2RDouble) * Math.Sin(retourDoubleLong / 2) * Math.Sin(retourDoubleLong / 2);
            */
            
            var a = Math.Sin(retourDoubleLat / 2) * Math.Sin(retourDoubleLat / 2) + Math.Sin(retourDoubleLong / 2) * Math.Cos(lat1RDouble) * Math.Cos(lat2RDouble);

            decimal a2 = Convert.ToDecimal(a);
            return a2;
        }

        public double CalculDistanceAngRadian(decimal a)
        {
            double c;
            double a2 = Convert.ToDouble(a);
            double a3 = Math.Round(a2,2);
            c = 2 * Math.Atan2(Math.Sqrt(a3), Math.Sqrt(1 - a3));
            decimal c2 = Convert.ToDecimal(c);
            return c;
        }

        public decimal CalculDistanceTotal(decimal c)
        {
            double c2 = Convert.ToDouble(c);
            var c3 =  radiusEarth * c2;
            var c4 = Convert.ToDecimal(c3);
            return c4;
        }
    }
}
