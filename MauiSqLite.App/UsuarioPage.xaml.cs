using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Dominio.Interface;
using MauiSqLite.Infra.Contexto;


namespace MauiSqLite.App
{
    public partial class UsuarioPage : ContentPage
    {
        private MeuContexto _meuContexto;
        public static IUsuarioRepositorio _iUsuarioRepositorio { get; private set; }
        public UsuarioPage()
        {
            InitializeComponent();
            _meuContexto = App.AppMeuContexto;
            _iUsuarioRepositorio = App.AppIUsuarioRepositorio;
        }

        private void OnGravarUsuarioClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomeEntry.Text) || string.IsNullOrWhiteSpace(EmailEntry.Text))
            {
                ResultadoLabel.Text = "Por favor, insira os dados obrigatórios (Nome e Email).";
            }

            UsuarioModel usuarioIncluir = new UsuarioModel().Incluir(NomeEntry.Text, EmailEntry.Text, TelefoneEntry.Text, DataNascimentoPicker.Date, DataNascimentoPicker.Date, AtivoSwitch.IsToggled);
            Task<int> gravacao = _iUsuarioRepositorio.Inserir(usuarioIncluir);
        }

        private void OnListarUsuariosClicked(object sender, EventArgs e)
        {
            var usuarios = _iUsuarioRepositorio.ObterTodos().Result;

            if (usuarios.Any())
            {
                UsuariosListView.ItemsSource = usuarios; // Define a fonte de dados da ListView
                UsuariosListView.IsVisible = true; // Torna a ListView visível
                ResultadoLabel.Text = $"{usuarios.Count} usuário(s) encontrado(s)."; // Mostra a contagem
            }
            else
            {
                UsuariosListView.IsVisible = false; // Esconde a ListView se não houver usuários
                ResultadoLabel.Text = "Nenhum usuário encontrado.";
            }
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var usuarioSelecionado = e.SelectedItem as UsuarioModel; // Obtém o usuário selecionado

                // Cria e exibe a página modal
                var detalhesPage = new UsuarioDetalhePage(usuarioSelecionado);
                await Navigation.PushModalAsync(detalhesPage); // Abre a página modal

                UsuariosListView.SelectedItem = null; // Limpa a seleção
            }
        }

    }
}
