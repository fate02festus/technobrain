using Exercise01;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.Write("Enter a number to convert to words: ");
            long input = long.Parse(Console.ReadLine());
           // Assert.IsTrue(Exercise01.Exercise01.NumToWords(input));

        }
    }
}
