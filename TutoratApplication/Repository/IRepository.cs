using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoratApplication.Repository
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();

        T SingleId();

        void Add(T entity);

        void Insert(T entity);

        void Delete(T entity);

        void DeleteAll();
    }
}
