using System;
using System.Collections.Generic;
using System.Linq;
using DryIoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WordFrequencyCounter.Factory;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Service;

namespace WordFrequencyCounter.UnitTest.Service
{
    [TestClass]
    public class WordCounterTests
    {
        [TestMethod]
        public void WordCounterCountTest()
        {
            IWordCounter counter = new WordCounter();
            try
            {
                counter.Count(null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("words"));
            }

            var ans = counter.Count(new List<string>(0));
            Assert.AreEqual(0, ans.Count());
            var ans2 = counter.Count(new List<string> { "yes", "no", string.Empty, null, "yes" }).ToList();
            Assert.AreEqual(3, ans2.Count);
            Assert.AreEqual("yes", ans2[0].Key);
            Assert.AreEqual("no", ans2[1].Key);
            Assert.AreEqual(string.Empty, ans2[2].Key);
            Assert.AreEqual(2, ans2[0].Value);
            Assert.AreEqual(1, ans2[1].Value);
            Assert.AreEqual(1, ans2[2].Value);
        }
    }

    [TestClass]
    public class CoordinatorTests
    {
        [TestMethod]
        public void CoordinatorCtorTest()
        {
            ICoordinator coordinator = null;
            try
            {
                coordinator = new Coordinator(null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("ioc"));
            }

            var ioc = new Container();
            try
            {
                coordinator = new Coordinator(ioc);
                Assert.Fail("Should fail until this moment");
            }
            catch (ContainerException ex)
            {
                Assert.IsTrue(ex.Message.Contains("IConsoleService"));
            }

            ioc.RegisterInstance(new Mock<IConsoleService>().Object);
            coordinator = new Coordinator(ioc);
            Assert.IsNotNull(coordinator);
            Assert.IsInstanceOfType(coordinator, typeof(ICoordinator));
            Assert.IsInstanceOfType(coordinator, typeof(Coordinator));
        }

        [TestMethod]
        public void CoordinatorStartTest()
        {
            var ioc = new Container();
            string outputData = string.Empty;
            var fakeConsole = new FakeConsoleService(a => outputData += a);
            fakeConsole.ReadyToRead("Very simple simple string");
            ioc.RegisterInstance<IConsoleService>(fakeConsole);
            ioc.Register<ICoordinator, Coordinator>();
            ioc.Register<IArgumentServiceFactory, ArgumentServiceFactory>();
            ioc.Register<ICleaningService, CleaningService>();
            ioc.Register<IWordSpliter, WordSpliter>();
            ioc.Register<IWordCounter, WordCounter>();
            ioc.Register<IFileService, FileService>();
            ICoordinator coordinator = new Coordinator(ioc);

            try
            {
                coordinator.Start(null);
                Assert.Fail("Should fail until this moment");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Contains("args"));
            }

            coordinator.Start(new string[] { });
            Assert.AreEqual("Application has been startedPlease enter input string. Finish by hitting return keyInput text has 25 charactersAfter cleaning input text has 25 charactersAfter splitting we have 4 wordsOutputting result to the console___________________________very - 1simple - 2string - 1___________________________Press return to exit", outputData);

            outputData = string.Empty;
            
            coordinator.Start(new[] { "-i:no.txt -s:count" });
            Assert.IsTrue(outputData.StartsWith("Application has been startedException occured: System.IO.FileNotFoundException: File does not exists. Please check the parameter provided\r\n   at WordFrequencyCounter.ContentReader.FileContentReader..ctor(IFileService fileService, String filePath) in"));
            Assert.IsTrue(outputData.EndsWith("Press return to exit"));
        }
    }
}
