using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Shared.DTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Prueba.Web.Controllers
{
    
    public class UsuariosController : Controller
    {

        private readonly IHttpClientFactory _httpClient;

        public UsuariosController(IHttpClientFactory httpClient)
        {
             _httpClient = httpClient;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClient.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7179/api/usuarios");

            if (response.IsSuccessStatusCode)
            {
                var productos = await response.Content.ReadFromJsonAsync<List<UsuarioDTO>>();
                return View(productos);
            }
            else
            {
                
                return View();
            }
            
        }


        public async Task<IActionResult> Create()
        {
                       
            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioDTO usuarioDTO)
        {
            // Eliminar la sesión actual
            
            var client = _httpClient.CreateClient();
            var apiUrl = "https://localhost:7179/api/usuarios";

            var response = await client.PostAsJsonAsync(apiUrl, usuarioDTO);

            if (response.IsSuccessStatusCode)
            {
               
                return RedirectToAction("Login", "Account");
            }
            else
            {
                   TempData["ErrorMensaje"] = "No se pudo agregar el usuario. Por favor, inténtalo de nuevo.";
        return View();
            }

        }

    }
}
