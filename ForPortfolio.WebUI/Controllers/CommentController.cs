using Application.Command.Comments.AddComments;
using ForPortfolio.WebUI.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForPortfolio.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentValidation comment)
        {
            if (ModelState.IsValid)
            {
               var text = await _mediator.Send(new AddCommentCommand { Text = comment.Text });

               return View("~/Views/Home/Succeful.cshtml");
            }

            return View("~/Views/Home/Index.cshtml");
        }
    }
}
