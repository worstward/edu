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
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ICourseRepository repository;
        public HomeController(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "My Edu WebApp";
            return View();
        }
        public ActionResult Contacts()
        {
            return View();
        }

        public ActionResult Courses()
        {
            return View(repository.Courses);
        }

        public ActionResult InstituteHead()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var course = repository.Courses.FirstOrDefault(crs => crs.Id == id);
            if (course != null)
                return PartialView(course);
            
            return HttpNotFound();
        }

        [HttpGet]
        public PartialViewResult SignUpForm()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SignUpForm(Edu.Models.Enrollee enrollee)
        {
            string Encoded = Request.Form["g-Recaptcha-Response"];

            var isCaptchaValid = CaptchaAnswer.ValidateCaptcha(Encoded);

            if (ModelState.IsValid && isCaptchaValid)
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.mail.ru";
                smtp.Port = 587;

                smtp.Credentials = new System.Net.NetworkCredential("", "");

                MailMessage mail = new MailMessage();
                mail.To.Add("");
                mail.From = new MailAddress("");
                mail.Subject = "Заявка на обучение";
                string Body = string.Format("Заявка от пользователя {0} {1}. Пожалуйста, перезвоните по телефону {2} для уточнения условий. Почта для обратной связи: {3}",
                    enrollee.Name, enrollee.Surname, enrollee.Phone, enrollee.Email);
                mail.Body = Body;
                mail.IsBodyHtml = true;

                smtp.EnableSsl = true;
                smtp.Send(mail);
                return PartialView("SignUpOk", enrollee);
            }
            return PartialView();
        }



        public ActionResult Gallery()
        {
            return View();
        }
        
	}
}