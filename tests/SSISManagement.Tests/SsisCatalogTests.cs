using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FakeItEasy;
using FluentAssertions;
using SqlServer.Management.IntegrationServices.Testing;
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
            "Then the Connection property should not be null"
                ._(() => catalog.Connection.Should().NotBeNull());
        }

        [Fact]
        public void WhenCreatedUsingNullConnection()
        {
            var ctor = new Action(() =>
            {
                var catalog = new SsisCatalog((IDbConnection)null);
            });
            ctor.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("connection");
        }

        [Scenario]
        public void WhenCreatedUsingDbConnection(SsisCatalog catalog, IDbConnection connection)
        {
            "Given a catalog created from a IDbConnection"
                ._(() =>
                {
                    connection = TestHelper.GetSqlConnection();
                    catalog = new SsisCatalog(connection);
                });
            "Then the Connection should be the same as the one passed in to the ctor"
                ._(() => catalog.Connection.Should().BeSameAs(connection));
            "And calling GetConnection() off of the Database property should return an equivalent connection"
                ._(() => catalog.Database.GetConnection().ShouldBeEquivalentTo(connection, o=>o.Including(x=>x.ConnectionString)));
        }

        
    }
}
