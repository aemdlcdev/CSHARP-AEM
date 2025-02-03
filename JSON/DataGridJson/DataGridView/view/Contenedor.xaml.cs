using DataGridView.persistence;
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
using System.Windows.Shapes;

namespace DataGridView.view
{
    /// <summary>
    /// Lógica de interacción para Contenedor.xaml
    /// </summary>
    public partial class Contenedor : Window
    {
        DataTable dt;
        public Contenedor()
        {
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellidos");
            dt.Columns.Add("Edad");

            foreach(Persona p in MainWindow.listaPersonas)
            {
                DataRow row = dt.NewRow();
                row["Nombre"] = p.Nombre;
                row["Apellidos"] = p.Apellidos;
                row["Edad"] = p.Edad;
                dt.Rows.Add(row);
            }

            CrystalReport1 report = new CrystalReport1();
            report.Database.Tables["DataTable1"].SetDataSource(dt);
            visor.ViewerCore.ReportSource = report;

        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
