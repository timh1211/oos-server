using OOS.Models;
using OOS.Models.Common;
using OOS.Repositories.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public override Employee Create(Employee entity)
        {
            Guid id = Guid.NewGuid();
            entity.Id = id;
            entity.Status = true;
            entity.Code = GetCode(entity.FirstName, entity.LastName, id);

            using (var context = new OOSContext())
            {
                context.Employees.Add(entity);
                context.SaveChanges();
                return context.Employees.Find(id);
            }
        }

        public string GetCode(string firstName, string lastName, Guid id)
        {
            return firstName[0].ToString().ToUpper() 
                    + lastName[0].ToString().ToUpper()
                    + id.ToString().Split('-')[4];
        }

        public bool HasCode(string code)
        {
            using (var context = new OOSContext())
            {
                return context.Employees.Any(e => e.Code == code);
            }
        }
    }
}