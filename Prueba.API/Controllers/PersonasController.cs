using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.API.Data;
using Prueba.API.Servicies;
using Prueba.Shared.DTOs;
using Prueba.Shared.Entities;

namespace Prueba.API.Controllers
{
    [Route("api/personas")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        
        private readonly IPersonaService _personaService;
        private readonly IMapper _mapper;
        public PersonaController(IPersonaService personaService, IMapper mapper)
        {
            _personaService = personaService;
            _mapper = mapper;

        }

        // GET: api/Persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDTO>>> GetPersonas()
        {
            return Ok(await _personaService.GetPersonaList());
        }

       
        
        // POST: api/Persona
        [HttpPost]
        public async Task<ActionResult<PersonaDTO>> PostPersona(PersonaDTO personaDTO)
        {
            
            if (personaDTO == null) { return BadRequest(); }

            
            if (!await _personaService.CrearPersona(personaDTO))
            {
                return BadRequest();
            }

            return Ok(personaDTO);
        }
                
      
    }
}
