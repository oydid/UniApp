namespace UniApp.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniApp.Data;
    using UniApp.Data.ViewModels;
    using UniApp.Models;

    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task AddMovie(NewMovieVM newMVM)
        {
            var movie = new Movie()
            {
                Name = newMVM.Name,
                Description = newMVM.Description,
                ReleaseDate = newMVM.ReleaseDate,
                Image = newMVM.Image,
                CreatedAt = newMVM.CreatedAt,
                UpdatedAt = newMVM.UpdatedAt,
                StudioId = newMVM.StudioId,
            };

            this._context.Movies.Add(movie);

            this._context.SaveChanges();

            //add movie Actors
            foreach (var actorId in newMVM.Actor_Ids)
            {
                var ActorMovie = new Actor_Movie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId,
                };

                this._context.Actors_Movies.Add(ActorMovie);
            }

            await this._context.SaveChangesAsync();

        }

        public void Delete(int Id)
        {
            var movie = this._context.Movies.FirstOrDefault(n => n.Id == Id);

            this._context.Movies.Remove(movie);

            this._context.SaveChanges();
        }

        public async Task<Movie> GetByIdAsync(int Id)
        {
            var details = await this._context.Movies
                .Include(s => s.Studio)
                .Include(am => am.Actor_Movies)
                .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == Id);

            return details;
        }

        public async Task<DropdownMovieVM> GetDropdownValues()
        {
            var response = new DropdownMovieVM();
            response.Actors = await this._context.Actors.OrderBy(n => n.Name).ToListAsync();
            response.Studios = await this._context.Studios.OrderBy(n => n.Name).ToListAsync();

            return response;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var result = this._context.Movies.ToList();
            return result;
        }

        public async Task Update(NewMovieVM newMVM)
        {
            var movie = await this._context.Movies.FirstOrDefaultAsync(n => n.Id == newMVM.Id);
            if (movie != null)
            {
                movie.Name = newMVM.Name;
                movie.Description = newMVM.Description;
                movie.ReleaseDate = newMVM.ReleaseDate;
                movie.Image = newMVM.Image;
                movie.CreatedAt = newMVM.CreatedAt;
                movie.UpdatedAt = newMVM.UpdatedAt;
                movie.StudioId = newMVM.StudioId;

                await this._context.SaveChangesAsync();
            }

            var actors = this._context.Actors_Movies.Where(n => n.MovieId == newMVM.Id).ToList();
            this._context.Actors_Movies.RemoveRange(actors);
            await this._context.SaveChangesAsync();

            foreach (var actorId in newMVM.Actor_Ids)
            {
                var newActor = new Actor_Movie()
                {
                    MovieId = newMVM.Id,
                    ActorId = actorId,
                };

                await this._context.Actors_Movies.AddAsync(newActor);
            }

            await this._context.SaveChangesAsync();
        }
    }
}
