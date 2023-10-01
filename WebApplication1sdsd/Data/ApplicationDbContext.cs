﻿using Microsoft.EntityFrameworkCore;
using WebApplication1sdsd.Models;

namespace WebApplication1sdsd.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID=1,Name="Action",DisplayOrder=1 },
                new Category { ID=2,Name="Scarify",DisplayOrder=2},
                new Category { ID=3,Name="History",DisplayOrder=3 }
                );


        }
    }
}
