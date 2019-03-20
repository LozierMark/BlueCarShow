using CarShow.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShow.Controllers
{
    public class RoleController : Controller
    {
        public bool IsAdminUser(Guid userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                foreach (var role in ctx.Users.Where(e => e.Id == userID.ToString()).Single().Roles)
                {
                    if (role.ToString() == "Admin") return true;
                }
                return false;
            }
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsAdminUser(Guid.Parse(User.Identity.GetUserId())))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            var Roles = new ApplicationDbContext().Roles.ToList();
            return View(Roles);
        }

    }
}

