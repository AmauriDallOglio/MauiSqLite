using MauiSqLite.Dominio.Interface;
using MauiSqLite.Infra.Contexto;

namespace MauiSqLite.App.Pagina.Usuario;

public partial class UsuarioIndex : ContentPage
{
    //private MeuContexto _meuContexto;
    public static IUsuarioRepositorio _iUsuarioRepositorio { get; private set; }
    public UsuarioIndex(IUsuarioRepositorio iUsuarioRepositorio)
    {
        InitializeComponent();
        //_meuContexto = App.AppMeuContexto;
        _iUsuarioRepositorio = iUsuarioRepositorio; //App.AppIUsuarioRepositorio;
    }

    private void OnGravarUsuarioClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NomeEntry.Text) || string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            ResultadoLabelCadastro.Text = "Por favor, insira os dados obrigatórios (Nome e Email).";
        }

        Dominio.Entidade.Usuario usuarioIncluir = new Dominio.Entidade.Usuario().Incluir(NomeEntry.Text, EmailEntry.Text, TelefoneEntry.Text, DataNascimentoPicker.Date, DataNascimentoPicker.Date, AtivoSwitch.IsToggled);
        Task<int> gravacao = _iUsuarioRepositorio.Inserir(usuarioIncluir);
    }

    private void OnListarUsuariosClicked(object sender, EventArgs e)
    {
        var usuarios = _iUsuarioRepositorio.ObterTodos().Result;

        if (usuarios.Any())
        {
            UsuariosListView.ItemsSource = usuarios;
            UsuariosListView.IsVisible = true;
            ResultadoLabelGrid.Text = $"{usuarios.Count} usuário(s) encontrado(s).";
        }
        else
        {
            UsuariosListView.IsVisible = false;
            ResultadoLabelGrid.Text = "Nenhum usuário encontrado.";
        }
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var usuarioSelecionado = e.SelectedItem as Dominio.Entidade.Usuario;

            var detalhesPage = new UsuarioDetalhe(usuarioSelecionado);
            await Navigation.PushModalAsync(detalhesPage);

            UsuariosListView.SelectedItem = null;
        }
    }

 
}