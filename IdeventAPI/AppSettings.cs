using Microsoft.Extensions.Configuration;

namespace IdeventAPI
{
    public class AppSettings
    {
        private IConfiguration _config;

        public AppSettings(IConfiguration configuration)
        {
            _config = configuration;
        }
    }
}
