using Grpc.Net.Client;
using GrpcProtos.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {

        private readonly ILogger<HelloController> _logger;
        private readonly Greeter.GreeterClient _greeterClient;

        public HelloController(ILogger<HelloController> logger, Greeter.GreeterClient greeterClient)
        {
            _logger = logger;
            _greeterClient = greeterClient;
        }

        [HttpGet]
        public async Task<HelloReply> GetAsync()
        {      
            var reply = await _greeterClient.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            return reply;


        }
    }
}
