using OOS.Models;
using OOS.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Repositories
{
    public class SupplierRepository: BaseRepository<Supplier>
    {
        public override Supplier Create(Supplier entity)
        {
            Guid id = Guid.NewGuid();
            entity.Id = id;
            entity.Status = true;
            entity.Code = GetCode(entity.Name, id);
            using (var context = new OOSContext())
            {
                context.Suppliers.Add(entity);
                context.SaveChanges();
                return context.Suppliers.Find(id);
            }
        }

        public string GetCode(string name, Guid id)
        {
            var firstKey = "";
            for (int i = 0; i < name.Split(' ').Length ; i++)
            {
                firstKey += name.Split(' ')[i][0].ToString().ToUpper();
            }
            return firstKey + id.ToString().Split('-')[4];
        }
    }
}
