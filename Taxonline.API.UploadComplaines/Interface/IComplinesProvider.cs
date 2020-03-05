using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.UploadComplaines.DB;
using Taxonline.API.UploadComplaines.Model;

namespace Taxonline.API.UploadComplaines.Interface
{
   public interface IComplinesProvider
    {
        public Task<(bool IsSuccess, IEnumerable<ComplainesModel> complainesFiles, string ErrorMessage)> GetComplainesFilesAsync(int UserId);
    }
}
