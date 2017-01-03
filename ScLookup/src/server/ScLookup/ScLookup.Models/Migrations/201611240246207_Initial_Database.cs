namespace ScLookup.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnitProductions",
                c => new
                    {
                        UnitId = c.Guid(nullable: false),
                        ProducedById = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("dbo.Units", t => t.UnitId)
                .ForeignKey("dbo.Units", t => t.ProducedById)
                .Index(t => t.UnitId)
                .Index(t => t.ProducedById);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        HitPoints = c.Int(nullable: false),
                        MineralCost = c.Int(nullable: false),
                        GasCost = c.Int(nullable: false),
                        BuildTime = c.Int(nullable: false),
                        Faction = c.Int(nullable: false),
                        UnitType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UnitProductions", "ProducedById", "dbo.Units");
            DropForeignKey("dbo.UnitProductions", "UnitId", "dbo.Units");
            DropIndex("dbo.UnitProductions", new[] { "ProducedById" });
            DropIndex("dbo.UnitProductions", new[] { "UnitId" });
            DropTable("dbo.Units");
            DropTable("dbo.UnitProductions");
        }
    }
}
