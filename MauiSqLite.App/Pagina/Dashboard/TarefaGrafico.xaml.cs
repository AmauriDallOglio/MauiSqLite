using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Dominio.Interface;
using System.Collections.ObjectModel;

namespace MauiSqLite.App.Pagina.Dashboard;

public partial class TarefaGrafico : ContentPage
{
    private readonly ITarefaRepositorio _tarefaRepositorio;
    public ObservableCollection<Tarefa> Tarefas { get; set; } = new();
    public TarefaGrafico(ITarefaRepositorio iTarefaRepositorio)
	{
		InitializeComponent();
        _tarefaRepositorio = iTarefaRepositorio;


        var agora = DateTime.Now;
        //var listaTarefas = new List<Tarefa>
        //{
        //    new() { Titulo = "Revisão de Código", Status = Status.Analise, DataCriacao = agora },
        //    new() { Titulo = "Testes API", Status = Status.ParaFazer, DataCriacao = agora },
        //    new() { Titulo = "Documentação", Status = Status.Desenvolvimento, DataCriacao = agora },
        //    new() { Titulo = "Deploy", Status = Status.Backlog, DataCriacao = agora },
        //    new() { Titulo = "Bug Fix", Status = Status.Analise, DataCriacao = agora }
        //};



        //// Instancia a ViewModel e configura o gráfico
        //var viewModel = new TarefaViewModel(listaTarefas);

        //// Define o DataContext da página
        //BindingContext = viewModel;
        //chartView.Chart = viewModel.TarefaChart;

        var listaTarefas = _tarefaRepositorio.ObterTodos();

        if (Tarefas.Count > 0)
            Tarefas.Clear();

        foreach (var tarefa in listaTarefas.Result.OrderByDescending(a => a.DataCriacao))
        {
            Tarefas.Add(tarefa);
        }

        var viewModel = new TarefaViewModel(listaTarefas.Result);
        BindingContext = viewModel;
 
        chartView.Loaded += (s, e) => chartView.Chart = viewModel.TarefaChart;



    }

 
}