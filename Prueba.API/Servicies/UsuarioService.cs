using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Prueba.API.Data;
using Prueba.Shared.DTOs;
using Prueba.Shared.Entities;
using System.Threading;

namespace Prueba.API.Servicies
{
    public class UsuarioService : IUsuarioService
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public UsuarioService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        
        public async Task<IEnumerable<UsuarioDTO>> GetUsuarioList()
        {


            var usuarios = await _dataContext.Usuario.ToListAsync();
            var uusariosDTOs = _mapper.Map<List<UsuarioDTO>>(usuarios);


            return uusariosDTOs;
        }

        public async Task<bool> CrearUsuario(UsuarioDTO usuarioDTO)
        {

            

            if (UsuarioExists(usuarioDTO.NombreUsuario))
            {
                return false;
            }

            usuarioDTO.Id = Guid.NewGuid();
            usuarioDTO.FechaCreacion = DateTime.Now;

            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            _dataContext.Usuario.Add(usuario);
            await _dataContext.SaveChangesAsync();

            return true;

        }


        public async Task<bool> Login(UsuarioDTO usuarioDTO)
        {


            var usuarios = await _dataContext.Usuario.ToListAsync();
            var usariosDTOs = _mapper.Map<List<UsuarioDTO>>(usuarios);

            var existe =  usariosDTOs.Where(u => u.NombreUsuario == usuarioDTO.NombreUsuario).Where(u => u.Password == usuarioDTO.Password).ToList();

            if (existe.Count() <= 0)
            {
                return false;
            }

            return true;
        }


        private  bool UsuarioExists(string nombreUsuario)
        {
            return (_dataContext.Usuario?.Any(e => e.NombreUsuario.Equals(nombreUsuario))).GetValueOrDefault();

        }


    }
}
