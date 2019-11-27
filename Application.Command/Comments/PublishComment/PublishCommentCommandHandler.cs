using Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Command.Comments.PublishComment
{
    public class PublishCommentCommandHandler : IRequestHandler<PublishCommentCommand, string>
    {
        private readonly MainContext _db;
        public PublishCommentCommandHandler(MainContext db)
        {
            _db = db;
        }
        public async Task<string> Handle(PublishCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _db.Comments.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (comment is null)
            {
                return $"Комментарий с ID {request.Id} не найден.";
            }

            if (request.Command =="да")
            {
                comment.Ispublish = true;
                comment.Answer = request.Answer;
            }
            else
            {
                _db.Comments.Remove(comment);
                _db.SaveChanges();
                return $"Комментарий c ID {request.Id} был удалён";
            }

            _db.SaveChanges();

            return $"Комментарий с ID {request.Id} был добавлен.";
        }
    }
}
