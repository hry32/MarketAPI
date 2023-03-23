using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IRepository<T> where T : class
    {       
            List<T> GetAll();
            T GetById(int Id);
            void Add(T _object);
            void Update(T _object);
            void Delete(T _object);
            void Save();        
    }
}
