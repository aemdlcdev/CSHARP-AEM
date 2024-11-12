using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MiniHito1.domain
{
    internal class Proyectos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        private List<Proyectos> proyectos { get; set; }

        public Proyectos()
        {
            proyectos = new List<Proyectos>();
        }

        public Proyectos(int id, string nombre, string fechaInicio, string fechaFin)
        {
            Id = id;
            Nombre = nombre;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            proyectos = new List<Proyectos>();
        }

        public List<Proyectos> GetProyectos()
        {
            return proyectos;
        }

        public void AñadirProyecto(Proyectos proyecto)
        {
            var proyectoExistente = proyectos.Exists(p => p.Id == proyecto.Id);
            if (proyectoExistente)
            {
                MessageBox.Show("Ya existe un proyecto con ese ID!", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                proyectos.Add(proyecto);
            }
        }

        public List<Proyectos> BuscarProyectosPorNombre(string nombre)
        {
            var proyectosEncontrados = proyectos.Exists(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (proyectosEncontrados)
            {
                return proyectos.Where(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            else
            {
                MessageBox.Show("No se encontraron proyectos con ese nombre!", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return proyectos;
            }
        }
    }
}
