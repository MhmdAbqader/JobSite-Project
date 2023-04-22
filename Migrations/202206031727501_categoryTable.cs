namespace trial2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cats1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        catname = c.String(nullable: false),
                        catdescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cats1");
        }
    }
}
