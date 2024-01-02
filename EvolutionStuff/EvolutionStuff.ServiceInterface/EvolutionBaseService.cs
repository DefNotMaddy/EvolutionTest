using CSharpFunctionalExtensions;
using EvolutionStuff.ServiceInterface.Users;
using EvolutionStuff.ServiceModel;
using EvolutionStuff.ServiceModel.Models.DbModel;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using ServiceStack.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace EvolutionStuff.ServiceInterface;

public partial class EvolutionTestService(ILog logger, IUserRepository userRepository, string baseUri) : Service
{
    private readonly ILog _logger = logger;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly string _baseUri = baseUri;
    internal interface IServiceError
    {
    }
    internal class GeneralServiceError(string message) : IServiceError
    {
        public string Message { get; } = message;
    }
    internal static HttpResult CreateResponse(HttpStatusCode httpStatusCode, ICustomResponse response)
    {
        return new HttpResult
        {
            StatusCode = httpStatusCode,
            ContentType = "application/json",
            Response = response
        };

    }
    internal static HttpResult CreateOkResponse(ICustomResponse response)
    {
        return CreateResponse(HttpStatusCode.OK, response);
    }
    internal static HttpResult CreateBadResponse(IServiceError serviceError)
    {
        return serviceError switch
        {
            GeneralServiceError error => CreateResponse(HttpStatusCode.BadRequest, new Response(error.Message)),
            _ => throw new NotSupportedException()
        };
    }
    internal Result<List<UserDb>, IServiceError> AddData(List<UserDb> users)
    {
        try
        {
            _userRepository.UpsertUsers(users);
            return users;
        }
        catch (DbUpdateException ex)
        {
            _logger.Error(ex.Message);
            return Result.Failure<List<UserDb>, IServiceError>(new GeneralServiceError("Record already exists"));
        }
        catch (Exception ex)
        {
            _logger.Error(ex.Message);
            return Result.Failure<List<UserDb>, IServiceError>(new GeneralServiceError(ex.Message));
        }
    }
}