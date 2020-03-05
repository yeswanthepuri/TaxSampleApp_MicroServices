using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.UploadComplaines.DB;
using Taxonline.API.UploadComplaines.Interface;
using Taxonline.API.UploadComplaines.Model;

namespace Taxonline.API.UploadComplaines.Provider
{
    public class ComplinesProvider : IComplinesProvider
    {
        private readonly UploadDbContext uploadDbContext;
        private readonly IMapper mapper;
        private readonly ILogger<ComplinesProvider> logger;

        public ComplinesProvider(UploadDbContext uploadDbContext,
            ILogger<ComplinesProvider> logger,
                        IMapper mapper
            )
        {
            this.uploadDbContext = uploadDbContext;
            this.mapper = mapper;
            this.logger = logger;

            Seed();
        }
        private void Seed()
        {
            if (!uploadDbContext.ComplainesFiles.Any())
            {
                uploadDbContext.ComplainesFiles.Add(new ComplainesFile() { Id = 1, FileName = "Sample1", FilePath = "//efd-sam/GTO/User2", UserId = 2 });
                uploadDbContext.ComplainesFiles.Add(new ComplainesFile() { Id = 2, FileName = "Sample2", FilePath = "//efd-sam/GTO/User2", UserId = 1 });
                uploadDbContext.ComplainesFiles.Add(new ComplainesFile() { Id = 3, FileName = "Sample3", FilePath = "//efd-sam/GTO/User2", UserId = 2 });
                uploadDbContext.SaveChanges();
            }
        }
        public async Task<(bool IsSuccess, IEnumerable<ComplainesModel> complainesFiles, string ErrorMessage)> GetComplainesFilesAsync(int UserId)
        {
            try
            {
                var complainesFile = await uploadDbContext.ComplainesFiles.Where(x => x.UserId == UserId).ToListAsync();

                if (complainesFile != null && complainesFile.Any())
                {
                    var result = mapper.Map<IEnumerable<ComplainesFile>, IEnumerable<ComplainesModel>>(complainesFile);
                    return (true, result, null);
                }
                return (false, null, "Records not found");
            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message, ex);
                return (false, null, ex.Message);
            }
        }
    }
}
