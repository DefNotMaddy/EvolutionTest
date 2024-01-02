using CSharpFunctionalExtensions;
using EvolutionStuff.ServiceInterface.Helpers;
using EvolutionStuff.ServiceModel;
using EvolutionStuff.ServiceModel.Models.DbModel;
using ServiceStack;
using System;
using System.Collections.Generic;

namespace EvolutionStuff.ServiceInterface
{
    public partial class EvolutionTestService : Service
    {
        public object Post(PostUsersRequest postUsersRequest)
        {
            return Parse(postUsersRequest)
                .Bind(AddData)
                .Match(
                onSuccess: users => CreateOkResponse(new Response($"{users.Count} has been upserted into the DB")),
                onFailure: error => CreateBadResponse(error));
        }
        private Result<List<UserDb>, IServiceError> Parse(PostUsersRequest postUsersRequest)
        {
            try
            {
                _logger.Info($"Processing request body: {postUsersRequest}");
                return MappingHelper.MapDtoListToDbList(postUsersRequest.Users);
            }
            catch (Exception ex)
            {
                return Result.Failure<List<UserDb>, IServiceError>(new GeneralServiceError($"Error while trying to map the document.\n" + $"{ex.Message}"));
            }
        }
    }
}
