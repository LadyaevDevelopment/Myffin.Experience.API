﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Myffin.API.SwaggerOptions.SchemaFilters
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                schema.Enum.Clear();
                Enum.GetNames(context.Type)
                    .ToList()
                    .ForEach(n => schema.Enum.Add(new OpenApiString(n)));

                schema.Description += "<p>Members:</p><ul>";
                Enum.GetNames(context.Type)
                    .ToList()
                    .ForEach(name => schema.Description += $"<li>{name}</li>");
                schema.Description += "</ul>";
            }
        }
    }
}