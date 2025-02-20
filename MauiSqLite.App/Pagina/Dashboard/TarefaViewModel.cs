using MauiSqLite.Dominio.Entidade;
using Microcharts;
using SkiaSharp;

namespace MauiSqLite.App.Pagina.Dashboard
{

    public class TarefaViewModel
    {
        public Chart TarefaChart { get; private set; }

        public TarefaViewModel(List<Tarefa> listaTarefas)
        {
            // Agrupando as tarefas por Status
            var statusAgrupado = listaTarefas
                .GroupBy(t => t.Status)
                .Select(g => new { Status = g.Key, Quantidade = g.Count() })
                .ToList();

            // Definição das cores para os status
            var cores = new[]
            {
                SKColor.Parse("#FF6384"), // Rosa
                SKColor.Parse("#36A2EB"), // Azul
                SKColor.Parse("#FFCE56"), // Amarelo
                SKColor.Parse("#4BC0C0"), // Verde
                SKColor.Parse("#9966FF")  // Roxo
            };

            // Criando entradas para o gráfico
            var chartEntries = statusAgrupado
                .Select((s, index) => new ChartEntry(s.Quantidade)
                {
                    Label = s.Status.ToString(),
                    ValueLabel = s.Quantidade.ToString(),
                    Color = cores[index % cores.Length]
                }).ToList();

            // Criando o gráfico
            TarefaChart = new PieChart
            {
                Entries = chartEntries,
                LabelTextSize = 30
            };
        }
    }
}
