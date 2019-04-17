using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class SequrenceTests
    {
        [TestMethod]
        public void ShouldGetSomeNoise()
        {
            var b = new Sequences.Builder();
            b.Nosie();
            var seq = b.Build().Take(5).ToList();

            Assert.AreEqual(5, seq.Count);
        }

        [TestMethod]
        public void ShouldMapAnF()
        {
            var b = new Sequences.Builder();
            b.Cardinals();
            b.Map("x^2");
            var seq = b.Build().Take(5).ToList();

            Assert.AreEqual(5, seq.Count);
        }
    }
}
