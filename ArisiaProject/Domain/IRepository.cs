using System;
using System.Collections.Generic;
using System.Linq;

namespace ArisiaProject.Domain
{
    public interface IRepository
    {
        
    }

    public interface IRepository<TEntity, TPrimaryKey> : IRepository
        where TEntity : Entity<TPrimaryKey>
    {
        void Insert(TEntity item);

        void Update(TEntity item);

        void Delete(TPrimaryKey itemId);

        TEntity GetById(TPrimaryKey itemId);

        IQueryable<TEntity> GetAll();
    }
}
