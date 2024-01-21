using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace congestion_tax_calculator_net_core.Contract
{

    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(object id);
        int GetCount();
        T GetMax<T>(Expression<Func<TEntity, int>> expression);
        List<TEntity> GetAll();
        IQueryable<TEntity> Query();
        void Update(TEntity obj);
        void UpdateRange(List<TEntity> obj);
        void Delete(object id);
        void DeleteRange(IEnumerable<TEntity> list);
        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<EntityEntry<TEntity>> Add(TEntity entity);
        void AddRange(List<TEntity> entities);
        void AttachRange(List<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> ExecuteStored(string ProcedureName, object[] parameters);
    }


}
