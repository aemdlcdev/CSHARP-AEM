using ExamenFinal.domain;
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

namespace ExamenFinal.view.pages
{
    /// <summary>
    /// Lógica de interacción para AltaLibro.xaml
    /// </summary>
    public partial class AltaLibro : Page
    {

        private Libro operaciones;
        private List<Libro> listaLibros;

        public AltaLibro()
        {
            InitializeComponent();
            operaciones = new Libro();
            listaLibros = operaciones.LeerLibros();
            dataGridLibros.ItemsSource = null;
            dataGridLibros.ItemsSource = listaLibros;
        }

        private void btnAddLibro_Click(object sender, RoutedEventArgs e)
        {
            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;
            int anio = int.Parse(txtAnio.Text);
            int idGenero = int.Parse(txtGenero.Text);

            Libro libroNuevo = new Libro(titulo, autor, anio,idGenero);
            operaciones.InsertarLibro(libroNuevo);
            MessageBox.Show("Libro agregado correctamente.");
            RefreshData();
        }

        private void RefreshData()
        {
            listaLibros.Clear();
            listaLibros = operaciones.LeerLibros();
            dataGridLibros.ItemsSource = null;
            dataGridLibros.ItemsSource = listaLibros;

            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtAnio.Text = "";
            txtIdLibro.Text = "";
            txtGenero.Text = "";
        }

        private void btnModLibro_Click(object sender, RoutedEventArgs e)
        {
            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;
            int anio = int.Parse(txtAnio.Text);
            int idGenero = int.Parse(txtGenero.Text);
            int idLibro = int.Parse(txtIdLibro.Text);

            Libro libroMod = new Libro(idLibro,titulo, autor, anio, idGenero);
            operaciones.ModificarLibro(libroMod);
            MessageBox.Show("Libro modificado correctamente.");
            RefreshData();
        }



        private void dataGridLibros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridLibros.SelectedItem != null)
            {
                Libro libro = (Libro)dataGridLibros.SelectedItem;
                txtIdLibro.Text = libro.idLibro.ToString();
                txtTitulo.Text = libro.titulo;
                txtAutor.Text = libro.autor;
                txtAnio.Text = libro.anioPublicacion.ToString();
                txtGenero.Text = libro.idGenero.ToString();
            }
        }

        private void btnDelLibro_Click(object sender, RoutedEventArgs e)
        {
            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;
            int anio = int.Parse(txtAnio.Text);
            int idGenero = int.Parse(txtGenero.Text);
            int idLibro = int.Parse(txtIdLibro.Text);

            Libro libroEliminado = new Libro(idLibro, titulo, autor, anio, idGenero);
            operaciones.EliminarLibro(libroEliminado);
            MessageBox.Show("Libro eliminado correctamente.");
            RefreshData();
        }
    }
}
