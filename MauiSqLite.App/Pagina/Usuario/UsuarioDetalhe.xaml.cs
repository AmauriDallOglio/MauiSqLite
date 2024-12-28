using MauiSqLite.Dominio.Entidade;

namespace MauiSqLite.App.Pagina.Usuario;

public partial class UsuarioDetalhe : ContentPage
{
    public UsuarioDetalhe(UsuarioModel usuario)
    {
        InitializeComponent();

        NomeLabel.Text = $"Nome: {usuario.Nome}";
        EmailLabel.Text = $"Email: {usuario.Email}";
        TelefoneLabel.Text = $"Telefone: {usuario.Telefone}";
        DataNascimentoLabel.Text = $"Data de Nascimento: {usuario.DataNascimento.ToShortDateString()}";
        DataCadastroLabel.Text = $"Data de Cadastro: {usuario.DataCadastro.ToShortDateString()}";

    }

    private async void OnFecharClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

}