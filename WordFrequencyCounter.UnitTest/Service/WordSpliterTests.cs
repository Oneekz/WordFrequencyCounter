using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Service;

namespace WordFrequencyCounter.UnitTest.Service
{
    [TestClass]
    public class WordSpliterTests
    {
        [TestMethod]
        public void WordSpliterSplitWordsTest()
        {
            IWordSpliter spliter = new WordSpliter();
            try
            {
                spliter.SplitWords(null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("input"));
            }

            var ans = spliter.SplitWords(string.Empty);
            Assert.AreEqual(0, ans.Count);

            ans = spliter.SplitWords(" \t");
            Assert.AreEqual(0, ans.Count);

            ans = spliter.SplitWords("Cześć?");
            Assert.AreEqual(1, ans.Count);
            Assert.AreEqual("cześć?", ans.First());

            ans = spliter.SplitWords("This is a statement, and so is this.");
            Assert.AreEqual(8, ans.Count);
            Assert.AreEqual("this", ans[0]);
            Assert.AreEqual("is", ans[1]);
            Assert.AreEqual("a", ans[2]);
            Assert.AreEqual("statement,", ans[3]);
            Assert.AreEqual("and", ans[4]);
            Assert.AreEqual("so", ans[5]);
            Assert.AreEqual("is", ans[6]);
            Assert.AreEqual("this.", ans[7]);
        }
    }
}