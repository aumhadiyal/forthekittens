using forthekittens_razor.Models;
using Microsoft.EntityFrameworkCore;

namespace forthekittens_razor.Data
{
    public class Kittensdbcontext_razor:DbContext
    {
        public Kittensdbcontext_razor(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Kitten1", DisplayOrder = 1 }
            );
        }
    }
}
