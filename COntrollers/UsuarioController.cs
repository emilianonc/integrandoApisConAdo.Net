using Microsoft.AspNetCore.Mvc;
using Emiliano_Chiapponi.Controllers.DTOS;

namespace Emiliano_Chiapponi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuarioController : ControllerBase
    {
        // Probado desde Postman:  (Devuelve: los 2 usuarios en BD y un "200 OK" )
        // (GET "http://localhost:5232/Usuario" Body none)
        [HttpGet(Name = "TraerUsuarios")] // No se reciben argumentos desde la URL. El cuerpo de la petición siempre está vacío.
        public List<Usuario> TraerUsuarios()
        {
            return UsuarioHandler.TraerUsuarios();
        }



        // Probado desde Postman: (Devuelve: TRUE y un "200 OK". Se valida que se modificó el usuario en BD)
        // (PUT "http://localhost:5232/Usuario" Body raw JSON)
        /*{
            "Id" : 2 ,
            "Nombre" : "Ernesto_" ,
            "Apellido" : "Perez_" ,
            "NombreUsuario" : "eperez123" ,
            "Contraseña" : "SoyErnestoPerez2" ,
            "Mail" : "ernesto@perez.com.ar"
        } */
        [HttpPut(Name = "ModificarUsuario")] // No se reciben argumentos desde la URL. El cuerpo de la petición debe contener los atributos del Usuario
                                             // El nombre de los atributos, utilizado en el JSON (Postman), debe coincidir con el nombre de los atributos definidos en PutUsuario.
        public bool ModificarUsuario([FromBody] PutUsuario usuario)
        {
            try
            {
                return UsuarioHandler.ModificarUsuario(
                    new Usuario
                    {
                        id = usuario.Id,
                        nombre = usuario.Nombre,
                        apellido = usuario.Apellido,
                        nombreUsuario = usuario.NombreUsuario,
                        contraseña = usuario.Contraseña,
                        mail = usuario.Mail
                    }
                );
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}


