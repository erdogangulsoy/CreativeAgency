using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeAgency.Services
{
    public interface IMailService
    {
        void Send(EmailAddress from, EmailAddress to, string subject, string htmlMessage, string ccTo = "danko@communityabroad.com");
    }

    public class MailService : IMailService
    {
        string ApiKey;

        EmailAddress From;
        EmailAddress To;
        string Subject;
        string Message;
        

        public MailService(string apiKey)
        {
            ApiKey = apiKey;

            
        }
        public void Send(EmailAddress from, EmailAddress to, string subject, string htmlMessage, string ccTo = "danko@communityabroad.com")
        {
            From = from;
            To = to;
            Subject = subject;
            Message = htmlMessage;

            Execute(ccTo).Wait();

        }

        async Task Execute(string ccTo)
        {
            var apiKey = ApiKey;
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = From,
                Subject = Subject,
                HtmlContent = Message
            };

            msg.AddTo(To);

            if (!string.IsNullOrEmpty(ccTo))
            {
                msg.AddCc(ccTo);
            }

            var response = await client.SendEmailAsync(msg);
        }
    }
}
