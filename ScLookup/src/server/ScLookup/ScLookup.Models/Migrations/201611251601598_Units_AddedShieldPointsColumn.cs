namespace ScLookup.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Units_AddedShieldPointsColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Units", "ShieldPoints", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Units", "ShieldPoints");
        }
    }
}
