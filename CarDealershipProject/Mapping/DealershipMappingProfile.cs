using System;
using AutoMapper;

namespace CarDealershipProject.Mapping
{
    public class DealershipMappingProfile : Profile
    {
        public DealershipMappingProfile()
        {

            CreateMap<CarDealershipProject.Models.CarSearchRequest, CarDealershipProject.Core.Domain.Content.CarSearchRequest>();
            CreateMap<CarDealershipProject.Core.Domain.Content.Car, CarDealershipProject.Models.Car>();
        }
    }
}
