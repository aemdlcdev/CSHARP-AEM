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
        public MainWindow()
        {
            InitializeComponent();

            // Crear el dataset
            DataSet ds = new DataSet();

            // Crear la tabla

            DataTable dt = new DataTable("Tabla");
            ds.Tables.Add(dt);

            // Definir columnas de la tabla
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Edad", typeof(int));
            dt.Columns.Add("Sexo", typeof(string));
            dt.Columns.Add("Pais", typeof(string));

            // Crear filas

            DataRow dr = dt.NewRow();
            dr["Nombre"] = "Juan";
            dr["Edad"] = 25;
            dr["Sexo"] = "Masculino";
            dr["Pais"] = "México";
            dt.Rows.Add(dr);


            
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["Nombre"] + " " + row["Edad"] + " " + row["Sexo"] + " " + row["Pais"]);
            }

        }
    }
}
