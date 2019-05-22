using Coffee.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Coffee.Data
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> options)
            : base(options)
        { }

        public CoffeeContext()
        {
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventUser>()
                .HasKey(x => new
                {
                    x.UserId,
                    x.EventId
                });
        }
    }

}
