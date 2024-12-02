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

        public Login()
        {
            InitializeComponent();
            UsuarioManage usuarioManage = new UsuarioManage();
            listaUsuarios = usuarioManage.LeerUsuarios();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                if (listaUsuarios[i].nombre == txtUsername.Text && listaUsuarios[i].password == txtPassword.Password)
                {
                    MessageBox.Show("Usuario correcto!" , "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
        }
    }
}
