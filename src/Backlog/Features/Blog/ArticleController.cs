using Backlog.Security;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using static Backlog.Features.Blog.AddOrUpdateArticleCommand;

namespace Backlog.Features.Blog
{
    [Authorize]
    [RoutePrefix("api/article")]
    public class ArticleController : ApiController
    {
        public ArticleController(IMediator mediator, IUserManager userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateArticleResponse))]
        public async Task<IHttpActionResult> Add(AddOrUpdateArticleRequest request)
        {
            try
            {                
                await _mediator.Send(request);

                return Ok();
            }
            catch(ArticleSlugExistsException)
            {
                return Conflict();
            }            
        }
            

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateArticleResponse))]
        public async Task<IHttpActionResult> Update(AddOrUpdateArticleRequest request)
            => Ok(await _mediator.Send(request));
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetArticlesQuery.GetArticlesResponse))]
        public async Task<IHttpActionResult> Get()
            => Ok(await _mediator.Send(new GetArticlesQuery.GetArticlesRequest()));

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetArticleByIdQuery.GetArticleByIdResponse))]
        public async Task<IHttpActionResult> GetById([FromUri]GetArticleByIdQuery.GetArticleByIdRequest request)
            => Ok(await _mediator.Send(request));

        [Route("getBySlug")]
        [HttpGet]
        [ResponseType(typeof(GetArticleBySlugQuery.GetArticleBySlugResponse))]
        public async Task<IHttpActionResult> GetBySlug([FromUri]GetArticleBySlugQuery.GetArticleBySlugRequest request)
            => Ok(await _mediator.Send(request));

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveArticleCommand.RemoveArticleResponse))]
        public async Task<IHttpActionResult> Remove([FromUri]RemoveArticleCommand.RemoveArticleRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
        protected readonly IUserManager _userManager;
    }
}