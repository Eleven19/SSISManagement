using System;
using System.Collections.Generic;
using FluentAssertions;
using Xbehave;
using Xunit;
using Xunit.Extensions;

namespace SqlServer.Management.IntegrationServices
{
    public class SsisApplicationTests
    {
        [Scenario]
        public void WhenCreatingFromParameterlessConstuctor(SsisApplication application)
        {
            "Given a SsisApplication created from the parameterless constructor"
                ._(() => application = new SsisApplication());
            "Then the Configuration property should not be null"
                ._(() => application.Configuration.Should().NotBeNull());
        }

        [Scenario]
        public void WhenCreatingByProvidingANullConfigurationObject(SsisApplication application, Action ctorCall)
        {
            "Given a constructor call with a null configuration"
                ._(() =>
                {
                    SsisConfiguration configuration = null;
                    ctorCall = ()  => application = new SsisApplication(configuration);
                });
            "Then the constructor should throw an ArgumentNullException"
                ._(() => ctorCall.ShouldThrow<ArgumentNullException>().Where(ex=>ex.ParamName == "configuration"));
        }

        [Scenario]
        public void WhenCreatingByProvidingConfigurationObject(SsisApplication application, SsisConfiguration configuration)
        {
            "Given a SsisApplication created from the parameterless constructor"
                ._(() =>
                {
                    configuration = new SsisConfiguration();
                    application = new SsisApplication(configuration);
                });
            "Then the Configuration property should be the same as the passed in configuration"
                ._(() => application.Configuration.Should().BeSameAs(configuration));
        }

        [Scenario, PropertyData("WhenGettingCatalogByConnectionStringOrNameData")]
        public void WhenGettingCatalogByConnectionStringOrName(string connectionStringOrName, ISsisApplication application, ISsisCatalog catalog)
        {
            "Given an ISsisApplication instance"
                ._(() => application = new SsisApplication());

            "When getting catalog by connection string or name"
                ._(() => catalog = application.GetCatalog(connectionStringOrName));

            "Then the catalog should not be null"
                ._(() => catalog.Should().NotBeNull());

        }

        public static IEnumerable<object[]> WhenGettingCatalogByConnectionStringOrNameData
        {
            get
            {
                yield return new object[]{"name=SSISDB"};
            }
        }
    }
}