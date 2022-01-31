namespace UniApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniApp.Models;
    using UniApp.Repositories;

    public class StudiosController : Controller
    {
        private readonly IStudioRepository _repo;
        public StudiosController(IStudioRepository repo)
        {
            this._repo = repo;
        }
        public IActionResult Index()
        {
            var data = this._repo.GetStudios();
            return View(data);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] Studio studio)
        {
            if (!ModelState.IsValid)
            {
                return View(studio);
            }
         
            this._repo.AddStudio(studio);
            return RedirectToAction(nameof(Index));
        }

        //Get
        public IActionResult Details(int id)
        {
            var studioView = this._repo.GetById(id);
            if (studioView == null)
            {
                return View("404");
            }

            return View(studioView);
        }

        //Get
        public IActionResult Edit(int id)
        {
            var studioView = this._repo.GetById(id);
            if (studioView == null)
            {
                return View("404");
            }

            return View(studioView);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, Name")] Studio studio)
        {
            if (!ModelState.IsValid)
            {
                return View(studio);
            }

            this._repo.Update(id, studio);

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
