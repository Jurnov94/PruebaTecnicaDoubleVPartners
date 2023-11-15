using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.API.Servicies;
using Prueba.Shared.DTOs;
using Prueba.Shared.Entities;

namespace Prueba.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;

        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            return Ok(await _usuarioService.GetUsuarioList());
        }



        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> PostUsuario(UsuarioDTO usuarioDTO)
        {

            if (usuarioDTO == null) { return BadRequest(); }

            if (!await _usuarioService.CrearUsuario(usuarioDTO))
            {
                return BadRequest();
            }

            return Ok(usuarioDTO);
        }


    }
}
