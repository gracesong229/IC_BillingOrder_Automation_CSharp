using APIAutomation.API;
using Commons.Model;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace APIAutomation.Test
{
    [Author("Grace", "ajit")]
    class BillingOrderAPITest
    {
        /*string jsonBody = "{\"addressLine1\":\"address1\",\"addressLine2\":\"add2\"," +
            "\"city\":\"auckland\",\"comment\":\"testcomment\",\"email\":\"ajit@sector36.com\"," +
            "\"firstName\":\"Ajit\",\"itemNumber\":0,\"lastName\":\"Sharma\"," +
            "\"phone\":\"0123456789\",\"state\":\"AL\",\"zipCode\":\"121212\"}"; */

        [Test]
        public void CreateBilllingOrderTest()
        {
            BillingOrder expectedOrder = new BillingOrder
            {
                AddressLine1 = "test",
                AddressLine2 = "test",
                FirstName = "ajit",
                LastName = "test",
                Phone = "1234567898",
                ZipCode = "123456",
                ItemNumber = 1,
                State = "AL",
                Email = "aj@testing.com",
                City = "test",
                Comment = "test comment"
            };

            //converting object to json 
            string jsonBody = JsonConvert.SerializeObject(expectedOrder);
            BillingOrderAPI billingOrderApi = new BillingOrderAPI();

            //Creating order 
            IRestResponse postResponse = billingOrderApi.Create(jsonBody);

            //converting json to object
            BillingOrder actualOrder = JsonConvert.DeserializeObject<BillingOrder>(postResponse.Content);

            //IRestResponse getResponse = billingOrder.Get(actualOrder.Id);


            //Assert.AreEqual(expectedOrder.FirstName, actualOrder.FirstName);
            //compare object expectedOrder == actualOrder

            //Hack 
            //actualOrder.Id = expectedOrder.Id;

            actualOrder.Should().BeEquivalentTo(expectedOrder,
            options => options.Excluding(o => o.Id));

        }



    }
}