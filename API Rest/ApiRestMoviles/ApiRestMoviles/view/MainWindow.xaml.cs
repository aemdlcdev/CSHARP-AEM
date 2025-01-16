using ApiRestMoviles.domain;
using System.Windows;

namespace ApiRestMoviles
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApiObject _apiObject;

        public MainWindow()
        {
            InitializeComponent();
            _apiObject = new ApiObject();
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            _apiObject.cargarDatos(this);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddObject addObjectWindow = new AddObject(this);
            addObjectWindow.Show();
        }

        private void btnCargarId_Click(object sender, RoutedEventArgs e)
        {
            ListById listByIdWindow = new ListById(this);
            listByIdWindow.Show();
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            _apiObject.deleteById(this);
        }
    }
}
