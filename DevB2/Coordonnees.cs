﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevB2
{
    public class Coordonnees
    {
        private double lattitude; 
        private double longitude;
        private string nom;

        // Definit en Kilometres (pour les mètre rajouter e3)
        public const double _RADIUSEARTH_ = 6371;

        public Coordonnees(double lat, double longi, string titre)
        {
            this.lattitude = lat;
            this.longitude = longi;
            this.nom = titre;
        }

        // Permet de convertir un degree en Radian
        public double TranslateLatToRadius(double lat)
        {
            return (lat * Math.PI) / 180;
        }

        public double getLat()
        {
            return this.lattitude;
        }
        
        public double getLon()
        {
            return this.longitude;
        }

        public string getName()
        {
            return this.nom;
        }

        public double FormuleHaversine(Coordonnees p2)
        {
            // Recup des coordonnees
            var lat1 = this.lattitude;
            var lat2 = p2.lattitude;

            var lon1 = this.longitude;
            var lon2 = p2.longitude;

            double x1 = TranslateLatToRadius(lat1);
            double x2 = TranslateLatToRadius(lat2);
            double y1 = TranslateLatToRadius(lon1);
            double y2 = TranslateLatToRadius(lon2);

            double deltaX = x2 - x1;
            double deltaY = y2 - y1;
            
            // Calcul Haversine

            double retour = Math.Sin(deltaX / 2) * Math.Sin(deltaX / 2) + Math.Cos(x1) * Math.Cos(x2) * Math.Sin(deltaY / 2) * Math.Sin(deltaY / 2);

            return retour;
        }

        public double CalculDistanceAngRadian(double a)
        {
            return 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        }

        public double CalculDistanceTotal(double c)
        {
            return _RADIUSEARTH_ * c;
        }

    }
}
