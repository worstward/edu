using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Edu.Domain.Models;

namespace Edu.Domain.Abstract
{
    public interface IDbContext
    {
        DbSet<Course> Courses { get; set; }
    }
}
