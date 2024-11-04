using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MarioBrosInterfazGrafica
{
    internal class Operaciones
    {
        private static Random random = new Random();
        private static string rutaMario = "/resources/mario.png"; // Imagen de Mario
        private static string rutaNoVisitada = "/resources/novisitada.png"; // Imagen de celda no visitada
        private static string rutaVisitada = "/resources/visitada.png"; // Imagen de celda visitada

        public static void InicializarTablero(int[,] tableroValores, Image[,] tableroArray, string imagePath, Grid tablero)
        {
            double cellWidth = tablero.ActualWidth / tablero.ColumnDefinitions.Count;
            double cellHeight = tablero.ActualHeight / tablero.RowDefinitions.Count;

            tablero.Children.Clear(); // Limpiar el Grid antes de agregar nuevas imágenes

            for (int i = 0; i < tableroValores.GetLength(0); i++)
            {
                for (int j = 0; j < tableroValores.GetLength(1); j++)
                {
                    tableroValores[i, j] = GeneraRandom(0, 2);
                    tableroArray[i, j] = new Image
                    {
                        Source = new BitmapImage(new Uri(imagePath, UriKind.Relative)),
                        Width = cellWidth,
                        Height = cellHeight,
                        Stretch = Stretch.Uniform
                    };
                    Grid.SetRow(tableroArray[i, j], i);
                    Grid.SetColumn(tableroArray[i, j], j);
                    tablero.Children.Add(tableroArray[i, j]);
                }
            }
        }


        public static void MuestraTableroOculto(Image[,] tableroArray, Grid tablero)
        {
            tablero.Children.Clear();
            double cellWidth = tablero.ActualWidth / tablero.ColumnDefinitions.Count;
            double cellHeight = tablero.ActualHeight / tablero.RowDefinitions.Count;

            for (int i = 0; i < tableroArray.GetLength(0); i++)
            {
                for (int j = 0; j < tableroArray.GetLength(1); j++)
                {
                    Image img = tableroArray[i, j];
                    img.Width = cellWidth;
                    img.Height = cellHeight;
                    img.Stretch = Stretch.Uniform;
                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, j);
                    tablero.Children.Add(img);
                }
            }
        }

        public static int GeneraRandom(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        private static void ActualizarVidasYPociones(ref int vidas, ref int pocion, int valorCelda)
        {
            if (valorCelda == -1)
            {
                return; // No hacer nada si la celda ya ha sido visitada
            }

            switch (valorCelda)
            {
                case 0:
                    vidas--;
                    break;
                case 1:
                    vidas++;
                    break;
                case 2:
                    pocion += 2;
                    break;
            }
        }

        private static bool VerificarGameOver(int vidas)
        {
            if (vidas <= 0)
            {
                MessageBox.Show("Game Over!");
                return true;
            }
            return false;
        }

        private static bool VerificarVictoria(int pocion, int fila, int columna)
        {
            if (pocion > 6 && fila == 10 && columna == 10)
            {
                MessageBox.Show("¡Has ganado!");
                return true;
            }
            return false;
        }



        public static void MoverDerecha(ref int[,] tableroValores, ref Image[,] tableroArray, ref int fila, ref int columna, ref int vidas, ref int pocion, Grid grid)
        {
            if (columna + 1 < tableroArray.GetLength(1))
            {
                tableroArray[fila, columna].Source = new BitmapImage(new Uri(rutaVisitada, UriKind.Relative));
                tableroValores[fila, columna] = -1; // Marcar la casilla como visitada
                columna++;
                ActualizarVidasYPociones(ref vidas, ref pocion, tableroValores[fila, columna]);
                if (VerificarGameOver(vidas) || VerificarVictoria(pocion, fila, columna)) return; // Verificar si el juego ha terminado o si has ganado
                tableroArray[fila, columna].Source = new BitmapImage(new Uri(rutaMario, UriKind.Relative));
                MuestraTableroOculto(tableroArray, grid);
            }
            else
            {
                MessageBox.Show("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        public static void MoverIzquierda(ref int[,] tableroValores, ref Image[,] tableroArray, ref int fila, ref int columna, ref int vidas, ref int pocion, Grid grid)
        {
            if (columna - 1 >= 0)
            {
                tableroArray[fila, columna].Source = new BitmapImage(new Uri(rutaVisitada, UriKind.Relative));
                tableroValores[fila, columna] = -1; // Marcar la casilla como visitada
                columna--;
                ActualizarVidasYPociones(ref vidas, ref pocion, tableroValores[fila, columna]);
                if (VerificarGameOver(vidas) || VerificarVictoria(pocion, fila, columna)) return; // Verificar si el juego ha terminado o si has ganado
                tableroArray[fila, columna].Source = new BitmapImage(new Uri(rutaMario, UriKind.Relative));
                MuestraTableroOculto(tableroArray, grid);
            }
            else
            {
                MessageBox.Show("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        public static void MoverArriba(ref int[,] tableroValores, ref Image[,] tableroArray, ref int fila, ref int columna, ref int vidas, ref int pocion, Grid grid)
        {
            if (fila - 1 >= 0)
            {
                tableroArray[fila, columna].Source = new BitmapImage(new Uri(rutaVisitada, UriKind.Relative));
                tableroValores[fila, columna] = -1; // Marcar la casilla como visitada
                fila--;
                ActualizarVidasYPociones(ref vidas, ref pocion, tableroValores[fila, columna]);
                if (VerificarGameOver(vidas) || VerificarVictoria(pocion, fila, columna)) return; // Verificar si el juego ha terminado o si has ganado
                tableroArray[fila, columna].Source = new BitmapImage(new Uri(rutaMario, UriKind.Relative));
                MuestraTableroOculto(tableroArray, grid);
            }
            else
            {
                MessageBox.Show("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }

        public static void MoverAbajo(ref int[,] tableroValores, ref Image[,] tableroArray, ref int fila, ref int columna, ref int vidas, ref int pocion, Grid grid)
        {
            if (fila + 1 < tableroArray.GetLength(0))
            {
                tableroArray[fila, columna].Source = new BitmapImage(new Uri(rutaVisitada, UriKind.Relative));
                tableroValores[fila, columna] = -1; // Marcar la casilla como visitada
                fila++;
                ActualizarVidasYPociones(ref vidas, ref pocion, tableroValores[fila, columna]);
                if (VerificarGameOver(vidas) || VerificarVictoria(pocion, fila, columna)) return; // Verificar si el juego ha terminado o si has ganado
                tableroArray[fila, columna].Source = new BitmapImage(new Uri(rutaMario, UriKind.Relative));
                MuestraTableroOculto(tableroArray, grid);
            }
            else
            {
                MessageBox.Show("Movimiento no válido: no puedes moverte fuera del tablero.");
            }
        }


    }
}

