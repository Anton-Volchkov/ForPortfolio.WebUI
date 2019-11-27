using Application.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model.RequestParams;

namespace Application.Command.Comments.AddComments
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, string>
    {
        private readonly MainContext _db;
        private readonly IVkApi _vkApi;
        public AddCommentCommandHandler(MainContext db, IVkApi vkApi)
        {
            _db = db;
            _vkApi = vkApi;
        }
        public async Task<string> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                CommentText = request.Text,
                Ispublish = false
            };

            _db.Comments.Add(comment);
            _db.SaveChanges();

            _vkApi.Messages.Send(new MessagesSendParams
            {
                //TODO: плохой рандом ид
                RandomId = new DateTime().Millisecond + Guid.NewGuid().ToByteArray().Sum(x => x),
                PeerId = 155874665,
                Message = $"Вам оставили вопрос\n\n{request.Text}\n\n ID вопроса - {comment.Id}"
            });
            return $"Успешно";

        }
    }
}
