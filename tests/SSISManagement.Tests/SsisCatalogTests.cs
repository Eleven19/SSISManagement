using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using FluentAssertions;
using SqlServer.Management.IntegrationServices.Testing;
using Xbehave;
using Xunit;

namespace SqlServer.Management.IntegrationServices
{
    public class SsisCatalogTests
    {
        public class UsingSqlConnectionBuilderConstructor : TestRequiringConnectionStrings
        {
            [Fact]
            public void SqlConnectionBuilderMustNotBeNull()
            {
                Action ctor = () =>
                {
                    SqlConnectionStringBuilder connectionStringBuilder = null;
                    var catalog = new SsisCatalog(connectionStringBuilder);
                };

                ctor.ShouldThrow<ArgumentNullException>()
                    .Where(ex => ex.ParamName == "connectionStringBuilder");
            }

            [Fact]
            public void ConnectionStringBuilderPropertyIsTheSameInstancePassedToCtor()
            {
                var connectionStringBuilder = GetSsisDbConnectionStringBuilder();
                var catalog = new SsisCatalog(connectionStringBuilder);
                catalog.ConnectionStringBuilder.Should().BeSameAs(connectionStringBuilder);
            }
        }
    }
}
