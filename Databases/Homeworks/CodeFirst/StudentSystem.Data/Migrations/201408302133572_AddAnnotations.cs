namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Homework", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(maxLength: 20));
            CreateIndex("dbo.Courses", "Name");
            CreateIndex("dbo.Students", "Number");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", new[] { "Number" });
            DropIndex("dbo.Courses", new[] { "Name" });
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Homework", "Content", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
