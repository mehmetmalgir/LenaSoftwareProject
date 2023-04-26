
using LenaSoftware.API.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;



namespace LenaSoftware.API.DataAccess.Implementations.EntityFramework.Contexts
{
    public class LenaSoftwareDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-J3DG8F2;database=LenaSoftwareDb;trusted_connection=true;");
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Fields> Fields { get; set; }
        public DbSet<User> Users { get; set; }
        





    }
}
