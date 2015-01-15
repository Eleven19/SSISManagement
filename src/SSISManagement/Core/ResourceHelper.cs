using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SqlServer.Management.IntegrationServices.Core
{
    internal static class ResourceHelper
    {
        public static string GetEmbeddedTextResource(this Assembly assembly, string resourceName)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            if (resourceName == null) throw new ArgumentNullException("resourceName");
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new KeyNotFoundException(
                        string.Format("Unable to find a resource by the name of \"{0}\" in assembly {1}. Please ensure you have specified the proper name and that the resource has been marked with a build action of Embedded Resource"
                        , resourceName
                        , assembly)
                    );
                }
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }            
        }
    }
}
