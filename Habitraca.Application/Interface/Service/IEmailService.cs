using Habitraca.Domain.EmailFolder;
using MimeKit;

namespace Habitraca.Application.Interface.Service
{
    public interface IEmailService
    {
        Task EmailConfirmation(string link, string email);
        Task SendMailAsync(EmailEntity emailEntity);
        void AttachFile(BodyBuilder bodyBuilder, string filePath, string fileName);
    }
}
