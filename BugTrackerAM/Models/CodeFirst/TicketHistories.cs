using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerAM.Models.CodeFirst
{
    public class TicketHistories
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string property { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Changed { get; set; }
        public int UserId { get; set; }

        public virtual Ticket Tickets { get; set; }
        public virtual ApplicationUser UserAssigned { get; set; }
        
    }
}