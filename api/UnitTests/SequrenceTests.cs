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
            b.Noise();
            var seq = b.Build().Take(5).ToList();

            Assert.AreEqual(5, seq.Count);
        }

        [TestMethod]
        public void ShouldMapAnF()
        {
            var b = new Sequences.Builder();
            b.Cardinals();
            b.Map("x^2");
            b.Noise();
            b.Merge();
            var seq = b.Build().Take(5).ToList();

            Assert.AreEqual(5, seq.Count);
        }
    }
}
