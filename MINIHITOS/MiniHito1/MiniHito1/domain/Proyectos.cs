using System;
using System.Collections.Generic;
using System.Linq;

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
            proyectos.Add(proyecto);
        }

        public List<Proyectos> BuscarProyectosPorNombre(string nombre)
        {
            return proyectos.Where(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
