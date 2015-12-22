using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Edu.Domain.Models.Mapping;
using Edu.Domain.Abstract;
using Edu.Domain.Models;

namespace Edu.Domain.Concrete
{
    public partial class TestDbContext : DbContext, IDbContext
    {
        static TestDbContext()
        {
            Database.SetInitializer<TestDbContext>(null);
        }

        public TestDbContext()
            : base("Name=TestDbContext")
        {
        }

        public DbSet<CourseDescription> CourseDescriptions { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CourseDescriptionMap());
            modelBuilder.Configurations.Add(new CourseMap());
        }
    }
}
