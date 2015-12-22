using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edu.Domain.Abstract;
using Edu.Domain.Models;
using System.Data.Entity;

namespace Edu.Domain.Concrete
{
    public class EFCourseRepository : ICourseRepository
    {


        public EFCourseRepository(IDbContext ctx)
        {
            context = ctx;
        }

        IDbContext context;

        public IQueryable<Course> Courses
        {
            get
            {
                return context.Courses;
            }
        }


    }
}
