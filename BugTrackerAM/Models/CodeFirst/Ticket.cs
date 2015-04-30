using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerAM.Models.CodeFirst
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title {get;set;}
        public string Description { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public int ProjectId { get; set; }
        public int TicketTypeId { get; set; }
        public int TicketPriorityId { get; set; }
        public int TicketStatusId { get; set; }
        public string OwnerUserId { get; set; }
        public string AssignedToUserId { get; set; }

        public virtual Project Project {get; set; }
        public virtual TicketTypes TicketType {get; set; }
        public virtual TicketPriorities TicketPriority {get; set; }
        public virtual TicketStatuses TicketStatus {get; set; }
        public virtual ApplicationUser UserAssigned { get; set; }
        public virtual ApplicationUser OwnerUser { get; set; }    
       // public virtual OwnerUserId OwnerUser { get; set; }     

        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public virtual ICollection<TicketComments> TicketComments { get; set; }
        public virtual ICollection<TicketHistories> TicketHistories { get; set; }
        public virtual ICollection<TicketNotifications> TicketNotifications { get; set; }
        
     
    }
}