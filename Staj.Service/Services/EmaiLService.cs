using Microsoft.Extensions.Options;
using Staj.Core.OptionsModels;
using System.Net;
using System.Net.Mail;

namespace Staj.Service.Services
{
    public class EmaiLService : IEmailService
    {
        //YAAAALLLLAN OLUCAZZZZ HIZLI GİDERSEK
        private readonly EmailSettings _emailSettings;

        public EmaiLService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task SendResetPasswordEmail(string emaillink, string to)
        {
            var smtpClient = new SmtpClient();

            smtpClient.Host = _emailSettings.Host;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smtpClient.EnableSsl = true;    
            var mailMessage = new MailMessage();
            mailMessage.From=new MailAddress(_emailSettings.Email);
            mailMessage.To.Add(to);
            mailMessage.Subject = "LocalHost | Şifre Sıfırlama Linki";
            mailMessage.Body = $@"
            <h4>Şifrenizi Yenilemek için aşağıdaki linke tıklayınız</h4>
            <p>
            <a href='{emaillink}'>şifre yenileme linki</a>
            </p>";
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
