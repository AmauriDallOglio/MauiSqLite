using MauiSqLite.App.Contexto;
using MauiSqLite.App.Model;
using Microsoft.EntityFrameworkCore;

namespace MauiSqLite.App.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MeuContexto _contexto;

        public UsuarioRepositorio(MeuContexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<int> Insert(UsuarioModel usuario)
        {
            _contexto.UsuarioModel.Add(usuario);
            return await _contexto.SaveChangesAsync();
        }


        public async Task<int> Update(UsuarioModel usuario)
        {
            _contexto.UsuarioModel.Update(usuario);
            return await _contexto.SaveChangesAsync();
        }

       
        public async Task<int> Delete(int id)
        {
            var usuario = await _contexto.UsuarioModel.FindAsync(id);
            if (usuario != null)
            {
                _contexto.UsuarioModel.Remove(usuario);
                return await _contexto.SaveChangesAsync();
            }
            return 0;
        }

       
        public async Task<List<UsuarioModel>> ObterTodos()
        {
            return await _contexto.UsuarioModel.ToListAsync();
        }

       
        public async Task<List<UsuarioModel>> Search(string termo)
        {
            return await _contexto.UsuarioModel
                .Where(u => u.Nome.Contains(termo) || u.Email.Contains(termo))
                .ToListAsync();
        }
    }
}
