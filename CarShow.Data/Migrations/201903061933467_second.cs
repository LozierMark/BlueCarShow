namespace CarShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Car");
            AlterColumn("dbo.Car", "CarId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Car", "OwnerId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Car", "CarId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Car");
            AlterColumn("dbo.Car", "OwnerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Car", "CarId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Car", "CarId");
        }
    }
}
