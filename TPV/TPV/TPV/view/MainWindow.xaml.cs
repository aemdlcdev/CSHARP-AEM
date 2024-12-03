using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using TPV.domain;
using TPV.persistence.manages;

namespace TPV
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private List<Clientes> listaClientes;
        private Clientes clienteInstance;
        private Productos producto;
        private List<Productos> listaProductos;
        private Usuario usuario;
        private List<Usuario> listaUsuarios;

        private string userType;

        public MainWindow(string userType)
        {
            InitializeComponent();
            this.userType = userType;
            InitializeTimer();
            clienteInstance = new Clientes();
            producto = new Productos();
            listaClientes = clienteInstance.LeerClientes();
            listaProductos = producto.LeerProductos();
            usuario = new Usuario();
            listaUsuarios = usuario.LeerUsuarios();
            dataUsers.ItemsSource = listaUsuarios;
            dataClientes.ItemsSource = listaClientes;
            dataInventario.ItemsSource = listaProductos;

            ConfigureUIBasedOnUserType(); // Depende del tipo de usuario, se mostrarán unas opciones u otras
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Hora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void ConfigureUIBasedOnUserType()
        {
            if (userType == "user")
            {
                tabVentas.Visibility = Visibility.Collapsed;
                tabConfiguracion.Visibility = Visibility.Collapsed;
                addProducto.IsEnabled = false;
                delProducto.IsEnabled = false;
                addProducto.Visibility = Visibility.Hidden;
                delProducto.Visibility = Visibility.Hidden;
            }
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string email = txtCorreo.Text;

            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(email))
            {
                MessageBox.Show("Por favor, rellene todos los campos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Clientes clienteNuevo = new Clientes(email, nombre);
            clienteNuevo.InsertarCliente(clienteNuevo);
            listaClientes.Clear();
            listaClientes = clienteNuevo.LeerClientes();
            dataClientes.ItemsSource = null;
            dataClientes.ItemsSource = listaClientes;
        }

        private void dataInventario_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Productos producto = (Productos)dataInventario.SelectedItem;

            if (producto != null)
            {
                txtIdProducto.Text = producto.idProducto.ToString();
                txtNombreProducto.Text = producto.nombre;
                txtAlergias.Text = producto.alergias;
                txtPrecio.Text = producto.precio.ToString();
                txtCantidad.Text = producto.cantidad.ToString();
            }
        }

        private void modProducto_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtIdProducto.Text);
            string nombre = txtNombreProducto.Text;
            string alergias = txtAlergias.Text;
            double precio = double.Parse(txtPrecio.Text);
            int cantidad = int.Parse(txtCantidad.Text);

            Productos productos = new Productos(id, nombre, alergias, precio, cantidad);

            producto.ModificarProducto(productos);
            listaProductos.Clear();
            listaProductos = producto.LeerProductos();
            dataInventario.ItemsSource = null;
            dataInventario.ItemsSource = listaProductos;
        }

        private void delProducto_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar este producto?", "Eliminar producto", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            else if (result == MessageBoxResult.Yes)
            {
                int id = int.Parse(txtIdProducto.Text);
                string nombre = txtNombreProducto.Text;
                string alergias = txtAlergias.Text;
                double precio = double.Parse(txtPrecio.Text);
                int cantidad = int.Parse(txtCantidad.Text);
                Productos productos = new Productos(id, nombre, alergias, precio, cantidad);
                producto.EliminarProducto(productos);

                listaProductos.Clear();
                listaProductos = producto.LeerProductos();
                dataInventario.ItemsSource = null;
                dataInventario.ItemsSource = listaProductos;
            }
        }

        private void addProducto_Click(object sender, RoutedEventArgs e)
        {
            producto = new Productos(txtNombreProducto.Text, txtAlergias.Text, double.Parse(txtPrecio.Text), int.Parse(txtCantidad.Text));
            producto.InsertarProducto(producto);
            listaProductos.Clear();
            listaProductos = producto.LeerProductos();
            dataInventario.ItemsSource = null;
            dataInventario.ItemsSource = listaProductos;
        }
    }
}

