using ServiceStack;

namespace EvolutionStuff.ServiceModel;

[Route("/Any")]
public record AnyRequest() : IReturnVoid;
