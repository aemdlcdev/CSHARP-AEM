using ExamenFinal.domain;
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

namespace ExamenFinal.view.pages
{
    /// <summary>
    /// Lógica de interacción para Informes.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class Informes : Page
    {
        /// <summary>
        /// The dt
        /// </summary>
        DataTable dt;
        /// <summary>
        /// The operaciones libro
        /// </summary>
        private Libro operacionesLibro;
        /// <summary>
        /// The operaciones genero
        /// </summary>
        private Genero operacionesGenero;
        /// <summary>
        /// The libros
        /// </summary>
        private List<Libro> libros;
        /// <summary>
        /// The generos
        /// </summary>
        private List<Genero> generos;
        /// <summary>
        /// Initializes a new instance of the <see cref="Informes"/> class.
        /// </summary>
        public Informes()
        {
            InitializeComponent();

            operacionesGenero = new Genero();
            operacionesLibro = new Libro();
            libros = operacionesLibro.LeerLibros();
            generos = operacionesGenero.LeerGeneros();

            


        }

        /// <summary>
        /// Cargars the informe.
        /// </summary>
        private void cargarInforme() 
        {
            dt = new DataTable();
            dt.Columns.Add("Titulo");
            dt.Columns.Add("Autor");
            dt.Columns.Add("Genero");

            DataRow row = dt.NewRow();

            foreach (Libro libro in libros)
            {

                row["Titulo"] = libro.titulo;
                row["Autor"] = libro.autor;

            }

            foreach (Genero operacion in generos)
            {
                row["Genero"] = operacion.nombreGenero;
            }

            dt.Rows.Add(row);

            CrystalReport1 report = new CrystalReport1();
            report.Database.Tables["DataTable1"].SetDataSource(dt);
            visor.ViewerCore.ReportSource = report;
        }

        /// <summary>
        /// Handles the Click event of the btnCargar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            cargarInforme();
        }
    }
}
