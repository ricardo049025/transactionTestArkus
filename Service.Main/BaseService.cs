using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domain.Interfaces;
using Domain.Domain.Interfaces.Services;
using Domain.Entities.Models;
namespace Service.Main
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity: class
    {
        protected IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<TEntity> getAll()
        {
            return this.repository.getAll();
        }

        public TEntity getById(int id)
        {
            return this.repository.getById(id);
        }

        public bool add(TEntity entity)
        {
            return this.repository.add(entity);
        }

        public bool addRange(List<TEntity> entities)
        {
            return this.repository.addRange(entities);
        }

        public bool update(TEntity entity)
        {
            return this.repository.update(entity);
        }

        public bool updateRange(List<TEntity> entities)
        {
            return this.repository.updateRange(entities);
        }

        public bool delete(int id)
        {
            return this.repository.delete(id);
        }
    }
}
