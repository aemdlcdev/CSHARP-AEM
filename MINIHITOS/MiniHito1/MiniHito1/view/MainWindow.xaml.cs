using MiniHito1.domain;
using MiniHito1.persistence.manages;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MiniHito1
{
    public partial class MainWindow : Window
    {
        private Proyectos proyecto;
        private List<Proyectos> listaProyectos;
        private ProyectoManage proyectosManage;
        public MainWindow()
        {
            
            InitializeComponent();
            proyectosManage = new ProyectoManage();
            proyecto = new Proyectos();
            dataGridView1.ItemsSource = proyecto.GetProyectos();
        }


        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            
            string nombreProyecto = txtBuscar.Text;

            // Buscar proyectos por nombre
            var proyectosEncontrados = proyecto.BuscarProyectosPorNombre(nombreProyecto);

            // Actualizar el DataGridView con los proyectos encontrados
            dataGridView1.ItemsSource = null;
            dataGridView1.ItemsSource = proyectosEncontrados;
        }

        private void addProyecto_Click(object sender, RoutedEventArgs e)
        {
            string codigoproyec = txtId.Text;
            string nombre = txtNombre.Text;
            string fechaInicio = txtFechaInicio.Text;
            string fechaFin = txtFechaFin.Text;
            Proyectos nuevoProyecto = new Proyectos(codigoproyec, nombre, fechaInicio, fechaFin);

            proyecto.AñadirProyecto(nuevoProyecto);
            proyectosManage.InsertarProyecto(nuevoProyecto);
            listaProyectos.Clear();
            // Actualizar el DataGridView
            dataGridView1.ItemsSource = null;
            dataGridView1.ItemsSource = proyecto.LeerProyectos();
        }

        private void btnProyectoss_Click(object sender, RoutedEventArgs e)
        {
            tabMenu.SelectedItem = tabProyectos;
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            proyecto = new Proyectos();
            proyecto.GenerarProyectos();
            listaProyectos = proyecto.LeerProyectos();
            dataGridView1.ItemsSource = null;
            dataGridView1.ItemsSource = listaProyectos;
            
        }

    }
}
