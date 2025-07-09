using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Mapping;

namespace Persistence.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(new BooksMap().Configure)
                .HasDefaultSchema("Library");
            base.OnModelCreating(modelBuilder);
        }
    }
}
