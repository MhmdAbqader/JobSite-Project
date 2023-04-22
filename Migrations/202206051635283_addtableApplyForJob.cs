namespace trial2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableApplyForJob : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyForJobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MSG = c.String(),
                        DATE = c.DateTime(nullable: false),
                        JodId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        job_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.job_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.job_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyForJobs", "job_Id", "dbo.Jobs");
            DropIndex("dbo.ApplyForJobs", new[] { "job_Id" });
            DropIndex("dbo.ApplyForJobs", new[] { "UserId" });
            DropTable("dbo.ApplyForJobs");
        }
    }
}
