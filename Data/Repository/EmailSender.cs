using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

using Bamak.Models;
using System.Net.Mail;
using System.Net;

namespace Bamak.Data.Repository
{
    public class EmailSender : IEmailSender
    {


        //namespace WebPWrecover.Services

        //    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        //    {
        //        Options = optionsAccessor.Value;
        //    }

        //    public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        //    public Task SendEmailAsync(string email, string subject, string message)
        //    {
        //        return Execute(Options.SendGridKey, subject, message, email);
        //    }

        //    public Task Execute(string apiKey, string subject, string message, string email)
        //    {
        //        var client = new SendGridClient(apiKey);
        //        var msg = new SendGridMessage()
        //        {
        //            From = new EmailAddress("sarzaminjokv@gmail.com", Options.SendGridUser),
        //            Subject = subject,
        //            PlainTextContent = message,
        //            HtmlContent = message
        //        };
        //        msg.AddTo(new EmailAddress(email));

        //        // Disable click tracking.
        //        // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
        //        msg.SetClickTracking(false, false);

        //        return client.SendEmailAsync(msg);
        //    }
        //}
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false)
        {
            using (var client = new SmtpClient())
            {

                var credentials = new NetworkCredential()
                {
                    UserName = "bamak.b11", // without @gmail.com
                    Password = "9617684003A"
                };

                client.Credentials = credentials;
                client.Host = "smtp.gmail.com";
                client.Port = 465;
                client.EnableSsl = false;

                using var emailMessage = new MailMessage()
                {
                    To = { new MailAddress(toEmail) },
                    From = new MailAddress("bamak.b11@gmail.com"), // with @gmail.com
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = isMessageHtml
                };

                client.Send(emailMessage);
            }

            return Task.CompletedTask;
        }
        }
    }

//https://console.developers.google.com/apis/credentials/consent/edit;newAppInternalUser=false?project=concrete-setup-306217&supportedpurview=project
