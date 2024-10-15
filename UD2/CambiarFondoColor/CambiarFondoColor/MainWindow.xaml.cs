using System;
using System.Windows;
using System.Windows.Media;

namespace CambiarFondoColor
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAzul_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Blue);
        }

        private void btnRojo_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Red);
        }

        private void btnVerde_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Green);
        }

        private void btnAmarillo_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.Yellow);
        }
    }
}
