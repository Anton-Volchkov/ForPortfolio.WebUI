using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Data;
using MediatR;

namespace Application.Command.Comments.GetAllComments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, Comment[]>
    {
        private readonly MainContext _db;
    
        public GetAllCommentsQueryHandler(MainContext db)
        {
            _db = db;
        }

        public async Task<Comment[]> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            return  _db.Comments.Where(x => x.Ispublish == true).ToArray();

        }
    }
}
