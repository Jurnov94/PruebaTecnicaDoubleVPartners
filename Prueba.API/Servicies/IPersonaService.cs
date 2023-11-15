using Prueba.Shared.DTOs;


namespace Prueba.API.Servicies
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaDTO>> GetPersonaList();
        Task<bool> CrearPersona(PersonaDTO personaDTO);


    }
}
