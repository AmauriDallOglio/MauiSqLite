using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Dominio.Interface;
using MauiSqLite.Infra.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MauiSqLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly MeuContexto _context;
        private readonly IUsuarioRepositorio _repositorio;
        public UsuarioController(MeuContexto context, IUsuarioRepositorio repositorio)
        {
            _context = context;
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _repositorio.ObterTodos();
            return Ok(usuarios);
        }


        [HttpGet("ObterUsuarios")]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> ObterUsuarios()
        {
            return await _context.UsuarioModel.ToListAsync();
        }

     
        [HttpGet("ObterUsuarios/{id}")]
        public async Task<ActionResult<UsuarioModel>> ObterUsuario(int id)
        {
            var usuario = await _context.UsuarioModel.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

   
        [HttpPost("Inserir")]
        public async Task<ActionResult<UsuarioModel>> Inserir(UsuarioModel usuario)
        {
            _context.UsuarioModel.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterUsuario), new { id = usuario.Id }, usuario);
        }


        [HttpPut("Alterar/{id}")]
        public async Task<IActionResult> Alterar(int id, UsuarioModel usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var usuario = await _context.UsuarioModel.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.UsuarioModel.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.UsuarioModel.Any(e => e.Id == id);
        }
    }
}
