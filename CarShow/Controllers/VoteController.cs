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
    public class VoteController : Controller
    {
        // GET: Vote
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VoteService(userId);
            var model = service.Getvotes();
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
        public ActionResult Create(VoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateVoteService();

            if (service.CreateVote(model))
            {
                TempData["SaveResult"] = "Your vote was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Vote could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateVoteService();
            var model = svc.GetVoteById(id);

            return View(model);
        }
        private VoteService CreateVoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VoteService(userId);
            return service;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VoteEdit model)
        {
            if (ModelState.IsValid) return View(model);

            if (model.VoteId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateVoteService();

            if (service.UpdateVote(model))
            {
                TempData["SaveResult"] = "Your vote was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your vote could not be updated.");
            return View(model);

        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateVoteService();
            service.DeleteVote(id);
            TempData["SaveResult"] = "Your vote was deleted";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = CreateVoteService();
            var detail = service.GetVoteById(id);
            var model =

                new VoteEdit
                {
                    VoteId = detail.VoteId,
                    OwnerId = detail.OwnerId,
                    Paint = detail.Paint,
                    Engine = detail.Engine,
                    Interior = detail.Interior,
                    BestOfShow = detail.BestOfShow,
                    ModifiedUtc = DateTimeOffset.UtcNow,
                    CreatedUtc = DateTimeOffset.UtcNow,
                };
            return View(model);
        }
        public ActionResult ShowWinners()
        {
            var svc = CreateWinnerService();
            int[] results = svc.FindWinners();
            var model = new WinnerModel
            {
                bestpaint = results[0],
                bestengine = results[1],
                bestinterior = results[2],
                bestofshow = results[3]
            };
            return View(model);
            
        }
        private WinnerService CreateWinnerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WinnerService(userId);
            return service;
        }

    }
    
}

