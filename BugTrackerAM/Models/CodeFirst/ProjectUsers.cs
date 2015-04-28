using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerAM.Models.CodeFirst
{
    public class ProjectUsers
    {
        
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }

        public virtual Project Projects { get; set; }
        public virtual ApplicationUser UserAssigned { get; set; }
      }
}