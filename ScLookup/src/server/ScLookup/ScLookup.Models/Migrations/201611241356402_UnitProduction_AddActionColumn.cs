namespace ScLookup.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitProduction_AddActionColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnitProductions", "Action", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UnitProductions", "Action");
        }
    }
}
