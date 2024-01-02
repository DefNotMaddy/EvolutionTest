using AutoMapper;
using EvolutionStuff.ServiceModel.Models.DbModel;
using EvolutionStuff.ServiceModel.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace EvolutionStuff.ServiceInterface.Helpers
{
    public static class MappingHelper
    {
        private static readonly Mapper Mapper;

        static MappingHelper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            Mapper = new Mapper(mapperConfiguration);
        }

        public static List<UserDb> MapDtoListToDbList(List<UserDto> users)
        {
            return users.Select(user => Mapper.Map<UserDb>(user)).ToList();
        }
        public static List<UserDto> MapDbListToDtoList(List<UserDb> users)
        {
            return users.Select(user => Mapper.Map<UserDto>(user)).ToList();
        }
    }

}
