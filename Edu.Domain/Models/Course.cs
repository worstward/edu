using System;
using System.Collections.Generic;

namespace Edu.Domain.Models
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual CourseDescription CourseDescription { get; set; }
    }
}
