using MauiSqLite.App.Contexto;
using MauiSqLite.App.Model;
using System.Text;


namespace MauiSqLite.App
{
    public partial class UsuarioPage : ContentPage
    {
        private MeuContexto dbContext;
        private const string dbFileName = "Usuarios.db";

        public UsuarioPage()
        {
            InitializeComponent();
            dbContext = new MeuContexto();
            dbContext.Database.EnsureCreated(); // Cria o banco se não existir
                                                // ConfigurarBancoDeDados();


            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db");
            AtualizarInformacoesBancoDeDados(dbPath);

            //PopularUsuarios();



            //// Obtém o caminho completo do banco de dados
            //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbFileName);

            //// Deleta o banco de dados se ele já existir (somente para desenvolvimento)
            //if (File.Exists(dbPath))
            //{
            //    File.Delete(dbPath);
            //}
        }

        private void ConfigurarBancoDeDados()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db");
            if (File.Exists(dbPath))
            {
                File.Delete(dbPath);
            }
            dbContext = new MeuContexto();
            dbContext.Database.EnsureCreated();

        }

        private void AtualizarInformacoesBancoDeDados(string dbPath)
        {
            string databaseName = Path.GetFileName(dbPath);
            DatabaseInfoLabel.Text = $"Nome do Banco de Dados: {databaseName}\n Caminho: {dbPath}";
        }




        private void OnGravarUsuarioClicked(object sender, EventArgs e)
        {
            var nome = NomeEntry.Text;
            var email = EmailEntry.Text;
            var telefone = TelefoneEntry.Text;
            var dataNascimento = DataNascimentoPicker.Date;
            var ativo = AtivoSwitch.IsToggled;

            if (!string.IsNullOrWhiteSpace(nome) && !string.IsNullOrWhiteSpace(email))
            {
                // Adiciona o novo usuário ao contexto
                dbContext.UsuarioModel.Add(new UsuarioModel
                {
                    Nome = nome,
                    Email = email,
                    Telefone = telefone,
                    DataNascimento = dataNascimento,
                    DataCadastro = DateTime.Now,
                    Ativo = ativo
                });

                dbContext.SaveChanges(); // Salva as mudanças no banco

                // Atualiza a interface
                ResultadoLabel.Text = $"Usuário '{nome}' gravado com sucesso!";
                NomeEntry.Text = string.Empty; // Limpa o campo de entrada
                EmailEntry.Text = string.Empty;
                TelefoneEntry.Text = string.Empty;
                DataNascimentoPicker.Date = DateTime.Now;
                AtivoSwitch.IsToggled = true;
            }
            else
            {
                ResultadoLabel.Text = "Por favor, insira os dados obrigatórios (Nome e Email).";
            }
        }

        private void OnListarUsuariosClicked(object sender, EventArgs e)
        {
            // Recupera os usuários do banco de dados
            var usuarios = dbContext.UsuarioModel.ToList();

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


        //public class BooleanToStringConverter : IValueConverter
        //{
        //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        if (value is bool booleanValue)
        //        {
        //            return booleanValue ? "Ativo" : "Inativo";
        //        }
        //        return string.Empty;
        //    }

        //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //    {
        //        return value.ToString() == "Ativo";
        //    }
        //}


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

        //private void PopularUsuarios()
        //{
        //    // Limpa o StackLayout antes de adicionar novos itens
        //    UsuariosStackLayout.Children.Clear();

        //    // Recupera os usuários do banco de dados
        //    var usuarios = dbContext.UsuarioModel.ToList();

        //    // Verifica se há usuários
        //    if (usuarios.Any())
        //    {
        //        foreach (var usuario in usuarios)
        //        {
        //            // Cria as labels para cada coluna
        //            var nomeLabel = new Label { Text = usuario.Nome, FontSize = 16 };
        //            var emailLabel = new Label { Text = usuario.Email, FontSize = 16 };
        //            var telefoneLabel = new Label { Text = usuario.Telefone, FontSize = 16 };
        //            var dataNascimentoLabel = new Label { Text = usuario.DataNascimento.ToShortDateString(), FontSize = 16 };
        //            var dataCadastroLabel = new Label { Text = usuario.DataCadastro.ToShortDateString(), FontSize = 16 };
        //            var ativoLabel = new Label { Text = usuario.Ativo ? "Sim" : "Não", FontSize = 16 };

        //            // Adiciona as labels ao StackLayout
        //            UsuariosStackLayout.Children.Add(nomeLabel);
        //            UsuariosStackLayout.Children.Add(emailLabel);
        //            UsuariosStackLayout.Children.Add(telefoneLabel);
        //            UsuariosStackLayout.Children.Add(dataNascimentoLabel);
        //            UsuariosStackLayout.Children.Add(dataCadastroLabel);
        //            UsuariosStackLayout.Children.Add(ativoLabel);
        //        }
        //    }
        //    else
        //    {
        //        var noUsersLabel = new Label { Text = "Nenhum usuário encontrado.", FontSize = 16 };
        //        UsuariosStackLayout.Children.Add(noUsersLabel);
        //    }
        //}



        //public async Task GerarTxt() // Mudança para Task
        //{

        //    // Obtém o diretório de documentos do aplicativo
        //    string diretorio = Path.Combine(FileSystem.AppDataDirectory, "Amauri");
        //    string caminho = Path.Combine(diretorio, "usuarios.txt");

        //    // Cria o diretório se não existir
        //    if (!Directory.Exists(diretorio))
        //    {
        //        Directory.CreateDirectory(diretorio);
        //    }

        //    // Exemplo de inicialização dos usuários
        //    List<UsuarioModel> usuarios = new List<UsuarioModel>
        //    {
        //        new UsuarioModel { Nome = "Maria", Email = "maria@example.com", Telefone = "123456789", DataNascimento = new DateTime(1990, 5, 10), DataCadastro = DateTime.Now, Ativo = true },
        //        new UsuarioModel { Nome = "João", Email = "joao@example.com", Telefone = "987654321", DataNascimento = new DateTime(1985, 8, 15), DataCadastro = DateTime.Now, Ativo = false }
        //    };

        //    // Salva os dados no arquivo
        //    using (var writer = new StreamWriter(caminho, false, Encoding.UTF8))
        //    {
        //        // Escrevendo cabeçalho
        //        await writer.WriteLineAsync("Nome,Email,Telefone,Data de Nascimento,Data de Cadastro,Ativo");

        //        // Escrevendo cada usuário
        //        foreach (var usuario in usuarios)
        //        {
        //            string linha = $"{usuario.Nome},{usuario.Email},{usuario.Telefone},{usuario.DataNascimento:dd/MM/yyyy},{usuario.DataCadastro:dd/MM/yyyy},{usuario.Ativo}";
        //            await writer.WriteLineAsync(linha);
        //        }
        //    }

        //    await Application.Current.MainPage.DisplayAlert("Exportação Completa", $"Os dados foram exportados para {caminho}", "OK");

        //}


    }
}
