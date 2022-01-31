namespace UniApp.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using UniApp.Data;
    using UniApp.Models;

    public class StudioRepository : IStudioRepository
    {
        private readonly ApplicationDbContext _context;
        public StudioRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void AddStudio(Studio studio)
        {
            this._context.Studios.Add(studio);

            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var studio = this._context.Studios.FirstOrDefault(n => n.Id == Id);

            this._context.Studios.Remove(studio);

            this._context.SaveChanges();
        }

        public IEnumerable<Studio> GetStudios()
        {
            var result = this._context.Studios.ToList();
            return result;
        }

        public Studio GetById(int Id)
        {
            var result = this._context.Studios.FirstOrDefault(n => n.Id == Id);

            return result;
        }

        public Studio Update(int Id, Studio updatedStudio)
        {
            this._context.Update(updatedStudio);

            this._context.SaveChanges();

            return updatedStudio;
        }
    }
}
