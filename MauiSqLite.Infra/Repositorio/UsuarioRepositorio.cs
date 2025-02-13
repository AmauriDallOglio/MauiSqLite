using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Dominio.Interface;
using MauiSqLite.Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace MauiSqLite.Infra.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MeuContexto _contexto;

        public UsuarioRepositorio(MeuContexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<int> Inserir(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            return await _contexto.SaveChangesAsync();
        }


        public async Task<int> Alterar(Usuario usuario)
        {
            _contexto.Usuario.Update(usuario);
            return await _contexto.SaveChangesAsync();
        }


        public async Task<int> Excluir(int id)
        {
            var usuario = await _contexto.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _contexto.Usuario.Remove(usuario);
                return await _contexto.SaveChangesAsync();
            }
            return 0;
        }


        public async Task<List<Usuario>> ObterTodos()
        {
            return await _contexto.Usuario.AsNoTracking().ToListAsync();
        }


        public async Task<List<Usuario>> ObterPorNomeOuEmail(string nomeOuEmail)
        {
            return await _contexto.Usuario
                .Where(u => u.Nome.Contains(nomeOuEmail) || u.Email.Contains(nomeOuEmail))
                .ToListAsync();
        }
    }
}
