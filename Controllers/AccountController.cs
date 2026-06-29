using Microsoft.AspNetCore.Mvc;
using app_to_do.Models;
using app_to_do.Services;

namespace app_to_do.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            bool valido =
                _authService.ValidarUsuario(
                    model.Usuario,
                    model.Password);

            if (valido)
                return RedirectToAction("Welcome");

            return RedirectToAction("Error");
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
