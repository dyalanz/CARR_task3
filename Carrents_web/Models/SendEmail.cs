using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Carrents_web.Models
{
    public class SendEmail
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents, String filename, String path)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "zzshark7@gmail.com");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes(path);
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment(filename, file);
            var response = client.SendEmailAsync(msg);
        }
    }
}