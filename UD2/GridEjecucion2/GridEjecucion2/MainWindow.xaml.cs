using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GridEjecucion2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button boton = new Button();
                    boton.Content = "Botón " + i + ", " + j;
                    boton.HorizontalAlignment =
                    HorizontalAlignment.Left;
                    boton.VerticalAlignment = VerticalAlignment.Top;
                    //La colocación de los controles depende de los métodos
                    //estáticos SetRow y SetColumn de la clase Grid
                    Grid.SetRow(boton, i);
                    Grid.SetColumn(boton, j);
                    contenedor.Children.Add(boton);
                }
            }
        }
    }
}
