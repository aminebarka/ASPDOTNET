using GestiondeLocation.EF_core;
using Microsoft.EntityFrameworkCore;

namespace GestiondeLocation.Models.Repositories
{
    public class SqlLocationRepository :IRepository<Location>
    {
        private readonly AppDbContext context;
        public SqlLocationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Location Add(Location L)
        {
            context.Locations.Add(L);
            context.SaveChanges();
            return L;
        }
        public Location Delete(int Id)
        {
           Location L = context.Locations.Find(Id);
            if (L != null)
            {
                context.Locations.Remove(L);
                context.SaveChanges();
            }
            return L;
        }
        public IEnumerable<Location> GetAll()
        {
            return context.Locations;
        }
        public Location Get(int Id)
        {
            return context.Locations.Find(Id);
        }
        public Location Update(Location L)
        {
            var Location =
            context.Locations.Attach(L);
            Location.State = EntityState.Modified;
            context.SaveChanges();
            return L;
        }
    }
}
