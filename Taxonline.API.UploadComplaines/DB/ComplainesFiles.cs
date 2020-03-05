using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxonline.API.UploadComplaines.DB
{
    public class ComplainesFile
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public int UserId { get; set; }
    }
}
