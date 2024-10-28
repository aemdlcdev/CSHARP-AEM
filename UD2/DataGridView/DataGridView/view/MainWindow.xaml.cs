using DataGridView;
using DataGridView.persistence;
using System.Collections.Generic;
using System.Windows;

namespace DataGridView
{
    public partial class MainWindow : Window
    {
        private List<Persona> listaPersonas;
        private Persona persona;

        public MainWindow()
        {
            InitializeComponent();
            listaPersonas = new List<Persona>();

            persona = new Persona();

            listaPersonas = persona.GetPersonas();

            dataGridPersonas.ItemsSource = listaPersonas;
        }

        private void btnAgregarPersona_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(txtEdad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtEdad.Text, out int edad))
            {
                MessageBox.Show("Por favor, ingrese una edad válida.", "Edad inválida", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;

            Persona nuevaPersona = new Persona(nombre, apellidos, edad);
            listaPersonas.Add(nuevaPersona);

            dataGridPersonas.Items.Refresh();
            start();
        }



        private void start()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            btnAgregarPersona.IsEnabled = true;
        }

        private void dataGridPersonas_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGridPersonas.SelectedItem is Persona personaSeleccionada)
            {
                txtNombre.Text = personaSeleccionada.Nombre;
                txtApellidos.Text = personaSeleccionada.Apellidos;
                txtEdad.Text = personaSeleccionada.Edad.ToString();
                btnAgregarPersona.IsEnabled = false;
            }
            else
            {
                txtNombre.Text = "";
                txtApellidos.Text = "";
                txtEdad.Text = "";
                btnAgregarPersona.IsEnabled = true;
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que quiere eliminar esta persona?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes && dataGridPersonas.SelectedItem is Persona personaSeleccionada)
            {
                listaPersonas.Remove(personaSeleccionada);
                dataGridPersonas.Items.Refresh();
                start();
            }
        }
    }
}
