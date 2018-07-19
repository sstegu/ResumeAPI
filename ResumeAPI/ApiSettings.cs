using Swashbuckle.AspNetCore.Swagger;

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
