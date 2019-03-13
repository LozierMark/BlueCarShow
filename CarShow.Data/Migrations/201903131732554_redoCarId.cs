namespace CarShow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class redoCarId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vote", "CarId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vote", "CarId", c => c.Int(nullable: false));
        }
    }
}
