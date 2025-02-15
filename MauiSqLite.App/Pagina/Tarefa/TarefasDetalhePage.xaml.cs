using MauiSqLite.Dominio.Interface;
using MauiSqLite.Infra.Contexto;

namespace MauiSqLite.App.Pagina.Tarefa;

public partial class TarefasDetalhePage : ContentPage
{
    private MeuContexto _meuContexto;
    public static ITarefaRepositorio _ITarefaRepositorio { get; private set; }
    public TarefasDetalhePage()
	{
		InitializeComponent();
        _meuContexto = App.AppMeuContexto;
        _ITarefaRepositorio = App.AppITarefaRepositorio;
    }


    private async void SalvarClicked(object sender, EventArgs e)
    {
        //var tarefa = new Tarefa
        //{
        //    Id = Convert.ToInt32(Id.Text),
        //    Titulo = Titulo.Text,
        //    Descricao = Descricao.Text,
        //    Status = (Status)Status.SelectedIndex
        //};
        //if (tarefa.Id == 0)
        //{
        //    await _ITarefaRepositorio.Inserir(tarefa);
        //}
        //else
        //{
        //    await _ITarefaRepositorio.Alterar(tarefa);
        //}
        //await Navigation.PopAsync();
    }
}