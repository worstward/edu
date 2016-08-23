using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Domain.Models
{
    public class CoursesPagingViewModel
    {
        public IEnumerable<Course> Courses
        { 
            get;
            set; 
        }

        public Paging PageInfo 
        {
            get; 
            set; 
        }
    }
}
