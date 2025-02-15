using MauiSqLite.Dominio.Interface;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiSqLite.App.Pagina.Tarefa;

public partial class TarefaIndex : ContentPage
{
    private readonly ITarefaRepositorio _tarefaRepositorio;
    public ObservableCollection<MauiSqLite.Dominio.Entidade.Tarefa> Tarefas { get; set; } = new();

    public ICommand AtualizarStatusCommand { get; }
    public TarefaIndex()
    {
		InitializeComponent();
      //  _tarefaRepositorio = new TarefaRepositorio(); // Injetar em produção
        AtualizarStatusCommand = new Command<MauiSqLite.Dominio.Entidade.Tarefa>(async (tarefa) => await AtualizarStatusAsync(tarefa));
        CarregarTarefas();
    }

    private async void CarregarTarefas()
    {
        var tarefas = await _tarefaRepositorio.ObterTodos();
        Tarefas.Clear();
        foreach (var tarefa in tarefas)
        {
            Tarefas.Add(tarefa);
        }
    }

    private async Task AtualizarStatusAsync(MauiSqLite.Dominio.Entidade.Tarefa tarefa)
    {
        if (tarefa.Status == MauiSqLite.Dominio.Enum.Status.ParaFazer)
            tarefa.Status = MauiSqLite.Dominio.Enum.Status.Desenvolvimento;
        else if (tarefa.Status == MauiSqLite.Dominio.Enum.Status.Feito)
            tarefa.Status = MauiSqLite.Dominio.Enum.Status.Backlog;

        //await _tarefaRepositorio.Inserir(tarefa.Id, tarefa.Status);
        OnPropertyChanged(nameof(Tarefas));
    }
}
