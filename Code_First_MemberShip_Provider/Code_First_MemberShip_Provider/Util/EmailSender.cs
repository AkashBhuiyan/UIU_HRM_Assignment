using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using Code_First_MemberShip_Provider.Models;

namespace Code_First_MemberShip_Provide.Util
{
    public class EmailSender
    {
        public void SendEmail(RegisterModel registerModel )
        {

            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(registerModel.UserName));  // replace with valid value 
            message.From = new MailAddress("XXXX");  // replace with valid value
            message.Subject = "[IMPORTANT] HRM Account Information";
            message.Body = string.Format(body, "From UIU HRM WEB", "iitmisu@gmail.com", "Dear HRM Account Holder ,Your HRM account has been created Here is the Account Information is given below </br> Email :"+registerModel .UserName+ " </br> Password: "+ registerModel.Password);


            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "XXXXX",  // replace with valid value
                    Password = ""  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);


            }

        }


    }
}