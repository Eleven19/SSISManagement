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
        public SsisCatalogTests()
        {
            
        }
        public string ConnectionString { get; private set; }

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
            //"And calling GetConnection() off of the Database property should return an equivalent connection"
            //    ._(() => catalog.Database.GetConnection().ShouldBeEquivalentTo(connection, o=>o.Including(x=>x.ConnectionString)));
        }

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
