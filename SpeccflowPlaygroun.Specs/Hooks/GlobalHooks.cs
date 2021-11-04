using RestSharp;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;
using SpeccflowPlaygroun.Specs.Configurations;

namespace SpeccflowPlaygroun.Specs.Hooks
{
    [Binding]
    public sealed class GlobalHooks
    {

        /// <summary>
        /// Starting point method where all drivers and classes will be added to DI container
        /// </summary>
        /// <param name="context"></param>
        [BeforeTestRun]
        public static void BeforeFeatureStarts(TestThreadContext context)
        {
            context.ConfigureAndRegisterSettings();
            var config = context.TestThreadContainer.Resolve<IConfiguration>();
            
            context.ConfigureAndRegisterRestClient(config["baseApiUrl"]);
        }

    }
}
