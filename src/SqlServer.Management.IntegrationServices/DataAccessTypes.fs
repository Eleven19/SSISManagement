namespace SqlServer.Management.IntegrationServices.Data

type ConnectionString = string

type IConnectionStringProvider =
    abstract member SSISDb: ConnectionString