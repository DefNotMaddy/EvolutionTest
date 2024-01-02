using EvolutionStuff.ServiceInterface.Helpers;
using EvolutionStuff.ServiceModel;
using EvolutionStuff.ServiceModel.Models.Dto;
using ServiceStack;

namespace EvolutionStuff.ServiceInterface
{
    public partial class EvolutionTestService : Service
    {
        public object Any(AnyRequest anyRequest)
        {
            var requestDto = MappingHelper.MapDbListToDtoList(_userRepository.GetAll());
            var restClient = new JsonServiceClient(_baseUri);
            string endUri = "/users";

            _logger.Info($"Preparing API call - POST {nameof(UserDto)}:\n" +
                         $"POST {restClient.BaseUri}{endUri} HTTP/2\n" +
                         $"Host: {restClient.BaseUri}\n" +
                         $"Content-Type: application/json\n" +
                         $"User-Agent: {nameof(EvolutionTestService)}/1.0\n" +
                         $"Headers: {restClient.Headers}\n" +
                         $"Content-Length: {requestDto.SerializeToString().Length}\n\n" +
                         $"Request Body: {requestDto.ToJson()}\n");

            //restClient.RequestFilter += (req) =>
            //{
            //    _logger.Info($"Preparing API call - {req.Method} {nameof(UserDto)}:\n" +
            //                 $"{req.Method} {req.RequestUri}{endUri} HTTP/2\n" +
            //                 $"Host: {req.RequestUri}\n" +
            //                 $"Content-Type: application/json\n" +
            //                 $"User-Agent: {nameof(EvolutionTestService)}/1.0\n" +
            //                 $"Headers: {req.Headers}\n" +
            //                 $"Content-Length: {req.ContentLength}\n\n" +
            //                 $"Request Body: {req.ToJson()}\n");
            //};
            ////var response = restClient.Post(requestDto);
            //_logger.Info($"API response: {response.ToJson()}");
            return null;
        }
    }
}
