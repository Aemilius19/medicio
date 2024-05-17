using Medicio.Application.Abstractions;
using Medicio.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Medicio.Presentation.Controllers
{
    public class RegisterController : Controller
    {
        IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            if (!ModelState.IsValid) { return View(); }
            _userService.Create(user);
            return RedirectToAction("Index");
        }
    }
}
