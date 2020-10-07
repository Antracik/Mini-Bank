using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Services.Services.Implementations
{
    public class EmailSender : IEmailSender
    {
        public AuthMessageSenderOptions Options { get; }

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(Options.SendGridKey, subject, htmlMessage, email);
        }

        private Task Execute(string apiKey, string subject, string htmlMessage, string email)
        {
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("preslav.miroslavov@gmail.com", "Mini Bank"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage,
                //TemplateId = "d-8536157281a74c86b9f21fee863a5608"
            };
            msg.AddTo(new EmailAddress(email));

            msg.SetClickTracking(false, false);
            return client.SendEmailAsync(msg);
        }
    }
}
