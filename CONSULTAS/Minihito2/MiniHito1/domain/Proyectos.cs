using DataGridView.persistence;
using MiniHito1.persistence.manages;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows;

namespace MiniHito1.domain
{
    public class Proyectos
    {
        public int Id { get; set; }
        public string Codigopy { get; set; }
        public string Nombre { get; set; }
        public string Descproy { get; set; }
        public float Presupuesto { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        private List<Proyectos> listaProyectos { get; set; }

        private ProyectoManage pm;

        public Proyectos()
        {
            listaProyectos = new List<Proyectos>();
            pm = new ProyectoManage();
        }

        public Proyectos(string codigopy, string nombre, string fechainicio, string fechafin)
        {
            Codigopy = codigopy;
            Nombre = nombre;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
            listaProyectos = new List<Proyectos>();
            pm = new ProyectoManage();
        }

        public Proyectos(int id, string codigopy, string nombre, string descr, float presupuesto, string fechainicio, string fechafin)
        {
            Id = id;
            Codigopy = codigopy;
            Nombre = nombre;
            Descproy = descr;
            Presupuesto = presupuesto;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
            listaProyectos = new List<Proyectos>();
            pm = new ProyectoManage();
        }

        public List<Proyectos> LeerProyectos()
        {

           return pm.LeerProyectos();

        }

        public void AñadirProyecto(Proyectos proyecto)
        {
            var proyectoExistente = listaProyectos.Exists(p => p.Id == proyecto.Id);
            if (proyectoExistente)
            {
                MessageBox.Show("Ya existe un proyecto con ese ID!", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                pm.InsertarProyecto(proyecto);
                listaProyectos.Add(proyecto);
            }
        }

        public List<Proyectos> BuscarProyectosPorNombre(string nombre)
        {
            var proyectosEncontrados = listaProyectos.Exists(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (proyectosEncontrados)
            {
                return listaProyectos.Where(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            else
            {
                MessageBox.Show("No se encontraron proyectos con ese nombre!", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return listaProyectos;
            }
        }



        public void GenerarProyectos() {
            pm.GenerarProyectos();
        }

        public void ModificarProyecto(Proyectos proyecto)
        {
            pm = new ProyectoManage();

            pm.ModificarProyecto(proyecto);

        }

        public override string ToString()
        {
            return this.Codigopy;
        }

    }
}
