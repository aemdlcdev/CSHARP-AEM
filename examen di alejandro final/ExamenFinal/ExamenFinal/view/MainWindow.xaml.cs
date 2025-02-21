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

namespace ExamenFinal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool IsMaximize = false;

        public MainWindow()
        {
            InitializeComponent();
            socioFrame.Visibility = Visibility.Visible;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAltaSocio_Click(object sender, RoutedEventArgs e)
        {
            socioFrame.Visibility=Visibility.Visible;
            libroFrame.Visibility = Visibility.Hidden;
            prestamoFrame.Visibility = Visibility.Hidden;
            informesFrame.Visibility = Visibility.Hidden;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        /// <summary>
        /// Maneja el evento MouseDown en el borde de la ventana.
        /// Permite arrastrar la ventana cuando se presiona el botón izquierdo del mouse.
        /// </summary>
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnAltaLibro_Click(object sender, RoutedEventArgs e)
        {
            socioFrame.Visibility =Visibility.Hidden;
            prestamoFrame.Visibility = Visibility.Hidden;
            informesFrame.Visibility = Visibility.Hidden;
            informesMensualFrame.Visibility = Visibility.Hidden;
            libroFrame.Visibility = Visibility.Visible;
        }

        private void btnAltaPrestamo_Click(object sender, RoutedEventArgs e)
        {
            socioFrame.Visibility = Visibility.Hidden;
            libroFrame.Visibility = Visibility.Hidden;
            informesFrame.Visibility = Visibility.Hidden;
            informesMensualFrame.Visibility = Visibility.Hidden;
            prestamoFrame.Visibility = Visibility.Visible;
        }

        private void btnInformes_Click(object sender, RoutedEventArgs e)
        {
            socioFrame.Visibility = Visibility.Hidden;
            libroFrame.Visibility = Visibility.Hidden;
            prestamoFrame.Visibility = Visibility.Hidden;
            informesMensualFrame.Visibility = Visibility.Hidden;
            informesFrame.Visibility = Visibility.Visible;
        }

        private void btnInformesMensual_Click(object sender, RoutedEventArgs e)
        {
            socioFrame.Visibility = Visibility.Hidden;
            libroFrame.Visibility = Visibility.Hidden;
            prestamoFrame.Visibility = Visibility.Hidden;
            informesFrame.Visibility = Visibility.Hidden;
            informesMensualFrame.Visibility= Visibility.Visible;
        }
    }
}
