using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxonline.API.UploadComplaines.DB;
using Taxonline.API.UploadComplaines.Model;
using AutoMapper;

namespace Taxonline.API.UploadComplaines.Profiles
{
    public class ComplineProfile : Profile
    {
        public ComplineProfile()
        {
            CreateMap<ComplainesFile, ComplainesModel>();
        }
    }
}
