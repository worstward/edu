using System;
using System.Collections.Generic;

namespace Edu.Domain.Models
{
    public partial class CourseDescription
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Nullable<int> CourseLength { get; set; }
        public virtual Course Course { get; set; }
    }
}
