using Prueba.Shared.DTOs;


namespace Prueba.API.Servicies
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetUsuarioList();
        Task<bool> CrearUsuario(UsuarioDTO usuarioDTO);

        Task<bool> Login(UsuarioDTO usuarioDTO);


    }
}
