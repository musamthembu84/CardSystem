using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime;
using OpenPop.Common;

namespace LostCard.Models
{
    public class EmailConfiguration
    {

        private bool isCardValid(string email,string password)
        {
            bool checkStatus = false;
            Pop3Client client = new Pop3Client();
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate(email, password);


            //get number of newly unread messages
            int counter = client.GetMessageCount();
            if (counter >= 1)
            {
                client.DeleteAllMessages();
                checkStatus = true;
                client.Disconnect();
            }
            return checkStatus;

        }


        public bool Email(mvcCards Number)
        {
            bool stats = false;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("universityofjohannesburg.card@gmail.com");
            mailMessage.To.Add(Number.SNumber + "@student.uj.ac.za");

            string body = "Greetings" + System.Environment.NewLine + "Our Notification system at the University of Johannesburg has indicated to us that you have lost your student card." + Environment.NewLine + "" + Number.SNumber + "" + " has been received and it may be collected at the Student Enrolment Center APK Campus for a fee of R10." + System.Environment.NewLine + "Yours Sincerly Admin UJ  APK Campus ";

            mailMessage.Subject = "Collection Of Your Card From University of Johannesburg";
            mailMessage.Body = body;

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("universityofjohannesburg.card@gmail.com", "streetwise");
            client.Port = 587;
            client.EnableSsl = true;
            client.Send(mailMessage);

            if (isCardValid("universityofjohannesburg.card@gmail.com", "streetwise") == true)
            {
                stats = true;

            }
            return stats;
        }


    }
}