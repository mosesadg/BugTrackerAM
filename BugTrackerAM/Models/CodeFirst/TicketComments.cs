using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerAM.Models.CodeFirst
{
    public class TicketComments
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset Created { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }


        public virtual Ticket Tickets { get; set; }
        public virtual ApplicationUser UserAssigned { get; set; }
    }
}