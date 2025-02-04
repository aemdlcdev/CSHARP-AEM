using System;
using System.Windows;
using System.Windows.Input;
using FPConnect.view;
using FPConnect.view.UserControls; // Asegúrate de que este espacio de nombres esté importado

namespace FPConnect
{
    public partial class MainWindow : Window
    {
        public bool IsInicioButtonPressed { get; set; }
        public bool IsAlumnosButtonPressed { get; set; }
        public bool IsEventosButtonPressed { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            alumnosFrame.Visibility = Visibility.Collapsed;
            eventosFrame.Visibility = Visibility.Collapsed;

            // Mostrar el Frame de Inicio
            inicioFrame.Visibility = Visibility.Visible;
            inicioFrame.Source = new Uri("pages/InicioGridControl.xaml", UriKind.Relative);

            IsInicioButtonPressed = true;
            IsAlumnosButtonPressed = false;
            IsEventosButtonPressed = false;
            UpdateButtonStyles();

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
            alumnosFrame.Source = new Uri("pages/AlumnosGridControl.xaml", UriKind.Relative);

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
            inicioFrame.Source = new Uri("pages/InicioGridControl.xaml", UriKind.Relative);

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
            eventosFrame.Source = new Uri("pages/EventosGridControl.xaml", UriKind.Relative);

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
            login.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
