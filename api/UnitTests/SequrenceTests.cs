using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class SequrenceTests
    {
        [TestMethod]
        public void ShouldGetSomeNoise()
        {
            var seq = new SimpleStackMachine.StackMachine(typeof(Sequences.SequenceCommands));
            seq.Eval("noise");
            var samples =((IEnumerable<double>)seq.Context.Peek()).Take(5).ToList();

            Assert.AreEqual(5, samples.Count);
        }

        [TestMethod]
        public void ShouldMapAnF()
        {
            var seq = new SimpleStackMachine.StackMachine(typeof(Sequences.SequenceCommands));
            seq.Eval("seq");
            seq.Eval("x^2");
            seq.Eval("map");
            seq.Eval("noise");
            seq.Eval("merge");
            var samples = ((IEnumerable<double>)seq.Context.Peek()).Take(5).ToList();

            Assert.AreEqual(5, samples.Count);
        }
    }
}
