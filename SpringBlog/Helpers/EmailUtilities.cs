using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace SpringBlog.Helpers
{
    public static class EmailUtilities
    {
        public static async Task SendEmailAsync(string destination, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(ConfigurationManager.AppSettings["mailAccount"], "Spring Blog");
            mail.To.Add(destination);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["mailAccount"], 
                    ConfigurationManager.AppSettings["mailPassword"]
                );
                await smtpClient.SendMailAsync(mail);
            }
        }
    }
}