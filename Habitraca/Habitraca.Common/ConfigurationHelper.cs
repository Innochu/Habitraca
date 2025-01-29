using Microsoft.Extensions.Configuration;

namespace Habitraca.Common
{
    public static class ConfigurationHelper
    {
        private static IConfiguration? _configuration;

        // Setter method for configuration instance
        public static void InstantiateConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Getter method for configuration instance
        public static IConfiguration GetConfiguration()
        {
            return _configuration ?? throw new InvalidOperationException("Configuration has not been set.");
        }
    }
}
