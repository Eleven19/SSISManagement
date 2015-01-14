using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xbehave;
using Xunit;

namespace SqlServer.Management.IntegrationServices
{
    public class SsisCatalogTests
    {
        [Fact]
        public void CanCreateWithParameterlessConstructor()
        {
            var ctor = new Action(() =>
            {
                var catalog = new SsisCatalog();
            });
            ctor.ShouldNotThrow();
        }

        [Scenario]
        public void WhenCreatedUsingParameterlessConstructor(SsisCatalog catalog)
        {
            "Given a catalog created with the parameterless constructor"
                ._(() => catalog = new SsisCatalog());
            "Then the Connection should not be null"
                ._(() => catalog.Connection.Should().NotBeNull());
        }
    }
}
