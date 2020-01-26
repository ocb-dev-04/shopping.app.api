using Microsoft.OpenApi.Models;

namespace ApiCore.ConfigServices
{
    internal class OAuth2Scheme : OpenApiSecurityScheme
    {
        public string Type { get; set; }
        public string Flow { get; set; }
        public string AuthorizationUrl { get; set; }
    }
}