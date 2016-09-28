using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Sorter;

namespace WordFrequencyCounter.UnitTest.Sorter
{
    [TestClass]
   public class CountSorterTests
    {
        [TestMethod]
        public void CountSorterCtorTest()
        {
            ISorter sorter = null;
            try
            {
                sorter = new CountSorter(null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("consoleService"));
            }
            sorter = new CountSorter(new Mock<IConsoleService>().Object);
            Assert.IsNotNull(sorter);
            Assert.IsInstanceOfType(sorter, typeof(ISorter));
            Assert.IsInstanceOfType(sorter, typeof(CountSorter));
        }

        [TestMethod]
        public void CountSorterSortTest()
        {
            var console = new Mock<IConsoleService>();
            var messages = new List<string>();
            console.Setup(s => s.WriteLine(It.IsAny<string>())).Callback<string>(s => messages.Add(s));
            var sorter = new CountSorter(console.Object);
            var dict = new Dictionary<string,int>
            {
                {"a", 3 },
                {"b", -5 },
                {"c", int.MaxValue },
                {"d", 0 },
                {"e", int.MinValue }
            };

            try
            {
                sorter.Sort(null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("collection"));
            }

            var sorted = sorter.Sort(dict).ToList();
            Assert.AreEqual(5, sorted.Count);
            Assert.AreEqual("c", sorted.ElementAt(0).Key);
            Assert.AreEqual("a", sorted.ElementAt(1).Key);
            Assert.AreEqual("d", sorted.ElementAt(2).Key);
            Assert.AreEqual("b", sorted.ElementAt(3).Key);
            Assert.AreEqual("e", sorted.ElementAt(4).Key);
            Assert.AreEqual(int.MaxValue, sorted.ElementAt(0).Value);
            Assert.AreEqual(3, sorted.ElementAt(1).Value);
            Assert.AreEqual(0, sorted.ElementAt(2).Value);
            Assert.AreEqual(-5, sorted.ElementAt(3).Value);
            Assert.AreEqual(int.MinValue, sorted.ElementAt(4).Value);
            Assert.AreEqual("Sorting by words frequency was applied", messages.First());
            Assert.IsTrue(messages.Count == 1);
            console.VerifyAll();
        }
    }
}
