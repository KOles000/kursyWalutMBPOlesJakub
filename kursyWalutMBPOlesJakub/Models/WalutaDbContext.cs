using Microsoft.EntityFrameworkCore;

namespace kursyWalutMBPOlesJakub.Models
{
    public class WalutaDbContext : DbContext
    {
        public WalutaDbContext(DbContextOptions<WalutaDbContext> options) : base(options) { }

        public DbSet<Waluta> Walutas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Waluta>(builder =>
            {
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Currency).IsRequired();
                builder.Property(p => p.Code).IsRequired();
                builder.Property(p => p.EffectiveDate).IsRequired();
                builder.Property(p => p.Bid).IsRequired();
                builder.Property(p => p.Ask).IsRequired();
            });
        }
    }
}
