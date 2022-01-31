namespace UniApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniApp.Models;

    public interface IStudioRepository
    {
        IEnumerable<Studio> GetStudios();
        void AddStudio(Studio actor);
        Studio GetById(int Id);
        Studio Update(int Id, Studio updatedStudio);
        void Delete(int Id);
    }
}
