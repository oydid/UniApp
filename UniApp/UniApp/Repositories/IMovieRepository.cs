namespace UniApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniApp.Data.ViewModels;
    using UniApp.Models;

    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();
        Task AddMovie(NewMovieVM newMVM);
        Task<Movie> GetByIdAsync(int Id);
        Task Update(NewMovieVM newMVM);
        void Delete(int Id);
        Task<DropdownMovieVM> GetDropdownValues();
    }
}
