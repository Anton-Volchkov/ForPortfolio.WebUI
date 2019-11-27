using System;
using System.Collections.Generic;
using System.Text;
using Application.Data;
using MediatR;

namespace Application.Command.Comments.GetAllComments
{
    public class GetAllCommentsQuery : IRequest<Comment[]>
    {
    }
}
