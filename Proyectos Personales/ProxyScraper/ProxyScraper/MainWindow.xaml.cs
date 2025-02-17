using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace ProxyScraper
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isClosing = false; // Bandera para evitar el bucle infinito

        public MainWindow()
        {
            InitializeComponent();
        }

        private void lanzarProceso()
        {
            try
            {
                string exePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "procesos\\proxyScraper.exe");
                
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
                start.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory; // Churchamos el directorio de trabajo

                using (Process process = Process.Start(start))
                {
                    // Para redireccionar las salidas de error y salida normal
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit(); // Para esperar al proceso que termine
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
            if (!isClosing)
            {
                e.Cancel = true; // Cancelar el cierre de la ventana
                isClosing = true; // Establecer la bandera para evitar el bucle infinito
                var fadeOutStoryboard = (Storyboard)this.Resources["FadeOutStoryboard"];
                fadeOutStoryboard.Completed += FadeOutStoryboard_Completed;
                fadeOutStoryboard.Begin(this);
            }
        }

        private void FadeOutStoryboard_Completed(object sender, EventArgs e)
        {
            var fadeOutStoryboard = (Storyboard)this.Resources["FadeOutStoryboard"];
            fadeOutStoryboard.Completed -= FadeOutStoryboard_Completed; // Me desuscribo del evento
            this.Close(); // Cierro la ventan despues de que termine la animacion
        }
    }
}
