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
            new Regex(@"(?<id>[A-Z,a-z,0-9]+)(?<underscore>_)*");
        public string MapParameter(Type type, IDbCommand command, IDataParameter parameter)
        {
            if (IsSsisCatalogStoredProcedureCall(command))
            {
                if (ShouldOverrideParameterMapping(type, command, parameter))
                {
                    Debug.WriteLine("[SsisParameterMapper]::[MapParameter] CommandText:{0}{1}"
                        , Environment.NewLine, command.CommandText);

                    var member = RenameRegex.Replace(parameter.ParameterName, match =>
                    {
                        var id = match.Groups["id"].Value;
                        return System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(id);
                    });

                    //TODO: For completeness we should check if the member exists, but for now lets do this until we hit issues
                    Debug.WriteLine("[SsisParameterMapper]::[MapParameter] Mapping ParameterName={0}; to Member={1};", parameter.ParameterName, member);
                    return member;
                }
            }
            return null;
        }

        private bool IsSsisCatalogStoredProcedureCall(IDbCommand command)
        {            
            var connectionString = command.Connection.ConnectionString;
            if (ConnectionStrings.IsSsisConnectionString(connectionString))
            {
                var commandText = command.CommandText ?? string.Empty;
                if (command.CommandType == CommandType.StoredProcedure)
                {
                    if (commandText.StartsWith("catalog."))
                    {
                        return true;
                    }
                    Debug.WriteLine("Stored Proc call: <{0}> is NOT a call to the SSIS catalog", commandText);
                }
            }                        
            return false;
        }

        private bool ShouldOverrideParameterMapping(Type type, IDbCommand command, IDataParameter parameter)
        {
            // Only override mappings for non-return value parameters
            if (parameter.Direction != ParameterDirection.ReturnValue)
            {
                // Only override things that have not already been mapped
                if (!string.IsNullOrWhiteSpace(parameter.SourceColumn))
                {
                    // We are only interested in overriding the parameters with an underscore
                    if (parameter.ParameterName.Contains("_"))
                    {
                        return true;
                    }
                    Debug.WriteLine("[SsisParameterMapper]::[ShouldOverrideParameterMapping] ParameterName: '{0}' will NOT be mapped by this mapper."
                        , parameter.ParameterName);

                }   
            }
            return false;
        }

    }
}