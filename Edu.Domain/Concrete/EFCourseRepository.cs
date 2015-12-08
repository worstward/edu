using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Domain.Abstract;
using Edu.Domain.Entities;

namespace Edu.Domain.Concrete
{
    public class EFCourseRepository : ICourseRepository
    {
        EFDbContext context = new EFDbContext();

        public IQueryable<Course> Courses
        {
            get
            {
                return context.Courses;
            }
        }


    }
}
