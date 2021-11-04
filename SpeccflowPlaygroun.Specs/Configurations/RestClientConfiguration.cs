using RestSharp;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpeccflowPlaygroun.Specs.Configurations
{
    public static class RestClientConfiguration
    {
        public static void ConfigureAndRegisterRestClient(this ITestThreadContext context, string baseUrl)
        {
            var client = new RestClient(baseUrl);
            client.AddDefaultHeaders(new Dictionary<string, string>() { { "Accept", "application/json" } });
            context.TestThreadContainer.RegisterInstanceAs<IRestClient>(client);
        }
    }
}
