using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Cli.Commands.Blogs
{
    public class ListTagsCommandCommand
    {
        public class ListTagsCommandRequest : IRequest<ListTagsCommandResponse>
        {
            public ListTagsCommandRequest()
            {

            }
        }

        public class ListTagsCommandResponse
        {
            public ListTagsCommandResponse()
            {

            }
        }

        public class ListTagsCommandHandler : IAsyncRequestHandler<ListTagsCommandRequest, ListTagsCommandResponse>
        {
            public ListTagsCommandHandler(BacklogContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<ListTagsCommandResponse> Handle(ListTagsCommandRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly BacklogContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
