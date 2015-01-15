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
        private SsisDatabase _database;

        public SsisDatabaseTests()
        {
            _database = TestHelper.GetSqlConnection().AsParallel<SsisDatabase>();
        }

        [Background]
        public void Background()
        {
            "Given a database object"
                ._(() => _database = TestHelper.GetSqlConnection().AsParallel<SsisDatabase>());
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
            Action action = () => _database.GetConnection();
            action.ShouldNotThrow();
        }

        [Fact]
        public void CallingStartupShouldSucceed()
        {
            Action action = ()=>_database.Startup();
            action.ShouldNotThrow();
        }

        [Scenario]
        [Example("DELETE_ME")]
        public void WhenDeletingAFolder(string folderName)
        {
            "When deleting a folder named {0}"
                ._(() => _database.DeleteFolder(folderName));

        }

        [Scenario]
        public void WhenCallingExecutePackageForAPackageWhichDoesntExist()
        {            
            "When calling ExecutePackage(...) for a package that doesn't exist"
                ._(
                    () =>
                        _database.ExecutePackage(new ProjectInfo("SSISManagementExamples", "SampleSSIS2012Project"),"IDONTEXIST"));
        }
    }
}
