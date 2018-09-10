using OOS.Models;
using OOS.Models.Common;
using OOS.Repositories.Common;
using OOS.Utilities;
using SuperDev.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace OOS.Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity : class, new()
    {
        public virtual TEntity Get(Guid id)
        {
            using (var context = new OOSContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public virtual IEnumerable All()
        {
            using (var context = new OOSContext())
            {
                TEntity entity = new TEntity();
                if (entity is ICreator)
                {
                    return context.Set<TEntity>().OrderBy("CreatedDate DESC").ToList();
                }
                else return context.Set<TEntity>().ToList();
            }
        }

        public virtual IEnumerable All(string whereClause)
        {
            using (var context = new OOSContext())
            {
                TEntity entity = new TEntity();
                if (entity is ICreator)
                {
                    return context.Set<TEntity>().Where(whereClause).OrderBy("CreatedDate DESC").ToList();
                }
                else return context.Set<TEntity>().Where(whereClause).ToList();
            }
        }

        public virtual PagedListResult List(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        {
            using (var context = new OOSContext())
            {
                var query = context.Set<TEntity>().Where(whereClause);
                var entities = query.OrderBy(string.Format("{0} {1}", orderBy.Trim(), orderDirection.Trim()))
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
                return new PagedListResult(entities, query.Count());
            }
        }

        //public virtual PagedListResult List(PagedListRequest request)
        //{
        //    return List(request.whereClause, request.orderBy, request.orderDirection, request.pageNumber, request.pageSize);
        //}

        public virtual TEntity Create(TEntity entity)
        {
            TEntity e = new TEntity();
            Guid id = Guid.NewGuid();
            entity.GetType().GetProperty("Id").SetValue(entity, id);
            if (entity is IStatus)
            {
                entity.GetType().GetProperty("Status").SetValue(entity, true);
            }
            using (var context = new OOSContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return context.Set<TEntity>().Find(id);
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            using (var context = new OOSContext())
            {
                Guid id = new Guid(entity.GetType().GetProperty("Id").GetValue(entity, null).ToString());
                TEntity origin = context.Set<TEntity>().Find(id);
                Utility.CloneObject(origin, entity);
                context.SaveChanges();
                context.Entry(origin).Reload();
                return origin;
            }
        }

        public virtual TEntity Disable(Guid id)
        {
            using (var context = new OOSContext())
            {
                TEntity entity = context.Set<TEntity>().Find(id);
                if (entity is IStatus)
                {
                    entity.GetType().GetProperty("Status").SetValue(entity, false);
                }
                if (entity is IModifier)
                {
                    entity.GetType().GetProperty("ModifiedDate").SetValue(entity, DateTime.Now);
                    entity.GetType().GetProperty("ModifiedBy").SetValue(entity, CurrentUserId);
                }
                context.SaveChanges();
                context.Entry(entity).Reload();
                return entity;
            }
        }

        public virtual TEntity Enable(Guid id)
        {
            using (var context = new OOSContext())
            {
                TEntity entity = context.Set<TEntity>().Find(id);
                if (entity is IStatus)
                {
                    entity.GetType().GetProperty("Status").SetValue(entity, true);
                }
                if (entity is IModifier)
                {
                    entity.GetType().GetProperty("ModifiedDate").SetValue(entity, DateTime.Now);
                    entity.GetType().GetProperty("ModifiedBy").SetValue(entity, CurrentUserId);
                }
                context.SaveChanges();
                context.Entry(entity).Reload();
                return entity;
            }
        }

        public virtual TEntity Delete(Guid id)
        {
            using (var context = new OOSContext())
            {
                TEntity entity = context.Set<TEntity>().Find(id);
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
                return null;
            }
        }

        public static void CloneObject(object des, object src)
        {
            foreach (PropertyInfo propertyInfo in des.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (src.GetType().GetProperty(propertyInfo.Name, BindingFlags.Public | BindingFlags.Instance) != null)
                {
                    var value = src.GetType().GetProperty(propertyInfo.Name).GetValue(src, null);
                    propertyInfo.SetValue(des, value, null);
                }
            }
        }

        public static Guid? CurrentUserId
        {
            get
            {
                try
                {
                    var token = HttpContext.Current.Request.Headers.Get("token").ToString();
                    var userId = Utility.Decrypt(token);
                    using (var context = new OOSContext())
                    {
                        var result = Guid.Empty;
                        if (Guid.TryParse(userId, out result)) return context.Accounts.FirstOrDefault(e => e.Id == result).EmployeeID;
                        else return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
