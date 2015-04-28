using BugTrackerAM.Models.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerAM.Models
{
    public class ProjectUsersViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public ApplicationUser Users { get;  set; }
    }
}