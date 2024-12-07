using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        private CuentaCliente cuentaCliente;
        private Dictionary<int, CuentaCliente> cuentasClientes; // Diccionario para almacenar las cuentas de los clientes

        // Calculadora

        private string input = string.Empty;
        private string operand1 = string.Empty;
        private string operand2 = string.Empty;
        private char operation;
        private double result = 0.0;

        private string userType;

        public MainWindow(string userType)
        {
            InitializeComponent();
            this.userType = userType;
            InitializeTimer();

            clienteInstance = new Clientes();
            producto = new Productos();

            listaClientes = clienteInstance.LeerClientes();

            dataClientes.ItemsSource = listaClientes;

            listaProductos = producto.LeerProductos();

            usuario = new Usuario();
            listaUsuarios = usuario.LeerUsuarios();

            dataUsers.ItemsSource = listaUsuarios;
            dataInventario.ItemsSource = listaProductos;

            cuentasClientes = new Dictionary<int, CuentaCliente>();

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

            Clientes clienteNuevo = new Clientes(email, nombre); // Asegúrate de que los parámetros estén en el orden correcto
            clienteNuevo.InsertarCliente(clienteNuevo);

            txtNombre.Text = "";
            txtCorreo.Text = "";

            RefreshDataClientes();
        }

        private void dataInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            MessageBox.Show("Producto modificado correctamente!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtBuscar.Text;
            var productos = listaProductos.FindAll(p => p.nombre.Contains(nombre));
            dataInventario.ItemsSource = null;
            dataInventario.ItemsSource = productos;
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombreUser.Text;
            string password = txtPassword.Text;

            Usuario usuario = new Usuario(nombre, password);
            usuario.InsertarUsuario(usuario);

            listaUsuarios.Clear();
            listaUsuarios = usuario.LeerUsuarios();
            dataUsers.ItemsSource = null;
            dataUsers.ItemsSource = listaUsuarios;
        }

        private void btnMostrarTodos_Click(object sender, RoutedEventArgs e)
        {
            listaProductos.Clear();
            listaProductos = producto.LeerProductos();
            dataInventario.ItemsSource = null;
            dataInventario.ItemsSource = listaProductos;
        }

        private void dataClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clientes clienteSeleccionado = (Clientes)dataClientes.SelectedItem;

            if (clienteSeleccionado != null)
            {
                // Guardar la cuenta actual en el diccionario
                if (cuentaCliente != null)
                {
                    cuentasClientes[cuentaCliente.cliente.codCliente] = cuentaCliente;
                    cuentaCliente.OnProductosChanged -= CuentaCliente_OnProductosChanged;
                }

                // Recuperar la cuenta del cliente seleccionado o crear una nueva si no existe
                if (cuentasClientes.TryGetValue(clienteSeleccionado.codCliente, out CuentaCliente cuenta))
                {
                    cuentaCliente = cuenta;
                }
                else
                {
                    cuentaCliente = new CuentaCliente(clienteSeleccionado);
                }

                cuentaCliente.OnProductosChanged += CuentaCliente_OnProductosChanged;
                txtSaldo.Text = cuentaCliente.Total.ToString("C");
            }
        }

        private void CuentaCliente_OnProductosChanged(object sender, EventArgs e)
        {
            txtSaldo.Text = cuentaCliente.Total.ToString("C");
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (cuentaCliente == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente primero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Image image = sender as Image;

            if (image != null)
            {
                // Obtener la ruta de la imagen
                string productoNombre = System.IO.Path.GetFileName(image.Source.ToString());

                // Buscar el producto correspondiente
                Productos productoSeleccionado = listaProductos.FirstOrDefault(p => System.IO.Path.GetFileName(p.Imagen) == productoNombre);

                if (productoSeleccionado != null)
                {
                    cuentaCliente.AgregarProducto(productoSeleccionado);
                    MessageBox.Show($"Producto {productoSeleccionado.nombre} agregado a la cuenta del cliente {cuentaCliente.cliente.cnombre}.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Actualizar el saldo en txtSaldo
                    txtSaldo.Text = cuentaCliente.Total.ToString("C");
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void chkDark_Checked(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Dark");
        }

        private void chkDark_Unchecked(object sender, RoutedEventArgs e)
        {
            ChangeTheme("Dark");
        }

        private void ChangeTheme(string theme)
        {
            ResourceDictionary newTheme = new ResourceDictionary();
            switch (theme)
            {
                case "Dark":
                    newTheme.Source = new Uri("/themes/DarkTheme.xaml", UriKind.Relative);
                    break;
                case "Light":
                    newTheme.Source = new Uri("LightTheme.xaml", UriKind.Relative);
                    break;
            }

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnTicket_Click(object sender, RoutedEventArgs e)
        {
            if (cuentaCliente == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente primero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            StringBuilder sb = new StringBuilder();

            List<string> consumiciones = cuentaCliente.consumiciones();

            foreach (string c in consumiciones)
            {
                sb.Append(c + "\n");
            }

            int idCliente = cuentaCliente.cliente.codCliente;

            Ticket ticket = new Ticket(sb.ToString(), cuentaCliente.Total, idCliente);
            ticket.InsertarTicket(ticket);

            txtSaldo.Text = "";

            cuentaCliente.cliente.ModificarCliente(cuentaCliente.cliente);

            RefreshDataClientes();

            MessageBox.Show("Ticket generado correctamente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RefreshDataClientes()
        {
            listaClientes.Clear();
            listaClientes = clienteInstance.LeerClientes();
            dataClientes.ItemsSource = null;
            dataClientes.ItemsSource = listaClientes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string buttonContent = button.Content.ToString();

            if (buttonContent == "C")
            {
                txtSaldo.Text = string.Empty;
                input = string.Empty;
                operand1 = string.Empty;
                operand2 = string.Empty;
                result = 0.0;
            }
            else if (buttonContent == "=")
            {
                operand2 = input;
                double num1, num2;
                double.TryParse(operand1, out num1);
                double.TryParse(operand2, out num2);

                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            MessageBox.Show("No se puede dividir por cero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                }
                txtSaldo.Text = result.ToString();
                input = result.ToString();

                // Actualizar la cuenta del cliente
                if (cuentaCliente != null)
                {
                    cuentaCliente.Total = result;
                }
            }
            else if (buttonContent == "+" || buttonContent == "-" || buttonContent == "*" || buttonContent == "/")
            {
                operand1 = input;
                operation = buttonContent[0];
                input = string.Empty;
            }
            else
            {
                input += buttonContent;
                txtSaldo.Text = input;
            }
        }
    }
}
