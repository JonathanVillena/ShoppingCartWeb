using System.Collections.Generic;
using System.Linq;
using System;

namespace ShoppingCartWeb.Repositories
{
    public interface IDataAccess< TEntity, U > where TEntity : class
    {
        IEnumerable< TEntity > GetAll();
        TEntity Get(U id);
        void Add(TEntity b);
        void Update(TEntity b);
        void Delete(U id); 
    }
}