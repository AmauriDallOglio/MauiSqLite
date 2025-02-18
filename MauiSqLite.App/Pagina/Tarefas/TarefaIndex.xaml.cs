using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Dominio.Interface;
using System.Collections.ObjectModel;
namespace MauiSqLite.App.Pagina.Tarefas;

public partial class TarefaIndex : ContentPage
{
    public ObservableCollection<Tarefa> Tarefas { get; set; } = new();
    private readonly ITarefaRepositorio _tarefaRepositorio; 
    public TarefaIndex(ITarefaRepositorio iTarefaRepositorio)
	{
        _tarefaRepositorio = iTarefaRepositorio;
        InitializeComponent();
        BindingContext = this;
        CarregarTarefas();
    }

    private async void CarregarTarefas()
    {
        var listaTarefas = await _tarefaRepositorio.ObterTodos();

        if (Tarefas.Count > 0)
            Tarefas.Clear();

        foreach (var tarefa in listaTarefas.OrderByDescending(a => a.DataCriacao))
        {
            Tarefas.Add(tarefa);
        }
    }
}