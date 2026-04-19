using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BackendTechnicalAssetsManagement.src.Filters
{
    /// <summary>
    /// Swagger operation filter to properly handle file upload endpoints with IFormFile parameters.
    /// - For endpoints where IFormFile is the ONLY parameter (e.g. import), renders a simple file picker.
    /// - For [FromForm] model endpoints (e.g. CreateItem), ensures multipart/form-data content type
    ///   is set and the image field is rendered as a binary file picker alongside other fields.
    /// </summary>
    public class FileUploadOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var parameters = context.ApiDescription.ParameterDescriptions;

            // Check if any parameter is a raw IFormFile (e.g. import endpoints)
            var rawFileParams = parameters
                .Where(p => p.Type == typeof(IFormFile))
                .ToList();

            // Check if any parameter is a [FromForm] model that contains IFormFile properties
            var formModelParams = parameters
                .Where(p => p.Type != typeof(IFormFile) && p.Source?.Id == "Form")
                .ToList();

            // Case 1: Raw IFormFile only (import endpoints) — simple file picker
            if (rawFileParams.Any() && !formModelParams.Any())
            {
                operation.Parameters?.Clear();
                operation.RequestBody = new OpenApiRequestBody
                {
                    Required = true,
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["multipart/form-data"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Type = "object",
                                Properties = new Dictionary<string, OpenApiSchema>
                                {
                                    ["file"] = new OpenApiSchema
                                    {
                                        Type = "string",
                                        Format = "binary",
                                        Description = "Upload file (.xlsx, .xls, .csv)"
                                    }
                                },
                                Required = new HashSet<string> { "file" }
                            }
                        }
                    }
                };
                return;
            }

            // Case 2: [FromForm] model with IFormFile property — ensure binary fields render correctly
            if (operation.RequestBody?.Content != null)
            {
                foreach (var content in operation.RequestBody.Content.Values)
                {
                    if (content.Schema?.Properties == null) continue;

                    foreach (var prop in content.Schema.Properties)
                    {
                        // Find properties that map to IFormFile and set them as binary
                        var matchingParam = parameters.FirstOrDefault(p =>
                            string.Equals(p.Name, prop.Key, StringComparison.OrdinalIgnoreCase) &&
                            p.Type == typeof(IFormFile));

                        if (matchingParam != null)
                        {
                            prop.Value.Type = "string";
                            prop.Value.Format = "binary";
                        }
                    }
                }
            }
        }
    }
}
