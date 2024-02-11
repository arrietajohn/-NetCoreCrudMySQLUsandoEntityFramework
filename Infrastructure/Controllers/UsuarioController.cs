using System.Net;
using CrudApiMySqlEf.Domain.Enties;
using CrudApiMySqlEfNet6.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiMySqlEfNet6.Infrastructure.Controllers;

[Route("api.[controller]")]
public class UsuarioController : ControllerBase
{

    private IUsuarioRepository usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        this.usuarioRepository = usuarioRepository;
    }

    [HttpPost]
    [Route("Post")]
    public IActionResult InsertUsuario([FromBody] Usuario usuario)
    {
        try
        {
            usuarioRepository.Insertar(usuario);
            return CreatedAtAction(null, new {Mensaje = "Usuario creado", usuario});
        }
        catch (System.Exception error)
        {
            return Problem(
                        detail: error.Message
                        , statusCode: (int?)HttpStatusCode.Found
                        , type: "Insertar"
                        , title: "Crear Usuario"
                        );
        }
    }

    [HttpGet]
    [Route("All")]
    public IActionResult ListAll()
    {
        List<Usuario> usuarios = usuarioRepository.ListarTodo();
        return Ok(usuarios);
    }

    [HttpGet]
    [Route("Get/{id}")]
    public IActionResult FindById([FromRoute] int id)
    {
        try
        {
            var usaurio = this.usuarioRepository.BuscarPorId(id);
            return Ok(usaurio);
        }
        catch (System.Exception error)
        {
            System.Console.WriteLine("ERROR: " + error.Message);
            return Problem(
                        detail: error.Message
                        , statusCode: (int?)HttpStatusCode.NotFound
                        , type: "Consulta"
                        , title: "Consulta de Usuario"
                        );
        }
    }

    [HttpGet]
    [Route("Count")]
    public IActionResult Count()
    {
        var resultado = new { items = usuarioRepository.Contar() };
        return Ok(resultado);
    }

    [HttpPut]
    [Route("Put/{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Usuario usuario)
    {
        try
        {
            usuario.Id = id;
            usuarioRepository.Actualizar(usuario);
            return CreatedAtAction(null, new { Mensaje = "Usaurio actualizado" });
        }
        catch (System.Exception error)
        {
            return Problem(title: "Actualizar Usuario"
                     , detail: error.Message
                     , type: "Actualizacion"
                     , statusCode: (int)HttpStatusCode.NotFound);
        }
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public IActionResult DeleteUsuario([FromRoute] int id)
    {
        try
        {
            usuarioRepository.EliminarPorId(id);
            return NoContent();
        }
       catch (System.Exception error)
        {
            return Problem(title: "Eliminar Usuario"
                     , detail: error.Message
                     , type: "Eliminar"
                     , statusCode: (int)HttpStatusCode.NotFound);
        }
    }

    [HttpDelete]
    [Route("Delete/All")]
    public IActionResult DeleteAllUsuario()
    {
        try
        {
            long total = usuarioRepository.EliminarTodo();
            return Ok(new {Total=total});
        }
       catch (System.Exception error)
        {
            return Problem(title: "Eliminar Todos los Usuarios"
                     , detail: error.Message
                     , type: "Eliminar"
                     , statusCode: (int)HttpStatusCode.NotFound);
        }
    }
    
}