using Microsoft.EntityFrameworkCore;
using sitedeventeTP05.Models;


public class CategorieRepository 
{
    private readonly AppDbContext context;
    public CategorieRepository(AppDbContext context)
    {
        this.context = context;
    }

    public Categorie GetProduitsByCateg(string cat)
    {
        return context.Categories.Include("Categories").Single(g => g.Nom == cat);
    }
   
    
        public IList<Categorie> GetAll()
        {
            return context.Categories.OrderBy(s => s.Nom).ToList();
        }

    
}
