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
            new() { Id = 1, Titulo = "Revis�o de C�digo", Descricao = "Verificar padr�es de c�digo", Status = Status.Analise, DataCriacao = agora.AddDays(-2) },
            new() { Id = 2, Titulo = "Testes API", Descricao = "Executar testes unit�rios", Status = Status.ParaFazer, DataCriacao = agora.AddDays(-5) },
            new() { Id = 3, Titulo = "Documenta��o", Descricao = "Escrever documenta��o", Status = Status.Desenvolvimento, DataCriacao = agora.AddDays(-10) },
            new() { Id = 4, Titulo = "Deploy", Descricao = "Publicar vers�o final", Status = Status.Backlog, DataCriacao = agora.AddDays(-1) }
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
        string resultado = await DisplayPromptAsync("Nova Tarefa", "Digite o t�tulo da tarefa:");

        if (!string.IsNullOrWhiteSpace(resultado))
        {
            // Criar uma nova tarefa
            var novaTarefa = new Tarefa
            {
                Titulo = resultado,
                Descricao = "Descri��o padr�o", // Pode ser personalizado
            };

            // Adiciona � lista de "Para Fazer" (ou outra coluna desejada)
            TarefasParaFazer.Add(novaTarefa);
        }
    }


    private void AdicionarTarefaAnalise_Clicked(object sender, EventArgs e)
    {
        var novaTarefa = new Tarefa
        {
            Titulo = "Nova Tarefa An�lise",
            Descricao = "Descri��o da tarefa"
        };

        TarefasAnalise.Add(novaTarefa);
    }

    private void AdicionarTarefaDesenvolvimento_Clicked(object sender, EventArgs e)
    {
        var novaTarefa = new Tarefa
        {
            Titulo = "Nova Tarefa Desenvolvimento",
            Descricao = "Descri��o da tarefa"
        };

        TarefasDesenvolvimento.Add(novaTarefa);
    }

    private void AdicionarTarefaConcluido_Clicked(object sender, EventArgs e)
    {
        var novaTarefa = new Tarefa
        {
            Titulo = "Nova Tarefa Conclu�da",
            Descricao = "Descri��o da tarefa"
        };

        TarefasBacklog.Add(novaTarefa);
    }
}