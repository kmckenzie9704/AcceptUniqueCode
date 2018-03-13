using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AcceptUniqueCode.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
            { }

        public DbSet<UniqueCode> UniqueCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UniqueCode.OnModelCreating(modelBuilder);

        }
    }
}