namespace VetOffice.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDataToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "FullName", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "Apt", c => c.String());
            AddColumn("dbo.Customer", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "CanText", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customer", "Email", c => c.String());
            AlterColumn("dbo.Appointment", "ApptTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customer", "StreetAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "ZipCode", c => c.String(nullable: false));
            DropColumn("dbo.Customer", "FirstName");
            DropColumn("dbo.Customer", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "ZipCode", c => c.String());
            AlterColumn("dbo.Customer", "State", c => c.String());
            AlterColumn("dbo.Customer", "City", c => c.String());
            AlterColumn("dbo.Customer", "StreetAddress", c => c.String());
            AlterColumn("dbo.Appointment", "ApptTime", c => c.String());
            DropColumn("dbo.Customer", "Email");
            DropColumn("dbo.Customer", "CanText");
            DropColumn("dbo.Customer", "Phone");
            DropColumn("dbo.Customer", "Apt");
            DropColumn("dbo.Customer", "FullName");
        }
    }
}
