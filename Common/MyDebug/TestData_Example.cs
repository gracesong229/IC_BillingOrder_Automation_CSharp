using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Common.MyDebug
{
    class TestData_Example
    {

        [TestCaseSource("TD")]
        public int SumTest(int num1, int num2)
        {
            return num1 + num2;

        }
        public static IEnumerable TD
        {
            get
            {
                yield return new TestCaseData(12, 3).Returns(15);   //*
                yield return new TestCaseData(12, 2).Returns(14);
                yield return new TestCaseData(12, 4).Returns(16);
            }
        }

        [TestCaseSource("TestData")]
        public void CSVTestExample(string name)
        {
            TestContext.WriteLine(name);
        }
        static IEnumerable<string> TestData()
        {
            for (int i = 0; i <= 10; i++)
                yield return "Test " + i;
        }
    }
}
