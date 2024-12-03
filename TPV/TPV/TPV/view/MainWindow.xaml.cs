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
        private ClientesManage clientesManage;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            clientesManage = new ClientesManage();
            listaClientes = clientesManage.LeerClientes();
            dataClientes.ItemsSource = listaClientes;
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

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string email = txtCorreo.Text;

            if(String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(email))
            {
                MessageBox.Show("Por favor, rellene todos los campos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Clientes cliente = new Clientes(email, nombre);
            
            clientesManage.InsertarCliente(cliente);

            listaClientes.Clear();
            listaClientes = clientesManage.LeerClientes();
            dataClientes.ItemsSource = null;
            dataClientes.ItemsSource = listaClientes;

        }
    }
}
