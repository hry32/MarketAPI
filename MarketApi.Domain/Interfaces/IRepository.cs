using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApi.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int Id);
        void Add(T _object);
        void Update(T _object);
        void Delete(T _object);
        void Save();
    }
}
