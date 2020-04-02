using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkDev.AngularAutomation.Services.CRMasServiceProviderApi.App_Start
{
    public class IgnoreFieldsSwishBuckleFilter : ISchemaFilter
    {
        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {

            var excludeProperties = new[] { "ProcessingStatus", "ProcessingCode", "ProcessingMessage" };
            foreach (var prop in excludeProperties)

                if (schema.properties.ContainsKey(prop))
                    schema.properties.Remove(prop);
        }
    }
}