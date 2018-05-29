using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEsting
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void EncounterAdjecantTest()
        {
            char[] line = new[] { '-', '-', '-' };
            Program.EncounterAdjacent(line, 1);
            Assert.AreEqual(line.All('@'.Equals), true);
        }

        [TestMethod]
        public void ContainsEncountered()
        {
            char[] line = new[] { '-', '-', '@', '#', '@' };
            Assert.IsTrue(Program.SpanContainsEncountered(line, 0, 3));
            Assert.IsFalse(Program.SpanContainsEncountered(line, 0, 2));
            Assert.IsTrue(Program.SpanContainsEncountered(line, 3, 2));
            Assert.IsFalse(Program.SpanContainsEncountered(line, 3, 1));
        }

        [TestMethod]
        public void FindLineStart()
        {
            char[] line = new[] { '-', '-', '@', '#', '#', '-', '@' };
            Assert.AreEqual(0, Program.FindLineStart(line, 0, 6));
            Assert.AreEqual(0, Program.FindLineStart(line, 0, 7));
            Assert.AreEqual(5, Program.FindLineStart(line, 3, 3));
            Assert.AreEqual(5, Program.FindLineStart(line, 3, 5));
            Assert.AreEqual(3, Program.FindLineStart(line, 3, 2));
        }
    }
}
