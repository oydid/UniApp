namespace UniApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniApp.Data.ViewModels;
    using UniApp.Models;
    using UniApp.Repositories;

    public class MoviesController : Controller
    {
        private readonly IMovieRepository _repo;
        public MoviesController(IMovieRepository repo)
        {
            this._repo = repo;
        }
        public IActionResult Index()
        {
            var data = this._repo.GetMovies();
            return View(data);
        }

        //Get
        public async Task<IActionResult> Create()
        {
            var movieDropdownValues = await this._repo.GetDropdownValues();

            ViewBag.Actors = new SelectList(movieDropdownValues.Actors, "Id", "Name");
            ViewBag.Studio = new SelectList(movieDropdownValues.Studios, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM newMVM)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownValues = await this._repo.GetDropdownValues();

                ViewBag.Actors = new SelectList(movieDropdownValues.Actors, "Id", "Name");
                ViewBag.Studio = new SelectList(movieDropdownValues.Studios, "Id", "Name");

                return View(newMVM);
            }

            await this._repo.AddMovie(newMVM);

            return RedirectToAction(nameof(Index));

        }

        //Get
        public async Task<IActionResult> Details(int id)
        {
            var movieView = await this._repo.GetByIdAsync(id);
            if (movieView == null)
            {
                return View("404");
            }

            return View(movieView);
        }

        //Get
        public async Task<IActionResult> Edit(int id)
        {
            var movieView = await this._repo.GetByIdAsync(id);
            if (movieView == null)
            {
                return View("404");
            }

            var response = new NewMovieVM()
            {
                Id = movieView.Id,
                Name = movieView.Name,
                Description = movieView.Description,
                Image = movieView.Image,
                StudioId = movieView.StudioId,
                Actor_Ids = movieView.Actor_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropdownValues = await this._repo.GetDropdownValues();

            ViewBag.Actors = new SelectList(movieDropdownValues.Actors, "Id", "Name");
            ViewBag.Studio = new SelectList(movieDropdownValues.Studios, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM newMVM)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownValues = await this._repo.GetDropdownValues();

                ViewBag.Actors = new SelectList(movieDropdownValues.Actors, "Id", "Name");
                ViewBag.Studio = new SelectList(movieDropdownValues.Studios, "Id", "Name");

                return View(newMVM);
            }

            await this._repo.Update(newMVM);

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
