using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerAM.Models.CodeFirst
{
    public class TicketNotifications
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; }

        public virtual Ticket Tickets { get; set; }
        public virtual ApplicationUser UserAssigned { get; set; }
    }
}