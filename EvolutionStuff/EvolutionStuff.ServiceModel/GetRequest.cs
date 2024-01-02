using ServiceStack;
using ServiceStack.Web;

namespace EvolutionStuff.ServiceModel
{

    [Route("/Get", "GET")]
    [Route("/Get/{UserId}", "GET")]
    public record GetRequest(int? UserId) : IReturn<IHttpResult>;

    [Route("/Get/Discrepencies", "GET")]
    public class GetDiscrepencies() : IReturn<IHttpResult> { }

}