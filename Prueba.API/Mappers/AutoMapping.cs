using AutoMapper;
using Prueba.Shared.DTOs;
using Prueba.Shared.Entities;

namespace Prueba.API.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Persona, PersonaDTO>();
            CreateMap<PersonaDTO, Persona>();

            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();


        }
    }
}
