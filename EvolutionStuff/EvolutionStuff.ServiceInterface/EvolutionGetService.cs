using EvolutionStuff.ServiceInterface.Helpers;
using EvolutionStuff.ServiceModel;
using EvolutionStuff.ServiceModel.Models.Dto;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolutionStuff.ServiceInterface
{
    public partial class EvolutionTestService : Service
    {
        public object Get(GetRequest user)
        {
            try
            {
                return (user?.UserId) switch
                {
                    null => _userRepository.GetAll().ToJson(),
                    int userId => _userRepository.GetOne(userId),
                };
            }
            catch (Exception ex)
            {
                return CreateBadResponse(new GeneralServiceError(ex.Message));
            }
        }
        public object Get(GetDiscrepencies getDiscrepencies)
        {
            try
            {
                JsonServiceClient restClient = new(_baseUri);

                List<UserDto> usersDb = MappingHelper.MapDbListToDtoList(_userRepository.GetAll());
                List<UserDto> usersRequest = restClient.Get<List<UserDto>>("/users");
                List<UserDto> differences = usersRequest.Except(usersDb).ToList();

                return differences.ToJson();

            }
            catch (Exception ex)
            {
                return CreateBadResponse(new GeneralServiceError(ex.Message));
            }
        }
    }
}
