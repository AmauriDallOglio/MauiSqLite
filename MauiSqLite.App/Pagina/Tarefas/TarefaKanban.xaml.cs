using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Dominio.Enum;
using System.Collections.ObjectModel;

namespace MauiSqLite.App.Pagina.Tarefas;

public partial class TarefaKanban : ContentPage
{
    public ObservableCollection<Tarefa> Tarefas_Backlog { get; set; } = new();
    public ObservableCollection<Tarefa> Tarefas_Analise { get; set; } = new();
    public ObservableCollection<Tarefa> Tarefas_ParaFazer { get; set; } = new();
    public ObservableCollection<Tarefa> Tarefas_Desenvolvimento { get; set; } = new();
    public ObservableCollection<Tarefa> Tarefas_Concluida { get; set; } = new();
    public Command<Tarefa> AlterarStatusTarefaCommand { get; }

    public TarefaKanban()
	{
		InitializeComponent();
        BindingContext = this;

        AlterarStatusTarefaCommand = new Command<Tarefa>(async (tarefa) => await AlterarStatusTarefa(tarefa));

        CarregarTarefas();
    }


    private async Task AlterarStatusTarefa(Tarefa tarefa)
    {
        // Mapeamento entre os status e seus c�digos
        var statusMap = new Dictionary<string, int>
        {
            { "Backlog", 1 },
            { "An�lise", 2 },
            { "Para Fazer", 3 },
            { "Desenvolvimento", 4 },
            { "Conclu�do", 5 },
        };

        // Exibe apenas os nomes no ActionSheet
        string novoStatus = await Application.Current.MainPage.DisplayActionSheet(
            "Alterar Status",
            "Cancelar",
            null,
            statusMap.Keys.ToArray() // Passa apenas os nomes dos status
        );

        var codigoo = statusMap.TryGetValue(novoStatus, out int statusCodigo);

        if (!string.IsNullOrWhiteSpace(novoStatus) && novoStatus != "Cancelar")
        {
            // Remover tarefa da lista atual
            RemoverTarefaDasListas(tarefa);

            // Atualizar status
            Status novoEnumStatus = (Status)statusCodigo;
            tarefa.Status = novoEnumStatus; 

            // Adicionar na nova lista
            AdicionarTarefaNaLista(tarefa);
        }
    }


    private void RemoverTarefaDasListas(Tarefa tarefa)
    {
        Tarefas_Backlog.Remove(tarefa);
        Tarefas_Analise.Remove(tarefa);
        Tarefas_ParaFazer.Remove(tarefa);
        Tarefas_Desenvolvimento.Remove(tarefa);
        Tarefas_Concluida.Remove(tarefa);
    }

    private void AdicionarTarefaNaLista(Tarefa tarefa)
    {
        switch (tarefa.Status)
        {
            case Status.Analise:
                Tarefas_Analise.Add(tarefa);
                break;
            case Status.ParaFazer:
                Tarefas_ParaFazer.Add(tarefa);
                break;
            case Status.Desenvolvimento:
                Tarefas_Desenvolvimento.Add(tarefa);
                break;
            case Status.Concluida:
                Tarefas_Concluida.Add(tarefa);
                break;
            case Status.Backlog:
                Tarefas_Backlog.Add(tarefa);
                break;
        }
    }

    private async void CarregarTarefas()
    {
        var agora = DateTime.Now;
        var listaTarefas = new List<Tarefa>
        {
            new() { Id = 1, Titulo = "Revis�o de C�digo", Descricao = "Verificar padr�es de c�digo", Status = Status.Analise, DataCriacao = agora.AddDays(-2) },
            new() { Id = 2, Titulo = "Testes API", Descricao = "Executar testes unit�rios", Status = Status.ParaFazer, DataCriacao = agora.AddDays(-5) },
            new() { Id = 3, Titulo = "Documenta��o", Descricao = "Escrever documenta��o", Status = Status.Desenvolvimento, DataCriacao = agora.AddDays(-10) },
            new() { Id = 4, Titulo = "Deploy", Descricao = "Publicar vers�o final", Status = Status.Backlog, DataCriacao = agora.AddDays(-1) },
            new() { Id = 5, Titulo = "Bug Fix", Descricao = "Corrigir erro cr�tico", Status = Status.Analise, DataCriacao = agora.AddDays(-3) },
            new() { Id = 6, Titulo = "Refatora��o", Descricao = "Melhorar c�digo legado", Status = Status.ParaFazer, DataCriacao = agora.AddDays(-7) },
            new() { Id = 7, Titulo = "Integra��o", Descricao = "Configurar APIs", Status = Status.Desenvolvimento, DataCriacao = agora.AddDays(-8) },
            new() { Id = 8, Titulo = "Revis�o Final", Descricao = "�ltima revis�o antes do deploy", Status = Status.Backlog, DataCriacao = agora.AddDays(-2) }
        };
 
        Tarefas_Analise.Clear();
        Tarefas_ParaFazer.Clear();
        Tarefas_Desenvolvimento.Clear();
        Tarefas_Backlog.Clear();
        Tarefas_Concluida.Clear();

        foreach (var tarefa in listaTarefas.Where(t => t.Status == Status.Analise))
        {
            Tarefas_Analise.Add(tarefa);
        }

        foreach (var tarefa in listaTarefas.Where(t => t.Status == Status.ParaFazer))
        {
            Tarefas_ParaFazer.Add(tarefa);
        }

        foreach (var tarefa in listaTarefas.Where(t => t.Status == Status.Desenvolvimento))
        {
            Tarefas_Desenvolvimento.Add(tarefa);
        }

        foreach (var tarefa in listaTarefas.Where(t => t.Status == Status.Backlog))
        {
            Tarefas_Backlog.Add(tarefa);
        }

        foreach (var tarefa in listaTarefas.Where(t => t.Status == Status.Concluida))
        {
            Tarefas_Concluida.Add(tarefa);
        }
    }

    private async void AdicionarTarefa_Backlog_Clicked(object sender, EventArgs e)
    {
        string titulo = await DisplayPromptAsync("Nova Tarefa", "Digite o t�tulo da tarefa:");

        if (!string.IsNullOrWhiteSpace(titulo))
        {
            string descricao = await DisplayPromptAsync("Nova Tarefa", "Digite a descri��o da tarefa:");

            var novaTarefa = new Tarefa
            {
                Titulo = titulo,
                Descricao = descricao
            };
            Tarefas_Backlog.Add(novaTarefa);
        }
    }

    private async void AdicionarTarefa_Analise_Clicked(object sender, EventArgs e)
    {
        string titulo = await DisplayPromptAsync("Nova Tarefa", "Digite o t�tulo da tarefa:");

        if (!string.IsNullOrWhiteSpace(titulo))
        {
            var novaTarefa = new Tarefa
            {
                Titulo = titulo,
                Descricao = "Descri��o padr�o"
            };
            Tarefas_Analise.Add(novaTarefa);
        }
    }

    private async void AdicionarTarefa_ParaFazer_Clicked(object sender, EventArgs e)
    {
        string titulo = await DisplayPromptAsync("Nova Tarefa", "Digite o t�tulo da tarefa:");

        if (!string.IsNullOrWhiteSpace(titulo))
        {
            var novaTarefa = new Tarefa
            {
                Titulo = titulo,
                Descricao = "Descri��o padr�o"
            };
            Tarefas_ParaFazer.Add(novaTarefa);
        }
    }

    private async void AdicionarTarefa_Desenvolvimento_Clicked(object sender, EventArgs e)
    {
        string titulo = await DisplayPromptAsync("Nova Tarefa", "Digite o t�tulo da tarefa:");

        if (!string.IsNullOrWhiteSpace(titulo))
        {
            var novaTarefa = new Tarefa
            {
                Titulo = titulo,
                Descricao = "Descri��o padr�o"
            };
            Tarefas_Desenvolvimento.Add(novaTarefa);
        }
    }

    private async void AdicionarTarefa_Concluida_Clicked(object sender, EventArgs e)
    {
        string titulo = await DisplayPromptAsync("Nova Tarefa", "Digite o t�tulo da tarefa:");

        if (!string.IsNullOrWhiteSpace(titulo))
        {
            var novaTarefa = new Tarefa
            {
                Titulo = titulo,
                Descricao = "Descri��o padr�o"
            };
            Tarefas_Concluida.Add(novaTarefa);
        }
    }
}