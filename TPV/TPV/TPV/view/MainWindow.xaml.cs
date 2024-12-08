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

        private Ticket ticket;
        private List<Ticket> listaTickets;

        private CuentaCliente cuentaCliente;

        private Dictionary<int, CuentaCliente> cuentasClientes; // Diccionario para almacenar las cuentas de los clientes

        // Calculadora

        private string currentOperator = string.Empty;
        private double currentValue = 0.0;

         // Asegúrate de que listaProductos contiene los objetos Productos


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
            listaUsuarios = usuario.LeerUsuariosGestion();

            dataUsers.ItemsSource = listaUsuarios;
            dataInventario.ItemsSource = listaProductos;

            ticket = new Ticket();
            listaTickets = ticket.LeerTickets();
            dataVentas.ItemsSource = listaTickets;

            cuentasClientes = new Dictionary<int, CuentaCliente>();

            double totalGanancias = CalcularGananciasTotales();
            txtGanancias.Text = $"{totalGanancias:C}";

            EstablecesCantidadProductos();

            ConfigureUIBasedOnUserType(); // Depende del tipo de usuario, se mostrarán unas opciones u otras
        }

        #region HORA
        private void InitializeTimer() // Metodo para mostrar la hora en la ventana
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
        #endregion


        #region CONFIGURACION USUARIOS
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
                lblRuta.Visibility = Visibility.Hidden;
                txtRuta.Visibility = Visibility.Hidden;
                lblRuta.IsEnabled = false;
                txtRuta.IsEnabled = false;

                txtNombreProducto.IsEnabled = false;
                txtPrecio.IsEnabled = false;

                lblIdRolC.Visibility = Visibility.Hidden;
                txtIdRol.Visibility = Visibility.Hidden;
                lblIdRolC.IsEnabled = false;
                txtIdRol.IsEnabled = false;
            }

            if (userType == "jefe")
            {
                addProducto.IsEnabled = false;
                addProducto.Visibility = Visibility.Hidden;
                lblRuta.Visibility = Visibility.Hidden;
                txtRuta.Visibility = Visibility.Hidden;
                lblRuta.IsEnabled = false;
                txtRuta.IsEnabled = false;

                lblIdRolC.Visibility = Visibility.Hidden;
                txtIdRol.Visibility = Visibility.Hidden;
                lblIdRolC.IsEnabled = false;
                txtIdRol.IsEnabled = false;
            }

            if (userType == "admin")
            {
                tabVentas.Visibility = Visibility.Visible;
                tabConfiguracion.Visibility = Visibility.Visible;
                addProducto.IsEnabled = true;
                delProducto.IsEnabled = true;
                addProducto.Visibility = Visibility.Visible;
                delProducto.Visibility = Visibility.Visible;
                listaUsuarios = usuario.LeerUsuarios();
                dataUsers.ItemsSource = null;
                dataUsers.ItemsSource = listaUsuarios;
                lblRuta.Visibility = Visibility.Visible;
                txtRuta.Visibility = Visibility.Visible;
                lblRuta.IsEnabled = true;
                txtRuta.IsEnabled = true;
                lblIdRolC.Visibility = Visibility.Visible;
                txtIdRol.Visibility = Visibility.Visible;
                lblIdRolC.IsEnabled = true;
                txtIdRol.IsEnabled = true;

            }
        }

        #endregion


        #region PRODUCTOS

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtBuscar.Text;
            var productos = listaProductos.FindAll(p => p.nombre.Contains(nombre));
            dataInventario.ItemsSource = null;
            dataInventario.ItemsSource = productos;
        }

        private void btnMostrarTodos_Click(object sender, RoutedEventArgs e)
        {
            listaProductos.Clear();
            listaProductos = producto.LeerProductos();
            dataInventario.ItemsSource = null;
            dataInventario.ItemsSource = listaProductos;
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
            EstablecesCantidadProductos();
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
            string nombre = txtNombreProducto.Text;
            string alergias = txtAlergias.Text;
            double precio = double.Parse(txtPrecio.Text);
            int cantidad = int.Parse(txtCantidad.Text);
            string ruta = txtRuta.Text;

            if(String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(alergias) || String.IsNullOrEmpty(precio.ToString()) || String.IsNullOrEmpty(cantidad.ToString()) || String.IsNullOrEmpty(ruta))
            {
                MessageBox.Show("Por favor, rellene todos los campos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            producto = new Productos(nombre,alergias,precio,cantidad,ruta);
            producto.InsertarProducto(producto);
            listaProductos.Clear();
            listaProductos = producto.LeerProductos();
            dataInventario.ItemsSource = null;
            dataInventario.ItemsSource = listaProductos;
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
                // Obtengo la ruta de la imagen
                string productoNombre = System.IO.Path.GetFileName(image.Source.ToString());

                // Busco el producto correspondiente
                Productos productoSeleccionado = listaProductos.FirstOrDefault(p => System.IO.Path.GetFileName(p.Imagen) == productoNombre);

                if (productoSeleccionado != null)
                {
                    cuentaCliente.AgregarProducto(productoSeleccionado);
                    MessageBox.Show($"Producto {productoSeleccionado.nombre} agregado a la cuenta del cliente {cuentaCliente.cliente.cnombre}.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Actualizo el saldo en txtSaldo
                    currentValue = cuentaCliente.Total;
                    txtSaldo.Text = currentValue.ToString("C");
                    
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        #endregion


        #region USUARIOS



        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombreUser.Text;
            string contraseña = txtPassword.Text;
            int idRol = 2;

            if(txtIdRol.Text != "")
            {
                idRol = int.Parse(txtIdRol.Text);
            }

            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(contraseña) || String.IsNullOrEmpty(idRol.ToString()))
            {
                MessageBox.Show("Por favor, rellene todos los campos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Encripto la contraseña
            string contraseñaEncriptada = Seguridad.EncriptarContraseña(contraseña);

            Usuario usuario = new Usuario(nombre, contraseñaEncriptada, idRol);
            usuario.InsertarUsuario(usuario);

            RefrescarUsuarios();
        }


        private void modUser_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtIdUser.Text);
            string nombre = txtNombreUser.Text;
            string contraseña = txtPassword.Text;
            int idRol = 2;

            if (txtIdRol.Text != "")
            {
                idRol = int.Parse(txtIdRol.Text);
            }

            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(contraseña) || String.IsNullOrEmpty(idRol.ToString()))
            {
                MessageBox.Show("Por favor, rellene todos los campos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Encripto la contraseña
            string contraseñaEncriptada = Seguridad.EncriptarContraseña(contraseña);

            Usuario usuario = new Usuario(id, nombre, contraseñaEncriptada, idRol);
            usuario.ModificarUsuario(usuario);

            RefrescarUsuarios();
        }


        private void delUser_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de que quieres eliminar este usuario?", "Eliminar usuario", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            else if (result == MessageBoxResult.Yes)
            {
                int idUsuario = int.Parse(txtIdUser.Text);
                string nombre = txtNombreUser.Text;
                string password = txtPassword.Text;
                int idRol = txtIdRol.Text == "" ? 2 : int.Parse(txtIdRol.Text);
                Usuario usuario = new Usuario(idUsuario, nombre, password, idRol);
                usuario.EliminarUsuario(usuario);

                RefrescarUsuarios();
            }
        }

        private void dataUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Usuario usuarioSeleccionado = (Usuario)dataUsers.SelectedItem;

            if (usuarioSeleccionado != null)
            {
                txtIdUser.Text = usuarioSeleccionado.idUsuario.ToString();
                txtNombreUser.Text = usuarioSeleccionado.nombre;
                txtPassword.Text = usuarioSeleccionado.password;
            }

        }

        private void RefrescarUsuarios()
        {
            listaUsuarios.Clear();
            if (userType == "admin")
            {
                listaUsuarios = usuario.LeerUsuarios();
            }
            else
            {
                listaUsuarios = usuario.LeerUsuariosGestion();
            }
            dataUsers.ItemsSource = null;
            dataUsers.ItemsSource = listaUsuarios;
        }

        #endregion


        #region CLIENTES

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

            txtNombre.Text = "";
            txtCorreo.Text = "";

            RefreshDataClientes();
        }
        private void dataClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Clientes clienteSeleccionado = (Clientes)dataClientes.SelectedItem;

            if (clienteSeleccionado != null)
            {
                // Recupero la cuenta del cliente actual
                if (cuentasClientes.TryGetValue(clienteSeleccionado.codCliente, out CuentaCliente cuenta))
                {
                    cuentaCliente = cuenta;
                }
                else
                {
                    cuentaCliente = new CuentaCliente(clienteSeleccionado);
                }

                // Establecer el saldo inicial del cliente (incluyendo operaciones previas)
                currentValue = cuentaCliente.Total;
                txtSaldo.Text = currentValue.ToString("C");
            }
        }


        private void CuentaCliente_OnProductosChanged(object sender, EventArgs e)
        {
            
            if (cuentaCliente != null)
            {
                currentValue = cuentaCliente.Total;
                txtSaldo.Text = currentValue.ToString("C");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string content = button.Content.ToString();

                if (double.TryParse(content, out double number))
                {
                    // Si el contenidoe es un numero lo pongo en pantalla
                    txtSaldo.Text += content;
                }
                else if (content == "=")
                {
                    // Al presionar el operador "=" realizamos la operación
                    if (double.TryParse(txtSaldo.Text, out double newValue))
                    {
                        switch (currentOperator)
                        {
                            case "+":
                                currentValue += newValue;  // Sumo el valor al total
                                break;
                            case "-":
                                currentValue -= newValue;  // Resto el valor al total
                                break;
                            case "*":
                                currentValue *= newValue;  // Multiplico el valor al total
                                break;
                            case "/":
                                if (newValue != 0)
                                {
                                    currentValue /= newValue;  // Divido el valor al total
                                }
                                else
                                {
                                    MessageBox.Show("No se puede dividir por cero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                break;
                        }

                        // Actualizo en pantalla
                        txtSaldo.Text = currentValue.ToString("C");

                        // Actualizo en la cuenta del cliente
                        if (cuentaCliente != null)
                        {
                            cuentaCliente.Total = currentValue;
                            cuentasClientes[cuentaCliente.cliente.codCliente] = cuentaCliente;
                        }
                    }
                    currentOperator = string.Empty;
                }
                else
                {
                    // Cuando preisono un operador
                    if (double.TryParse(txtSaldo.Text, out double newValue))
                    {
                        switch (currentOperator)
                        {
                            case "+":
                                currentValue += newValue;
                                break;
                            case "-":
                                currentValue -= newValue;
                                break;
                            case "*":
                                currentValue *= newValue;
                                break;
                            case "/":
                                if (newValue != 0)
                                {
                                    currentValue /= newValue;
                                }
                                else
                                {
                                    MessageBox.Show("No se puede dividir por cero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                break;
                            default:
                                currentValue = newValue;
                                break;
                        }

                        // Actualizo en pantalla
                        txtSaldo.Text = currentValue.ToString("C");

                        // Actualizo en la cuenta del cliente
                        if (cuentaCliente != null)
                        {
                            cuentaCliente.Total = currentValue;
                            cuentasClientes[cuentaCliente.cliente.codCliente] = cuentaCliente;
                        }
                    }
                    currentOperator = content;
                    txtSaldo.Clear();
                }
            }
        }

        private void RefreshDataClientes()
        {
            listaClientes.Clear();
            listaClientes = clienteInstance.LeerClientes();
            dataClientes.ItemsSource = null;
            dataClientes.ItemsSource = listaClientes;
        }


        #endregion


        #region TICKET Y VENTAS
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
            string name = cuentaCliente.cliente.cnombre;
            string email = cuentaCliente.cliente.email;

            Ticket ticket = new Ticket(sb.ToString(), cuentaCliente.Total, name, email, idCliente);
            ticket.InsertarTicket(ticket);

            // Actualizo las cantidades de los productos en la base de datos
            foreach (var producto in cuentaCliente.productos)
            {
                producto.cantidad -= 1; 
                producto.ModificarProducto(producto);
            }

            txtSaldo.Text = "";

            cuentaCliente.cliente.ModificarCliente(cuentaCliente.cliente);

            RefreshDataClientes();

            EstablecesCantidadProductos();

            MessageBox.Show("Ticket generado correctamente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        
        private double CalcularGananciasTotales()
        {
            Ticket ticket = new Ticket();
            List<Ticket> listaTickets = ticket.LeerTickets();
            double totalGanancias = listaTickets.Sum(t => t.importe);
            return totalGanancias;
        }
        #endregion


        private void btnRefrescar_Click(object sender, RoutedEventArgs e)
        {
            double ganancias = CalcularGananciasTotales();
            txtGanancias.Text = $"{ganancias:C}";
            listaTickets.Clear();
            listaTickets = ticket.LeerTickets();
            dataVentas.ItemsSource = null;
            dataVentas.ItemsSource = listaTickets;
        }

        // Método para poner la ventana en pantalla completa al presionar F11
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.F11) // Si presiono F11
            {
                if (this.WindowState != WindowState.Maximized)
                {
                    // Pongo en pantalla completa
                    this.WindowState = WindowState.Maximized;
                    this.WindowStyle = WindowStyle.None; // Quito el estilo de window por lo que desaparecen los bordes y la barra de título
                    this.Topmost = true; // La ventana estará siempre por encima de otras

                    // Ocultola ventana en la barra de tareas
                    this.ShowInTaskbar = false;
                }
                else
                {
                    // Volvemos al tamaño normal
                    this.WindowState = WindowState.Normal;
                    this.WindowStyle = WindowStyle.SingleBorderWindow; // Restauro el estilo de window
                    this.Topmost = false; // La ventana ya no estará por encima de otras

                    // Muestro otra vez la barra de tareas
                    this.ShowInTaskbar = true;
                }
            }
        }

        private void EstablecesCantidadProductos()
        {
            tNuggets.Text = listaProductos[0].cantidad.ToString();
            tPescado.Text = listaProductos[1].cantidad.ToString();
            tEsalada.Text = listaProductos[2].cantidad.ToString();
            tPatatas.Text = listaProductos[3].cantidad.ToString();
            tIbericos.Text = listaProductos[4].cantidad.ToString();
            tTartaQueso.Text = listaProductos[5].cantidad.ToString();
            tFlan.Text = listaProductos[6].cantidad.ToString();
            tNatillas.Text = listaProductos[7].cantidad.ToString();
            tGofres.Text = listaProductos[8].cantidad.ToString();
            tHelado.Text = listaProductos[9].cantidad.ToString();
            tRefresco.Text = listaProductos[10].cantidad.ToString();
            tCerveza.Text = listaProductos[11].cantidad.ToString();
            tVino.Text = listaProductos[12].cantidad.ToString();
            tCombinado.Text = listaProductos[13].cantidad.ToString();
            tAgua.Text = listaProductos[14].cantidad.ToString();
        } 
    }
}
