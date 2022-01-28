namespace UniApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniApp.Models;

    public interface IActorRepository
    {
        IEnumerable<Actor> GetActors();
        void AddActor(Actor actor);
        Actor GetById(int Id);
        Actor Update(int Id, Actor updatedActor);
        void Delete(int Id);
    }
}
