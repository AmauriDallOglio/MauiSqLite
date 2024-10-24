using MauiSqLite.Dominio.Entidade;

namespace MauiSqLite.Dominio.Interface
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
