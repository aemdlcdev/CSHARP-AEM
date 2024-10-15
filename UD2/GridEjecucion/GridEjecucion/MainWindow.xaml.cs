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

namespace GridEjecucion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            contenedor.RowDefinitions.Add(new RowDefinition());
            contenedor.RowDefinitions.Add(new RowDefinition());
            contenedor.RowDefinitions.Add(new RowDefinition());

            contenedor.ColumnDefinitions.Add(new ColumnDefinition());
            contenedor.ColumnDefinitions.Add(new ColumnDefinition());
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Button boton = new Button();
                    boton.Width = 100;
                    boton.Height = 50;
                    boton.Content = "Botón " + i + ", " + j;
                    boton.HorizontalAlignment = HorizontalAlignment.Left;
                    boton.VerticalAlignment = VerticalAlignment.Top;

                    //La colocación de los controles depende
                    //de su alineación y del margen de cada control

                    boton.Margin = new Thickness(20 + i * 110, 10 + j * 55, 0, 0);
                    contenedor.Children.Add(boton);
                }
            }

        }
    }
}
