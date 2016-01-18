using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Edu.Domain.Concrete;
using Edu.Domain.Abstract;


namespace Edu.Controllers
{
    public class CourseController : Controller
    {

        ICourseRepository repository;
        public CourseController(ICourseRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Courses()
        {
            return View(repository.Courses);
        }

        public ActionResult Details(int id)
        {
            var course = repository.Courses.FirstOrDefault(crs => crs.Id == id);
            if (course != null)
                return PartialView(course);

            return HttpNotFound();
        }



        ////
        //// GET: /Courses/
        //public ActionResult Index()
        //{
        //    return View();
        //}
	}
}