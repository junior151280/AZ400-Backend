using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AZ400_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureArtifactsController : ControllerBase
    {
        // GET: api/<AzureArtifactsController>/feedId
        [HttpGet("{feedId}")]
        public string Get(string feedId)
        {
            Service service = new();
            
            return JsonConvert.SerializeObject(service.GetPackages(feedId).Result);
        }

        // GET api/<AzureArtifactsController>/feedId/packageId
        [HttpGet("{feedId}/{packageName}")]
        public string Get(string feedId, string packageName)
        {
            Service service = new();

            return JsonConvert.SerializeObject(service.GetPackage(feedId, packageName).Result);
        }
    }
}
