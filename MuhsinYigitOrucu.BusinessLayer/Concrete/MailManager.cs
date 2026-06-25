
using Microsoft.Extensions.Options;
using MimeKit;
using MuhsinYigitOrucu.BusinessLayer.Abstract;
using MuhsinYigitOrucu.BusinessLayer.MailConfigs;

namespace MuhsinYigitOrucu.BusinessLayer.Concrete
{
    public class MailManager : IMailService
    {
        private readonly MailSettings _settings;

        public MailManager(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_settings.SenderEmail);
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;

            string htmlBody = $@"
            <div style='max-width: 600px; margin: 20px auto; font-family: -apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, Helvetica, Arial, sans-serif; background-color: #0F172A; border: 1px solid #1E293B; border-radius: 16px; overflow: hidden; box-shadow: 0 10px 30px -10px rgba(6, 182, 212, 0.1);'>
                
                <div style='background-color: #1E293B; padding: 25px; text-align: center; border-bottom: 2px solid #06B6D4;'>
                    <h2 style='margin: 0; color: #06B6D4; font-size: 22px; font-weight: 700; letter-spacing: 0.5px;'>
                        ⚡ Muhsin Yiğit Orucu | Geliştirici Destek
                    </h2>
                </div>
                
                <div style='padding: 30px; background-color: #0F172A;'>
                    
                    <div style='background-color: #1E293B; border-left: 4px solid #06B6D4; padding: 20px; margin: 10px 0 25px 0; border-radius: 8px;'>
                        <p style='margin: 0; color: #E2E8F0; font-size: 15px; line-height: 1.7; white-space: pre-line;'>
                            {body}
                        </p>
                    </div>
                    
                    <p style='font-size: 13px; color: #94A3B8; line-height: 1.5; margin: 0; border-top: 1px solid #1E293B; padding-top: 20px;'>
                        💡 Bu mesaj, portfolyo sitem üzerinden iletmiş olduğunuz iletişim formuna istinaden gönderilmiştir. Detaylar ve projeler için web sitemi ziyaret edebilirsiniz.
                    </p>
                </div>
                
                <div style='background-color: #1E293B; padding: 20px; text-align: center; font-size: 12px; color: #64748B; border-top: 1px solid #1E293B;'>
                    <div>
                        © 2026 MYOrucu | Designed & Built for Performance.
                    </div>
                </div>
            </div>";
            var builder = new BodyBuilder { HtmlBody = htmlBody };
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            await smtp.ConnectAsync(_settings.Server, _settings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_settings.SenderEmail, _settings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
