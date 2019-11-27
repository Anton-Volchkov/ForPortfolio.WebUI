using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command.Comments.PublishComment
{
    public class PublishCommentCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Command { get; set; }
        public string Answer { get; set; }
    }
}
