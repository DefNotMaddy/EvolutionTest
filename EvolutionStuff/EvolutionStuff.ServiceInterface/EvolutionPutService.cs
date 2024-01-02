using CSharpFunctionalExtensions;
using EvolutionStuff.ServiceModel;
using EvolutionStuff.ServiceModel.Models.DbModel;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using System;
using System.Collections.Generic;

namespace EvolutionStuff.ServiceInterface;

public partial class EvolutionTestService : Service
{
    public object Put(PutUsersRequest putRequest)
    {
        List<UserDb> users = [];
        return GetData(users)
            .Bind(AddData)
            .Match(
            onSuccess: users => CreateOkResponse(new Response($"{users.Count} has been put into the DB")),
            onFailure: error => CreateBadResponse(error));
    }
    internal Result<List<UserDb>, IServiceError> GetData(List<UserDb> users)
    {
        try
        {
            JsonServiceClient restClient = new(_baseUri);
            users = restClient.Get<List<UserDb>>("/users");

            _logger.Info($"Payload received: {users.ToJson()}");

            return users != null
                ? Result.Success<List<UserDb>, IServiceError>(users)
                : new GeneralServiceError("Invalid data");
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return Result.Failure<List<UserDb>, IServiceError>(new GeneralServiceError(ex.Message));
        }
    }
}