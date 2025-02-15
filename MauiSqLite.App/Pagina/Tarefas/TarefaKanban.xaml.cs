using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Dominio.Enum;
using System.Collections.ObjectModel;

namespace MauiSqLite.App.Pagina.Tarefas;

public partial class TarefaKanban : ContentPage
{
    public ObservableCollection<Tarefa> TarefasAnalise { get; set; } = new();
    public ObservableCollection<Tarefa> TarefasParaFazer { get; set; } = new();
    public ObservableCollection<Tarefa> TarefasDesenvolvimento { get; set; } = new();
    public ObservableCollection<Tarefa> TarefasBacklog { get; set; } = new();

    public TarefaKanban()
	{
		InitializeComponent();
        BindingContext = this;
        CarregarTarefas();
    }
    private async void CarregarTarefas()
    {
        var agora = DateTime.Now;

        var listaTarefas = new List<Tarefa>
        {
            new() { Id = 1, Titulo = "Revisão de Código", Descricao = "Verificar padrões de código", Status = Status.Analise, DataCriacao = agora.AddDays(-2) },
            new() { Id = 2, Titulo = "Testes API", Descricao = "Executar testes unitários", Status = Status.ParaFazer, DataCriacao = agora.AddDays(-5) },
            new() { Id = 3, Titulo = "Documentação", Descricao = "Escrever documentação", Status = Status.Desenvolvimento, DataCriacao = agora.AddDays(-10) },
            new() { Id = 4, Titulo = "Deploy", Descricao = "Publicar versão final", Status = Status.Backlog, DataCriacao = agora.AddDays(-1) }
        };

        TarefasAnalise.Clear();
        TarefasParaFazer.Clear();
        TarefasDesenvolvimento.Clear();
        TarefasBacklog.Clear();

        foreach (var tarefa in listaTarefas)
        {
            switch (tarefa.Status)
            {
                case Status.Analise:
                    TarefasAnalise.Add(tarefa);
                    break;
                case Status.ParaFazer:
                    TarefasParaFazer.Add(tarefa);
                    break;
                case Status.Desenvolvimento:
                    TarefasDesenvolvimento.Add(tarefa);
                    break;
                case Status.Backlog:
                    TarefasBacklog.Add(tarefa);
                    break;
            }
        }
    }

    private async void AdicionarTarefa_Clicked(object sender, EventArgs e)
    {
        string resultado = await DisplayPromptAsync("Nova Tarefa", "Digite o título da tarefa:");

        if (!string.IsNullOrWhiteSpace(resultado))
        {
            // Criar uma nova tarefa
            var novaTarefa = new Tarefa
            {
                Titulo = resultado,
                Descricao = "Descrição padrão", // Pode ser personalizado
            };

            // Adiciona à lista de "Para Fazer" (ou outra coluna desejada)
            TarefasParaFazer.Add(novaTarefa);
        }
    }


    private void AdicionarTarefaAnalise_Clicked(object sender, EventArgs e)
    {
        var novaTarefa = new Tarefa
        {
            Titulo = "Nova Tarefa Análise",
            Descricao = "Descrição da tarefa"
        };

        TarefasAnalise.Add(novaTarefa);
    }

    private void AdicionarTarefaDesenvolvimento_Clicked(object sender, EventArgs e)
    {
        var novaTarefa = new Tarefa
        {
            Titulo = "Nova Tarefa Desenvolvimento",
            Descricao = "Descrição da tarefa"
        };

        TarefasDesenvolvimento.Add(novaTarefa);
    }

    private void AdicionarTarefaConcluido_Clicked(object sender, EventArgs e)
    {
        var novaTarefa = new Tarefa
        {
            Titulo = "Nova Tarefa Concluída",
            Descricao = "Descrição da tarefa"
        };

        TarefasBacklog.Add(novaTarefa);
    }
}