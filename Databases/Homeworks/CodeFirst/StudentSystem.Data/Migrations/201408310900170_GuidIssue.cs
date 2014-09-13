namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuidIssue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Homework", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentsInCourses", "StudentId", "dbo.Students");
            DropIndex("dbo.Students", new[] { "Number" });
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "Number", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Students", "StudentId");
            CreateIndex("dbo.Students", "Number", unique: true);
            AddForeignKey("dbo.Homework", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.StudentsInCourses", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentsInCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Homework", "StudentId", "dbo.Students");
            DropIndex("dbo.Students", new[] { "Number" });
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "Number", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Students", "StudentId");
            CreateIndex("dbo.Students", "Number", unique: true);
            AddForeignKey("dbo.StudentsInCourses", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.Homework", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
    }
}
