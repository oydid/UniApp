namespace UniApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniApp.Models;
    using UniApp.Repositories;

    public class ActorsController : Controller
    {
        private readonly IActorRepository _repo;
        public ActorsController(IActorRepository repo)
        {
            this._repo = repo;
        }
        public IActionResult Index()
        {
            var data = this._repo.GetActors();
            return View(data);
        }

        //Get
        [Authorize]
        public IActionResult Create()
        {
            if (User.Identity.Name != "test@test.com")
            {
                return View("403");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Name, Description, Image")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
         
            this._repo.AddActor(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get
        [Authorize]
        public IActionResult Details(int id)
        {
            var actorView = this._repo.GetById(id);
            if (actorView == null)
            {
                return View("404");
            }

            if (User.Identity.Name != "test@test.com")
            {
                return View("403");
            }

            return View(actorView);
        }

        //Get
        [Authorize]
        public IActionResult Edit(int id)
        {
            
            var actorView = this._repo.GetById(id);
            if (actorView == null)
            {
                return View("404");
            }

            if (User.Identity.Name != "test@test.com")
            {
                return View("403");
            }

            return View(actorView);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, [Bind("Id, Name, Description, Image")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            this._repo.Update(id, actor);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int id)
        {
            this._repo.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
