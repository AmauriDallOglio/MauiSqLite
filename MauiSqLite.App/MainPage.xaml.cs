namespace MauiSqLite.App
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            string dbPath = App.AppDatabasePath;
            string databaseName = Path.GetFileName(dbPath);
            DatabaseInfoLabel.Text = $"Nome do Banco de Dados: {databaseName}\n Caminho: {dbPath}";
        }

        private async void OnExemplosButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Exemplos());
        }

        private async void OnUsuarioButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina.Usuario.UsuarioIndex());
        }

    }

}
