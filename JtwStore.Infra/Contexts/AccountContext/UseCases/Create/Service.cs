using JtwStore.core;
using JtwStore.core.Contexts.AccountContext.Entities;
using JtwStore.core.Contexts.AccountContext.UseCases.Create.Contracts;
using System.Net.Mail;
using System.Net;

namespace JtwStore.Infra.Contexts.AccountContext.UseCases.Create;

public class Service : IService
{
    public async Task SendVerificationEmailAsync(User user, CancellationToken cancellationToken)
    {
        bool Send(
        string toName,
        string toEmail,
        string subject,
        string body,
        string fromName = "Equipe Blog",
        string fromEmail = "douglas.dev@gmail.com")
        {
            var smtpClient = new SmtpClient(Configuration.Smtp.Host, Configuration.Smtp.Port)
            {
                Credentials = new NetworkCredential(Configuration.Smtp.UserName, Configuration.Smtp.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };
            var mail = new MailMessage
            {
                From = new MailAddress(fromEmail, fromName)
            };
            mail.To.Add(new MailAddress(toEmail, toName));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            try
            {
                smtpClient.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
