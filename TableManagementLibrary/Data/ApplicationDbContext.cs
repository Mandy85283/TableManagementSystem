using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TableManagementLibrary.Models;

namespace TableManagementLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

       
        public DbSet<foodType> FoodType { get; set; }
        public DbSet<flowers> Flowers { get; set; }
        public DbSet<tables> Tables { get; set; }
        public DbSet<tablePosition> tablePosition { get; set; }
        public DbSet<meal> Meal { get; set; }
        public DbSet<guest> Guests { get; set; }
        public string DbPath { get; private set; }

        public ApplicationDbContext()
        {
            var path = Environment.CurrentDirectory;
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}TableManagementDB.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
