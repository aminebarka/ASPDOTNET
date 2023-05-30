namespace GestiondeLocation.Models.Repositories
{
    public interface IRepository<T>
    {
    
        T Get(int Id);
        IEnumerable<T> GetAll();
        T FindByID(int Id);
        T Add(T t);
        T Update(T t);
        T Delete(int Id);
        
    
    }
}
