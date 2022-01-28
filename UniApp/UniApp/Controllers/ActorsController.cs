namespace UniApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
    }
}
