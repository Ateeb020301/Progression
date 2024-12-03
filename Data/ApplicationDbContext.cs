using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Models.Profile> Profile { get; set; }
    }
}
