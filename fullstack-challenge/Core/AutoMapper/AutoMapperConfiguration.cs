using AutoMapper;
using Core.Entities;
using Core.Services.Models;

namespace Core.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SwapiSpecies, Species>();
                cfg.CreateMap<SwapiPerson, Person>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        }

    }
}