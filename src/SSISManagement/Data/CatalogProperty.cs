using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Database;

namespace SqlServer.Management.IntegrationServices.Data
{
    public class CatalogProperty
    {
        //[Column("property_name")]
        public string PropertyName { get; set; }
        //[Column("property_value")]
        public string PropertyValue { get; set; }
    }
}
