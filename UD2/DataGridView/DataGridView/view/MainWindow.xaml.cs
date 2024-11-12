using DataGridView;
using DataGridView.persistence;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DataGridView
{
    public partial class MainWindow : Window
    {
        private List<Persona> listaPersonas;
        private PersonasManage personasManage;
        private string btnAgregarPersonaContent;

        public MainWindow()
        {
            InitializeComponent();
            personasManage = new PersonasManage();
            listaPersonas = personasManage.LeerPersonas();

            dataGridPersonas.ItemsSource = listaPersonas;

            btnAgregarPersonaContent = "Añadir persona"; // String para el content del btnAgregarPersona
            btnAgregarPersona.Content = btnAgregarPersonaContent;
        }

        #region Eventos de botones

        private void btnAgregarPersona_Click(object sender, RoutedEventArgs e)
        {
            bool error = false;
            if (btnAgregarPersona.Content.Equals("Añadir persona"))
            {
                string nombre = txtNombre.Text;
                string apellidos = txtApellidos.Text;

                // Validar que la edad sea un número
                if (!int.TryParse(txtEdad.Text, out int edad))
                {
                    MessageBox.Show("Por favor, ingrese una edad válida.", "Edad inválida", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                error = ValidarCampos();

                if (error == false)
                {
                    // Verificar si los campos están vacíos
                    if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidos) || edad == 0)
                    {
                        MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    int lastId = personasManage.LastId() + 1;
                    Persona nuevaPersona = new Persona(lastId, nombre, apellidos, edad);

                    if (VerificarExistencia(nuevaPersona))
                    {
                        MessageBox.Show("La persona ya existe", "Persona existente", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        personasManage.InsertarPersona(nuevaPersona); // Insertar en la base de datos
                        RefreshDataGrid(); // Refrescar el DataGrid
                        start();
                    }
                }
            }
            else if (btnAgregarPersona.Content.Equals("Guardar cambios"))
            {
                error = ValidarCampos();
                if (dataGridPersonas.SelectedItem is Persona personaSeleccionada && error == false)
                {
                    // Validar que la edad sea un número
                    if (!int.TryParse(txtEdad.Text, out int edad))
                    {
                        MessageBox.Show("Por favor, ingrese una edad válida.", "Edad inválida", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    personaSeleccionada.Nombre = txtNombre.Text;
                    personaSeleccionada.Apellidos = txtApellidos.Text;
                    personaSeleccionada.Edad = edad;

                    personasManage.ModificarPersona(personaSeleccionada); // Modificar en la base de datos

                    MessageBox.Show("Cambios guardados", "Cambios guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                    RefreshDataGrid(); // Refrescar el DataGrid
                    start();
                }
            }
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
                personasManage.EliminarPersona(personaSeleccionada); // Eliminar de la base de datos
                RefreshDataGrid(); // Refrescar el DataGrid
                start();
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            bool errorCampos = ValidarCampos();

            if (errorCampos == false && dataGridPersonas.SelectedItem is Persona personaSeleccionada)
            {
                btnAgregarPersonaContent = "Guardar cambios";
                btnAgregarPersona.Content = btnAgregarPersonaContent;
                btnEliminar.IsEnabled = false;
                btnModificar.IsEnabled = false;
                btnAgregarPersona.IsEnabled = true;
            }
        }

        #endregion

        #region Eventos de validación de campos y start

        private bool VerificarExistencia(Persona persona)
        {
            bool existe = false;
            int id = persona.id;
            string name = persona.Nombre;
            string lastName = persona.Apellidos;
            int age = persona.Edad;
            existe = listaPersonas.Exists(p => p.id == id || (p.Nombre == name && p.Apellidos == lastName && p.Edad == age));

            return existe;
        }

        private bool ValidarCampos()
        {
            bool error = false;
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(txtEdad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                error = true;
            }

            return error;
        }

        private void start()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            btnAgregarPersona.IsEnabled = true;
            btnAgregarPersonaContent = "Añadir persona";
            btnAgregarPersona.Content = btnAgregarPersonaContent;
            btnEliminar.IsEnabled = true;
            btnModificar.IsEnabled = true;
        }

        private void RefreshDataGrid()
        {
            listaPersonas.Clear(); // Limpio la lista antes de cargarla para que no me aparezca duplicada
            listaPersonas = personasManage.LeerPersonas(); // Recargo la lista desde la bbdd
            dataGridPersonas.ItemsSource = null; 
            dataGridPersonas.ItemsSource = listaPersonas; 
            dataGridPersonas.Items.Refresh();
        }

        #endregion
    }
}

