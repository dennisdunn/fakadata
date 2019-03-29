using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Models.Impl;
using System.Collections.Generic;
using System.Linq;

namespace LibraryUnitTests
{
    [TestClass]
    public class ModelTests
    {
        const string SOURCE_NAME = "inlet_t_c";

        [TestMethod]
        public void CatalogHasEntries()
        {
            Assert.IsTrue(Catalog.Current.Keys.Count() > 0);
        }

        [TestMethod]
        public void SoureFromTheCatalogHasPoints()
        {
            var source = Catalog.Current[SOURCE_NAME];
            var point = source.Skip(5).Take(1).First();

            Assert.IsTrue(point.Value > 0);
        }

        [TestMethod]
        public void ExpressionDecoratorShouldChangeValues()
        {
            var a = Catalog.Current[SOURCE_NAME];
            var point = a.Skip(5).Take(1).First();

            var b = Catalog.Current[SOURCE_NAME];
            var c = new ExpressionDecorator(b, x => 2 * x);

            var secondPoint = c.Skip(5).Take(1).First();

            Assert.AreEqual(2 * point.Value, secondPoint.Value, 1e-6);
        }

        [TestMethod]
        public void IsTheCollectionPerpetual()
        {
            var data = new List<int> { 0, 1, 2, 3, 4 };

            var iterator = new PerpetualAdapter<int>(data.GetEnumerator());

            for(var i = 0; i < 10; i++)
            {
                iterator.MoveNext();
            }

            Assert.AreEqual(4, iterator.Current);
        }
    }
}
