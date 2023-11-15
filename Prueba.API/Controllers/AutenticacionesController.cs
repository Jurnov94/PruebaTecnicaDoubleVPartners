using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.API.Servicies;
using Prueba.Shared.DTOs;

namespace Prueba.API.Controllers
{
    [Route("api/Autenticaciones")]
    [ApiController]
    public class AutenticacionesController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public AutenticacionesController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;

        }

        // POST: api/Persona
        [HttpPost]
        public async Task<ActionResult<bool>> Login(UsuarioDTO usuarioDTO)
        {

            if (usuarioDTO == null) { return BadRequest(); }

            if (!await _usuarioService.Login(usuarioDTO))
            {
                return BadRequest(false);
            }

            return Ok(true);
        }



    }
}
