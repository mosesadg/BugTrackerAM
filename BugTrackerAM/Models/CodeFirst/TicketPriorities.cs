using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerAM.Models.CodeFirst
{
    public class TicketPriorities
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}