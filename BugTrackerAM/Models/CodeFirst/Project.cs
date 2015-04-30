using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerAM.Models.CodeFirst
{
    public class Project
    {
        public Project ()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Tickets = new HashSet<Ticket>();

        }

        public int Id { get; set; }

        public string Name { get; set; }


        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }

    }


}