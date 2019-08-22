using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TestTask.Data.Models;

namespace TestTask.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Film> Films { get; set; }
        public ApplicationDbContext() : base("FilmsConnection") { }
        public static ApplicationDbContext Create()
        {
            
            return new ApplicationDbContext();
        }
    }
}