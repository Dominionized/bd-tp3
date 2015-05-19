using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoratApplication.Repository
{
    public class TutoratRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly TutoringContext Context {get;set;}

        public TutoratRepository<T>(TutoringContext ctx)
        {
            
        }
        public IQueryable<T> GetById(int Id)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>().AsQueryable();
        }

        public void Add(T entity)
        {
            Context.Set<T>.Add(entity);
        }

        public void Insert(T entity)
        {
            Context.Set<T>.Insert(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>.Delete(entity);
        }

        public void DeleteAll()
        {
            Context.Set<T>.DeleteAll();
        }
    }
}
