using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxOnline.API.Users.DB;
using TaxOnline.API.Users.Model;

namespace Taxonline.API.WorkItems.Profile
{
    public class UserProfile: AutoMapper.Profile
        {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
