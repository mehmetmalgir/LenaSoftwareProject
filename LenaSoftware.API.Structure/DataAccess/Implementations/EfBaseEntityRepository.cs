
using LenaSoftware.API.Structure.DataAccess.Contracts;
using LenaSoftware.API.Structure.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LenaSoftware.API.Structure.DataAccess.Implementations
{
    public abstract class EfBaseEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                ctx.Set<TEntity>().Add(entity);
                ctx.SaveChanges();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                ctx.Set<TEntity>().Remove(entity);
                ctx.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> query = ctx.Set<TEntity>();

                foreach (var item in includeList)
                {
                    query = query.Include(item);
                }

                return query.SingleOrDefault(filter);


            }
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> query = ctx.Set<TEntity>();

                query = filter == null ? query : query.Where(filter);

                foreach (var item in includeList)
                {
                    query = query.Include(item);
                }

                return query.ToList();

            }
        }

        public TEntity GetById(int id, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> query = ctx.Set<TEntity>();

                foreach (var item in includeList)
                {
                    query = query.Include(item);

                }

                return query.SingleOrDefault(x => x.Id == id);

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                ctx.Set<TEntity>().Update(entity);
                ctx.SaveChanges();
            }
        }
    }
}
