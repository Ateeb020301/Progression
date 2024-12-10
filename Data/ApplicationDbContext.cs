using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Progression.Models;

namespace Progression.Data
{
    public class ApplicationDbContext : DbContext
    {
        private string _Connect;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _Connect = configuration.GetValue<string>("ConnectionStrings:DevConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_Connect);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
        }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Milestone> Milestone { get; set; }
        public DbSet<Goal> Goal { get; set; }


    }
}
