using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxOnline.API.Users.DB
{
    public class UserDbContext :DbContext
    {

        public DbSet<User> Users { get; set; }
        public UserDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
    }
}
