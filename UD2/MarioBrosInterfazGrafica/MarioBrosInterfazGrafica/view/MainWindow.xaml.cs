using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MarioBrosInterfazGrafica
{
    public partial class MainWindow : Window
    {
        private int[,] tableroValores;
        private Image[,] tableroArray;
        private int fila = 0;
        private int columna = 0;
        private int vidas;
        private int pocion;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            if (btnJugar.Content.ToString() == "Jugar")
            {
                IniciarJuego();
                btnJugar.Content = "Jugar de nuevo";
            }
            else if (btnJugar.Content.ToString() == "Jugar de nuevo")
            {
                ReiniciarJuego();
            }
        }

        private void IniciarJuego()
        {
            btnAbajo.IsEnabled = true;
            btnArriba.IsEnabled = true;
            btnDerecha.IsEnabled = true;
            btnIzquierda.IsEnabled = true;

            tableroValores = new int[10, 10];
            tableroArray = new Image[10, 10];
            string imagePath = "/resources/novisitada.png";
            Operaciones.InicializarTablero(tableroValores, tableroArray, imagePath, tablero);

            // Colocar a Mario en la posición inicial (0,0)
            tableroArray[0, 0].Source = new BitmapImage(new Uri("/resources/mario.png", UriKind.Relative));
            fila = 0;
            columna = 0;
            vidas = (int)sliderVidas.Value;
            pocion = (int)sliderPociones.Value;
            ActualizarStats();
            Operaciones.MuestraTableroOculto(tableroArray, tablero);

        }

        private void ReiniciarJuego()
        {
            IniciarJuego();
        }

        private void ActualizarStats()
        {
            lblVidas.Content = "Vidas: " + vidas;
            lblPociones.Content = "Pociones: " + pocion;
        }

        private void btnArriba_Click(object sender, RoutedEventArgs e)
        {
            Operaciones.MoverArriba(ref tableroValores, ref tableroArray, ref fila, ref columna, ref vidas, ref pocion, tablero);
            ActualizarStats();
        }

        private void btnDerecha_Click(object sender, RoutedEventArgs e)
        {
            Operaciones.MoverDerecha(ref tableroValores, ref tableroArray, ref fila, ref columna, ref vidas, ref pocion, tablero);
            ActualizarStats();
        }

        private void btnIzquierda_Click(object sender, RoutedEventArgs e)
        {
            Operaciones.MoverIzquierda(ref tableroValores, ref tableroArray, ref fila, ref columna, ref vidas, ref pocion, tablero);
            ActualizarStats();
        }

        private void btnAbajo_Click(object sender, RoutedEventArgs e)
        {
            Operaciones.MoverAbajo(ref tableroValores, ref tableroArray, ref fila, ref columna, ref vidas, ref pocion, tablero);
            ActualizarStats();
        }

        private void mainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabJugar.IsSelected)
            {
                // Se ha seleccionado la pestaña de instrucciones
                MessageBox.Show("Instrucciones:\n\n" +
                    "1. El objetivo del juego es llegar a la meta (casilla con valor 2) sin quedarte sin vidas.\n" +
                    "2. Mario se mueve con las flechas del teclado.\n" +
                    "3. Mario puede recoger pociones (casilla con valor 1) para recuperar vidas.\n" +
                    "4. Mario no puede moverse fuera del tablero.\n" +
                    "5. Si Mario se queda sin vidas, pierde el juego.\n" +
                    "6. Si Mario llega a la meta, gana el juego.\n" +
                    "7. Puedes ajustar el número de vidas y pociones antes de iniciar el juego.\n" +
                    "8. ¡Diviértete!");
                btnAbajo.Visibility = Visibility.Visible;
                btnArriba.Visibility = Visibility.Visible;
                btnDerecha.Visibility = Visibility.Visible;
                btnIzquierda.Visibility = Visibility.Visible;
            }

            if(tabInicio.IsSelected)
            {
                btnAbajo.Visibility = Visibility.Hidden;
                btnAbajo.IsEnabled = false;
                btnArriba.Visibility = Visibility.Hidden;
                btnArriba.IsEnabled = false;
                btnDerecha.Visibility = Visibility.Hidden;
                btnDerecha.IsEnabled = false;
                btnIzquierda.Visibility = Visibility.Hidden;
                btnIzquierda.IsEnabled = false;
            }

        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            vidas = (int) sliderVidas.Value;
            pocion = (int) sliderPociones.Value;
        }
    }
}
