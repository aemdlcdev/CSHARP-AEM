using ControlzEx.Standard;
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
    /// Lógica de interacción para AltaSocio.xaml
    /// </summary>
    public partial class AltaSocio : Page
    {

        private List<Socio> listaSocios;
        private Socio operaciones;
        public AltaSocio()
        {
            InitializeComponent();
            operaciones = new Socio();
            listaSocios = operaciones.LeerSocios();
            dataGridSocios.ItemsSource = null;
            dataGridSocios.ItemsSource = listaSocios;
        }

        private void btnAddSocio_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string fecha = txtFecnac.Text;
            string email = txtEmail.Text;
            int tlfno = int.Parse(txtTlfn.Text.ToString().Replace(" ",""));

            Socio socioNuevo = new Socio(nombre,fecha, email, tlfno);

            operaciones.InsertarSocio(socioNuevo);
            MessageBox.Show("Socio agregado correctamente.");
            RefreshData();
        }

        


        private void RefreshData() 
        {
            listaSocios.Clear();
            listaSocios = operaciones.LeerSocios();
            dataGridSocios.ItemsSource = null;
            dataGridSocios.ItemsSource = listaSocios;

            txtNombre.Text = "";
            txtEmail.Text = "";
            txtIdSocio.Text = "";
            txtFecnac.Text = "";
            txtTlfn.Text = "";

        }

        private void btnModSocio_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string fecha = txtFecnac.Text;
            string email = txtEmail.Text;
            int tlfno = int.Parse(txtTlfn.Text.ToString().Replace(" ", ""));
            int idSocio = int.Parse(txtIdSocio.Text);
            Socio socioMod = new Socio(idSocio, nombre, fecha, email, tlfno);

            operaciones.ModificarSocio(socioMod);
            MessageBox.Show("Socio actualizado correctamente.");
            RefreshData();

        }

        private void dataGridSocios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridSocios.SelectedItem != null)
            {
                Socio socio = (Socio)dataGridSocios.SelectedItem;
                txtIdSocio.Text = socio.idSocio.ToString();
                txtNombre.Text = socio.nombreSocio;
                txtFecnac.Text = socio.fec_nacimiento;
                txtEmail.Text = socio.email;
                txtTlfn.Text = socio.tlfno.ToString();
            }
        }

        private void btnDelSocio_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string fecha = txtFecnac.Text;
            string email = txtEmail.Text;
            int tlfno = int.Parse(txtTlfn.Text.ToString().Replace(" ", ""));
            int idSocio = int.Parse(txtIdSocio.Text);
            Socio socioEliminado = new Socio(idSocio,nombre, fecha, email, tlfno);

            operaciones.EliminarSocio(socioEliminado);
            MessageBox.Show("Socio eliminado correctamente.");
            RefreshData();
        }
    }
}
