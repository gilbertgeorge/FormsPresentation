namespace ScLookup.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_DependencyTableForUnits : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnitDependencies",
                c => new
                    {
                        TargetUnitId = c.Guid(nullable: false),
                        DependentUnitId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.TargetUnitId, t.DependentUnitId })
                .ForeignKey("dbo.Units", t => t.DependentUnitId, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.TargetUnitId)
                .Index(t => t.TargetUnitId)
                .Index(t => t.DependentUnitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UnitDependencies", "TargetUnitId", "dbo.Units");
            DropForeignKey("dbo.UnitDependencies", "DependentUnitId", "dbo.Units");
            DropIndex("dbo.UnitDependencies", new[] { "DependentUnitId" });
            DropIndex("dbo.UnitDependencies", new[] { "TargetUnitId" });
            DropTable("dbo.UnitDependencies");
        }
    }
}
