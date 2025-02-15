using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Dominio.Enum;
using System.Collections.ObjectModel;
namespace MauiSqLite.App.Pagina.Tarefas;

public partial class TarefaIndex : ContentPage
{
    public ObservableCollection<Tarefa> Tarefas { get; set; } = new();
    public TarefaIndex()
	{
        InitializeComponent();
        BindingContext = this;
        CarregarTarefas();
    }

    private async void CarregarTarefas()
    {
        //var listaTarefas = new List<Tarefa>
        //{
        //    new Tarefa { Id = 1, Descricao = "Revisar código", Status = Status.Analise },
        //    new Tarefa { Id = 2, Descricao = "Testar API", Status  = Status.ParaFazer },
        //    new Tarefa { Id = 3, Descricao = "Documentar projeto", Status = Status.Desenvolvimento }
        //};
        var agora = DateTime.Now;

        var listaTarefas = new List<Tarefa>
        {
            new() { Id = 1, Titulo = "Revisão de Código", Descricao = "Verificar padrões e qualidade do código.",
                    Status = Status.Analise, DataCriacao = agora.AddDays(-2), DataAtualizacao = agora, UsuarioId = 101 },

            new() { Id = 2, Titulo = "Testes de API", Descricao = "Executar testes unitários na API.",
                    Status  = Status.ParaFazer, DataCriacao = agora.AddDays(-5), DataAtualizacao = agora.AddDays(-1), UsuarioId = 102 },

            new() { Id = 3, Titulo = "Documentação", Descricao = "Escrever documentação do projeto.",
                    Status = Status.Desenvolvimento, DataCriacao = agora.AddDays(-10), DataAtualizacao = agora.AddDays(-3), UsuarioId = 103 }
        };

        if (Tarefas.Count > 0)
            Tarefas.Clear();

        foreach (var tarefa in listaTarefas)
        {
            Tarefas.Add(tarefa);
        }
    }
}