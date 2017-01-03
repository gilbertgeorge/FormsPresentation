using System.Data.Entity;

namespace ScLookup.Models.Context
{
    public class StarcraftContext : DbContext, IContext
    {
        public IDbSet<Unit> Units { get; set; }
        public IDbSet<UnitDependency> UnitDependencies { get; set; }
        public IDbSet<UnitProduction> UnitProductions { get; set; }

        public StarcraftContext() : base("StarcraftConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitProduction>()
                .HasKey(x => x.UnitId);

            modelBuilder.Entity<Unit>()
                .HasRequired(x => x.Production)
                .WithRequiredPrincipal(x => x.Unit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnitProduction>()
                .HasRequired<Unit>(x => x.ProducedBy)
                .WithMany(x => x.UnitsProduced)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnitDependency>()
                .HasRequired(x => x.TargetUnit)
                .WithMany(x => x.Dependencies)
                .WillCascadeOnDelete(false);
        }
    }
}