using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Edu.Domain.Concrete
{
    class CourseDbInitializer : CreateDatabaseIfNotExists<TestDbContext>
    {
        protected override void Seed(TestDbContext context)
        {
            
            var courseList = new List<Models.Course>();

            for (int i = 0; i < 100; i++)
            {
                var course = new Models.Course()
                {
                    Id = i,
                    Price = 1000,
                    Name = string.Format("Название курса {0}", i)
                };
                var courseDesc = new Models.CourseDescription()
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

            courseList.ForEach(course => context.Courses.Add(course));

            context.SaveChanges();
        }
    }
}
