using System;
using System.Data;
using FakeItEasy;
using FluentAssertions;
using Xbehave;

namespace SqlServer.Management.IntegrationServices
{
    public class SsisConfigurationTests
    {
        [Scenario]
        public void CreatingWithDefaults(SsisConfiguration config)
        {
            "Given a default SsisConfiguration"
                ._(()=> config = new SsisConfiguration());
            "Then the ConnectionProvider property should not be null"
                ._(() => config.ConnectionProvider.Should().NotBeNull());
        }

        [Scenario]
        public void WhenCallingSetConnectionProviderWithANullParameter(SsisConfiguration config, Action theCall)
        {
            "Given an SsisConfiguration instance"
                ._(() => config = new SsisConfiguration());
            "When SetConnectionProvider is passed a null"
                ._(() => theCall = config.Invoking(cfg => cfg.SetConnectionProvider(null)));
            "Then we should throw an ArgumentNullException"
                ._(() => theCall.ShouldThrow<ArgumentNullException>().Where(ex => ex.ParamName == "connectionProvider"));
        }

        [Scenario]
        public void WhenCallingSetConnectionProvider(SsisConfiguration config, Func<string,IDbConnection> connectionProvider)
        {
            "Given an SsisConfiguration instance"
                ._(() =>
                {
                    config = new SsisConfiguration();
                    connectionProvider = A.Fake<Func<string, IDbConnection>>();
                });
            "When SetConnectionProvider is called with a non-null value"
                ._(() => config.SetConnectionProvider(connectionProvider));
            "Then the ConnectionProvider property should have been set"
                ._(() => config.ConnectionProvider.Should().BeSameAs(connectionProvider));
        }
    }
}