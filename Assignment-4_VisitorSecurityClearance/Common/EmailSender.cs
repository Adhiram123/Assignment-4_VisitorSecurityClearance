using SendGrid;
using SendGrid.Helpers.Mail;
using System.ComponentModel.DataAnnotations;

namespace Assignment_4_VisitorSecurityClearance.Common
{
    public class EmailSender
    {
        public async Task SendEmail(string subject,string toEmail,string Username,string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("tidkeshubham10@gmail.com");
            var to = new EmailAddress(toEmail,Username);
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
