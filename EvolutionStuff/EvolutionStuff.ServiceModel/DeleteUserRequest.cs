using ServiceStack;

namespace EvolutionStuff.ServiceModel;

[Route("/Delete/{UserId}", "DELETE")]
public record DeleteUserRequest(int UserId) : IReturnVoid;
