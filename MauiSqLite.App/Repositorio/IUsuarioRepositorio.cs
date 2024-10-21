using MauiSqLite.App.Model;

namespace MauiSqLite.App.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<int> Insert(UsuarioModel usuario);
        Task<int> Update(UsuarioModel usuario);
        Task<int> Delete(int id);
        Task<List<UsuarioModel>> GetAll();
        Task<List<UsuarioModel>> Search(string termo);
    }
}
