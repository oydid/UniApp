namespace UniApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniApp.Data;
    using UniApp.Models;

    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;
        public ActorRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void AddActor(Actor actor)
        {
            this._context.Actors.Add(actor);

            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var actor = this._context.Actors.FirstOrDefault(n => n.Id == Id);

            this._context.Actors.Remove(actor);

            this._context.SaveChanges();
        }

        public IEnumerable<Actor> GetActors()
        {
            var result = this._context.Actors.ToList();
            return result;
        }

        public Actor GetById(int Id)
        {
            var result = this._context.Actors.FirstOrDefault(n => n.Id == Id);

            return result;
        }

        public Actor Update(int Id, Actor updatedActor)
        {
            this._context.Update(updatedActor);

            this._context.SaveChanges();

            return updatedActor;
        }
    }
}
