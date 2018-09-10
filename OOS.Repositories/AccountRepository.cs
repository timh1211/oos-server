using OOS.Models;
using OOS.Models.Common;
using OOS.Repositories.Common;
using OOS.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OOS.Repositories
{
    public class AccountRepository : BaseRepository<Account>
    {
        public Account Get(string username)
        {
            using (var context = new OOSContext())
            {
                return context.Accounts.Include(e => e.Owner)
                    .FirstOrDefault(e => e.Username == username && e.Status == true);
            }
        }

        public Account GetAccountOfEmployee(Guid employeeID)
        {
            using (var context = new OOSContext())
            {
                return context.Accounts.FirstOrDefault(e => e.EmployeeID == employeeID && e.Status == true);
            }
        }

        public override PagedListResult List(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        {
            using (var context = new OOSContext())
            {
                var query = context.Accounts.Select(e => new AccountComplex
                {
                    Id = e.Id,
                    Username = e.Username,
                    HashedPassword = e.HashedPassword,
                    EmployeeID = e.EmployeeID,
                    CreatedDate = e.CreatedDate,
                    CreatedBy = e.CreatedBy,
                    ModifiedDate = e.ModifiedDate == null ? DateTime.MinValue : e.ModifiedDate.Value,
                    ModifiedBy = e.ModifiedBy,
                    Status = e.Status,
                    Owner = e.Owner == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.EmployeeID).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.EmployeeID).FirstName,
                    CreatorName = e.CreatedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).FirstName,
                    ModifierName = e.ModifiedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).FirstName
                }).Where(whereClause);
                var entities = query.OrderBy(string.Format("{0} {1}", orderBy.Trim(), orderDirection.Trim()))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
                return new PagedListResult(entities, query.Count());
            }
        }

        public override IEnumerable All(string whereClause)
        {
            using (var context = new OOSContext())
            {
                return context.Accounts.Select(e => new AccountComplex
                {
                    Id = e.Id,
                    Username = e.Username,
                    HashedPassword = e.HashedPassword,
                    EmployeeID = e.EmployeeID,
                    CreatedDate = e.CreatedDate,
                    CreatedBy = e.CreatedBy,
                    ModifiedDate = e.ModifiedDate == null ? DateTime.MinValue : e.ModifiedDate.Value,
                    ModifiedBy = e.ModifiedBy,
                    Status = e.Status,
                    CreatorName = e.CreatedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).FirstName,
                    ModifierName = e.ModifiedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).FirstName,
                    Owner = e.Owner == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.EmployeeID).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.EmployeeID).FirstName
                }).Where(whereClause).OrderBy("CreatedDate DESC").ToList();
            }
        }

        public override IEnumerable All()
        {
            using (var context = new OOSContext())
            {
                return context.Accounts.Select(e => new AccountComplex
                {
                    Id = e.Id,
                    Username = e.Username,
                    HashedPassword = e.HashedPassword,
                    EmployeeID = e.EmployeeID,
                    CreatedDate = e.CreatedDate,
                    CreatedBy = e.CreatedBy,
                    ModifiedDate = e.ModifiedDate == null ? DateTime.MinValue : e.ModifiedDate.Value,
                    ModifiedBy = e.ModifiedBy,
                    Status = e.Status,
                    CreatorName = e.CreatedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.CreatedBy).FirstName,
                    ModifierName = e.ModifiedBy == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.ModifiedBy).FirstName,
                    Owner = e.Owner == null ? string.Empty : context.Employees.FirstOrDefault(a => a.Id == e.EmployeeID).LastName + " " + context.Employees.FirstOrDefault(a => a.Id == e.EmployeeID).FirstName
                }).OrderBy("CreatedDate DESC").ToList();
            }
        }

        public override Account Create(Account entity)
        {
            using (var context = new OOSContext())
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = CurrentUserId;
                entity.HashedPassword = Utility.HashMD5(entity.HashedPassword);
                entity.ModifiedDate = null;
            }
            return base.Create(entity);
        }

        public override Account Update(Account entity)
        {
            using (var context = new OOSContext())
            {
                var user = context.Accounts.FirstOrDefault(e => e.Id == entity.Id);
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedBy = CurrentUserId;
                if (user.HashedPassword != entity.HashedPassword) entity.HashedPassword = Utility.HashMD5(entity.HashedPassword);
            }
            return base.Update(entity);
        }

        public static Guid? CurrentUserId
        {
            get
            {
                try
                {
                    var token = HttpContext.Current.Request.Headers.Get("token").ToString();
                    var userId = Utility.Decrypt(token);
                    using(var context = new OOSContext())
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

        public bool HasUsername(string username)
        {
            using (var context = new OOSContext())
            {
                return context.Accounts.Any(e => e.Username == username);
            }
        }

        public bool HasCode(Guid id, string username)
        {
            using (var context = new OOSContext())
            {
                return context.Accounts.Any(e => e.Id != id && e.Username == username);
            }
        }
    }
}
