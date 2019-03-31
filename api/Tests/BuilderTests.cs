using Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LibraryUnitTests
{
    [TestClass]
    public class BuilderUnitTests
    {
        const string SOURCE_NAME = "inlet_t_c";

        [TestMethod]
        public void BuildFromACatalogEntry()
        {
            var source = Configurator.Instance
                .With(SOURCE_NAME)
                .WithTimestamp()
                .Build();

            var point = source.Skip(5).Take(1).First();

            Assert.IsTrue(point.Value > 0);
        }
    }
}
