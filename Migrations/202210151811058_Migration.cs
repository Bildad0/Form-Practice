namespace UserFormApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DepartmentInfo", "Department_DepartmentId", "dbo.DepartmentInfo");
            DropForeignKey("dbo.JobDepartments", "Job_JobId", "dbo.JobInfo");
            DropForeignKey("dbo.JobDepartments", "Department_DepartmentId", "dbo.DepartmentInfo");
            DropForeignKey("dbo.UserInfo", "DepertmentId", "dbo.DepartmentInfo");
            DropForeignKey("dbo.UserInfo", "UserJobId", "dbo.JobInfo");
            DropIndex("dbo.DepartmentInfo", new[] { "Department_DepartmentId" });
            DropIndex("dbo.UserInfo", new[] { "UserJobId" });
            DropIndex("dbo.UserInfo", new[] { "DepertmentId" });
            DropIndex("dbo.JobDepartments", new[] { "Job_JobId" });
            DropIndex("dbo.JobDepartments", new[] { "Department_DepartmentId" });
            AddColumn("dbo.JobInfo", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.JobInfo", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobInfo", "UserId");
            CreateIndex("dbo.JobInfo", "DepartmentId");
            AddForeignKey("dbo.JobInfo", "DepartmentId", "dbo.DepartmentInfo", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.JobInfo", "UserId", "dbo.UserInfo", "UserId", cascadeDelete: true);
            DropColumn("dbo.DepartmentInfo", "Department_DepartmentId");
            DropColumn("dbo.UserInfo", "UserJobId");
            DropColumn("dbo.UserInfo", "DepertmentId");
            DropTable("dbo.JobDepartments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobDepartments",
                c => new
                    {
                        Job_JobId = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_JobId, t.Department_DepartmentId });
            
            AddColumn("dbo.UserInfo", "DepertmentId", c => c.Int());
            AddColumn("dbo.UserInfo", "UserJobId", c => c.Int());
            AddColumn("dbo.DepartmentInfo", "Department_DepartmentId", c => c.Int());
            DropForeignKey("dbo.JobInfo", "UserId", "dbo.UserInfo");
            DropForeignKey("dbo.JobInfo", "DepartmentId", "dbo.DepartmentInfo");
            DropIndex("dbo.JobInfo", new[] { "DepartmentId" });
            DropIndex("dbo.JobInfo", new[] { "UserId" });
            DropColumn("dbo.JobInfo", "DepartmentId");
            DropColumn("dbo.JobInfo", "UserId");
            CreateIndex("dbo.JobDepartments", "Department_DepartmentId");
            CreateIndex("dbo.JobDepartments", "Job_JobId");
            CreateIndex("dbo.UserInfo", "DepertmentId");
            CreateIndex("dbo.UserInfo", "UserJobId");
            CreateIndex("dbo.DepartmentInfo", "Department_DepartmentId");
            AddForeignKey("dbo.UserInfo", "UserJobId", "dbo.JobInfo", "JobId");
            AddForeignKey("dbo.UserInfo", "DepertmentId", "dbo.DepartmentInfo", "DepartmentId");
            AddForeignKey("dbo.JobDepartments", "Department_DepartmentId", "dbo.DepartmentInfo", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.JobDepartments", "Job_JobId", "dbo.JobInfo", "JobId", cascadeDelete: true);
            AddForeignKey("dbo.DepartmentInfo", "Department_DepartmentId", "dbo.DepartmentInfo", "DepartmentId");
        }
    }
}
