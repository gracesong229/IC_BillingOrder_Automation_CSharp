using APIAutomation.API;
using Commons.Model;
using FluentAssertions;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace APIAutomation.Test
{
    class Test_CSV
    {

        [NUnit.Framework.TestCaseSource("TestData")]
        public void CreateBilllingOrderTest(Commons.Model.BillingOrder expectedOrder)
        {
            //converting object to json 
            string jsonBody = JsonConvert.SerializeObject(expectedOrder);
            BillingOrderAPI billingOrderApi = new BillingOrderAPI();

            //Creating order 
            IRestResponse postResponse = billingOrderApi.Create(jsonBody);

            //converting json to object
            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(postResponse.Content);


            actualOrder.Should().BeEquivalentTo(expectedOrder,
            options => options.Excluding(o => o.Id));

        }

        static IEnumerable<TestCaseData> TestData()
        {
            using (var csv = new CsvReader(new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + "TestData\\basic.csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                    BillingOrder order =
                        new BillingOrder(
                        firstName: csv["firstname"],
                        lastName: csv["lastname"],
                        email: csv["email"]);

                    yield return new TestCaseData(order).SetName(csv["tcname"]);
                }
            }
        }
    }
}

