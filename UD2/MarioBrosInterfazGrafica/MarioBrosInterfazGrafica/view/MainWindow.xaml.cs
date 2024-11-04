using System.Windows;
using System.Windows.Controls;

namespace MarioBrosInterfazGrafica
{
    public partial class MainWindow : Window
    {
        private string[,] tableroArray;
        private int fila = 0;
        private int columna = 0;
        private int vidas = 3;
        private int pocion = 0;

        public MainWindow()
        {
            InitializeComponent();
            btnSiguiente.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Acción del botón Inicio
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            tableroArray = new string[10, 10];
            Operaciones.InicializarTablero(tableroArray, "M");
            Operaciones.MuestraTableroOculto(tableroArray, fila, columna, "M", tablero);
            btnJugar.IsEnabled = false;
            btnSiguiente.IsEnabled = true;
            tabInicio.IsEnabled = false; // Deshabilitar la pestaña "Inicio"
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            int movimiento = Operaciones.GeneraRandom(1, 4);
            switch (movimiento)
            {
                case 1: // Derecha
                    Operaciones.MoverDerecha(ref tableroArray, ref fila, ref columna, ref vidas, ref pocion, tablero);
                    break;
                case 2: // Izquierda
                    Operaciones.MoverIzquierda(ref tableroArray, ref fila, ref columna, ref vidas, ref pocion, tablero);
                    break;
                case 3: // Arriba
                    Operaciones.MoverArriba(ref tableroArray, ref fila, ref columna, ref vidas, ref pocion, tablero);
                    break;
                case 4: // Abajo
                    Operaciones.MoverAbajo(ref tableroArray, ref fila, ref columna, ref vidas, ref pocion, tablero);
                    break;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (((TabControl)e.Source).SelectedIndex == 1) // Tab "Jugar"
                {
                    tablero.Visibility = Visibility.Visible;
                }
                else
                {
                    tablero.Visibility = Visibility.Collapsed;
                    btnSiguiente.IsEnabled = false;
                }
            }
        }
    }
}
