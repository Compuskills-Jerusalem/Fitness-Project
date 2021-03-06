﻿using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace FitnessProject.Web.Notifications
{
    public class EMailNotification :INotifications
    {
        public EMailNotification():this("compuskills.fitnessprojekt@gmail.com", "Compuskills Capstone", "3412534125Es")
        { }
        public EMailNotification(string senderEmail, string senderName, string senderPassword)
        {
            SenderEmail = senderEmail;
            SenderName = senderName;
            SenderPassword = senderPassword;
        }

        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string SenderPassword { get; set; }

        
        public void Send(MessageData messageData)
        {
            var fromAddress = new MailAddress(SenderEmail, SenderName);
            var toAddress = new MailAddress(messageData.EMail);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(SenderEmail, SenderPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = messageData.MsgHeader,
                Body = messageData.MsgBody
            })
            {
                smtp.Send(message);
            }

            smtp.Dispose();
        }
    }
    //SMS Api Using https://control.txtlocal.co.uk/docs/ Login: qcr57223@oqiwq.com Password:3412534125Cc
    public class SMSNotification : INotifications
    {
        public SMSNotification():this("G33intyT/XI-Ak1t1ZQUsEA4VUUIQ2yrZ6WXW2BdlW", "Capstone Projekt")
        {
        }
        public SMSNotification(string apiKey, string senderName)
        {
            ApiKey = apiKey;
            SenderName = senderName;
        }

        public string ApiKey { get; set; }
        public string SenderName { get; set; }
        public void Send(MessageData messageData)
        {
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                {
                    {"apikey" , ApiKey},
                    {"numbers" , messageData.TelNr},
                    {"message" , messageData.MsgHeader+" "+messageData.MsgBody},
                    {"sender" , SenderName}
                });
            }
        }
    }
    public class PushFirebase : INotifications
    {
        public PushFirebase()
        {
        }
        public PushFirebase(string serverKey, string senderID)
        {
            ServerKey = serverKey;
            SenderID = senderID;
        }

        //serverKey - Key from Firebase cloud messaging server  
        public string ServerKey { get; set; }

        //Sender Id - From firebase project setting  
        public string SenderID { get; set; }

        public void Send(MessageData messageData)
        {
            ServerKey= "AAAAaYh8kqY:AAAAGYK30PE:APA91bFcEQhzUzMnuU9lckj9Kt1CQbdC-BpLEYH1btjw0Yw6PkJI5Jhlug1jjSe4PIZdbe5_RaQqt3geDdUT7k5H7l3qpTn19PY7XyrNXw7gi4pyZkxMAP31KIQj375IoLIMxNZe3uI_";
            SenderID = "109567267057";
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", ServerKey));
            tRequest.Headers.Add(string.Format("Sender: id={0}", SenderID));
            tRequest.ContentType = "application/json";
            var msg = new
            {
                to = messageData.PushID,
                priority = "high",
                content_available = true,
                notification = new
                {
                    body = messageData.MsgHeader,
                    title = messageData.MsgHeader,
                    badge = 1
                },
            };

            string postbody = JsonConvert.SerializeObject(msg).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;

            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                //result.Response = sResponseFromServer;
                            }
                    }
                }
            }
        }


    }
}
