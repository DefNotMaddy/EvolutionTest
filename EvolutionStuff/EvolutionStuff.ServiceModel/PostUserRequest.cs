using EvolutionStuff.ServiceModel.Models.Dto;
using ServiceStack;
using ServiceStack.Web;
using System.Collections.Generic;

namespace EvolutionStuff.ServiceModel;


[Route("/PostUsers", "POST")]
public class PostUsersRequest : IReturn<IHttpResult>
{
    public List<UserDto> Users { get; set; }
}
