﻿using BugTrackerAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BugTrackerAM.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Admin
        public ActionResult Users()
        {
        
            return View(db.Users.ToList());
        }
    //[Authorize]
    public ActionResult EditUser(string Id)
    {

        var user = db.Users.Find(Id);

        var roleList = db.Roles.Select(r => new UserRoleViewModel { Name = r.Name, UserId = Id, IsInRole = r.Users.Any(u => u.UserId == Id) });

        var selected = roleList.Where(r => r.IsInRole).Select(n => n.Name).ToArray();

        var selectList = new MultiSelectList(roleList, "Name", "Name", selected);

        var model = new AdminUserViewModel
        {
            User = user,
            Roles = selectList,
            SelectedRoles = selected
        };
        
        return View(model);
    }
    

        [HttpPost]
        public ActionResult EditUser(AdminUserViewModel model)
    {
        var user = db.Users.Find(model.User.Id);
        var um = Request.GetOwinContext().Get<ApplicationUserManager>();

            foreach(var role in db.Roles.ToList())
            {
                if (model.SelectedRoles.Contains(role.Name))
                    um.AddToRole(user.Id, role.Name);
                else
                    um.RemoveFromRole(user.Id, role.Name);
             }
            return RedirectToAction("EditUser", new { Id = model.User.Id });

     }
    }
}