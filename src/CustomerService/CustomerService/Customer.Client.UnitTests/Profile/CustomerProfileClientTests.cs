using Customer.Client.Profile;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.Client.UnitTests.Profile
{
    [TestClass]
    public class CustomerProfileClientTests
    {
        [TestMethod]
        public async Task AddCustomerProfileAsync_Success200()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new ObjectContent<TestObject>(new TestObject() { TestProperty = "I Work" }, new JsonMediaTypeFormatter())
                   //Content = new StringContent("[{'id':1,'value':'1'}]"),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };

            ICustomerProfileClient customerProfileClient = new CustomerProfileClient(httpClient);

            var response = await customerProfileClient.AddCustomerProfileAsync<TestObject>(new TestObject() { TestProperty = "I Work" });
            
            
        }

        public class TestObject
        {
            public string TestProperty { get; set; }
        }
    }
}
