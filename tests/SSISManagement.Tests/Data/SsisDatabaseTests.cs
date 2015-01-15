using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Insight.Database;
using Insight.Database.Providers;
using SqlServer.Management.IntegrationServices.Testing;
using Xbehave;
using Xunit;

namespace SqlServer.Management.IntegrationServices.Data
{
    public class SsisDatabaseTests
    {
        public SsisDatabaseTests()
        {
            Database = TestHelper.GetSqlConnection().AsParallel<SsisDatabase>();
        }

        public SsisDatabase Database { get; private set; }

        [Background]
        public void Background()
        {
            "Given a database object"
                ._(() => Database = TestHelper.GetSqlConnection().AsParallel<SsisDatabase>());
        }
        [Fact]
        public void ShouldBeCreatableByInsightDatabase()
        {
            var database = TestHelper.GetSqlConnection().As<SsisDatabase>();
            database.Should().NotBeNull();
        }

        [Fact]
        public void ShouldBeCreatableByInsightDatabaseAsParallel()
        {
            var database = TestHelper.GetSqlConnection().AsParallel<SsisDatabase>();
            database.Should().NotBeNull();
        }

        [Fact]
        public void CallingGetConnectionShouldSucceed()
        {
            Action action = () => Database.GetConnection();
            action.ShouldNotThrow();
        }

        [Fact]
        public void CallingStartupShouldSucceed()
        {
            Action action = ()=>Database.Startup();
            action.ShouldNotThrow();
        }

        [Scenario]
        [Example("SSISManagement_Tests_DELETE_ME")]
        public void WhenCreatingAndDeletingFolders(string folderName)
        {
            "When a folder named {0} is created"
                ._(() => Database.CreateFolder(folderName));
            "Then we shold be able to  delete it"
                ._(() => Database.DeleteFolder(folderName));

        }

        [Scenario]
        public void WhenCallingGetCatalogProperties(IList<CatalogProperty> properties)
        {
            "When calling GetCatalogProperties()"
                ._(() => properties = Database.GetCatalogProperties());
            "Then the properties should list should not be null or empty"
                ._(() => properties.Should().NotBeNullOrEmpty());
            "And the list should contain the SCHEMA_BUILD property"
                ._(() => properties.Should().Contain(prop => prop.PropertyName == "SCHEMA_BUILD"));
        }

        [Scenario]
        public void WhenCallingExecutePackageForAPackageWhichDoesntExist()
        {            
            "When calling ExecutePackage(...) for a package that doesn't exist"
                ._(
                    () =>
                        Database.ExecutePackage(new ProjectInfo("SSISManagementExamples", "SampleSSIS2012Project"),"IDONTEXIST"));
        }
    }
}
