using MiniHito1.domain;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MiniHito1.view.pages
{
    /// <summary>
    /// Lógica de interacción para ResultsQuerys.xaml
    /// </summary>
    public partial class ResultsQuerys : Page
    {
        public ResultsQuerys()
        {
            InitializeComponent();
        }
        public ResultsQuerys(List<Proyectos> proyectos)
        {
            InitializeComponent();
            dataGridResults.ItemsSource = proyectos;
        }
    }
}
