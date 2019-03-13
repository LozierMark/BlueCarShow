using CarShow.Models;
using CarShow.Services;
using Microsoft.AspNet.Identity;
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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CarService(userId);
            var model = service.GetCars();

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
            if (!ModelState.IsValid) return View(model);

            var service = CreateCarService();

            if (service.CreateCar(model))
            {
                TempData["SaveResult"] = "Your Car was created.";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "Car could not be created.");

            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateCarService();
            var model = svc.GetCarById(id);

            return View(model);
        }
        private CarService CreateCarService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CarService(userId);
            return service;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CarEdit model)
        {
            if (ModelState.IsValid) return View(model);

            if (model.CarId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCarService();

            if (service.UpdateCar(model))
            {
                TempData["SaveResult"] = "Your car was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your car could not be updated.");
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCarService();
            service.DeleteCar(id);
            TempData["SaveResult"] = "Your car was deleted";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCarService();

            var detail = service.GetCarById(id);

            new CarEdit
            {
                CarId = detail.CarId,
                Make = detail.Make,
                Model = detail.Model,
                Year = detail.Year,
                Color = detail.Color,
                ModifiedUtc = DateTimeOffset.UtcNow,
            };

            return View();
        }

    }
}