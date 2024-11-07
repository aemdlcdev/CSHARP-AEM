using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProxyScraper
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

        private void lanzarProceso()
        {
            try
            {
                string exePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "C:\\Users\\Alejandro\\Documents\\GitHub\\DI-AEM\\Proyectos Personales\\ProxyScraper\\ProxyScraper\\procesos\\proxyScraper.exe");
                if (!System.IO.File.Exists(exePath))
                {
                    MessageBox.Show($"El ejecutable no se encontró en la ruta: {exePath}", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = exePath;
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                start.RedirectStandardError = true;
                start.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory; // Directorio de trabajo actual

                using (Process process = Process.Start(start))
                {
                    // Leer la salida estándar y de error
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit(); // Esperar a que el proceso termine

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.lanzarProceso();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true; // Cancelar el cierre de la ventana
            var fadeOutStoryboard = (Storyboard)this.Resources["FadeOutStoryboard"];
            fadeOutStoryboard.Completed += (s, a) => this.Close(); // Cerrar la ventana después de la animación
            fadeOutStoryboard.Begin(this);
        }





    }
}
