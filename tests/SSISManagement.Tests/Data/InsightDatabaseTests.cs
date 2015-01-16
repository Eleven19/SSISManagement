using System;
using System.Data;
using FluentAssertions;
using Insight.Database;
using Insight.Database.Providers;
using Xunit;

namespace SqlServer.Management.IntegrationServices.Data
{
    public class InsightDatabaseTests
    {
        public InsightDatabaseTests()
        {            
            Connection = Testing.TestHelper.GetSqlConnection();
            SsisDb = Connection.As<ISsisDb>();
            SsisDbAsParallel = Connection.AsParallel<ISsisDb>();
            SsisDbFromAbstract = Connection.As<SsisDb>();
        }
        public IDbConnection Connection { get; private set; }
        public ISsisDb SsisDb { get; private set; }
        public ISsisDb SsisDbAsParallel { get; private set; }
        public SsisDb SsisDbFromAbstract { get; set; }

        [Fact]
        [Trait("Category", "Integration Tests")]
        [Trait("Category", "SSISDB")]
        public void UsingSsisDb_A_CallToStartupShouldSucceed()
        {
            SsisDb
                .Invoking(db=>db.Startup())
                .ShouldNotThrow();
        }

        [Fact]
        [Trait("Category", "Integration Tests")]
        [Trait("Category", "SSISDB")]
        public void UsingSsisDb_AsParallel_A_CallToStartupShouldSucceed()
        {
            SsisDbAsParallel
                .Invoking(db => db.Startup())
                .ShouldNotThrow();
        }

        [Fact]
        public void UsingSsisDb_AsParallel_A_CallToGetConnection_Should_Succeed()
        {
            SsisDbFromAbstract
                .Invoking(db => db.GetConnection())
                .ShouldNotThrow();
        }
    }

    public interface ISsisDb
    {
        [Sql("startup", Schema = "catalog")]
        void Startup();
    }

    public abstract class SsisDb : IDatabase
    {
        public abstract IDbConnection GetConnection();        
    }
}