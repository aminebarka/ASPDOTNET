/*using Microsoft.EntityFrameworkCore;

namespace sitedeventeTP05.Models
{
    public class PanierRepository
    {

    
      readonly AppDbContext context;
    public PanierRepository(AppDbContext context)
    {
        this.context = context;
    }
    public IList<Panier> GetAll()
    {
        return context.Paniers.OrderBy(x => x.PanierId).Include(x => x.PanierId).ToList();
    }
    public Commande GetById(int id)
    {
        return context.Paniers.Where(x => x.Panier == id).Include(x => x.Panier).SingleOrDefault();
    }
    public void Add(Panier s)
    {
        context.Paniers.Add(s);
        context.SaveChanges();
    }
    public void Edit(Panier s)
    {
            Panier s1 = context.Paniers.Find(s.PanierId);
        if (s1 != null)
        {
            s1.PanierId = s.PanierId;

            context.SaveChanges();
        }
    }
    public void Delete(Commande s)
    {
            Panier s1 = context.Paniers.Find(s.PanierId);
        if (s1 != null)
        {
            context.Commandes.Remove(s1);
            context.SaveChanges();
        }
    }
    public IList<Panier> GetStudentsBySchoolID(int PanierId)
    {
        return context.Paniers.Where(s =>
        s.PanierId.Equals(PanierId))
        .OrderBy(s => s.PanierId).Include(std => std.Panier).ToList();
    }
    public IList<Commande> FindByName(string name)
    {
        return context.Paniers.Where(s => s.PanierId.Contains(name)).Include(std => std.Panier).ToList();
    }
}
}
*/