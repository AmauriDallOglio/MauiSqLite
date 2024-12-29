using System.Collections.ObjectModel;

namespace MauiSqLite.App.Pagina.Exemplos;

public partial class ExemploPaginaPicker : ContentPage
{
    public ObservableCollection<string> Opcoes { get; set; }

    public ExemploPaginaPicker()
    {
        InitializeComponent();

        // Configurando a lista de op��es
        Opcoes = new ObservableCollection<string>
        {
            "Op��o 1",
            "Op��o 2",
            "Op��o 3",
            "Op��o 4"
        };

        // Associando as op��es ao BindingContext
        BindingContext = this;
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        if (picker != null && picker.SelectedIndex != -1)
        {
            OpcaoSelecionadaLabel.Text = $"Voc� selecionou: {picker.SelectedItem}";
        }
    }
}