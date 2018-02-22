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
            bool localCheck = false;
            Pop3Client client = new Pop3Client();
            client.Connect("pop.gmail.com", 995, true);
            client.Authenticate(email, password);


            //get number of newly unread messages
            int counter = client.GetMessageCount();
            if (counter >= 1)
            {
                client.DeleteAllMessages();
                localCheck = true;
                client.Disconnect();
            }
            return localCheck;

        }
        

    }
}