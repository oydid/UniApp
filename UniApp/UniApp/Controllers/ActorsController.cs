namespace UniApp.Controllers
{
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Description, Image")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            //TODO middleware 404 page
            this._repo.AddActor(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get
        public IActionResult Details(int id)
        {
            var actorView = this._repo.GetById(id);
            if (actorView == null)
            {
                return View("404");
            }

            return View(actorView);
        }

        //Get
        public IActionResult Edit(int id)
        {
            var actorView = this._repo.GetById(id);
            if (actorView == null)
            {
                return View("404");
            }

            return View(actorView);
        }

        [HttpPost]
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
        public IActionResult Delete(int id)
        {
            this._repo.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
