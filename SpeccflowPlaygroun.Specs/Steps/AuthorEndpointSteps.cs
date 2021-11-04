using RestSharp;
using Shouldly;
using System.Net;
using TechTalk.SpecFlow;

namespace SpeccflowPlaygroun.Specs.Steps
{
    [Binding]
    public class AuthorEndpointSteps
    {
        private readonly ScenarioContext _context;
        private readonly IRestClient _client;
        private readonly RestRequest _request;

        public AuthorEndpointSteps(ScenarioContext context, IRestClient client)
        {
            _context = context;
            _client = client;
            _request = new RestRequest();
        }

        [Given(@"the last name of an author is Grisham")]
        public void GivenTheLastNameOfAnAuthorIsGrisham()
        {
            _request.AddParameter("lastName", "Grisham");
        }
        
        [Given(@"the endpoint is /resources/authors")]
        public void GivenTheEndpointIsResourcesAuthors()
        {
            _request.Resource = "resources/authors";
        }
        
        [When(@"i send the GET request")]
        public void WhenISendTheGETRequest()
        {
            var response = _client.Get(_request);
            _context.Add("response", response);
        }
        
        [Then(@"i should get OK response")]
        public void ThenIShouldGetOKResponse()
        {
            var response = _context.Get<IRestResponse>("response");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [When(@"I send a rest request /resources/authors/{id} with no existing author")]
        public void WhenISendARestRequestWithNoExistingAuthor()
        {
            _request.Resource = "resources/authors/1223312121313";
            var response = _client.Get(_request);
            _context.Add("response", response);
        }

        [Then(@"I should get not found response")]
        public void ThenIShouldGetNotFoundResponse()
        {
            var response = _context.Get<IRestResponse>("response");
            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

    }
}
