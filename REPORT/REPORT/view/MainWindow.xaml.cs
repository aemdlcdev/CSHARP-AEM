using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace REPORT
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable tabla1;
        public MainWindow()
        {
            InitializeComponent();

            // Crear una tabla a partir de un DataTable que ya tenemos
            tabla1 = new DataTable("DataTable1");
            // Crear las columnas con los mismo nombres de campos del detatable creado en el crystal report
            tabla1.Columns.Add("Name");
            tabla1.Columns.Add("Age");
            tabla1.Columns.Add("Adress");
            tabla1.Columns.Add("Phone");

            // Añadimos 100 registros para probar
            



        }
    }
}
