using AutoMapper;
using Carepatron.DAL.Entities;
using Carepatron.DAL.Models;

namespace Carepatron.ConfigServices;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Client, ClientModel>();
        CreateMap<ClientModel, Client>();
    }
}

public static class MapperConfigService
{
    public static IServiceCollection RegisterMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}