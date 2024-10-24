namespace MauiSqLite.App.Repositorio
{
    //public class UsuarioRepositorio : IUsuarioRepositorio
    //{
    //    private readonly MeuContexto _contexto;

    //    public UsuarioRepositorio(MeuContexto contexto)
    //    {
    //        _contexto = contexto;
    //    }


    //    public async Task<int> Inserir(UsuarioModel usuario)
    //    {
    //        _contexto.UsuarioModel.Add(usuario);
    //        return await _contexto.SaveChangesAsync();
    //    }


    //    public async Task<int> Alterar(UsuarioModel usuario)
    //    {
    //        _contexto.UsuarioModel.Update(usuario);
    //        return await _contexto.SaveChangesAsync();
    //    }


    //    public async Task<int> Excluir(int id)
    //    {
    //        var usuario = await _contexto.UsuarioModel.FindAsync(id);
    //        if (usuario != null)
    //        {
    //            _contexto.UsuarioModel.Remove(usuario);
    //            return await _contexto.SaveChangesAsync();
    //        }
    //        return 0;
    //    }


    //    public async Task<List<UsuarioModel>> ObterTodos()
    //    {
    //        return await _contexto.UsuarioModel.AsNoTracking().ToListAsync();
    //    }


    //    public async Task<List<UsuarioModel>> ObterPorNomeOuEmail(string nomeOuEmail)
    //    {
    //        return await _contexto.UsuarioModel
    //            .Where(u => u.Nome.Contains(nomeOuEmail) || u.Email.Contains(nomeOuEmail))
    //            .ToListAsync();
    //    }
    //}
}
