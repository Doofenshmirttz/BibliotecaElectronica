using BibliotecaElectronica.Data.Context;
using BibliotecaElectronica.Data.Models;
using BibliotecaElectronica.Data.Request;
using BibliotecaElectronica.Data.Response;

using Microsoft.EntityFrameworkCore;

namespace BibliotecaElectronica.Data.Services
{


    public class UsuarioServices : IUsuarioServices
    {
        private readonly IBibliotecaElectronicaDbContext dbContext;

        public UsuarioServices(IBibliotecaElectronicaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(UsuarioRequest request)
        {
            try
            {
                var usuario = Usuario.Crear(request);

                var existente = await dbContext.Usuarios.AnyAsync(u => u.NombreUsuario == request.NombreUsuario);

                if (!existente)
                {
                    dbContext.Usuarios.Add(usuario);
                    await dbContext.SaveChangesAsync();
                    return new Result() { Message = "Te has regitrado correctamente", Success = true };

                }
                else
                {
                    return new Result() { Message = "Usuario ya existente", Success = false };
                }

            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(UsuarioRequest request)
        {
            try
            {
                var usuario = await dbContext.Usuarios
                    .FirstOrDefaultAsync(u => u.IdUsuario == request.IdUsuario);



                if (usuario == null)
                    return new Result() { Message = "No se encontró el usuario", Success = false };

                if (usuario.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Eliminar(UsuarioRequest request)
        {
            try
            {
                var usuario = await dbContext.Usuarios
                    .FirstOrDefaultAsync(u => u.IdUsuario == request.IdUsuario && u.Clave == request.Clave);

                if (usuario == null)
                    return new Result() { Message = "No se encontró el usuario", Success = false };

                if (usuario != null)
                    dbContext.Usuarios.Remove(usuario);
                await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result<UsuarioResponse>> Consultar(UsuarioRequest usuario)
        {
            try
            {


                var usuarios = await dbContext.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.NombreUsuario == usuario.NombreUsuario && u.Clave == usuario.Clave
                );

                if (usuarios != null)
                {
                    var usuarioResponse = usuarios.ToResponse();
                    return new Result<UsuarioResponse>()
                    {
                        Message = "Ok",
                        Success = true,
                        Data = usuarioResponse
                    };
                }
                else
                {
                    return new Result<UsuarioResponse>()
                    {
                        Message = "No se encontró el usuario",
                        Success = false
                    };
                }


            }
            catch (Exception E)
            {
                return new Result<UsuarioResponse>()
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }


        public async Task<Result<UsuarioResponse>> ConsultarUsuario(int Id)
        {
            try
            {


                var usuario = await dbContext.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.IdUsuario == Id);


                if (usuario != null)
                {
                    var usuarioResponse = usuario.ToResponse();
                    return new Result<UsuarioResponse>()
                    {
                        Message = "Ok",
                        Success = true,
                        Data = usuarioResponse
                    };
                }
                else
                {
                    return new Result<UsuarioResponse>()
                    {
                        Message = "No se encontró el usuario",
                        Success = false
                    };
                }


            }
            catch (Exception E)
            {
                return new Result<UsuarioResponse>()
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }

}
