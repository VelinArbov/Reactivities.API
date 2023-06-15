﻿using Application.Activities;
using AutoMapper;
using Data;
using Domain;

namespace API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Activity, Activity>();
            CreateMap<Activity, ActivityDto>().ForMember(d => d.HostUsername,
                o
                    => o.MapFrom(s => s.Attendees
                        .FirstOrDefault(x => x.IsHost).AppUser.UserName));

            CreateMap<ActivityUser, Application.Profiles.Profile>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio));

            CreateMap<AppUser, Application.Profiles.Profile>()
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}