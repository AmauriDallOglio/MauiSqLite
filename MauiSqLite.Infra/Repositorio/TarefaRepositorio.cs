using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Dominio.Interface;
using MauiSqLite.Infra.Contexto;
using Microsoft.EntityFrameworkCore;

namespace MauiSqLite.Infra.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly MeuContexto _contexto;
        public TarefaRepositorio(MeuContexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<int> Inserir(Tarefa tarefa)
        {
            _contexto.Tarefa.Add(tarefa);
            return await _contexto.SaveChangesAsync();
        }


        public async Task<int> Alterar(Tarefa tarefa)
        {
            _contexto.Tarefa.Update(tarefa);
            return await _contexto.SaveChangesAsync();
        }


        public async Task<int> Excluir(int id)
        {
            var Tarefa = await _contexto.Tarefa.FindAsync(id);
            if (Tarefa != null)
            {
                _contexto.Tarefa.Remove(Tarefa);
                return await _contexto.SaveChangesAsync();
            }
            return 0;
        }


        public async Task<List<Tarefa>> ObterTodos()
        {
            return await _contexto.Tarefa.AsNoTracking().ToListAsync();
        }


        public async Task<List<Tarefa>> ObterStatusEmAnalise()
        {
            return await _contexto.Tarefa
                .AsNoTracking().Where(u => u.Status == Dominio.Enum.Status.Analise)
                .ToListAsync();
        }

        public async Task<List<Tarefa>> ObterStatusParaFazer()
        {
            return await _contexto.Tarefa
                .AsNoTracking().Where(u => u.Status == Dominio.Enum.Status.ParaFazer)
                .ToListAsync();
        }

        public async Task<List<Tarefa>> ObterStatusBacklog()
        {
            return await _contexto.Tarefa
                .AsNoTracking().Where(u => u.Status == Dominio.Enum.Status.Backlog)
                .ToListAsync();
        }



        public async Task<List<Tarefa>> ObterStatusConcluida()
        {
            return await _contexto.Tarefa
                .AsNoTracking().Where(u => u.Status == Dominio.Enum.Status.Concluida)
                .ToListAsync();
        }

        public async Task<List<Tarefa>> ObterStatusDesenvolvimento()
        {
            return await _contexto.Tarefa
                .AsNoTracking().Where(u => u.Status == Dominio.Enum.Status.Desenvolvimento)
                .ToListAsync();
        }

    }
}
