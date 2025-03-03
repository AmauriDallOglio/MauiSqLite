﻿using MauiSqLite.Dominio.Interface;

namespace MauiSqLite.App
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private readonly IUsuarioRepositorio _iUsuarioRepositorio;
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public MainPage(ITarefaRepositorio tarefaRepositorio, IUsuarioRepositorio iUsuarioRepositorio)
        {
            InitializeComponent();

            _iUsuarioRepositorio = iUsuarioRepositorio;
            _tarefaRepositorio = tarefaRepositorio;

            string dbPath = App.AppDatabasePath;
            string databaseName = Path.GetFileName(dbPath);
            DatabaseInfoLabel.Text = $"Nome do Banco de Dados: {databaseName}\n Caminho: {dbPath}";
        }


        private async void OnComponentesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina.Exemplos.Componentes());
        }





        private async void OnBotaoButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina.Exemplos.Botao());
        }



        private async void OnDicionarioButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina.Exemplos.Dicionario());
        }


        private async void OnMenuButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina.Exemplos.MenuHorizontal());
        }


        private async void OnExemplosButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina.Exemplos.ExemploPagina());
        }

        private async void OnComboButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina.Exemplos.ExemploPaginaPicker());
        }

        private async void OnUsuarioButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina.Usuario.UsuarioIndex(_iUsuarioRepositorio));
        }
        private async void OnTarefaButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina.Tarefas.TarefaIndex(_tarefaRepositorio));
        }

        private async void OnKanbanButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina.Tarefas.TarefaKanban(_tarefaRepositorio));
        }

        private async void OnGraficoTarefaButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pagina.Dashboard.TarefaGrafico(_tarefaRepositorio));
        }

    }

}
