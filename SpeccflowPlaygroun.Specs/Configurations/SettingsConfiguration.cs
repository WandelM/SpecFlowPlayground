using Microsoft.Extensions.Configuration;
using System;
using TechTalk.SpecFlow;

namespace SpeccflowPlaygroun.Specs.Configurations
{
    public static class SettingsConfiguration
    {
        public static void ConfigureAndRegisterSettings(this ITestThreadContext context)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("testConfig.json")
                .Build();

            context.TestThreadContainer.RegisterInstanceAs<IConfiguration>(config);
        }
    }
}
