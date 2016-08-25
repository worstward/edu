using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Edu.Domain.Concrete;
using Edu.Domain.Abstract;


namespace Edu.Controllers
{

    [Helpers.Exception]
    public class CourseController : Controller
    {

        ICourseRepository repository;
        public CourseController(ICourseRepository repository)
        {
            this.repository = repository;
        }

        private int _pageSize = 10;

        public ActionResult Courses(int page = 1)
        {
            var coursePage = repository.Courses.OrderBy(x => x.Id).Skip((page - 1) * _pageSize).Take(_pageSize);

            if(coursePage.Count() == 0)
            {
                throw new ArgumentOutOfRangeException();
            }


            var viewModel = new Domain.Models.CoursesPagingViewModel()
            {
                Courses = coursePage,
                PageInfo = new Domain.Models.Paging()
                {
                    PageSize = _pageSize,
                    CurrentPageNumber = page,
                    Total = repository.Courses.Count()
                }
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var course = repository.Courses.FirstOrDefault(crs => crs.Id == id);
            if (course != null)
                return PartialView(course);

            return HttpNotFound();
        }

	}
}