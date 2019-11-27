using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command.Comments.AddComments
{
    public class AddCommentCommand : IRequest<string>
    {
        public string Text { get; set; }
    }
}
