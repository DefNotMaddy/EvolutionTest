namespace EvolutionStuff.ServiceModel
{
    public interface ICustomResponse { }

    public class Response(object result) : ICustomResponse
    {
        public object Result { get; set; } = result;
    }
}
