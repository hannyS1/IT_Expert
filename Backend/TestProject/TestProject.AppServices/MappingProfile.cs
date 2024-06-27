using AutoMapper;
using TestProject.Api.Contracts.Data;
using TestProject.Entities;

namespace TestProject.AppServices;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Item, ItemResponseDto>();
    }
}