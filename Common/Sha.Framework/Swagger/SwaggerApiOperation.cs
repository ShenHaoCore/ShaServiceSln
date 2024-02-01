using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Sha.Framework.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerApiOperation : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            bool isFileupload = context.ApiDescription.CustomAttributes().Any(it => it is UploadApiAttribute);
            if (isFileupload) { operation.Parameters.Add(new OpenApiParameter { Name = "File", In = ParameterLocation.Header, Description = "文件上传", Required = true, Schema = new OpenApiSchema { Type = "file" } }); }
        }
    }
}
