namespace Bandemic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTourDateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TourDate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfShow = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TourDate");
        }
    }
}
