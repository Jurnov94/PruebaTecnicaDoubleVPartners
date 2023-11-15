using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Prueba.Shared.DTOs;
using System.Security.Claims;

namespace Prueba.Web.Controllers
{
    public class AccountController : Controller
    {
       
        private readonly IHttpClientFactory _httpClient;

        public AccountController( IHttpClientFactory httpClient)
        {           
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Login()
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Usuarios");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioDTO usuarioDTO)
        {
           

            var client = _httpClient.CreateClient();
            var apiUrl = "https://localhost:7179/api/Autenticaciones";

            var response = await client.PostAsJsonAsync(apiUrl, usuarioDTO);

            if (response.IsSuccessStatusCode)
            {

                List<Claim> c = new List<Claim>()
                                {
                                    new Claim(ClaimTypes.NameIdentifier, usuarioDTO.NombreUsuario)
                                };
                ClaimsIdentity ci = new(c, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties p = new();

                p.AllowRefresh = true;

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);

                return RedirectToAction("Index", "Personas");


            }
            else
            {
                TempData["ErrorMensaje"] = "Usuario y Contraseña incorrectos. Por favor, inténtalo de nuevo.";
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

    }
}
