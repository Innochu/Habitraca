using Habitraca.Domain.EmailFolder;

namespace Habitraca.Application.Interface.Service
{
    public interface IEmailService
    {
        Task EmailConfirmation(string link, string email);
        Task SendMailAsync(EmailEntity emailEntity);
    }
}
