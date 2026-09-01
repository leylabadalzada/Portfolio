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

            string htmlContent = "";

            if (toAuthor)
            {
                // Google SMTP BLOKLAMASIN DEYƏ: From hissəsi sistem email-i olmalıdır!
                email.From.Add(new MailboxAddress("Portfolio Contact Form", systemEmail));
                email.To.Add(MailboxAddress.Parse(systemEmail));

                // Cavab yazarkən birbaşa istifadəçiyə getməsi üçün:
                email.ReplyTo.Add(MailboxAddress.Parse(emailAddress));

                // Mesajın daxilində göndərənin məlumatlarını modern HTML formatında hazırlayırıq
                htmlContent = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; border: 1px solid #e0e0e0; border-radius: 8px; overflow: hidden;'>
                    <div style='background-color: #0d233a; color: #ffffff; padding: 20px; text-align: center;'>
                        <h2 style='margin: 0; font-size: 20px;'>Yeni Əlaqə Mesajı</h2>
                    </div>
                    <div style='padding: 25px; background-color: #ffffff;'>
                        <p style='margin-bottom: 15px;'><strong>Göndərən Email:</strong> <a href='mailto:{emailAddress}' style='color: #0d233a;'>{emailAddress}</a></p>
                        <p style='margin-bottom: 15px;'><strong>Mövzu:</strong> {subject}</p>
                        <hr style='border: none; border-top: 1px solid #eee; margin: 20px 0;' />
                        <p style='font-weight: bold; margin-bottom: 10px; color: #333;'>Mesaj Mətn:</p>
                        <div style='background-color: #f8f9fa; padding: 15px; border-radius: 6px; border-left: 4px solid #0d233a; color: #555; line-height: 1.6;'>
                            {body}
                        </div>
                    </div>
                    <div style='background-color: #f1f5f9; padding: 12px; text-align: center; font-size: 12px; color: #666;'>
                        Bu mesaj portfoliodakı əlaqə formasından göndərilib. Doğrudan cavablamaq üçün e-poçtunuzda 'Reply' vurmağınız kifayətdir.
                    </div>
                </div>";
            }
            else
            {
                // Sayt -> İstifadəçi
                email.From.Add(new MailboxAddress("Portfolio", systemEmail));
                email.To.Add(MailboxAddress.Parse(emailAddress));
                htmlContent = body;
            }

            email.Subject = toAuthor ? $"[Portfolio Contact]: {subject}" : subject;

            email.Body = new TextPart(TextFormat.Html)
            {
                Text = htmlContent
            };

            try
            {
                using var smtp = new SmtpClient();

                await smtp.ConnectAsync(
                    _config["EmailSettings:Server"],
                    int.Parse(_config["EmailSettings:Port"]),
                    MailKit.Security.SecureSocketOptions.SslOnConnect);

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
            catch (Exception ex)
            {
                return new ResponseVM
                {
                    Result = false,
                    Message = ex.Message
                };
            }
        }
    }
}