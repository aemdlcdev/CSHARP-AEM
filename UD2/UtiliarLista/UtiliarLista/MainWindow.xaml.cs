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

namespace UtiliarLista
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

        private void btnAniadir_Click(object sender, RoutedEventArgs e)

        {
            if(string.IsNullOrEmpty(txtTituloPelicula.Text))
            {
                MessageBox.Show("Debe ingresar un titulo de pelicula!");
                return;
            }
            
            cmbPeliculas.Items.Add(txtTituloPelicula.Text);

            txtTituloPelicula.Text = "";
        }

        private void cmbPeliculas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstPeliculas.Items.Add(cmbPeliculas.SelectedItem);
        }
    }
}
