using DomainModel.Entities;
using DomainModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        MUTANTEContext<TEntity> _Context ;

        public Repository()
        {
            _Context = new MUTANTEContext<TEntity>();
        }

        private MUTANTEContext<TEntity> DbContext
        {
            get
            {          
                if (_Context == null)
                    throw new InvalidOperationException("Sin contexto de tipo DbContext.");

                return _Context;
            }
        }

        public void Add(TEntity modelo)
        {

            DbContext.Modelo.Add(modelo);
        }
        public void Remove(TEntity modelo)
        {
            DbContext.Modelo.Remove(modelo);
        }
        public TEntity Get(int id)
        {
            return DbContext.Modelo.Find(id);
        }

        public List<TEntity> GetAll(string include = "")
        {
         //   if (include == "")
                return DbContext.Modelo.ToList();
           // else
           //     return DbContext.Modelo.Include(include).ToList();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> whereCondition, string include = "")
        {
          //  if (include == "")
                return DbContext.Modelo.Where(whereCondition).ToList();
            //else
             //   return DbContext.Modelo.Include(include).Where(whereCondition).ToList();
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> whereCondition, string include = "")
        {
         //   if (include == "")
                return DbContext.Modelo.Where(whereCondition).FirstOrDefault();
           // else
           //     return DbContext.Modelo.Include(include).Where(whereCondition).FirstOrDefault();
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }


    }
}
