namespace trial2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        jobtitle = c.String(),
                        jobcontent = c.String(),
                        jobImage = c.String(),
                        cat_id = c.Int(nullable: false),
                        category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cats1", t => t.category_Id)
                .Index(t => t.category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "category_Id", "dbo.Cats1");
            DropIndex("dbo.Jobs", new[] { "category_Id" });
            DropTable("dbo.Jobs");
        }
    }
}
