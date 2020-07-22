using System;
using Microsoft.EntityFrameworkCore;
using Domain.Core.Models;
using Aplication.Interfaces;

namespace Presistence {
    public class AppDbContext : DbContext, IAppDbContext {

        // User
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }


    }
}