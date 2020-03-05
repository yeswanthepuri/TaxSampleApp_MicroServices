using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxonline.API.UploadComplaines.DB
{
    public class UploadDbContext : DbContext
    {
        public DbSet<ComplainesFile> ComplainesFiles { get; set; }
        public UploadDbContext(DbContextOptions options) 
            : base(options)
        {

        }
    }
}
