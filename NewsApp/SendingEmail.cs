using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApp.Service
{
    public class SendingEmail
    {
        private readonly ILogger<SendingEmail> logger;
        public SendingEmail(ILogger<SendingEmail> logger)
        {
            this.logger = logger;
        }
        public void SendEmailKit(string messTo)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("alexmelentev01@gmail.com"));
                message.To.Add(new MailboxAddress(messTo));
                message.Subject = "Message from NewsApp";
                message.Body = new BodyBuilder() { TextBody = "Conrgatulation! You're regestered on NewsApp.com" }.ToMessageBody();

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("alexmelentev01@gmail.com", "Hrenmorzhovyi1@");
                    client.Send(message);
                    logger.LogInformation("Message sent successfully");
                    
                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

        }
    }
}
