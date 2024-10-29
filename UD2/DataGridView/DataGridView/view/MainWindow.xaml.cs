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
            if(btnAgregarPersona.Content.Equals("Añadir persona"))
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
                if (VerificarExistencia(nuevaPersona))
                {
                    MessageBox.Show("La persona ya existe", "Persona existente", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    listaPersonas.Add(nuevaPersona);
                    dataGridPersonas.Items.Refresh();
                    start();
                }
            }
            else if (btnAgregarPersona.Content.Equals("Guardar cambios"))
            {
                if (dataGridPersonas.SelectedItem is Persona personaSeleccionada)
                {
                    
                    personaSeleccionada.Nombre = txtNombre.Text;
                    personaSeleccionada.Apellidos = txtApellidos.Text;
                    personaSeleccionada.Edad = int.Parse(txtEdad.Text);

                    dataGridPersonas.Items.Refresh();
                    start();
                }
            }

        }

        private void start()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            btnAgregarPersona.IsEnabled = true;
            btnAgregarPersona.Content = "Añadir persona";
            btnEliminar.IsEnabled = true;
            btnModificar.IsEnabled = true;
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

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridPersonas.SelectedItem is Persona personaSeleccionada)
            {
                btnAgregarPersona.Content = "Guardar cambios";
                btnEliminar.IsEnabled = false;
                btnModificar.IsEnabled = false;
                btnAgregarPersona.IsEnabled = true;
            }

        }

        private bool VerificarExistencia(Persona persona)
        { 
            bool existe = false;
            string name = persona.Nombre;
            string lastName = persona.Apellidos;
            int age = persona.Edad;
            if(listaPersonas.Exists(p => p.Nombre == name && p.Apellidos == lastName && p.Edad == age))
            {
                existe = true;
            }
            return existe;
        }

    }
}
