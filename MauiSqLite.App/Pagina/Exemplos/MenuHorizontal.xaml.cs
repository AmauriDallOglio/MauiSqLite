namespace MauiSqLite.App.Pagina.Exemplos;

public partial class MenuHorizontal : ContentPage
{
	public MenuHorizontal()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            DisplayAlert("Bot�o Clicado", $"Voc� clicou na {button.Text}", "OK");
        }
    }
}