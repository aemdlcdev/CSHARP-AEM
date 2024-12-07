using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TPV.domain;
using TPV.persistence.manages;

namespace TPV.view
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private List<Usuario> listaUsuarios;
        private Usuario usuario;
        public Login()
        {
            InitializeComponent();
            usuario = new Usuario();
            listaUsuarios = usuario.LeerUsuarios();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var usuarioEncontrado = listaUsuarios.FirstOrDefault(u => u.nombre == txtUsername.Text && u.password == txtPassword.Password);

            if (usuarioEncontrado != null)
            {
                MessageBox.Show("Usuario correcto!", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                string userType;
                switch (usuarioEncontrado.idRol)
                {
                    case 1:
                        userType = "jefe";
                        break;
                    case 2:
                        userType = "user";
                        break;
                    case 3:
                        userType = "admin";
                        break;
                    default:
                        userType = "user";
                        break;
                }
                MainWindow mainWindow = new MainWindow(userType);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

