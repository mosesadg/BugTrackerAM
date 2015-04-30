
using BugTrackerAM.Models.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using BugTrackerAM.Models;

namespace BugTrackerAM.Helpers
{
    public class UserProjectsHelper
    {


       // private BugTrackerAM.Models.ApplicationDbContext db = new ApplicationDbContext();


        public static ApplicationDbContext db = new ApplicationDbContext();
        public bool IsUserInProject(string userId, int projectId)
        {
            
            if (db.Projects.Include(p => p.Users).FirstOrDefault(pr => pr.Id == projectId).Users.Any(u => u.Id == userId))
            {
                return true;
            }
            return false;
        }

       public bool IsUserNotInProject(string userId, int projectId)
        {
            return !db.Projects.Find(projectId).Users.Any(u => u.Id == userId);
        }

        public void AddUserToProject(string userId, int projectId)
        {
            if (!IsUserInProject(userId, projectId))
            {
                var project = db.Projects.Find(projectId);       //(Good Example)
                project.Users.Add(db.Users.Find(userId));
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void RemoveUserFromProject(string userId, int projectId)
        {
            if (IsUserInProject(userId, projectId))
            {
                var project = db.Projects.Find(projectId);
                project.Users.Remove(db.Users.Find(userId));
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public ICollection<Project> ListProjectsForUser(string userId)
        {
            return db.Projects.Where(p => p.Users.Any(u => u.Id == userId)).ToList();
        }

        public ICollection<ApplicationUser> ListUsersOnProject(int projectId)
        {
            //return db.Projects.Find(projectId).Users;//old statmenet
            //return db.Users.Where(u => u.Projects.All(p => p.Id = projectId)).ToList();
            
            return db.Projects.Include(p => p.Users).FirstOrDefault(pr => pr.Id == projectId).Users;//just changed

            //return db.ProjectUsers.Where(u => u.  p => p.ProjectUsers).FirstOrDefault(pr => pr.Id == projectId).ProjectUsers;
        }


        public ICollection<ApplicationUser> ListUsersNotOnProject(int projectId)
        {
        
            //Efficient
            //return db.ProjectUsers.Where(u => u.Projects.(p => p.Id != projectId)).ToList();

            return db.Users.Where(u => u.Projects.All(p=> p.Id != projectId)).ToList();

        }
    }
}











