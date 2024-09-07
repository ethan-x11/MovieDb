using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;
using FluentAssertions;
using FluentAssertions.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IMDbRESTAPI.Tests.StepDefinitions
{
    public abstract class BaseSteps
    {
        protected WebApplicationFactory<TestStartup> Factory;
        protected HttpClient Client { get; set; }
        protected HttpResponseMessage Response { get; set; }

        public BaseSteps(WebApplicationFactory<TestStartup> baseFactory)
        {
            Factory = baseFactory;
        }

        [Given(@"I am a Client")]
        public void GivenIAmAClient()
        {
            Client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost/")
            });
        }

        [When(@"I make GET Request to '(.*)'")]
        public virtual async Task GETRequest(string endpoint)
        {
            var uri = new Uri(endpoint, UriKind.Relative);
            Response = await Client.GetAsync(uri);
        }

        [Then(@"response code must be '(.*)'")]
        public void ResponseCodeCompare(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }

        [Then(@"response data must look like '(.*)'")]
        public void ResponseDataCompare(string response)
        {
            var responseData = JToken.Parse(Response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            //Assert.Equal(response, responseData);
            responseData.Should().BeEquivalentTo(JToken.Parse(response));
        }

        [When(@"I make POST Request to '(.*)' with body '(.*)'")]
        public virtual async Task POSTRequestAsync(string endpoint, string postDataJson)
        {
            var uri = new Uri(endpoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            Response = await Client.PostAsync(uri, content);
        }

        [When(@"I make PUT Request to '(.*)' with requestBody '(.*)'")]
        public virtual async Task PUTRequestAsync(string endpoint, string putDataJson)
        {
            var uri = new Uri(endpoint, UriKind.Relative);
            var content = new StringContent(putDataJson, Encoding.UTF8, "application/json");
            Response = await Client.PutAsync(uri, content);
        }

        [When(@"I make DELETE Request to '(.*)'")]
        public virtual async Task DELETERequestAsync(string endpoint)
        {
            var uri = new Uri(endpoint, UriKind.Relative);
            Response = await Client.DeleteAsync(uri);
        }
    }
}
