using DataGridView;
using DataGridView.persistence;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DataGridView
{
    public partial class MainWindow : Window
    {
        private List<Persona> listaPersonas;
        private Persona personaM;
        private string btnAgregarPersonaContent;

        public MainWindow()
        {
            InitializeComponent();
            personaM = new Persona();
            try
            {
                listaPersonas = personaM.GetPersonas();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deserializar el JSON: {ex.Message}");
            }

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

                if (!int.TryParse(txtEdad.Text, out int edad))
                {
                    MessageBox.Show("Por favor, ingrese una edad válida.", "Edad inválida", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                error = ValidarCampos();

                if (error == false)
                {

                    if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidos) || edad < 0)
                    {
                        MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    int lastId = personaM.LastId() + 1;
                    Persona nuevaPersona = new Persona(lastId, nombre, apellidos, edad);

                    if (VerificarExistencia(nuevaPersona))
                    {
                        MessageBox.Show("La persona ya existe", "Persona existente", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        personaM.InsertarPersona(nuevaPersona);
                        RefreshDataGrid();
                        start();
                    }
                }
            }
            else if (btnAgregarPersona.Content.Equals("Guardar cambios"))
            {
                error = ValidarCampos();
                if (dataGridPersonas.SelectedItem is Persona personaSeleccionada && error == false)
                {

                    if (!int.TryParse(txtEdad.Text, out int edad))
                    {
                        MessageBox.Show("Por favor, ingrese una edad válida.", "Edad inválida", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    personaSeleccionada.Nombre = txtNombre.Text;
                    personaSeleccionada.Apellidos = txtApellidos.Text;
                    personaSeleccionada.Edad = edad;

                    personaM.ModificarPersona(personaSeleccionada);

                    MessageBox.Show("Cambios guardados", "Cambios guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                    RefreshDataGrid();
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

                txtNombre.IsReadOnly = true;
                txtApellidos.IsReadOnly = true;
                txtEdad.IsReadOnly = true;
            }
            else
            {
                txtNombre.Text = "";
                txtApellidos.Text = "";
                txtEdad.Text = "";
                btnAgregarPersona.IsEnabled = true;

                txtNombre.IsReadOnly = false;
                txtApellidos.IsReadOnly = false;
                txtEdad.IsReadOnly = false;
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPersonas.SelectedItem != null && MessageBox.Show("¿Está seguro que quiere eliminar esta persona?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes && dataGridPersonas.SelectedItem is Persona personaSeleccionada)
            {
                listaPersonas.Remove(personaSeleccionada);
                personaM.EliminarPersona(personaSeleccionada);
                RefreshDataGrid();
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

                txtNombre.IsReadOnly = false;
                txtApellidos.IsReadOnly = false;
                txtEdad.IsReadOnly = false;
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

            txtNombre.IsReadOnly = false;
            txtApellidos.IsReadOnly = false;
            txtEdad.IsReadOnly = false;
        }

        private void RefreshDataGrid()
        {
            listaPersonas = personaM.GetPersonas();
            dataGridPersonas.ItemsSource = null;
            dataGridPersonas.ItemsSource = listaPersonas;
            dataGridPersonas.Items.Refresh();
        }

        #endregion

        #region Evento de clic en el Grid principal

        private void MainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!dataGridPersonas.IsMouseOver && !btnAgregarPersona.Content.Equals("Guardar cambios"))
            {
                btnAgregarPersona.IsEnabled = true;
                dataGridPersonas.SelectedItem = null;
                LimpiarTextBoxes();
            }
        }

        private void LimpiarTextBoxes()
        {
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
        }

        #endregion
    }
}

