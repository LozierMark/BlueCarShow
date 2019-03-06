using CarShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShow.Controllers
{
    [Authorize]
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult Index()
        {
            var model = new CarListItem[0];
            return View(model);
        }

        //Add method here VVVV
        // GET
        public ActionResult Create()
        {
            return View();
        }
        //Add code here vvvv
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}

