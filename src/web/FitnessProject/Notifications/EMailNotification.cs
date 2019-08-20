using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;

namespace Notifications
{
    public static class EMailNotification
    {
        public static void Send(string To, string Sub, string Message)
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
    //SMS Api Using https://control.txtlocal.co.uk/docs/ Login: qcr57223@oqiwq.com Password:3412534125Cc
    public static class SMSNotification
    {
        public static void Send(string ToNuber, string Message)
        {
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                {
                {"apikey" , "n6131WEXd5Y-0b0KBG44o7r4QmD25gv3GkwgmXSBeW"},
                {"numbers" , ToNuber},
                {"message" , Message},
                {"sender" , "Capstone Projekt"}
                });
            }
        }
    }
}
