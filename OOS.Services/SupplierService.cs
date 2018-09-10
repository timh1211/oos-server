using OOS.Models;
using OOS.Repositories;
using OOS.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOS.Services
{
    public class SupplierService: BaseService<Supplier, SupplierRepository>
    {
        SupplierRepository supplierRepository = new SupplierRepository();

        public override Supplier Save(Supplier entity)
        {
            Guid id = new Guid(entity.GetType().GetProperty("Id").GetValue(entity, null).ToString());
            if (id == Guid.Empty)
            {
                return supplierRepository.Create(entity);
            }
            else
            {
                return repository.Update(entity);
            }
        }
    }
}
