using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Stack.WeChat.WebAPI.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class AssignOperationVendorExtensions : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Parameters = operation.Parameters ?? new List<IParameter>();
            operation.Parameters.Add(new NonBodyParameter()
            {
                In = "header",
                Type = "string",
                Required = false,
                Name = "AccessToken",
                Description = "访问令牌"
            });
        }
    }
}