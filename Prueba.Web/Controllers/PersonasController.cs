using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Shared.DTOs;
using Prueba.Web.Helper;


namespace Prueba.Web.Controllers
{
    [Authorize]
    public class PersonasController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ICombosHelper _combosHelper;

        public PersonasController(IHttpClientFactory httpClient, ICombosHelper combosHelper)
        {
            _httpClient = httpClient;
            _combosHelper = combosHelper;
        }
        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClient.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7179/api/personas");

            if (response.IsSuccessStatusCode)
            {
                var personas = await response.Content.ReadFromJsonAsync<List<PersonaDTO>>();
                return View(personas);
            }
            else
            {

                return View();
            }

        }


        public async Task<IActionResult> Create()
        {

            ViewBag.TiposdeDocumento = _combosHelper.GetComboTipoIdentificacion();


            return View();


        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonaDTO personaDTO)
        {
            
            var client = _httpClient.CreateClient();
            var apiUrl = "https://localhost:7179/api/personas";

            var response = await client.PostAsJsonAsync(apiUrl, personaDTO);

            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Personas");
            }
            else
            {
                TempData["ErrorMensaje"] = "No se pudo agregar la persona. Por favor, inténtalo de nuevo.";
                ViewBag.TiposdeDocumento = _combosHelper.GetComboTipoIdentificacion();
                return View();
            }

        }


    }
}
