﻿using AuthorizationService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.AppDbContext
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.id)
                .IsUnique();
        }
    }
}
