using Microsoft.EntityFrameworkCore;
using MobilivaCase.Core.Entities;
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
        
        public void Add(TEntity entity) => Add(entity);
        public void Delete(TEntity entity) => Delete(entity);
        public void Update(TEntity entity) => Update(entity);
        public TEntity Get(Expression<Func<TEntity, bool>> filter)=> _dbContext.Set<TEntity>().SingleOrDefault(filter);
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
            => filter == null ? _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().Where(filter);
        public void Save() => _dbContext.SaveChanges();



    }
}
