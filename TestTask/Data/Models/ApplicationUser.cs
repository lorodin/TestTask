using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

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