namespace Edu.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Edu.Domain.Concrete.TestDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Edu.Domain.Concrete.TestDbContext";
        }

        protected override void Seed(Edu.Domain.Concrete.TestDbContext context)
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
