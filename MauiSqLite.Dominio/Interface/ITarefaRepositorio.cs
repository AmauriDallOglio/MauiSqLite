using MauiSqLite.Dominio.Entidade;

namespace MauiSqLite.Dominio.Interface
{
    public interface ITarefaRepositorio
    {
        Task<int> Inserir(Tarefa tarefa);
        Task<int> Alterar(Tarefa tarefa);
        Task<int> Excluir(int id);
        Task<List<Tarefa>> ObterTodos();
        Task<List<Tarefa>> ObterStatusEmAnalise();
        Task<List<Tarefa>> ObterStatusParaFazer();
        Task<List<Tarefa>> ObterStatusBacklog();
        Task<List<Tarefa>> ObterStatusConcluida();
        Task<List<Tarefa>> ObterStatusDesenvolvimento();
    }
}
