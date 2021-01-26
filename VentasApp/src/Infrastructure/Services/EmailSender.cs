using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Application.Common.Interfaces;

namespace VentasApp.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private SmtpClient Cliente { get; }
        private EmailOptions Options { get; }

        public EmailSender(IOptions<EmailOptions> options)
        {
            Options = options.Value;
            Cliente = new SmtpClient()
            {
                Host = Options.Host,
                Port = Options.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Options.Email, Options.Password),
                EnableSsl = Options.EnableSsl,
            };
        }

        public async Task<int> SendEmailAsync(string email, string name, string subject, string body)
        {
            MailAddress from = new MailAddress(Options.Email, Options.Name);
            MailAddress to = new MailAddress(email, name);
            //var correo = new MailMessage(from: Options.email, to: email, subject: subject, body: body.ToString());
            var correo = new MailMessage(from, to);
            correo.Subject = subject;
            correo.Body = body;
            correo.IsBodyHtml = true;
            try
            {
                await Cliente.SendMailAsync(correo);
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }

        }
    }
}
