using OOS.Models;
using OOS.Models.Common;
using OOS.Repositories.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        //public Customer Get(string code)
        //{
        //    using (var context = new OOSContext())
        //    {
        //        return context.Customers.FirstOrDefault(e => e.Code == code && e.Status == true);
        //    }
        //}

        public Customer Get(string username)
        {
            using (var context = new OOSContext())
            {
                return context.Customers.FirstOrDefault(e => e.Username == username && e.Status == true);
            }
        }

        public override Customer Create(Customer entity)
        {
            Guid id = Guid.NewGuid();
            entity.Id = id;
            entity.Status = true;
            entity.HashedPassword = Utilities.Utility.HashMD5(entity.HashedPassword);
            entity.Code = GetCode(entity.FirstName, entity.LastName, id);
            using (var context = new OOSContext())
            {
                context.Customers.Add(entity);
                context.SaveChanges();
                return context.Customers.Find(id);
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
                return context.Customers.Any(e => e.Code == code);
            }
        }
    }
}
