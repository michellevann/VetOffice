namespace VetOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pet", "ReasonForVisit", c => c.Int(nullable: false));
            DropTable("dbo.Reason");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reason",
                c => new
                    {
                        VisitId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ReasonForVisit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitId);
            
            DropColumn("dbo.Pet", "ReasonForVisit");
        }
    }
}
