namespace UMS_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseModellingV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        AdditionalInfo = c.String(),
                        OnlineMeeting = c.Boolean(nullable: false),
                        Address = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateStop = c.DateTime(nullable: false),
                        CourseModuleId = c.Int(nullable: false),
                        SupervisorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseModules", t => t.CourseModuleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.SupervisorId)
                .Index(t => t.CourseModuleId)
                .Index(t => t.SupervisorId);
            
            CreateTable(
                "dbo.CourseModules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseModels", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        AdditionalInfo = c.String(),
                        Price = c.Double(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        SupervisorId = c.String(maxLength: 128),
                        CourseExamsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SupervisorId)
                .Index(t => t.SupervisorId);
            
            CreateTable(
                "dbo.CourseExams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        DateOpen = c.DateTime(nullable: false),
                        LengthInMinutes = c.Int(nullable: false),
                        IsOnline = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseModels", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.StudentCourseExamDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Passed = c.Boolean(nullable: false),
                        ExamResult = c.Double(nullable: false),
                        StudentId = c.String(maxLength: 128),
                        CourseExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseExams", t => t.CourseExamId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseExamId);
            
            CreateTable(
                "dbo.AccountOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Amount = c.Double(nullable: false),
                        OperationDate = c.DateTime(nullable: false),
                        IsPosted = c.Boolean(nullable: false),
                        WalletId = c.String(maxLength: 128),
                        CourseFeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseModels", t => t.CourseFeeId)
                .ForeignKey("dbo.WalletModels", t => t.WalletId)
                .Index(t => t.WalletId)
                .Index(t => t.CourseFeeId);
            
            CreateTable(
                "dbo.WalletModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CourseActivityApplicationUsers",
                c => new
                    {
                        CourseActivity_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseActivity_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.CourseActivities", t => t.CourseActivity_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.CourseActivity_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.CourseModelApplicationUsers",
                c => new
                    {
                        CourseModel_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseModel_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.CourseModels", t => t.CourseModel_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.CourseModel_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "WalletId", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WalletModels", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseActivities", "SupervisorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseActivities", "CourseModuleId", "dbo.CourseModules");
            DropForeignKey("dbo.CourseModules", "CourseId", "dbo.CourseModels");
            DropForeignKey("dbo.CourseModels", "SupervisorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseModelApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseModelApplicationUsers", "CourseModel_Id", "dbo.CourseModels");
            DropForeignKey("dbo.AccountOperations", "WalletId", "dbo.WalletModels");
            DropForeignKey("dbo.AccountOperations", "CourseFeeId", "dbo.CourseModels");
            DropForeignKey("dbo.CourseExams", "CourseId", "dbo.CourseModels");
            DropForeignKey("dbo.StudentCourseExamDatas", "StudentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentCourseExamDatas", "CourseExamId", "dbo.CourseExams");
            DropForeignKey("dbo.CourseActivityApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseActivityApplicationUsers", "CourseActivity_Id", "dbo.CourseActivities");
            DropIndex("dbo.CourseModelApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CourseModelApplicationUsers", new[] { "CourseModel_Id" });
            DropIndex("dbo.CourseActivityApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CourseActivityApplicationUsers", new[] { "CourseActivity_Id" });
            DropIndex("dbo.WalletModels", new[] { "Id" });
            DropIndex("dbo.AccountOperations", new[] { "CourseFeeId" });
            DropIndex("dbo.AccountOperations", new[] { "WalletId" });
            DropIndex("dbo.StudentCourseExamDatas", new[] { "CourseExamId" });
            DropIndex("dbo.StudentCourseExamDatas", new[] { "StudentId" });
            DropIndex("dbo.CourseExams", new[] { "CourseId" });
            DropIndex("dbo.CourseModels", new[] { "SupervisorId" });
            DropIndex("dbo.CourseModules", new[] { "CourseId" });
            DropIndex("dbo.CourseActivities", new[] { "SupervisorId" });
            DropIndex("dbo.CourseActivities", new[] { "CourseModuleId" });
            DropColumn("dbo.AspNetUsers", "WalletId");
            DropTable("dbo.CourseModelApplicationUsers");
            DropTable("dbo.CourseActivityApplicationUsers");
            DropTable("dbo.WalletModels");
            DropTable("dbo.AccountOperations");
            DropTable("dbo.StudentCourseExamDatas");
            DropTable("dbo.CourseExams");
            DropTable("dbo.CourseModels");
            DropTable("dbo.CourseModules");
            DropTable("dbo.CourseActivities");
        }
    }
}
