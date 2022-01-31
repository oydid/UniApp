namespace UniApp.Data.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniApp.Models;

    public class DropdownMovieVM
    {
        public DropdownMovieVM()
        {
            Actors = new List<Actor>();
            Studios = new List<Studio>();
        }

        public List<Actor> Actors { get; set; }
        public List<Studio> Studios { get; set; }
    }
}
