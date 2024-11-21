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
    internal class Proyectos
    {
        public int Id { get; set; }
        public string Codigopy { get; set; }
        public string Nombre { get; set; }
        public string Descproy { get; set; }
        public float Presupuesto { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        private static Random random = new Random();
        private List<Proyectos> listaProyectos { get; set; }

        private ProyectoManage pm;

        public Proyectos()
        {
            listaProyectos = new List<Proyectos>();
        }

        public Proyectos(string codigopy, string nombre, string fechainicio, string fechafin)
        {
            Codigopy = codigopy;
            Nombre = nombre;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
            listaProyectos = new List<Proyectos>();
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
        }

        public List<Proyectos> LeerProyectos()
        {

            Proyectos proyecto = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM mydb.proyecto");

            foreach (List<Object> c in aux)
            {
                proyecto = new Proyectos(int.Parse(c[0].ToString()), c[1].ToString(), c[2].ToString(), c[3].ToString(),
                   float.Parse(c[4].ToString()), c[5].ToString(), c[6].ToString());
                this.listaProyectos.Add(proyecto);
            }

            return listaProyectos;

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

        private static int GeneraRandom(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public void GenerarProyectos() {
            Proyectos proyecto = null;
            ProyectoManage pm = new ProyectoManage();

            string[] listaEmpresas = {"allegro","velneo","SAP","naturgy","santander","mutuaMadrileña"}; //0-5
            for (int i = 0; i < 20; i++) 
            {
                string empresaRandom = listaEmpresas[GeneraRandom(0, 5)];
                string anioDigitos = DateTime.Now.Year.ToString().Substring(2,2);
                proyecto = new Proyectos("MTR"+i+empresaRandom+anioDigitos, empresaRandom,DateTime.Now.AddDays(GeneraRandom(1,25)).AddMonths(GeneraRandom(1, 8)).ToString(), DateTime.Now.AddDays(GeneraRandom(1,20)).AddMonths(GeneraRandom(1, 5)).ToString());
                proyecto.AñadirProyecto(proyecto);
                pm.InsertarProyecto(proyecto);
            }
        }

        public void ModificarProyecto(Proyectos proyecto)
        {
            var proyectoExistente = listaProyectos.Find(p => p.Id == proyecto.Id);
            if (proyectoExistente != null)
            {
                proyectoExistente.Codigopy = proyecto.Codigopy;
                proyectoExistente.Nombre = proyecto.Nombre;
                proyectoExistente.FechaInicio = proyecto.FechaInicio;
                proyectoExistente.FechaFin = proyecto.FechaFin;
            }
            pm.ModificarProyecto(proyectoExistente);

        }


    }
}
