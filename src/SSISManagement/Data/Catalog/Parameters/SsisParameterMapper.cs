using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using Insight.Database.Mapping;

namespace SqlServer.Management.IntegrationServices.Data.Catalog.Parameters
{
    /// <summary>
    /// A parameter mapper which changes the SSIS style parameters to CamelCase.
    /// </summary>
    internal class SsisParameterMapper : IParameterMapper
    {
        private static readonly Regex RenameRegex =
            new Regex(@"(?<id>[A-Z,a-z,0-9]+)(?<underscore>_)+");
        public string MapParameter(Type type, IDbCommand command, IDataParameter parameter)
        {
            var connectionString = command.Connection.ConnectionString;
            var commandText = command.CommandText ?? string.Empty;
            if (ConnectionStrings.IsSsisConnectionString(connectionString) 
                // don't change casing of the ReturnValue parameter since Insight.Database makes use of it
                && parameter.Direction != ParameterDirection.ReturnValue
                )
            {
                Console.WriteLine(command.CommandText);
                var member = RenameRegex.Replace(parameter.ParameterName, match =>
                {                    
                    var id = match.Groups["id"].Value;
                    return System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(id);
                });

                //TODO: For completeness we should check if the member exists, but for now lets do this until we hit issues
                Debug.WriteLine("Mapping ParameterName={0}; to Member={1};", parameter.ParameterName, member);
                return member;
            }
            return null;
        }

    }
}