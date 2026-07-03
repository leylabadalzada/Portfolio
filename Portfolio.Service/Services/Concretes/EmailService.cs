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

        public async Task<ResponseVM> SendEmailAsync(string fromUserEmail, string subject, string body, bool isHTML = true)
        {
            var email = new MimeMessage();

            // Göndərən yenə sizin öz emailiniz olur (Serverin xəta verməməsi üçün)
            var myEmail = _config["EmailSettings:Receiver"];
            email.From.Add(MailboxAddress.Parse(myEmail));
            email.To.Add(MailboxAddress.Parse(myEmail));

            // ƏSAS HİSSƏ: İstifadəçi "Reply" edəndə mesajın gedəcəyi ünvan
            email.ReplyTo.Add(MailboxAddress.Parse(fromUserEmail));

            email.Subject = subject;

            // Mesajın içinə istifadəçinin emailini də qeyd olaraq əlavə edirik ki, vizual olaraq da görəsiniz
            string formattedBody = $"<b>Göndərən istifadəçi:</b> {fromUserEmail}<br><br><b>Mesaj:</b><br>{body}";

            email.Body = new TextPart(TextFormat.Html) { Text = formattedBody };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["EmailSettings:Server"], int.Parse(_config["EmailSettings:Port"]), MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_config["EmailSettings:Receiver"], _config["EmailSettings:Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

            return new ResponseVM { Message = "Email is sent successfully", Result = true }; // Qeyd: Controller-də result.Result yoxlaması olduğu üçün bura true əlavə etdim.
        }
    }
}
