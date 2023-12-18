using AirBnB.Api.Models.Dtos;
using AirBnB.Domain.Entities;
using AutoMapper;

namespace AirBnB.Api.Mappers;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<Location, LocationDto>().ForMember(dest => dest.Price, src => src.MapFrom(src => src.PricePerNight * 5));
    }
}