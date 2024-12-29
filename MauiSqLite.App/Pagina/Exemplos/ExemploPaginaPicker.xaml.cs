using System.Collections.ObjectModel;

namespace MauiSqLite.App.Pagina.Exemplos;

public partial class ExemploPaginaPicker : ContentPage
{
    public ObservableCollection<string> Opcoes { get; set; }

    public ExemploPaginaPicker()
    {
        InitializeComponent();

        // Configurando a lista de opções
        Opcoes = new ObservableCollection<string>
        {
            "Opção 1",
            "Opção 2",
            "Opção 3",
            "Opção 4"
        };

        // Associando as opções ao BindingContext
        BindingContext = this;
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        if (picker != null && picker.SelectedIndex != -1)
        {
            OpcaoSelecionadaLabel.Text = $"Você selecionou: {picker.SelectedItem}";
        }
    }
}