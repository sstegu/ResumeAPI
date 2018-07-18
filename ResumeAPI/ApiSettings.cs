using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeAPI
{
    public class ApiSettings
    {
        public string[] CorsOrigins { get; set; }
        public bool UseInMemory { get; set; }
        public Info SwaggerInfo { get; set; }
        public string SwaggerJson { get; set; }
    }
}
