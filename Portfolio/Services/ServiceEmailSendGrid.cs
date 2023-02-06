using Portfolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portfolio.Services
{
    public class ServiceEmailSendGrid : IServiceEmailSendGrid
    {
        private readonly IConfiguration _configuration;
        public ServiceEmailSendGrid(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public async Task Send(ContactViewModel contact)
        {
            var apiKey = _configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = _configuration.GetValue<string>("SENDGRID_FROM");
            var name = _configuration.GetValue<string>("SENDGRID_NAME");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var subject = $"El cliente {contact.Email} quiere contactarte";
            var to = new EmailAddress(email + ":" + name);
            var messageTxt = contact.Message;
            var contentHtml = @$"De: {contact.Name} 
                Email:{contact.Email} 
                Mensaje: {contact.Message} ";

            var singleEmail = MailHelper.CreateSingleEmail(from, to,
                subject, messageTxt, contentHtml);
            var respon = await client.SendEmailAsync(singleEmail);

        }
    }
}
