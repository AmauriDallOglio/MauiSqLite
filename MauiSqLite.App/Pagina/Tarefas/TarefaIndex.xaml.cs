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
        //    new Tarefa { Id = 1, Descricao = "Revisar c�digo", Status = Status.Analise },
        //    new Tarefa { Id = 2, Descricao = "Testar API", Status  = Status.ParaFazer },
        //    new Tarefa { Id = 3, Descricao = "Documentar projeto", Status = Status.Desenvolvimento }
        //};
        var agora = DateTime.Now;

        var listaTarefas = new List<Tarefa>
        {
            new() { Id = 1, Titulo = "Revis�o de C�digo", Descricao = "Verificar padr�es e qualidade do c�digo.",
                    Status = Status.Analise, DataCriacao = agora.AddDays(-2), DataAtualizacao = agora, UsuarioId = 101 },

            new() { Id = 2, Titulo = "Testes de API", Descricao = "Executar testes unit�rios na API.",
                    Status  = Status.ParaFazer, DataCriacao = agora.AddDays(-5), DataAtualizacao = agora.AddDays(-1), UsuarioId = 102 },

            new() { Id = 3, Titulo = "Documenta��o", Descricao = "Escrever documenta��o do projeto.",
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