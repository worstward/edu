using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using Edu.Domain.Models;
using Moq;

namespace Edu.Tests
{
    [TestClass]
    public class CourseControllerTests
    {

        Mock<Domain.Abstract.ICourseRepository> _repo;
        Domain.Models.CoursesPagingViewModel _paginator;
        Edu.Controllers.CourseController _courseController;


        [TestInitialize]
        public void InitTestContext()
        {
            var courseList = new List<Course>();

            for (int i = 1; i < 50; i++)
            {
                var course = new Course()
                {
                    Id = i,
                    Price = 1000,
                    Name = string.Format("Название курса {0}", i)
                };
                var courseDesc = new CourseDescription()
                {
                    Course = course,
                    Id = i,
                    CourseLength = 10,
                    ShortDescription = string.Format("Короткое описание курса {0}", i),
                    LongDescription = string.Format("Длинное описание курса", i)
                };

                course.CourseDescription = courseDesc;
                courseList.Add(course);
            }

            _repo = new Mock<Domain.Abstract.ICourseRepository>();
            _repo.Setup(m => m.Courses).Returns(courseList.AsQueryable());

             _courseController = new Edu.Controllers.CourseController(_repo.Object);
        }


        [TestMethod]
        public void CanPaginate()
        {
            int currentPage = 1;
            var result = _courseController.Courses(currentPage) as ViewResult;
            _paginator = result.Model as Domain.Models.CoursesPagingViewModel;

            Assert.AreEqual(_paginator.PageInfo.CurrentPageNumber, currentPage);
        }

        [TestMethod]
        public void CountTotalPages()
        {
            int currentPage = 1;
            var result = _courseController.Courses(currentPage) as ViewResult;
            _paginator = result.Model as Domain.Models.CoursesPagingViewModel;

            Assert.AreEqual(_paginator.PageInfo.TotalPages, 
                Math.Ceiling(_repo.Object.Courses.Count() / (double)_paginator.PageInfo.PageSize));
        }


        [TestMethod]
        public void CanProcessMissingCourses()
        {
            Assert.AreEqual(_courseController.Details(-1).GetType(), typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void CanShowExistingCourse()
        {
            int courseIndex = 1;

            var viewResult = _courseController.Details(courseIndex) as PartialViewResult;
            var course = viewResult.Model as Course;

            Assert.AreEqual(course.Id, courseIndex);
        }


    }
}
