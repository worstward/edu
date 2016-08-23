namespace Edu.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseDescription",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        CourseLength = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseDescription", "Id", "dbo.Courses");
            DropIndex("dbo.CourseDescription", new[] { "Id" });
            DropTable("dbo.Courses");
            DropTable("dbo.CourseDescription");
        }
    }
}
