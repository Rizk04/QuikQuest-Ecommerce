

using Microsoft.EntityFrameworkCore;
using QuikQuest.Models;

namespace QuikQuest.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasMany(c => c.Carts)
            .WithMany(p => p.Products)
            .UsingEntity<Dictionary<string, object>>("CartProducts",
            cp => cp.HasOne<Cart>()
            .WithMany()
            .HasForeignKey("CartId"),
            cp => cp.HasOne<Product>()
            .WithMany()
            .HasForeignKey("ProductId"),

             cp =>
             {
                 cp.ToTable("CartProducts");
                 cp.Property<int>("CartProductId")
                     .ValueGeneratedOnAdd();
                 cp.HasKey("CartProductId");
             });
            


        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Question> Questions { get; set; }

    }
}
