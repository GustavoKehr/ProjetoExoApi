using ExoApiProject.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoApiProject.WebApi.Contexts
{
    public class ExoApiProjectContext : DbContext
    {
        public ExoApiProjectContext()
        { 
        }

        public ExoApiProjectContext(DbContextOptions<ExoApiProjectContext> options) : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-174R7TJ\\SQLEXPRESS; initial catalog = ExoApiProject;Integrated Security = true");
            }
        }
        public DbSet<Project> Project { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
