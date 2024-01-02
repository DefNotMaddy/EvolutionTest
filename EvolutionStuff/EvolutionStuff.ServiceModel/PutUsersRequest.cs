using EvolutionStuff.ServiceModel.Models.Dto;
using ServiceStack;
using ServiceStack.Web;

namespace EvolutionStuff.ServiceModel;

[Route("/PutUsers", "PUT")]
public class PutUsersRequest : IReturn<IHttpResult>
{
    public UserDto[] Users { get; set; }
}
