using AutoMapper;
using GymManagmentBLL.ViewModels.SessionViewModel;
using GymManagmentDAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(dest => dest.CategoryName, Options => Options.MapFrom(src => src.Category.CategoryName))
                 .ForMember(dest => dest.TrainerName, Options => Options.MapFrom(src => src.trainer.Name))
                 .ForMember(dest => dest.TrainerName, Options => Options.Ignore());

        }
    }
}
