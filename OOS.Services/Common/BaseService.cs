using OOS.Models.Common;
using OOS.Repositories;
using OOS.Repositories.Common;
using SuperDev.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Services.Common
{
    public abstract class BaseService<TEntity, TBaseRepository>
        where TEntity : class, new()
        where TBaseRepository : BaseRepository<TEntity>, new()
    {
        public TBaseRepository repository = new TBaseRepository();
        public virtual PagedListResult List(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        {
            return repository.List(whereClause, orderBy, orderDirection, pageNumber, pageSize);
        }

        public virtual PagedListResult List(PagedListRequest request)
        {
            TEntity entity = new TEntity();
            if (entity is ICode)
            {
                request.orderBy = "Code";
                request.orderDirection = "DESC";
            }
            else if (entity is IReview)
            {
                request.orderBy = "ReviewDate";
                request.orderDirection = "DESC";
            }
            return this.List(request.whereClause, request.orderBy, request.orderDirection, request.pageNumber, request.pageSize);
        }

        public virtual IEnumerable All()
        {
            return repository.All();
        }

        public virtual IEnumerable All(string whereClause)
        {
            if (string.IsNullOrWhiteSpace(whereClause)) return repository.All();
            return repository.All(whereClause);
        }

        public virtual TEntity Get(Guid id)
        {
            var entity = repository.Get(id);
            if (entity == null) throw new Exception("ENTITY_INCORRECT_ID");
            return entity;
        }

        public virtual TEntity Save(TEntity entity)
        {
            Guid id = new Guid(entity.GetType().GetProperty("Id").GetValue(entity, null).ToString());
            if (id == Guid.Empty)
            {
                return repository.Create(entity);
            }
            else
            {
                return repository.Update(entity);
            }
        }

        public virtual TEntity Enable(Guid id)
        {
            var entity = repository.Get(id);
            if (entity == null) throw new Exception("ENTITY_INCORRECT_ID");
            return repository.Enable(id);
        }

        public virtual TEntity Disable(Guid id)
        {
            var entity = repository.Get(id);
            if (entity == null) throw new Exception("ENTITY_INCORRECT_ID");
            return repository.Disable(id);
        }

        public virtual TEntity Delete(Guid id)
        {
            var entity = repository.Get(id);
            if (entity == null) throw new Exception("ENTITY_INCORRECT_ID");
            return repository.Delete(id);
        }
    }
}
