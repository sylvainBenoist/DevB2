using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevB2
{
    public class Coordonnees
    {
        public double lattitude;
        public double longitude;
        public string nom;

        public const double radiusEarth = 6371;



        public Coordonnees(double lat, double longi, string titre)
        {
            this.lattitude = lat;
            this.longitude = longi;
            this.nom = titre;
        }

        public double TranslateLatToRadius(double lat)
        {
            double lat1 = Convert.ToDouble(lat);

            var a = (lat1 * Math.PI) / 180;

            return a;
        }
        /*
        public double CalculToRadius(double lat1, double lat2)
        {
            decimal r = lat2 - lat1;
            TranslateLatToRadius(r);
            return r;
        }
        */
        public double FormuleHaversine(Coordonnees p1, Coordonnees p2)
        {
            // Recup des coordonnees
            var lat1 = p1.lattitude;
            var lat2 = p2.lattitude;

            var lon1 = p1.longitude;
            var lon2 = p2.longitude;

            // Calcul
          //  var retourCalculRadiusLat = p1.CalculToRadius(lat1, lat2);
          //  var retourDoubleLat = Convert.ToDouble(retourCalculRadiusLat);

          //  var retourCalculRadiusLon = p2.CalculToRadius(lon1, lon2);
          //  var retourDoubleLong = Convert.ToDouble(retourCalculRadiusLon);
          
            var lat1Radius = TranslateLatToRadius(lat1);
            var lat1RDouble = Convert.ToDouble(lat1Radius);

            var lat2Radius = TranslateLatToRadius(lat2);
            var lat2RDouble = Convert.ToDouble(lat2Radius);

            double lon1Radius = TranslateLatToRadius(lon1);
            double lon1Rdouble = Convert.ToDouble(lon1Radius);

            double lon2Radius = TranslateLatToRadius(lon2);
            double lon2Rdouble = Convert.ToDouble(lon2Radius);

            double deltaX = lat2RDouble - lat1RDouble;
            double deltaY = lon2Rdouble - lon1Rdouble;

            double x1 = TranslateLatToRadius(lat1);
            double x2 = TranslateLatToRadius(lat2);
            double y1 = TranslateLatToRadius(lon1);
            double y2 = TranslateLatToRadius(lon2);

            //var a = Math.Sin(deltaX / 2) * Math.Sin(deltaX / 2) + Math.Cos(lat1RDouble) * Math.Cos(lat2RDouble) * Math.Sin(deltaY / 2) * Math.Sin(deltaY / 2);
            double a = Math.Sin(deltaX / 2) * Math.Sin(deltaX / 2) + Math.Cos(x1) * Math.Cos(x2) * Math.Sin(deltaY / 2) * Math.Sin(deltaY / 2);

            /*
            var a = Math.Sin(retourDoubleLat / 2) * Math.Sin(retourDoubleLat / 2) + Math.Sin(retourDoubleLong / 2) * Math.Cos(lat1RDouble) * Math.Cos(lat2RDouble);
            */
            decimal a2 = Convert.ToDecimal(a);

            return a;
        }

        public double CalculDistanceAngRadian(double a)
        {
            double c;
            double a2 = Convert.ToDouble(a);
            double a3 = Math.Round(a2, 2);
            c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            decimal c2 = Convert.ToDecimal(c);
            return c;
        }

        public double CalculDistanceTotal(double c)
        {
            double c2 = Convert.ToDouble(c);
            // var d2 = radiusEarth * c2;
            double r = 6371;
            double distance = r * c;

            return distance;
        }

    }
}
