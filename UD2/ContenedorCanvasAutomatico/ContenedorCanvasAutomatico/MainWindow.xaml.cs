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

namespace ContenedorCanvasAutomatico
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Random aleatorio = new Random();
            for (int i = 0; i < 10; i++)
            {
                Button boton = new Button();
                boton.Content = i;
                boton.Width = aleatorio.Next(100);
                boton.HorizontalAlignment = HorizontalAlignment.Center;
                boton.VerticalAlignment = VerticalAlignment.Center;
                //La colocación de los controles depende de los métodos
                //estáticos SetLeft y SetTop de la clase Canvas
                Canvas.SetLeft(boton, aleatorio.Next((int)this.Width));
                Canvas.SetTop(boton, aleatorio.Next((int)this.Height));
                contenedor.Children.Add(boton);
            }
        }
    }
}
