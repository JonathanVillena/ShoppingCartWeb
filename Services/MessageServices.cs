using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http;
using System.Net;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ShoppingCartWeb.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient("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");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("richi_540@hotmail.com", "Ricardo Garcia"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            /*
            var client = new SendGridClient("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");
            var from = new EmailAddress("richi_540@hotmail.com", "Ricardo Garcia");
            var to = new EmailAddress(email, "Example User");
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
             */
            return  client.SendEmailAsync(msg);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
