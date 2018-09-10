using OOS.Models;
using OOS.Repositories;
using OOS.Repositories.Common;
using OOS.Services.Common;
using OOS.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OOS.Services
{
    public class EmployeeService : BaseService<Employee, EmployeeRepository>
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();

        public override Employee Save(Employee entity)
        {
            Guid id = new Guid(entity.GetType().GetProperty("Id").GetValue(entity, null).ToString());
            if (id == Guid.Empty)
            {
                return employeeRepository.Create(entity);
            }
            else
            {
                return repository.Update(entity);
            }
        }

        //public override PagedListResult List(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        //{
        //    return employeeRepository.List(whereClause, orderBy, orderDirection, pageNumber, pageSize);
        //}

        //public override PagedListResult List(PagedListRequest request)
        //{
        //    return this.List(request.whereClause, request.orderBy, request.orderDirection, request.pageNumber, request.pageSize);
        //}
    }
}
