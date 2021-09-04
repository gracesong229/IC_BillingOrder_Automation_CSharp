using Commons.Model;
using LumenWorks.Framework.IO.Csv;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.MyDebug
{
    class CSVExample2
    {
        [TestCaseSource("TestData2")]
        public void CSVTestExample(BillingOrder order)
        {
            TestContext.WriteLine(order.FirstName);
            TestContext.WriteLine(order.LastName);
            TestContext.WriteLine(order.Email);
        }
        static IEnumerable<TestCaseData> TestData2()
        {
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "TestData\\basic.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    //--------------good way to create 
                    BillingOrder order =
                        new BillingOrder(firstName: csv["firstname"], lastName: csv["lastname"], email: csv["email"]);

                    //yield return new TestCaseData(order).SetName("Billing order TC " + csv["firstname"]);

                    //if (csv["dp"].Equals("1")) yield return new TestCaseData(order);

                    yield return new TestCaseData(order).SetName(csv["tcname"]);
                }
            }
        }
    }
}
