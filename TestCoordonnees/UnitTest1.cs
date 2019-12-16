using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevB2;

namespace TestCoordonnees
{
    [TestClass]
    public class TestCoordonnes
    {
        [TestMethod]
        public void TestDuConstructeur()
        {
            var test = new Coordonnees(10, 12, "portTest");
            Assert.AreEqual(test.lattitude, 10);
            Assert.AreEqual(test.longitude, 12);
            Assert.AreEqual(test.nom, "portTest");
        }

        [TestMethod]
        public void TestTranslateLatToRadius()
        {
            var test = new Coordonnees(10, 12, "portTest");
            Assert.AreEqual(test.TranslateLatToRadius(10), 0.174532925199433);
        }

        [TestMethod]
        public void TestCalculToRadius()
        {
            var test = new Coordonnees(10, 12, "portTest");
            var test2 = new Coordonnees(15, 12, "portTest2");
            Assert.AreEqual(test.CalculToRadius(test.lattitude, test2.lattitude), -5);
        }

        [TestMethod]
        public void TestFormuleHaversine()
        {
            var test = new Coordonnees(10, 12, "portTest");
            var test2 = new Coordonnees(15, 12, "portTest2");


            Assert.AreEqual(test.FormuleHaversine(test,test2), 0.358168907268387);
        }

        [TestMethod]
        public void TestCalculDistanceAngularRadian()
        {
            var test = new Coordonnees(10, 12, "portTest");
            var test2 = new Coordonnees(15, 12, "portTest2");

            decimal a = 0.358168907268387m;

            var c = test.CalculDistanceAngRadian(a);

            Assert.AreEqual(c, 1.28318530717959);
          
        }

        [TestMethod]
        public void TestCalculDistanceTotal()
        {
            var test = new Coordonnees(10, 12, "portTest");
            var test2 = new Coordonnees(15, 12, "portTest2");
            double rEarth = 6371e3;
            var a = 0.358168907268387m;

            var c = test.CalculDistanceAngRadian(a);

            var Distance = test.CalculDistanceTotal(c);

            Assert.AreEqual(Distance, 8175173.59204115);
        }

    }

}
