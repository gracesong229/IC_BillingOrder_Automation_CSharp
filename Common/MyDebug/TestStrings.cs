using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyDebug
{
    class TestStrings
    {

        [TestCaseSource(("TestString"), new object[] { false })]
        public void ShortName(string name)
        {
            TestContext.WriteLine(name);
        }

        [TestCaseSource(("TestString"), new object[] { true })]
        public void ShortName2(string name)
        {
            TestContext.WriteLine(name);
        }

        static IEnumerable<string> TestString(bool filter)
        {
            if (filter) yield return "ThisIsAVeryLongNameThisIsAVeryLongName";
            if (!filter) yield return "SomeName";
            if (!filter) yield return "YetAnotherName";
            if (filter) yield return "YetAnotherName1";
            if (filter) yield return "YetAnotherName2";
        }
    }
}
