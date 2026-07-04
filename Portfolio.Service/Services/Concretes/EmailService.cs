using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Portfolio.Service.Services.Abstractions;
using Portfolio.Service.ViewModels.Response;

namespace Portfolio.Service.Services.Concretes
{
    public class EmailService : IEmailService
    {
        readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ResponseVM> SendEmailAsync(string emailAddress, string subject, string body, bool toAuthor = true)
        {
            var email = new MimeMessage();

            var systemEmail = _config["EmailSettings:Receiver"];

            if (toAuthor)
            {
                // İstifadəçi -> Sayt sahibi
                email.From.Add(MailboxAddress.Parse(emailAddress));
                email.To.Add(MailboxAddress.Parse(systemEmail));

                // SMTP auth üçün ReplyTo da əlavə etmək olar
                email.ReplyTo.Add(MailboxAddress.Parse(emailAddress));
            }
            else
            {
                // Sayt -> İstifadəçi
                email.From.Add(MailboxAddress.Parse(systemEmail));
                email.To.Add(MailboxAddress.Parse(emailAddress));
            }

            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(
                _config["EmailSettings:Server"],
                int.Parse(_config["EmailSettings:Port"]),
                MailKit.Security.SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(
                systemEmail,
                _config["EmailSettings:Password"]);

            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

            return new ResponseVM
            {
                Result = true,
                Message = "Email sent successfully"
            };
        }
    }
}
