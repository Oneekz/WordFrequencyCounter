using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordFrequencyCounter.Interface;
using WordFrequencyCounter.Service;

namespace WordFrequencyCounter.UnitTest.Service
{
    [TestClass]
    public class ConsoleServiceTests
    {
        [TestMethod]
        public void ConsoleServiceWriteLineTest()
        {
            IConsoleService console = new ConsoleService();
            console.WriteLine("test");
            console.WriteLine("test{0}", 2);
        }

        [TestMethod]
        public void ConsoleServiceReadLineTest()
        {
            IConsoleService console = new ConsoleService();
            Task.Run(() =>
            {
                console.ReadLine();
            });
        }

        [TestMethod]
        public void ConsoleServiceForegroundTest()
        {
            IConsoleService console = new ConsoleService();
            Assert.AreEqual(ConsoleColor.Gray, console.Foreground);
            console.Foreground = ConsoleColor.Cyan;
            Assert.AreEqual(ConsoleColor.Cyan, console.Foreground);
        }
    }
}