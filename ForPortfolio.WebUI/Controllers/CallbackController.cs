using Application.Data;
using ForPortfolio.WebUI.Executor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using VkBot.Data.Models;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace ForPortfolio.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        /// <summary>
        ///     Конфигурация приложения
        /// </summary>
        private readonly IConfiguration _configuration;

        private readonly IVkApi _vkApi;

        private readonly MessageExecutor _executor;

        private readonly MainContext _db;


        public CallbackController(IVkApi vkApi, IConfiguration configuration, MainContext db, MessageExecutor executor)
        {
            _vkApi = vkApi;
            _configuration = configuration;
            _db = db;
            _executor = executor;
        }

        [HttpPost]
        public async Task<IActionResult> Callback([FromBody] Updates updates)
        {
            // Проверка совпадения ключа
            if(updates.Secret != _configuration["secret"])
            {
                return Ok("Bad Secret Key");
            }

            // Проверяем, что находится в поле "type" 
            if (updates.Type == "confirmation")
            {
                // Отправляем строку для подтверждения 
                return Ok(_configuration["Config:Confirmation"]);
            }

            if (updates.Type == "message_new")
            {
                var msg = Message.FromJson(new VkResponse(updates.Object));

                if (msg.FromId.Value != 155874665)
                {
                    return Ok("ok");
                }

                var text = await _executor.HandleMessage(msg);

             
                // Отправим в ответ полученный от пользователя текст
                _vkApi.Messages.Send(new MessagesSendParams
                {
                    //TODO: плохой рандом ид
                    RandomId = new DateTime().Millisecond + Guid.NewGuid().ToByteArray().Sum(x => x),
                    PeerId = msg.PeerId.Value,
                    Message = text
                });
            }

            // Возвращаем "ok" серверу Callback API
            return Ok("ok");
        }
    }
}
