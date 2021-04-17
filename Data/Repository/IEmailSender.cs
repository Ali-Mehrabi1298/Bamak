using Bamak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bamak.Data.Repository
{
   public interface IEmailSender
    {

        //public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        //public Task SendEmailAsync(string email, string subject, string message);
        //public Task Execute(string apiKey, string subject, string message, string email);
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false);
    }
}
