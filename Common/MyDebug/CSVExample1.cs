using Commons.Model;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.MyDebug
{
    class CSVExample1
    {
        [TestCaseSource("TestData1")]
        public void CSVTestExample(string name)
        {
            TestContext.WriteLine(name);
        }
        static IEnumerable<string> TestData1()
        {
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "TestData\\basic.csv"), true))
            {
                while (csv.ReadNextRecord())
                    yield return csv["firstname"] + " " + csv["lastname"] + " " + csv["email"];
            }
        }

    }
}
