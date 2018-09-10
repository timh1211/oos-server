using OOS.Models;
using OOS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOS.Utilities;
using System.Web;
using OOS.Repositories.Common;
using System.Collections;
using OOS.Services.Common;

namespace OOS.Services
{
    public class AccountService : BaseService<Account, AccountRepository>
    {
        AccountRepository accountRepository = new AccountRepository();

        public Account GetAccountOfEmployee(Guid employeeID)
        {
            return accountRepository.GetAccountOfEmployee(employeeID);
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
                firstName = user.Owner.FirstName,
                lastName = user.Owner.LastName,
                fullName = user.Owner.LastName + " " + user.Owner.FirstName
            };
        }

        public override PagedListResult List(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        {
            return accountRepository.List(whereClause, orderBy, orderDirection, pageNumber, pageSize);
        }

        public override PagedListResult List(PagedListRequest request)
        {
            return this.List(request.whereClause, request.orderBy, request.orderDirection, request.pageNumber, request.pageSize);
        }

        public override IEnumerable All()
        {
            return accountRepository.All();
        }

        public override IEnumerable All(string whereClause)
        {
            if (string.IsNullOrWhiteSpace(whereClause)) return accountRepository.All();
            return accountRepository.All(whereClause);
        }

        public override Account Save(Account entity)
        {
            Guid id = new Guid(entity.GetType().GetProperty("Id").GetValue(entity, null).ToString());
            if (id == Guid.Empty)
            {
                return accountRepository.Create(entity);
            }
            else
            {
                return accountRepository.Update(entity);
            }
        }

        public Account GetCurrentUser()
        {
            var token = HttpContext.Current.Request.Headers.Get("token").ToString();
            var userId = Utility.Decrypt(token);
            var user = repository.Get(new Guid(userId));
            if (user != null) return user;
            else throw new Exception("TOKEN_INVALID");
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
