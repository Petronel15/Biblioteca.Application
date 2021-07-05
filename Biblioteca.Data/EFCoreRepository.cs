using Biblioteca.Core.Exceptions;
using Biblioteca.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Infrastructure.Data
{
    public partial class EFCoreRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext dbContext;
        private DbSet<TEntity> entities;

        #region Constructor
        public EFCoreRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Methods

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Add(entity);
                DbContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new ItemCannotBeInsertedException(GetFullErrorText(exception), exception);
            }
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.AddRange(entities);
                DbContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new ItemCannotBeInsertedException(GetFullErrorText(exception), exception);
            }
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                var existingEntity = this.Entities.Find(entity.Id);

                if (existingEntity == null)
                    throw new ArgumentException("Entity does not exist in the DB");

                (this.dbContext as DbContext).Entry(existingEntity).CurrentValues.SetValues(entity);
                DbContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new ItemCannotBeUpdatedException(GetFullErrorText(exception), exception);
            }
        }

        public void Update(IEnumerable<TEntity> entities)
        {

            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.UpdateRange(entities);
                DbContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new ItemCannotBeUpdatedException(GetFullErrorText(exception), exception);
            }
        }

        public void Upsert(TEntity entity)
        {

            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                var existingEntity = Entities.Find(entity);

                if (existingEntity == null)
                {
                    Entities.Add(entity);
                }
                else
                {
                    Entities.Update(entity);
                }
                DbContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new ItemCannotBeUpdatedException(GetFullErrorText(exception), exception);
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Remove(entity);
                DbContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new ItemCannotBeDeletedException(GetFullErrorText(exception), exception);
            }
        }
        public void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.RemoveRange(entities);
                DbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new ItemCannotBeDeletedException("Item cannot be deleted", ex);
            }
        }

        public void Delete(long id)
        {
            var existingEntity = GetById(id);

            if (existingEntity == null)
                throw new ArgumentException("Entity with id not found");

            try
            {
                Entities.Remove(existingEntity);
                DbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new ItemCannotBeDeletedException("Item cannot be deleted", ex);
            }
        }

        protected string GetFullErrorText(DbUpdateException exception)
        {
            return exception.ToString();
        }

        #endregion

        #region Properties
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = dbContext.Set<TEntity>();
                }

                return entities;
            }
        }

        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public IDbContext DbContext { get => dbContext; }

        #endregion
    }
}
