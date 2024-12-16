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
            // Encriptar la contraseña ingresada por el usuario desde el PasswordBox
            string contraseñaEncriptada = Seguridad.EncriptarContraseña(txtPassword.Password);

            // Si necesitas crear el admin, puedes dejar la siguiente línea solo una vez. Luego, quitala o comentala.
            // Seguridad.GetPassword("admin"); // Solo para crear el admin en la base de datos

            // Busco el usuario con la contraseña encriptada
            var usuarioEncontrado = listaUsuarios.FirstOrDefault(u => u.nombre == txtUsername.Text && u.password == contraseñaEncriptada);

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

        private void chkMostrarPassword_Checked(object sender, RoutedEventArgs e)
        {
            if (chkMostrarPassword.IsChecked == true)
            {
                // Muestro el texto de la contraseña en el TextBox
                txtPasswordVisible.Text = txtPassword.Password;
                txtPasswordVisible.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Resto de la contraseña al PasswordBox
                txtPassword.Password = txtPasswordVisible.Text;
                txtPasswordVisible.Visibility = Visibility.Collapsed;
                txtPassword.Visibility = Visibility.Visible;
            }
        }


    }
}
