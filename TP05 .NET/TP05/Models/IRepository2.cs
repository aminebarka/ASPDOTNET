﻿namespace sitedeventeTP05.Models
{
    public interface IRepository2<T>
    {
        T Get(int Id);
        IEnumerable<T> GetAll();
        T Add(T t);
        T Update(T t);
        T Delete(int Id);
    }
}
