using System.Collections.ObjectModel;

namespace MauiSqLite.App.Pagina.Exemplos;

public partial class Componentes : ContentPage
{
    public ObservableCollection<string> Options { get; set; }
    public Componentes()
	{
		InitializeComponent();
        Options = new ObservableCollection<string> { "Opção 1", "Opção 2", "Opção 3" };
        BindingContext = this;
    }



}