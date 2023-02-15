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
    }
}
