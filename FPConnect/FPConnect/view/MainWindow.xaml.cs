using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Style = System.Windows.Style;

namespace FPConnect
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsInicioButtonPressed { get; set; }
        public bool IsAlumnosButtonPressed { get; set; }
        public bool IsEventosButtonPressed { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool IsMaximize = false;
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

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnAlumnos_Click(object sender, RoutedEventArgs e)
        {
            // Ocultar otros Frames
            inicioFrame.Visibility = Visibility.Collapsed;
            eventosFrame.Visibility = Visibility.Collapsed;

            // Mostrar el Frame de Alumnos
            alumnosFrame.Visibility = Visibility.Visible;
            alumnosFrame.Source = new Uri("UserControls/AlumnosGridControl.xaml", UriKind.Relative);

            IsInicioButtonPressed = false;
            IsAlumnosButtonPressed = true;
            IsEventosButtonPressed = false;
            UpdateButtonStyles();
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            // Ocultar otros Frames
            alumnosFrame.Visibility = Visibility.Collapsed;
            eventosFrame.Visibility = Visibility.Collapsed;

            // Mostrar el Frame de Inicio
            inicioFrame.Visibility = Visibility.Visible;
            inicioFrame.Source = new Uri("UserControls/InicioGridControl.xaml", UriKind.Relative);

            IsInicioButtonPressed = true;
            IsAlumnosButtonPressed = false;
            IsEventosButtonPressed = false;
            UpdateButtonStyles();
        }

        private void btnEventos_Click(object sender, RoutedEventArgs e)
        {
            // Ocultar otros Frames
            alumnosFrame.Visibility = Visibility.Collapsed;
            inicioFrame.Visibility = Visibility.Collapsed;

            // Mostrar el Frame de Eventos
            eventosFrame.Visibility = Visibility.Visible;
            eventosFrame.Source = new Uri("UserControls/EventosGridControl.xaml", UriKind.Relative);

            IsInicioButtonPressed = false;
            IsAlumnosButtonPressed = false;
            IsEventosButtonPressed = true;
            UpdateButtonStyles();
        }

        private void UpdateButtonStyles()
        {
            btnInicio.Style = (Style)FindResource(IsInicioButtonPressed ? "menuButtonPressed" : "menuButton");
            btnAlumnos.Style = (Style)FindResource(IsAlumnosButtonPressed ? "menuButtonPressed" : "menuButton");
            btnEventos.Style = (Style)FindResource(IsEventosButtonPressed ? "menuButtonPressed" : "menuButton");
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show(); // Cambiar Show() por ShowDialog()
            this.Close();
        }


    }
}
