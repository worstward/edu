using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Edu.Domain.Concrete;
using Edu.Domain.Abstract;
using Edu.Helpers;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;


namespace Edu.Controllers
{

    [Helpers.Exception]
    public class HomeController : Controller
    {
        public HomeController(ICaptchaHelper captchaHelper)
        {
            _captchaHelper = captchaHelper;
        }

        private ICaptchaHelper _captchaHelper;

        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.Title = "My Edu WebApp";
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult InstituteHead()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SignUpForm()
        {
            ViewBag.isCaptchaValid = true;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SignUpForm(Edu.Models.Enrollee enrollee)
        {
            string encoded;


            try
            {
                encoded = Request.Form["g-Recaptcha-Response"];
            }
            catch
            {
                encoded = "empty message";
            }

            var isCaptchaValid = _captchaHelper.ValidateCaptcha(encoded);

            ViewBag.isCaptchaValid = isCaptchaValid;
            if (ModelState.IsValid && isCaptchaValid)
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.mail.ru";
                smtp.Port = 587;

                smtp.Credentials = new System.Net.NetworkCredential(MailInfoRes.Login, MailInfoRes.Password);

                MailMessage mail = new MailMessage();
                mail.To.Add(MailInfoRes.ReceiverMail);
                mail.From = new MailAddress(MailInfoRes.Sender);
                mail.Subject = "Заявка на обучение";
                string Body = string.Format("Заявка от пользователя {0} {1}. Пожалуйста, перезвоните по телефону {2} для уточнения условий. Почта для обратной связи: {3}",
                    enrollee.Name, enrollee.Surname, enrollee.Phone, enrollee.Email);
                mail.Body = Body;
                mail.IsBodyHtml = true;

                smtp.EnableSsl = true;
                smtp.Send(mail);
                return PartialView("SignUpOk", enrollee);
            }
            
            return PartialView("SignUpForm");
        }
	}
}