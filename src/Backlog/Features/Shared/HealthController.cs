using System.Web.Http;

namespace Backlog.Features.Shared
{
    [AllowAnonymous]
    [RoutePrefix("api/health")]
    public class HealthController: ApiController
    {
        [HttpGet]
        [Route("status")]
        public IHttpActionResult Status() => Ok();
    }
}