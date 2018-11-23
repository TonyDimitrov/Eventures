using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Web;

namespace Data.Web
{
    public class EventuresDbContext : IdentityDbContext<EventureUser>
    {
        public EventuresDbContext(DbContextOptions<EventuresDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventureUser> EventureUsers { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EventureUser>()
                .HasMany(u => u.Events)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            builder.Entity<EventureUser>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            builder.Entity<Event>()
                .HasOne(e => e.Order)
                .WithOne(o => o.Event)
                .HasForeignKey<Order>(o => o.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Order>()
                .HasOne(o => o.Event)
                .WithOne(e => e.Order)
                .HasForeignKey<Event>(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
