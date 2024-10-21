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
            dbContext.Database.EnsureCreated(); // Cria o banco se n�o existir
                                                // ConfigurarBancoDeDados();


            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db");
            AtualizarInformacoesBancoDeDados(dbPath);

            //PopularUsuarios();



            //// Obt�m o caminho completo do banco de dados
            //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbFileName);

            //// Deleta o banco de dados se ele j� existir (somente para desenvolvimento)
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
                // Adiciona o novo usu�rio ao contexto
                dbContext.UsuarioModel.Add(new UsuarioModel
                {
                    Nome = nome,
                    Email = email,
                    Telefone = telefone,
                    DataNascimento = dataNascimento,
                    DataCadastro = DateTime.Now,
                    Ativo = ativo
                });

                dbContext.SaveChanges(); // Salva as mudan�as no banco

                // Atualiza a interface
                ResultadoLabel.Text = $"Usu�rio '{nome}' gravado com sucesso!";
                NomeEntry.Text = string.Empty; // Limpa o campo de entrada
                EmailEntry.Text = string.Empty;
                TelefoneEntry.Text = string.Empty;
                DataNascimentoPicker.Date = DateTime.Now;
                AtivoSwitch.IsToggled = true;
            }
            else
            {
                ResultadoLabel.Text = "Por favor, insira os dados obrigat�rios (Nome e Email).";
            }
        }

        private void OnListarUsuariosClicked(object sender, EventArgs e)
        {
            // Recupera os usu�rios do banco de dados
            var usuarios = dbContext.UsuarioModel.ToList();

            if (usuarios.Any())
            {
                UsuariosListView.ItemsSource = usuarios; // Define a fonte de dados da ListView
                UsuariosListView.IsVisible = true; // Torna a ListView vis�vel
                ResultadoLabel.Text = $"{usuarios.Count} usu�rio(s) encontrado(s)."; // Mostra a contagem

            }
            else
            {
                UsuariosListView.IsVisible = false; // Esconde a ListView se n�o houver usu�rios
                ResultadoLabel.Text = "Nenhum usu�rio encontrado.";
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
                var usuarioSelecionado = e.SelectedItem as UsuarioModel; // Obt�m o usu�rio selecionado

                // Cria e exibe a p�gina modal
                var detalhesPage = new UsuarioDetalhePage(usuarioSelecionado);
                await Navigation.PushModalAsync(detalhesPage); // Abre a p�gina modal

                UsuariosListView.SelectedItem = null; // Limpa a sele��o
            }
        }

        //private void PopularUsuarios()
        //{
        //    // Limpa o StackLayout antes de adicionar novos itens
        //    UsuariosStackLayout.Children.Clear();

        //    // Recupera os usu�rios do banco de dados
        //    var usuarios = dbContext.UsuarioModel.ToList();

        //    // Verifica se h� usu�rios
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
        //            var ativoLabel = new Label { Text = usuario.Ativo ? "Sim" : "N�o", FontSize = 16 };

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
        //        var noUsersLabel = new Label { Text = "Nenhum usu�rio encontrado.", FontSize = 16 };
        //        UsuariosStackLayout.Children.Add(noUsersLabel);
        //    }
        //}



        //public async Task GerarTxt() // Mudan�a para Task
        //{

        //    // Obt�m o diret�rio de documentos do aplicativo
        //    string diretorio = Path.Combine(FileSystem.AppDataDirectory, "Amauri");
        //    string caminho = Path.Combine(diretorio, "usuarios.txt");

        //    // Cria o diret�rio se n�o existir
        //    if (!Directory.Exists(diretorio))
        //    {
        //        Directory.CreateDirectory(diretorio);
        //    }

        //    // Exemplo de inicializa��o dos usu�rios
        //    List<UsuarioModel> usuarios = new List<UsuarioModel>
        //    {
        //        new UsuarioModel { Nome = "Maria", Email = "maria@example.com", Telefone = "123456789", DataNascimento = new DateTime(1990, 5, 10), DataCadastro = DateTime.Now, Ativo = true },
        //        new UsuarioModel { Nome = "Jo�o", Email = "joao@example.com", Telefone = "987654321", DataNascimento = new DateTime(1985, 8, 15), DataCadastro = DateTime.Now, Ativo = false }
        //    };

        //    // Salva os dados no arquivo
        //    using (var writer = new StreamWriter(caminho, false, Encoding.UTF8))
        //    {
        //        // Escrevendo cabe�alho
        //        await writer.WriteLineAsync("Nome,Email,Telefone,Data de Nascimento,Data de Cadastro,Ativo");

        //        // Escrevendo cada usu�rio
        //        foreach (var usuario in usuarios)
        //        {
        //            string linha = $"{usuario.Nome},{usuario.Email},{usuario.Telefone},{usuario.DataNascimento:dd/MM/yyyy},{usuario.DataCadastro:dd/MM/yyyy},{usuario.Ativo}";
        //            await writer.WriteLineAsync(linha);
        //        }
        //    }

        //    await Application.Current.MainPage.DisplayAlert("Exporta��o Completa", $"Os dados foram exportados para {caminho}", "OK");

        //}


    }
}
