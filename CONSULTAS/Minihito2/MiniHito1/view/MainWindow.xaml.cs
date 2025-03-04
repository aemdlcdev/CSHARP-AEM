﻿using MiniHito1.domain;
using MiniHito1.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace MiniHito1
{
    public partial class MainWindow : Window
    {
        private Proyectos proyecto;
        private List<Proyectos> listaProyectos;
        private List<Usuario> listaUsuarios;
        private Usuario usuario;
        private Usuario usuarioEmpleado; 
        private List<Empleado> listaEmpleados;
        private Empleado empleado;
        private Empleado empleadoHorasSelected;
        private Proyectos proyectoSelected;
        private ProyectoEmpleado proyectoEmpleado;
        private List<ProyectoEmpleado> listaProyectoEmpleado;
        private DataTable dt;

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

            btnModifyUser.IsEnabled = false;

            /*
             * =============================
                Selecciones de los combox
             * =============================
             */

            usuarioEmpleado = new Usuario();
            empleadoHorasSelected = new Empleado();
            proyectoSelected = new Proyectos();

            //Empleados
            empleado = new Empleado();
            listaEmpleados = new List<Empleado>();
            listaEmpleados = empleado.LeerEmpleados();
            dataGridEmpleados.ItemsSource = listaEmpleados;

            //ProyectoEmpleado

            proyectoEmpleado = new ProyectoEmpleado();
            listaProyectoEmpleado = proyectoEmpleado.LeerProyectoEmpleado();

            /*
             ================================
             Cargar los datos en los combobox
             ================================
             */

            cbxProyectos.ItemsSource = listaProyectos;
            cbxUsuarios.ItemsSource = listaUsuarios;
            cbxEmpleados.ItemsSource = listaEmpleados;

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
                txtPassword.Password = "";
                txtIdUser.Text = (usuario.idUsuario).ToString();
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

        private void RefrescarEmple()
        {
            dataGridEmpleados.ItemsSource = null;
            listaEmpleados.Clear();
            listaEmpleados = empleado.LeerEmpleados();
            dataGridEmpleados.ItemsSource = listaEmpleados;
        }

        private void btnUpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            string name = txtUsername.Text;
            int id = int.Parse(txtIdUser.Text);
            if (string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Por favor, rellena el campo contraseña.");
                return;
            }
            string password = Seguridad.EncriptarContraseña(txtPassword.Password);   
            Usuario usuarioModificado = new Usuario(id, name, password);
            usuarioModificado.ModificarUsuario(usuarioModificado);
            RefrescarUsers();
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            string name = txtUsername.Text;
            string password = Seguridad.EncriptarContraseña(txtPassword.Password);
            int id = int.Parse(txtIdUser.Text);
            Usuario usuarioAeliminar = new Usuario(id, name, password);
            usuarioAeliminar.EliminarUsuairo(usuarioAeliminar);
            listaUsuarios.Remove(usuarioAeliminar);
            RefrescarUsers();
        }

        private void cbxUsuarios_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbxUsuarios.SelectedItem != null)
            {
                Usuario usuario = (Usuario)cbxUsuarios.SelectedItem;
                foreach(Usuario user in listaUsuarios)
                {
                    if (user.nombre.Equals(usuario.nombre))
                    {
                        usuarioEmpleado = user;
                    }
                }
            }         
        }

        private void cbRegistrado_Checked(object sender, RoutedEventArgs e)
        {
            cbNoregistrado.IsEnabled = false;
            btnAddUserEmple.IsEnabled = false;
            txtUserEmple.IsEnabled = false;
            txtPassEmple.IsEnabled = false;
            RefrescarUsers();

        }

        private void cbNoregistrado_Checked(object sender, RoutedEventArgs e)
        {
            cbRegistrado.IsEnabled = false;
            cbxUsuarios.IsEnabled = false;
        }

        private void cbRegistrado_Unchecked(object sender, RoutedEventArgs e)
        {
            cbNoregistrado.IsEnabled=true;
            txtUserEmple.IsEnabled = true;
            txtPassEmple.IsEnabled = true;
        }

        private void cbNoregistrado_Unchecked(object sender, RoutedEventArgs e)
        {
            cbRegistrado.IsEnabled=true;
            cbxUsuarios.IsEnabled=true;         
        }

        private void btnAddUserEmple_Click(object sender, RoutedEventArgs e)
        {

            if (cbNoregistrado.IsChecked == false)
            {
                MessageBox.Show("Por favor, marque la opción de usuario no registrado.");
                return;
            }

            string usernameU = txtUserEmple.Text;
            string password = Seguridad.EncriptarContraseña(txtPassEmple.Password);
            Console.WriteLine("Traza" + usernameU, password);
            Usuario nuevoUsuario = new Usuario(usernameU, password);
            nuevoUsuario.InsertarUsuario(nuevoUsuario);
            listaUsuarios.Add(nuevoUsuario);
            RefrescarUsers();

            

            string username = txtEmple.Text;
            string apellidos = txtApellidos.Text;
            float crs = float.Parse(txtCsr.Text);
            int idRol = int.Parse(txtRol.Text);
            int idUsuario = nuevoUsuario.getIdByName(usernameU);
            Console.WriteLine("Traza " + idUsuario);
            Empleado nuevoEmpleado = new Empleado(username, apellidos, crs, idUsuario, idRol);
            nuevoEmpleado.InsertarEmpleado(nuevoEmpleado);
            listaEmpleados.Add(nuevoEmpleado);
            RefrescarEmple();


            txtUserEmple.Text = "";
            txtPassEmple.Password = "";
            
        }

        private void btnAddEmple_Click(object sender, RoutedEventArgs e)
        {
            if(cbRegistrado.IsChecked==false)
            {
                MessageBox.Show("Por favor, marque la opción de usuario ya registrado.");
                return;
            }

            string username = txtEmple.Text;
            string apellidos = txtApellidos.Text;
            float crs = float.Parse(txtCsr.Text);
            int idRol = int.Parse(txtRol.Text);
            int idUsuario = usuarioEmpleado.idUsuario;
            Empleado nuevoEmpleado = new Empleado(username, apellidos,crs,idUsuario,idRol);
            nuevoEmpleado.InsertarEmpleado(nuevoEmpleado);
            listaEmpleados.Add(nuevoEmpleado);
            cbxUsuarios.ItemsSource = null;

            cbNoregistrado.IsEnabled = true;
            btnAddUserEmple.IsEnabled = true;
            txtUserEmple.IsEnabled = true;
            txtPassEmple.IsEnabled = true;

            RefrescarEmple();
        }

        private void btnUpdateEmple_Click(object sender, RoutedEventArgs e)
        {
            string username = txtEmple.Text;
            string apellidos = txtApellidos.Text;
            float crs = float.Parse(txtCsr.Text);
            int idRol = int.Parse(txtRol.Text);
            int idUsuario = usuarioEmpleado.idUsuario;
            int idEmpleado = int.Parse(txtIdEmple.Text);

            Empleado empModificado = new Empleado(idEmpleado,username, apellidos, crs, idUsuario, idRol);
            empModificado.ModificarEmpleado(empModificado);
            MessageBox.Show("Empleado actualizado correctamente.");
            RefrescarEmple();
        }

        private void dataGridEmpleados_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGridEmpleados.SelectedItem != null)
            {
                Empleado empleado = (Empleado)dataGridEmpleados.SelectedItem;
                txtIdEmple.Text = empleado.idEmpleado.ToString();
                txtEmple.Text = empleado.nombre;
                txtApellidos.Text = empleado.apellidos;
                txtCsr.Text = empleado.csr.ToString();
                txtRol.Text = empleado.idRol.ToString();
                txtIdUsuEmple.Text = empleado.idUsuario.ToString();
            }
        }

        private void btnDeleteEmple_Click(object sender, RoutedEventArgs e)
        {
            string username = txtEmple.Text;
            string apellidos = txtApellidos.Text;
            float crs = float.Parse(txtCsr.Text);
            int idRol = int.Parse(txtRol.Text);
            int idUsuario = usuarioEmpleado.idUsuario;
            int idEmpleado = int.Parse(txtIdEmple.Text);

            Empleado empModificado = new Empleado(idEmpleado, username, apellidos, crs, idUsuario, idRol);
            empModificado.EliminarEmpleado(empModificado);
            RefrescarEmple();
        }

        private void cargarInforme() 
        {
            // Inicializar tabla 
            dt = new DataTable("DataTable1");


            // Crear columnas

            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellidos");
            dt.Columns.Add("CSR");

            // Meter el contenido en la tabla

            foreach(Empleado emple in listaEmpleados)
            {

                // Creo la fila

                DataRow row = dt.NewRow();

                row["Nombre"] = emple.nombre;
                row["Apellidos"] = emple.apellidos;
                row["CSR"] = emple.csr;


                // Añadir la fila a la tabla

                dt.Rows.Add(row);

            }

            CrystalReport1 cr = new CrystalReport1();

            cr.Database.Tables["DataTable1"].SetDataSource((DataTable)dt);

            // Mostrar los datos en el visor

            visor.ViewerCore.ReportSource = cr;

        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            cargarInforme();
        }

        private void cbxEmpleados_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbxEmpleados.SelectedItem != null)
            {
                Empleado empleado = (Empleado)cbxEmpleados.SelectedItem;
                foreach (Empleado emple in listaEmpleados)
                {
                    if (emple.nombre.Equals(empleado.nombre))
                    {
                        empleadoHorasSelected = emple;
                    }
                }
            }


        }

        private void cbxProyectos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbxUsuarios.SelectedItem != null)
            {
                Proyectos proyecto = (Proyectos)cbxUsuarios.SelectedItem;
                foreach (Proyectos proy in listaProyectos)
                {
                    if (proy.Codigopy.Equals(proyecto.Codigopy))
                    {
                        proyectoSelected = proy;
                    }
                }
            }
        }

        private void btnAddHoras_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
