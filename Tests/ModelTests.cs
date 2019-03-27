using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
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
            var catalog = Pointsource.Catalog.ToList();

            Assert.AreEqual(SOURCE_NAME, catalog[0]);
        }

        [TestMethod]
        public void SoureFromTheCatalogHasPoints()
        {
            var source = new Pointsource(SOURCE_NAME);
            var point = source.Datapoints.Skip(5).Take(1).First();

            Assert.IsTrue(point.Value > 0);
        }

        [TestMethod]
        public void ExpressionDecoratorShouldChangeValues()
        {
            var source = new Pointsource(SOURCE_NAME) as IPointsource;
            var point = source.Datapoints.Skip(5).Take(1).First();

            source = new Pointsource(SOURCE_NAME) as IPointsource;
            source = new ExpresisonDecorator(source, x =>
            {
                x.Value += 1;
                return x;
            });

            var secondPoint = source.Datapoints.Skip(5).Take(1).First();

            Assert.IsTrue(point.Value < secondPoint.Value);
        }
    }
}
