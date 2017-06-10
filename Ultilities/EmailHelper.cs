using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ultilities
{
    public class EmailHelper
    {
        public static bool Send(string to_address, string subject, string body_html)
        {
            bool result = false;
            var fromAddress = new MailAddress("dev1.doconaca@gmail.com", "dona_web");
            const string fromPassword = "D0conac@";

            var toAddress = new MailAddress(to_address);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body_html,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
                result = true;
            }
            return result;
        }
    }
}
