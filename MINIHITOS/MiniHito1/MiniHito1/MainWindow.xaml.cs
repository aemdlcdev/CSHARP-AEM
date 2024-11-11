using MiniHito1.domain;
using System;
using System.Windows;

namespace MiniHito1
{
    public partial class MainWindow : Window
    {
        private Proyectos proyecto;

        public MainWindow()
        {
            InitializeComponent();
            proyecto = new Proyectos();
            dataGridView1.ItemsSource = proyecto.GetProyectos();
        }


        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            // Obtener el nombre del proyecto a buscar (puedes obtener este valor de un control de entrada en tu formulario)
            string nombreProyecto = txtNombre.Text;

            // Buscar proyectos por nombre
            var proyectosEncontrados = proyecto.BuscarProyectosPorNombre(nombreProyecto);

            // Actualizar el DataGridView con los proyectos encontrados
            dataGridView1.ItemsSource = null;
            dataGridView1.ItemsSource = proyectosEncontrados;
        }

        private void addProyecto_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            string fechaInicio = txtFechaInicio.Text;
            string fechaFin = txtFechaFin.Text;

            Proyectos nuevoProyecto = new Proyectos(id, nombre, fechaInicio, fechaFin);

            // Añadir el proyecto a la lista
            proyecto.AñadirProyecto(nuevoProyecto);

            // Actualizar el DataGridView
            dataGridView1.ItemsSource = null;
            dataGridView1.ItemsSource = proyecto.GetProyectos();
        }

        private void btnProyectoss_Click(object sender, RoutedEventArgs e)
        {
            tabMenu.Selected = tabProyectos;
        }
    }
}
