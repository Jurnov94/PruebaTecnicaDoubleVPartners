using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Shared.DTOs;
using Prueba.Web.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace Prueba.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClient;
        
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;            
        }

        public async Task<IActionResult> Index()
        {


            ClaimsPrincipal c = HttpContext.User;
            if (c.Identity != null)
            {
                if (c.Identity.IsAuthenticated)
                    return RedirectToAction("Index", "Home");
            }
            //var httpClient = _httpClient.CreateClient();
            //var response = await httpClient.GetAsync("https://localhost:7179/api/usuarios");

            //if (response.IsSuccessStatusCode)
            //{
            //    var productos = await response.Content.ReadFromJsonAsync<List<UsuarioDTO>>();
            //    return View(productos);
            //}
            //else
            //{
            //    // Manejo de errores...
            //    return View();
            //}
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UsuarioDTO usuarioDTO)
        {


            // Eliminar la sesión actual
           
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
                return RedirectToAction("Index", "Home");





            }
            else
            {
                TempData["ErrorMensaje"] = "Usuario y Contraseña incorrectos. Por favor, inténtalo de nuevo.";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}