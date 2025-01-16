using ApiRestMoviles.persistence;
using System.Windows;

namespace ApiRestMoviles
{
    /// <summary>
    /// Lógica de interacción para ListById.xaml
    /// </summary>
    public partial class ListById : Window
    {
        private MainWindow _mainWindow;

        public ListById(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void btnCargarId_Click(object sender, RoutedEventArgs e)
        {
            ApiobjectManage apiObjectManage = new ApiobjectManage();
            apiObjectManage.listByid(_mainWindow, this);
        }
    }
}

