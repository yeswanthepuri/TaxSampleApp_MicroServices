using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxOnline.API.Users.DB;
using TaxOnline.API.Users.Interfaces;
using TaxOnline.API.Users.Model;

namespace TaxOnline.API.Users.Provider
{
    public class UserProvider : IUserProvider
    {
        private readonly UserDbContext dataBase;
        private readonly ILogger<UserProvider> logger;
        private readonly IMapper mapper;

        public UserProvider(UserDbContext dataBase,
            ILogger<UserProvider> logger,
            IMapper mapper)
        {
            this.dataBase = dataBase;
            this.logger = logger;
            this.mapper = mapper;

            Seed();
        }
        private void Seed()
        {
            if (!dataBase.Users.Any())
            {
                dataBase.Users.Add(new User() { ID = 1, Name = "Yeswanth", Address = "Vizag", Email = "Epuri.yeshu@gMail.com" });
                dataBase.Users.Add(new User() { ID = 2, Name = "Seth", Address = "Atlanta", Email = "Seth@us.gt.com" });
                dataBase.Users.Add(new User() { ID = 3, Name = "Samir", Address = "Bihar", Email = "SamirGover@us.gt.com" });
                dataBase.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, UserModel User, string ErrorMessage)> GetUserAsync(int id)
        {

            try
            {
                var User = await dataBase.Users.FirstOrDefaultAsync(x=>x.ID==id);
                if (User != null)
                {
                    var result = mapper.Map<User, UserModel>(User);
                    return (true, result, null);
                }
                return (false, null, "Records Not Found");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<UserModel> Users, string ErrorMessage)> GetUsersAsync()
        {
            try
            {
                var User = await dataBase.Users.ToListAsync();
                if (User != null && User.Any())
                {
                    var result = mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(User);
                    return (true, result, null);
                }
                return (false, null, "Records Not Found");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                return (false, null, ex.Message);
            }
        }
    }
}
