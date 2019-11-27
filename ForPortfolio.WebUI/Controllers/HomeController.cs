using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Command.Comments.GetAllComments;
using Microsoft.AspNetCore.Mvc;
using ForPortfolio.WebUI.Models;

using MediatR;

namespace ForPortfolio.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ViewResult> Index()
        {
            return View();
        }

        public async Task<ViewResult> Comments()
        {
            var comments = await _mediator.Send(new GetAllCommentsQuery());

            return View(comments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
