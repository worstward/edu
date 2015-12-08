using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Edu.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column("ShortDescription", TypeName = "NVARCHAR")]
        public string ShortDescription { get; set; }
        [Column("LongDescription", TypeName = "NVARCHAR")]
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
    }
}
