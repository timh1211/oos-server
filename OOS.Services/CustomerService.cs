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
    public class CustomerService: BaseService<Customer, CustomerRepository>
    {
        CustomerRepository customerRepository = new CustomerRepository();

        public override Customer Save(Customer entity)
        {
            Guid id = new Guid(entity.GetType().GetProperty("Id").GetValue(entity, null).ToString());
            if (id == Guid.Empty)
            {
                return customerRepository.Create(entity);
            }
            else
            {
                return repository.Update(entity);
            }
        }

        public dynamic Login(string username, string password)
        {
            var user = repository.Get(username);
            if (user == null) throw new Exception("USER_USERNAME_NOTFOUND");
            if (user.HashedPassword != Utility.HashMD5(password)) throw new Exception("USER_INCORRECT_PASSWORD");
            var token = Utility.Encrypt(user.Id.ToString());
            return new
            {
                token = Utility.Encrypt(user.Id.ToString()),
                username = user.Username,
                firstName = user.FirstName,
                lastName = user.LastName,
                fullName = user.LastName + " " + user.FirstName,
                email = user.Email,
                code = user.Code,
                phone = user.Phone,
                customerId = user.Id,
                address = user.Address
            };
        }

        public Customer SingUp(Customer customer)
        {
            return customerRepository.Create(customer);
        }

        public bool IsValidToken()
        {
            var token = HttpContext.Current.Request.Headers.Get("token").ToString();
            var userId = Utility.Decrypt(token);
            var user = repository.Get(new Guid(userId));
            if (user != null) return true;
            return false;
        }
    }
}
