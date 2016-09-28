using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Sorter;

namespace WordFrequencyCounter.UnitTest.Sorter
{
    [TestClass]
    public class NonSorterSort
    {
        [TestMethod]
        public void NameSorterCtorTest()
        {
            ISorter sorter = new NonSorter();

            try
            {
                sorter.Sort(null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("collection"));
            }
            var dict = new Dictionary<string, int>
            {
                {"z", 3 },
                {"a", -5 },
                {"^", 0 }
            };
            var sorted = sorter.Sort(dict).ToList();
            Assert.AreEqual(3, sorted.Count);
            Assert.AreEqual("z", sorted.ElementAt(0).Key);
            Assert.AreEqual("a", sorted.ElementAt(1).Key);
            Assert.AreEqual("^", sorted.ElementAt(2).Key);
            Assert.AreEqual(3, sorted.ElementAt(0).Value);
            Assert.AreEqual(-5, sorted.ElementAt(1).Value);
            Assert.AreEqual(0, sorted.ElementAt(2).Value);
        }
    }
}