namespace VetOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointment", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointment", "PetId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointment", "CustomerId");
            CreateIndex("dbo.Appointment", "PetId");
            AddForeignKey("dbo.Appointment", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Appointment", "PetId", "dbo.Pet", "PetId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "PetId", "dbo.Pet");
            DropForeignKey("dbo.Appointment", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Appointment", new[] { "PetId" });
            DropIndex("dbo.Appointment", new[] { "CustomerId" });
            DropColumn("dbo.Appointment", "PetId");
            DropColumn("dbo.Appointment", "CustomerId");
        }
    }
}
