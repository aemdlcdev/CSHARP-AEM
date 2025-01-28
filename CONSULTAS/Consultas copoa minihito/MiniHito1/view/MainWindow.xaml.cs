using MiniHito1.domain;
using MiniHito1.persistence.manages;
using MiniHito1.view.pages;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MiniHito1
{
    public partial class MainWindow : Window
    {
        private Proyectos proyecto;
        private List<Proyectos> listaProyectos;
        private List<Usuario> listaUsuarios;
        private Usuario usuario;
        public MainWindow()
        {
            
            InitializeComponent();
            proyecto = new Proyectos();
            // Cargo los proyectos de la bbdd en el data grid
            listaProyectos = proyecto.LeerProyectos();
            dataGridView1.ItemsSource = listaProyectos;

            // Usuarios
            usuario = new Usuario();
            listaUsuarios = usuario.LeerUsuarios();
            dataGridUsers.ItemsSource = listaUsuarios;
        }


        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            
            string nombreProyecto = txtBuscar.Text;

            // Buscar proyectos por nombre
            var proyectosEncontrados = proyecto.BuscarProyectosPorNombre(nombreProyecto);

            // Actualizar el DataGridView con los proyectos encontrados
            dataGridView1.ItemsSource = null;
            dataGridView1.ItemsSource = proyectosEncontrados;
        }

        private void addProyecto_Click(object sender, RoutedEventArgs e)
        {
            string codigoproyec = txtId.Text;
            string nombre = txtNombre.Text;
            string fechaInicio = txtFechaInicio.Text;
            string fechaFin = txtFechaFin.Text;
            Proyectos nuevoProyecto = new Proyectos(codigoproyec, nombre, fechaInicio, fechaFin);

            proyecto.AñadirProyecto(nuevoProyecto);
            listaProyectos.Clear();
            // Actualizar el DataGridView
            dataGridView1.ItemsSource = null;
            dataGridView1.ItemsSource = proyecto.LeerProyectos();
        }

        private void btnProyectoss_Click(object sender, RoutedEventArgs e)
        {
            tabMenu.SelectedItem = tabProyectos;
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            proyecto = new Proyectos();
            proyecto.GenerarProyectos();
            listaProyectos = proyecto.LeerProyectos();
            dataGridView1.ItemsSource = null;
            dataGridView1.ItemsSource = listaProyectos;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Verificar que los campos de texto no estén vacíos
            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtFechaInicio.Text) || string.IsNullOrEmpty(txtFechaFin.Text))
            {
                MessageBox.Show("Por favor, rellena todos los campos antes de modificar el proyecto.");
                return;
            }

            string codigoproyec = txtId.Text;
            string nombre = txtNombre.Text;
            string fechaInicio = txtFechaInicio.Text;
            string fechaFin = txtFechaFin.Text;

            // Crear el objeto Proyectos
            Proyectos proyecto = new Proyectos(codigoproyec, nombre, fechaInicio, fechaFin);

            // Modificar el proyecto
            proyecto.ModificarProyecto(proyecto);

            // Verificar que listaProyectos esté inicializada
            if (listaProyectos == null)
            {
                listaProyectos = new List<Proyectos>();
            }

            // Limpiar y actualizar el DataGrid
            listaProyectos.Clear();
            dataGridView1.ItemsSource = null;
            dataGridView1.ItemsSource = proyecto.LeerProyectos();
        }


        private void dataGridView1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGridView1.SelectedItem != null)
            {
                Proyectos proyecto = (Proyectos)dataGridView1.SelectedItem;
                txtId.Text = proyecto.Codigopy;
                txtNombre.Text = proyecto.Nombre;
                txtFechaInicio.Text = proyecto.FechaInicio;
                txtFechaFin.Text = proyecto.FechaFin;
            }
        }

        private void btnConsultaFiltrada_Click(object sender, RoutedEventArgs e)
        {
            //ResultsQuerys resultsQuerys = new ResultsQuerys(listaProyectos);
            //frameConsulta.Navigate(resultsQuerys);
        }

        private void dataGridUsers_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(dataGridUsers.SelectedItem != null)
            {
                Usuario usuario = (Usuario)dataGridUsers.SelectedItem;
                txtUsername.Text = usuario.nombre;
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = Seguridad.EncriptarContraseña(txtPassword.Password);
            Console.WriteLine("Traza" + username, password);
            Usuario nuevoUsuario = new Usuario(username,password);
            nuevoUsuario.InsertarUsuario(nuevoUsuario);
            listaUsuarios.Add(nuevoUsuario);
            RefrescarUsers();
        }

        private void RefrescarUsers() 
        {
            dataGridUsers.ItemsSource = null;
            listaUsuarios.Clear();
            listaUsuarios = usuario.LeerUsuarios();
            dataGridUsers.ItemsSource = listaUsuarios;
        }

        private void btnModifyUser_Click(object sender, RoutedEventArgs e)
        {
            string name = txtUsername.Text;
            string password = txtPassword.Password;
            Usuario usuarioModificado = new Usuario(0,name, password);

            var usuarioModificadoConId = listaUsuarios.Find(u => u.nombre == usuarioModificado.nombre);

            if (usuarioModificadoConId != null)
            {
                usuario.ModificarUsuario(usuarioModificadoConId);
                RefrescarUsers();
            }


        }
    }
}
