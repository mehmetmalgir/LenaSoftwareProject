
using LenaSoftware.API.Structure.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LenaSoftware.API.Structure.DataAccess.Contracts
{
    public interface IEntityRepository<TEntity> where TEntity : BaseEntity, new()
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeList);

        TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList);

        TEntity GetById(int id, params string[] includeList);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        TEntity Add(TEntity entity);


    }
}
