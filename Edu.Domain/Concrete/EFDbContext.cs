using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Edu.Domain.Entities;

namespace Edu.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

    }
}
