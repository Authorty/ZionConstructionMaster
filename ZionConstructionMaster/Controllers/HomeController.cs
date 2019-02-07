using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;

namespace ZionConstructionMaster.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SendEmail(string Name, string Phone, string Message, string Email, string Subject)
        {

            var emailmessage = new System.Web.Mail.MailMessage()
            {
                Subject = Name,
                Body = "From: " + Name + "\n Phone Number: " + Phone + "\n Job Description: " + Message + "\n Email: " + Email,
                From = "ZionConstructionEmail@gmail.com",
                To = "zionconstructionofwi@gmail.com",
                BodyFormat = MailFormat.Text,
                Priority = System.Web.Mail.MailPriority.High
            };
            var passWord = "ZionConstruction123";
            var email = new MailAddress("ZionConstructionEmail@gmail.com", "Pablo");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(email.Address, passWord)
            };

            using (var mess = new System.Net.Mail.MailMessage(email, email)
            {
                Subject = Subject,
                Body = "From: " + Name + "\n Phone Number: " + Phone + "\n Job Description: " + Message + "\n Email: " + Email
            })
            {
                smtp.Send(mess);
            }

            return new EmptyResult();
        }
    }
}