using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Data.Models
{
    public class ApplicationUser: IdentityUser
    {
        public virtual IEnumerable<Film> Films { get; set; }
        public ApplicationUser()
        {

        }
    }
}