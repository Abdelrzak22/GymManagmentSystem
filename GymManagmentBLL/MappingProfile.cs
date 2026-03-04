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
                 .ForMember(dest => dest.StartDate, Options => Options.MapFrom(src => src.CreatedAt))
                 .ForMember(dest => dest.TrainerName, Options => Options.Ignore());

            CreateMap<CreateSessionViewModel, Session>()
                 .ForMember(dest => dest.CreatedAt, Options => Options.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.trainerId, Options => Options.MapFrom(src => src.TrainerId));

            CreateMap<Session, UpdateSessionViewModel>()
                  .ForMember(dest => dest.StartDate, Options => Options.MapFrom(src => src.CreatedAt))
                  .ForMember(dest => dest.TrainerId, Options => Options.MapFrom(src => src.trainerId));

            CreateMap<UpdateSessionViewModel, Session>()
                 .ForMember(dest => dest.CreatedAt, Options => Options.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.trainerId, Options => Options.MapFrom(src => src.TrainerId));



        }
    }
}
