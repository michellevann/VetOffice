namespace VetOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPetTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pet",
                c => new
                    {
                        PetId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        PetName = c.String(nullable: false),
                        TypeOfPet = c.Int(nullable: false),
                        AgeOfPet = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            DropColumn("dbo.Customer", "PetName");
            DropColumn("dbo.Customer", "TypeOfPet");
            DropColumn("dbo.Customer", "AgeOfPet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "AgeOfPet", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "TypeOfPet", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "PetName", c => c.String(nullable: false));
            DropForeignKey("dbo.Pet", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Pet", new[] { "CustomerId" });
            DropTable("dbo.Pet");
        }
    }
}
