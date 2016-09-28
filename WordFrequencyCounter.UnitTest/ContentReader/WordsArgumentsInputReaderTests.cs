using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordFrequencyCounter.ContentReader;
using WordFrequencyCounter.Interface;

namespace WordFrequencyCounter.UnitTest.ContentReader
{
    [TestClass]
    public class WordsArgumentsInputReaderTests
    {
        [TestMethod]
        public void WordsArgumentsInputReaderCtorTest()
        {
            IContentReader reader = null;
            try
            {
                reader = new WordsArgumentsInputReader(null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("arg"));
            }
            reader = new WordsArgumentsInputReader(string.Empty);
            Assert.IsNotNull(reader);
            Assert.IsInstanceOfType(reader, typeof (IContentReader));
            Assert.IsInstanceOfType(reader, typeof (WordsArgumentsInputReader));
        }


        [TestMethod]
        public void WordsArgumentsInputReaderReadTest()
        {
            IContentReader reader = new WordsArgumentsInputReader("-w:\"Hello everybody\"");
            var words = reader.Read();
            Assert.AreEqual("\"Hello everybody\"", words);
        }
    }
}