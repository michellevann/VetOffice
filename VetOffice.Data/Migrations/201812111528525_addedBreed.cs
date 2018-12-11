namespace VetOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBreed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pet", "Breed", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pet", "Breed");
        }
    }
}
