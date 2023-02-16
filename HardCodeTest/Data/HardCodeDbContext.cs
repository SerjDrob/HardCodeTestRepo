using Microsoft.EntityFrameworkCore;
using HardCodeData.Models;

namespace HardCodeTest.Data
{
    public class HardCodeDbContext:DbContext
    {
        public HardCodeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MiscField> MiscFields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.MiscFields)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MiscField>()
                .HasMany(mf=>mf.MiscFieldValues)
                .WithOne(v=>v.MiscField)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Category>()
                .HasMany(c=>c.Products)
                .WithOne(p=>p.Category)
                .OnDelete(DeleteBehavior.Cascade);
            //base.OnModelCreating(modelBuilder);
        }
    }
}
