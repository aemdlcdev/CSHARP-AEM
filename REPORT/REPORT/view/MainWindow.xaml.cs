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
        private static  Random random = new Random();
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
            for (int i = 0; i < 100; i++)
            {
                DataRow row = tabla1.NewRow();
                row["Name"] = "Alejandro";
                row["Age"] = random.Next(20, 50);
                row["Adress"] = "Calle falsa 123";
                row["Phone"] = "123456789";

                tabla1.Rows.Add(row);
            }

            // Verificar que la tabla tiene datos
            if (tabla1.Rows.Count > 0)
            {
                // Crear una instancia de crystal report
                CrystalReport1 reporte = new CrystalReport1();

                // Asignar la tabla al reporte
                reporte.Database.Tables["DataTable1"].SetDataSource((DataTable)tabla1);

                // Asignar el reporte al visor de reportes
                visor.ViewerCore.ReportSource = reporte;
            }
            else
            {
                MessageBox.Show("La tabla no tiene datos.");
            }
        }
    }
}
