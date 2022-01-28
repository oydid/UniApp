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
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetActors()
        {
            var result = this._context.Actors.ToList();
            return result;
        }

        public Actor GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int Id, Actor updatedActor)
        {
            throw new NotImplementedException();
        }
    }
}
