using GestiondeLocation.EF_core;
using Microsoft.EntityFrameworkCore;

namespace GestiondeLocation.Models.Repositories
{
    public class SqlVoitureRepository : IRepository<Voiture>
    {
        private readonly AppDbContext context;
        public SqlVoitureRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Voiture Add(Voiture V)
        {
            context.Voitures.Add(V);
            context.SaveChanges();
            return V;
        }
        public Voiture Delete(int Id)
        {
            Voiture V = context.Voitures.Find(Id);
            if (V != null)
            {
                context.Voitures.Remove(V);
                context.SaveChanges();
            }
            return V;
        }
        public IEnumerable<Voiture> GetAll()
        {
            return context.Voitures;
        }
        public Voiture Get(int Id)
        {
            return context.Voitures.Find(Id);
        }
        public Voiture Update(Voiture V)
        {
            var Voiture =
            context.Voitures.Attach(V);
            Voiture.State = EntityState.Modified;
            context.SaveChanges();
            return V;
        }

        public IList<Voiture> GetStudentsBySchoolID(int? id)
        {
            return context.Voitures.Where(s =>
            s.id.Equals(id))
            .OrderBy(s => s.VoitureMatricule)
            .Include(std => std.Location).ToList();
        }
        public IList<Location> FindByName(string name)
        {
            return context.Locations.Where(s =>
            s.StudentName.Contains(name)).Include(std =>
            std.School).ToList();
        }
    }

}
