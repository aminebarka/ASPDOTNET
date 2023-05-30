namespace sitedeventeTP05.Models
{
    public interface IRepository1<T>
    {
        T GetProduitsByCateg(String cat);
        IEnumerable<T> GetAll();
      
    }
}
