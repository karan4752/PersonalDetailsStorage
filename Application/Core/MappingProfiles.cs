using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.BankDetail;
using Application.CardDetail;
using Application.NetbankingDetails;
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
                    .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName));

            CreateMap<AppUser, Profiles.Profile>()
                    .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.DisplayName))
                    .ForMember(d => d.Username, o => o.MapFrom(s => s.UserName))
                    .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<Domain.CardDetail, CardDetailDto>().ReverseMap();
            CreateMap<NetBankingDetail, NetBankingDetailDto>().ReverseMap();
        }
    }
}