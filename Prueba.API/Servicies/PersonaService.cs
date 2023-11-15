using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.API.Data;
using Prueba.Shared.DTOs;
using Prueba.Shared.Entities;
using System.Threading;

namespace Prueba.API.Servicies
{
    public class PersonaService : IPersonaService
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public PersonaService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PersonaDTO>> GetPersonaList()
        {


            var personas = await _dataContext.Persona.ToListAsync();
            var personaDTOs = _mapper.Map<List<PersonaDTO>>(personas);


            return personaDTOs;
        }

        public async Task<bool> CrearPersona(PersonaDTO personaDTO)
        {

            if (PersonaExists(personaDTO.NumeroIdentificacion))
            {
                return false;
            }

            personaDTO.Id = Guid.NewGuid();
            personaDTO.FechaCreacion = DateTime.Now;

            var persona = _mapper.Map<Persona>(personaDTO);

            _dataContext.Persona.Add(persona);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        private bool PersonaExists(int identificacion)
        {
            return (_dataContext.Persona?.Any(e => e.NumeroIdentificacion == identificacion)).GetValueOrDefault();
           
        }

    }
}
