using CSharpFunctionalExtensions;
using EvolutionStuff.ServiceModel;
using ServiceStack;
using System;

namespace EvolutionStuff.ServiceInterface
{
    public partial class EvolutionTestService : Service
    {
        public object Delete(DeleteUserRequest user)
        {
            return DeleteById(user.UserId)
                .Match(
                onSuccess: id => CreateOkResponse(new Response($"User with {user.UserId} has been deleted.")),
                onFailure: error => CreateBadResponse(error));
        }
        internal Result<int, IServiceError> DeleteById(int id)
        {
            try
            {
                _userRepository.Delete(id);
                return id;
            }
            catch (Exception ex)
            {
                return Result.Failure<int, IServiceError>(new GeneralServiceError(ex.Message));
            }
        }
    }
}
