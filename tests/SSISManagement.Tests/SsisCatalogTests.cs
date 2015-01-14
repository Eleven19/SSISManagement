using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
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
    }
}
