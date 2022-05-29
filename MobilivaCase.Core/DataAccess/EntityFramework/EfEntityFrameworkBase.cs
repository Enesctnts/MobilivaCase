using Microsoft.EntityFrameworkCore;
using MobilivaCase.Core.Entities;
using MobilivaCase.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobilivaCase.Core.DataAccess.EntityFramework
{
    public class EfEntityFrameworkBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        protected TContext _dbContext;

        public EfEntityFrameworkBase(TContext dbContext) => _dbContext = dbContext;

        public void Add(TEntity entity)
        {

            var addedEntity = _dbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            _dbContext.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            var deleteEntity = _dbContext.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            _dbContext.SaveChanges();

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {

            return _dbContext.Set<TEntity>().SingleOrDefault(filter);

        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _dbContext.Set<TEntity>().ToList() : _dbContext.Set<TEntity>().Where(filter).ToList();

        }

        public void Update(TEntity entity)
        {
            var updateEntity = _dbContext.Entry(entity);
            updateEntity.State = EntityState.Modified;
            _dbContext.SaveChanges();

        }

    }
}
