using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxOnline.API.Users.DB;
using TaxOnline.API.Users.Model;

namespace TaxOnline.API.Users.Interfaces
{
    public interface IUserProvider
    {
        public Task<(bool IsSuccess, IEnumerable<UserModel> Users, string ErrorMessage)> GetUsersAsync();
        public Task<(bool IsSuccess, UserModel User, string ErrorMessage)> GetUserAsync(int id);

    }
}
