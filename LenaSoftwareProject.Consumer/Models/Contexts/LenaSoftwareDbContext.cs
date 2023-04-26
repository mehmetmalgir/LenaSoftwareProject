using Microsoft.EntityFrameworkCore;

namespace LenaSoftwareProject.Consumer.Models.Contexts
{
    public class LenaSoftwareDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-J3DG8F2;database=LenaSoftwareDb;trusted_connection=true;");
        }

        public DbSet<User> Users { get; set; }






    }
}
