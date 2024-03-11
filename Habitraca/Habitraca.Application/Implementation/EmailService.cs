using Habitraca.Domain.EmailFolder;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Habitraca.Application.Implementation
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task EmailConfirmation(string link, string email)
        {
            try
            {
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $"<a href='{link}'>Click here to confirm your email</a>"
                };

                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(_emailSettings.DisplayName, _emailSettings.Email));
                emailMessage.To.Add(new MailboxAddress(email, email));
                emailMessage.Subject = "Email Confirmation";
                emailMessage.Body = bodyBuilder.ToMessageBody();

                using var client = new SmtpClient();

                // Handling for SSL/TLS handshake issue
                client.ServerCertificateValidationCallback = (s, c, h, e) => true; // Permissive certificate validation
                //s-sender, c-certificate, h-host, e-error
                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port); // Use STARTTLS
                await client.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
              //  _logger.LogError(ex, "Error occurred while sending email.");
                throw new Exception("Error occurred while sending email. Please try again later.", ex);
            }
        }

        public async Task SendMailAsync(EmailEntity emailEntity)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress(_emailSettings.DisplayName, _emailSettings.Email));
                emailMessage.To.Add(new MailboxAddress(emailEntity.ReceiverEmail, emailEntity.ReceiverEmail));

                emailMessage.Subject = emailEntity.Subject;

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $"{emailEntity.Body}<br/>"
                };

                emailMessage.Body = bodyBuilder.ToMessageBody();

                using var client = new SmtpClient();
                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
            catch (Exception)
            {
              //  _logger.LogError(ex, "Error occurred while sending email.");
                throw;
            }



        }
    }
}
