using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
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