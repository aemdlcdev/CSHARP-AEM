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
        private ListById _listById;
        private AddObject _addObject;

        public MainWindow()
        {
            InitializeComponent();
            _apiObject = new ApiObject();
            _listById = new ListById(this);
            _addObject = new AddObject(this);
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            _apiObject.cargarDatos(this);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _addObject.Show();
        }

        private void btnCargarId_Click(object sender, RoutedEventArgs e)
        {
            _listById.Show();
        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            _apiObject.deleteById(this);
        }
    }
}

