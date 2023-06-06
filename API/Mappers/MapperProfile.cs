using AutoMapper;
using Domain;

namespace API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Activity, Activity>();
        }
    }
}
