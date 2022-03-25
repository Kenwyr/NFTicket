using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NFT_API.Models;

namespace NFT_API.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist_Event>().HasKey(ae => new
            {
                ae.ArtistId,
                ae.EventId
            });

            modelBuilder.Entity<Artist_Event>().HasOne(e => e.Event).WithMany(ae => ae.Artists_Events).HasForeignKey(e => e.EventId);

            modelBuilder.Entity<Artist_Event>().HasOne(e => e.Artist).WithMany(ae => ae.Artists_Events).HasForeignKey(e => e.ArtistId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Artist_Event> Artists_Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}