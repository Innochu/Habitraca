using Habitraca.Domain.EmailFolder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Habitraca.Application.Configurations
{
    public static class EmailConfiguration
    {
        public static void EmailConfig(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<EmailSettings>(config.GetSection("EmailSettings"));
        }
    }
}
