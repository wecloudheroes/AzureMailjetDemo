using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace AzureMailJetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            Console.WriteLine("Hello World!");
            // Insert your mailjet account key
            String APIKey = "MailJetAPIKey";
            // Insert your mailjet SecretKey
            String SecretKey = "MailJetSecretKey";
            // From address/domain should be validated in Mailjet
            String From = "you@example.com";
            // Receiver address
            String To = "myname@mydomain.com";

            //Create new message
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(From);

            msg.To.Add(new MailAddress(To));

            msg.Subject = "Your mail from Mailjet";
            msg.Body = "Your mail from Mailjet, sent by C#.";

            // Create new attachment and add to message
            Attachment att = new Attachment("c:\\temp\\test.txt");
            msg.Attachments.Add(att);
            // Insert host name and port from Mailject Azure settings. 
            SmtpClient client = new SmtpClient("in-v3.mailjet.com", 587);

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(APIKey, SecretKey);
            
            // send email
            client.Send(msg);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
