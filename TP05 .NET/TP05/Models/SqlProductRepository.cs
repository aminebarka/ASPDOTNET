using Microsoft.EntityFrameworkCore;
using sitedeventeTP05.Models;

public class SqlProductRepository : IRepository<Produit>
{
    private readonly AppDbContext context;
    public SqlProductRepository(AppDbContext context)
    {
        this.context = context;
    }
    public Produit Add(Produit P)
    {
        context.Produits.Add(P);
        context.SaveChanges();
        return P;
    }
    public Produit Delete(int Id)
    {
        Produit P = context.Produits.Find(Id);
        if (P != null)
        {
            context.Produits.Remove(P);
            context.SaveChanges();
        }
        return P;
    }
    public IEnumerable<Produit> GetAll()
    {
        return context.Produits;
    }
    public Produit Get(int Id)
    {
        return context.Produits.Find(Id);
    }
    public Produit Update(Produit P)
    {
        var Product =
        context.Produits.Attach(P);
        Product.State = EntityState.Modified;
        context.SaveChanges();
        return P;
    }
}
