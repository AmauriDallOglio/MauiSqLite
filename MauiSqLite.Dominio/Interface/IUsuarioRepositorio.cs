using MauiSqLite.Dominio.Entidade;

namespace MauiSqLite.Dominio.Interface
{
    public interface IUsuarioRepositorio
    {
        Task<int> Inserir(Usuario usuario);
        Task<int> Alterar(Usuario usuario);
        Task<int> Excluir(int id);
        Task<List<Usuario>> ObterTodos();
        Task<List<Usuario>> ObterPorNomeOuEmail(string nomeOuEmail);
    }
}
