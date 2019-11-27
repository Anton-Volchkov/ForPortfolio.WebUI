using Application.Command.Comments.AddComments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Command.Comments.PublishComment;
using VkNet.Model;

namespace ForPortfolio.WebUI.Executor
{
    public class MessageExecutor
    {
        private const string ErrorMessage = "Я не знаю такой команды =(";
        private readonly IMediator _mediator;
        public MessageExecutor(IMediator mediator)
        {
            _mediator = mediator;
        }

        // тут вся логика обработки команд
        public async Task<string> HandleMessage(Message msg)
        {
            var split = msg.Text.Split(' ', 3); // [ответ, ид , ответ на комментарий]

            var result = "";

            if (split[0].ToLower() == "да")
            {
                 result = await _mediator.Send(new PublishCommentCommand { Id = Convert.ToInt32(split[1]), Command = split[0].ToLower() , Answer =  split[2]});

            }
            else
            {
                result = await _mediator.Send(new PublishCommentCommand { Id = Convert.ToInt32(split[1]), Command = split[0].ToLower() });
            }



            if (string.IsNullOrEmpty(result)) // если вернули пустую строку или Null
            {
                result = ErrorMessage;
            }

            return result;
        }
    }
}
