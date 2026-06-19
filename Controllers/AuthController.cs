using Microsoft.AspNetCore.Mvc;
using AppDoAPI.Data;
using System.Linq;
using AppDoAPI.models;

namespace AppDoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        
        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == request.Email && u.password == request.password);

            if (user == null)
            {
                return Unauthorized(new {message = "Usuario no encontrado, reintente su contraseña o usuario"});
            }
            return Ok(new { token = "appdo-token-123", email = user.Email, nombre = user.Nombre });
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {

            var userExists = _context.Users.Any(u => u.Email == request.Email);
            if (userExists)
            {
                // le rebotamos si ya existe dentro de la base
                return BadRequest(new { message = "Este correo ya está registrado." });
            }

            // preparamos al nuevo usuario
            var newUser = new User
            {
                Nombre = request.Nombre,
                Email = request.Email,
                password = request.Password
            };

            // lo guardamos en el sqlite
            _context.Users.Add(newUser);
            _context.SaveChanges(); 

            return Ok(new { message = "Usuario creado con éxito." });
        }
    }
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string password { get; set; } =string.Empty;
    }
    public class RegisterRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}