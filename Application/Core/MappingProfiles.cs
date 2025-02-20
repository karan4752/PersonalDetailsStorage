using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BankDetail;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BankDetails, BankDetails>();
            CreateMap<BankDetails, BankDetailsDto>()
                    .ForMember(d => d.UserName, o => o.MapFrom(s => s.UserBankDetails
                    .FirstOrDefault(x => x.IsUserBankDetails).AppUser.UserName));
            CreateMap<UserBankDetails, Profiles.Profile>()
                    .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                    .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio))
                    .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName))
                    ;
        }
    }
}