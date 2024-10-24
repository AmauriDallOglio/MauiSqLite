using MauiSqLite.App.Model;

namespace MauiSqLite.App.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<int> Inserir(UsuarioModel usuario);
        Task<int> Alterar(UsuarioModel usuario);
        Task<int> Excluir(int id);
        Task<List<UsuarioModel>> ObterTodos();
        Task<List<UsuarioModel>> ObterPorNomeOuEmail(string nomeOuEmail);
    }
}
