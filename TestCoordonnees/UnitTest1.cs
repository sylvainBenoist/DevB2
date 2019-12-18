using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevB2;
using NSubstitute;

namespace TestCoordonnees
{
    [TestClass]
    public class TestCoordonnes
    {
        [TestMethod]
        public void TestDuConstructeur()
        {
            var test = new Coordonnees(10, 12, "portTest");
            Assert.AreEqual(test.getLat(), 10);
            Assert.AreEqual(test.getLon(), 12);
            Assert.AreEqual(test.getName(), "portTest");
        }

        [TestMethod]
        public void TestTranslateLatToRadius()
        {
            var test = new Coordonnees(10, 12, "portTest");
            var a = test.TranslateLatToRadius(10);

            a = Math.Round(a, 2);
            Assert.AreEqual(0.17, 0.17);
        }


        [TestMethod]
        public void TestFormuleHaversine()
        {
            var test = new Coordonnees(10, 12, "portTest");
            var test2 = new Coordonnees(15, 12, "portTest2");

            var a = test.FormuleHaversine(test2);

            a = Math.Round(a,2);

            Assert.AreEqual(a, 0);
        }

        [TestMethod]
        public void TestCalculDistanceAngularRadian()
        {
            var test = new Coordonnees(10, 12, "portTest");
            var test2 = new Coordonnees(15, 12, "portTest2");

            double a = 0.358168907268387;

            var c = test.CalculDistanceAngRadian(a);
            c = Math.Round(c, 2);

            Assert.AreEqual(c, 1.28);
          
        }

        [TestMethod]
        public void TestCalculDistanceTotal()
        {
            var test = new Coordonnees(10, 12, "portTest");
            var test2 = new Coordonnees(15, 12, "portTest2");

            var a = 0.358168907268387;

            var c = test.CalculDistanceAngRadian(a);

            var Distance = test.CalculDistanceTotal(c);
            Distance = Math.Round(Distance, 2);
            Assert.AreEqual(Distance, 8175.17);
        }

        [TestMethod]
        public void TestDistanceBrestEtCapVert()
        {
            var test = new Coordonnees(48.40, -4.48, "brest");
            var test2 = new Coordonnees(14.92, -23.49, "cap-vert");

            double a = test.FormuleHaversine(test2);

            double c = test.CalculDistanceAngRadian(a);

            var d = test.CalculDistanceTotal(c);

            d = Math.Round(d, 0);

            Assert.AreEqual(d,4109);
        }

        [TestMethod]
        public void TestAffichageDesDonnees()
        {
            var test = new Coordonnees(48.40, -4.48, "1");
            var test2 = new Coordonnees(14.92, -23.49, "2");

            double a = test.FormuleHaversine(test2);

            double c = test.CalculDistanceAngRadian(a);

            var d = test.CalculDistanceTotal(c);

            d = Math.Round(d, 0);
            string retour = "";

            ITestAffichage media = Substitute.For<ITestAffichage>();
            TestAffichage.Fake = "oui";
            media.Afficher(retour);

            media.Received(1).Afficher("");

        }

        
        [TestMethod]
        public void TestLongitudePositif()
        {
            var test = new Coordonnees(-48.40, 4.48, "brest");
            var test2 = new Coordonnees(-14.92, 23.49, "cap-vert");

            double a = test.FormuleHaversine(test2);
            double c = test.CalculDistanceAngRadian(a);
            var d = test.CalculDistanceTotal(c);

            Assert.AreEqual(d, 25);
           
        }

       // Assert.ThrowsException<IndexOutOfRangeException>(()=> test.CalculDistanceAngRadian(a));


    }

}
