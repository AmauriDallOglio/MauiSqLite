using System.Collections.ObjectModel;

namespace MauiSqLite.App.Pagina.Exemplos;

public partial class Componentes : ContentPage
{
    public ObservableCollection<string> Options { get; set; }
    public Componentes()
	{
		InitializeComponent();
        Options = new ObservableCollection<string> { "Op��o 1", "Op��o 2", "Op��o 3" };
        BindingContext = this;
    }



}