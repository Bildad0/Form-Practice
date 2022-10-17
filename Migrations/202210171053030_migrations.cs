namespace UserFormApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DepartmentInfo", "Department_DepartmentId", "dbo.DepartmentInfo");
            DropForeignKey("dbo.JobDepartments", "Job_JobId", "dbo.JobInfo");
            DropForeignKey("dbo.JobDepartments", "Department_DepartmentId", "dbo.DepartmentInfo");
            DropForeignKey("dbo.UserInfo", "DepertmentId", "dbo.DepartmentInfo");
            DropIndex("dbo.DepartmentInfo", new[] { "Department_DepartmentId" });
            DropIndex("dbo.UserInfo", new[] { "DepertmentId" });
            DropIndex("dbo.JobDepartments", new[] { "Job_JobId" });
            DropIndex("dbo.JobDepartments", new[] { "Department_DepartmentId" });
            RenameColumn(table: "dbo.UserInfo", name: "UserJobId", newName: "job_JobId");
            RenameIndex(table: "dbo.UserInfo", name: "IX_UserJobId", newName: "IX_job_JobId");
            AddColumn("dbo.DepartmentInfo", "DepLocation", c => c.String());
            AddColumn("dbo.JobInfo", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.UserInfo", "JobTitle", c => c.String());
            CreateIndex("dbo.JobInfo", "DepartmentId");
            AddForeignKey("dbo.JobInfo", "DepartmentId", "dbo.DepartmentInfo", "DepartmentId", cascadeDelete: true);
            DropColumn("dbo.DepartmentInfo", "DepartmentLocation");
            DropColumn("dbo.DepartmentInfo", "Department_DepartmentId");
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
            AddColumn("dbo.DepartmentInfo", "Department_DepartmentId", c => c.Int());
            AddColumn("dbo.DepartmentInfo", "DepartmentLocation", c => c.Geography());
            DropForeignKey("dbo.JobInfo", "DepartmentId", "dbo.DepartmentInfo");
            DropIndex("dbo.JobInfo", new[] { "DepartmentId" });
            DropColumn("dbo.UserInfo", "JobTitle");
            DropColumn("dbo.JobInfo", "DepartmentId");
            DropColumn("dbo.DepartmentInfo", "DepLocation");
            RenameIndex(table: "dbo.UserInfo", name: "IX_job_JobId", newName: "IX_UserJobId");
            RenameColumn(table: "dbo.UserInfo", name: "job_JobId", newName: "UserJobId");
            CreateIndex("dbo.JobDepartments", "Department_DepartmentId");
            CreateIndex("dbo.JobDepartments", "Job_JobId");
            CreateIndex("dbo.UserInfo", "DepertmentId");
            CreateIndex("dbo.DepartmentInfo", "Department_DepartmentId");
            AddForeignKey("dbo.UserInfo", "DepertmentId", "dbo.DepartmentInfo", "DepartmentId");
            AddForeignKey("dbo.JobDepartments", "Department_DepartmentId", "dbo.DepartmentInfo", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.JobDepartments", "Job_JobId", "dbo.JobInfo", "JobId", cascadeDelete: true);
            AddForeignKey("dbo.DepartmentInfo", "Department_DepartmentId", "dbo.DepartmentInfo", "DepartmentId");
        }
    }
}
