/*using Microsoft.EntityFrameworkCore;

namespace sitedeventeTP05.Models
{
    public class CommandeRepository
    {

        readonly AppDbContext context;
        public CommandeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IList<Commande> GetAll()
        {
            return context.Commandes.OrderBy(x => x.PanierId).Include(x => x.Panier).ToList();
        }
        public Commande GetById(int id)
        {
            return context.Commandes.Where(x => x.CommandeId == id).Include(x => x.Panier).SingleOrDefault();
        }
        public void Add(Commande s)
        {
            context.Commandes.Add(s);
            context.SaveChanges();
        }
        public void Edit(Commande s)
        {
            Commande s1 = context.Commandes.Find(s.CommandeId);
            if (s1 != null)
            {
                s1.PanierId = s.PanierId;

                context.SaveChanges();
            }
        }
        public void Delete(Commande s)
        {
            Commande s1 = context.Commandes.Find(s.CommandeId);
            if (s1 != null)
            {
                context.Commandes.Remove(s1);
                context.SaveChanges();
            }
        }
        public IList<Commande> GetStudentsBySchoolID(int CommandeId)
        {
            return context.Commandes.Where(s =>
            s.CommandeId.Equals(CommandeId))
            .OrderBy(s => s.PanierId)
            .Include(std => std.Panier).ToList();
        }
        public IList<Commande> FindByName(string name)
        {
            return context.Commandes.Where(s =>s.PanierId.Contains(name)).Include(std => std.PanierId).ToList();
        }
    }
}
    
*/