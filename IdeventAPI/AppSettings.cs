using Microsoft.Extensions.Configuration;

namespace IdeventAPI
{
    /// <summary>
    /// Should be used to give a connection string to the managers without them having to inject an IConfiguration, but so far I - Noit -
    /// have not gotten it to work.
    /// </summary>
    public class AppSettings
    {
        private IConfiguration _config;

        public AppSettings(IConfiguration configuration)
        {
            _config = configuration;
        }
    }
}
