using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using congestion_tax_calculator_net_core.Contract;
using System.Threading.Tasks;

namespace congestion_tax_calculator_net_core.EF
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(object id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            if (entity != null)
                Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }


        public List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }



        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public async Task<EntityEntry<TEntity>> Add(TEntity entity)
        {
            return await Context.Set<TEntity>().AddAsync(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }
        public void AttachRange(List<TEntity> entities)
        {
            Context.Set<TEntity>().AttachRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public IEnumerable<TEntity> ExecuteStored(string ProcedureName, object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
                ProcedureName += " @p" + i.ToString() + ",";
            ProcedureName = ProcedureName.Remove(ProcedureName.Length - 1, 1);

            var result = Context.Set<TEntity>().FromSqlRaw(ProcedureName, parameters).ToList();
            return result;
        }

        private static async System.Threading.Tasks.Task<IEnumerable<TEntity>> GetAsync(DbContext Context, string ProcedureName, object[] parameters)
        {
            return Context.Set<TEntity>().FromSqlRaw<TEntity>(ProcedureName, parameters);
        }



        public void Update(TEntity obj)
        {
            Context.Set<TEntity>().Update(obj);
        }
        public void UpdateRange(List<TEntity> obj)
        {
            Context.Set<TEntity>().UpdateRange(obj);
        }

        public void Delete(object id)
        {
            var obj = Get(id);
            Context.Set<TEntity>().Remove(obj);
        }

        public void DeleteRange(IEnumerable<TEntity> list)
        {
            Context.Set<TEntity>().RemoveRange(list);
        }



        List<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToList();
        }

        public int GetCount()
        {
            return Context.Set<TEntity>().Count();
        }
        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }
        public T GetMax<T>(Expression<Func<TEntity, int>> expression)
        {
            if (Context.Set<TEntity>().Count() == 0)
                return (T)Convert.ChangeType(0, typeof(T));
            return (T)Convert.ChangeType(Context.Set<TEntity>().Max(expression), typeof(T));
        }
    }

}
