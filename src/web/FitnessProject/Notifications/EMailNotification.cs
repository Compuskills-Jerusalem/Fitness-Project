using System;
using System.Net;
using System.Net.Mail;

namespace Notifications
{
    public static class EMailNotification
    {
        public static void send(string To, string Sub, string Message)
        {
            var fromAddress = new MailAddress("compuskills.fitnessprojekt@gmail.com", "Compuskills Capstone");
            var toAddress = new MailAddress(To);
            const string fromPassword = "3412534125";


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
                Subject = Sub,
                Body = Message
            })
            {
                smtp.Send(message);
            }
        }
    }
}
