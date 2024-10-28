using DataGridView;
using System.Collections.ObjectModel;
using System.Windows;

namespace DataGridView
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Persona> Personas { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Personas = new ObservableCollection<Persona>();
            dataGridPersonas.ItemsSource = Personas;
        }

       

        private void txtNombre_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void txtApellidos_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void txtEdad_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
