using DataGridView.persistence;
using MiniHito1.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace MiniHito1.persistence.manages
{
    internal class ProyectoManage
    {
        private DataTable dataTable { get; set; }
        private List<Proyectos> listaProyectos { get; set; }
        private static Random random = new Random();
        private DBBroker dbBroker = DBBroker.obtenerAgente();
        public ProyectoManage()
        {
            dataTable = new DataTable();
            listaProyectos = new List<Proyectos>();

        }


        public List<Proyectos> FiltrarPorNombreYFechas(string nombreProyecto, string fechaInicio, string fechaFin)
        {

            Proyectos proyecto = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM mydb.proyecto WHERE ");

            foreach (List<Object> c in aux)
            {
                proyecto = new Proyectos(int.Parse(c[0].ToString()), c[1].ToString(), c[2].ToString(), c[3].ToString(),
                   float.Parse(c[4].ToString()), c[5].ToString(), c[6].ToString());

                this.listaProyectos.Add(proyecto);
            }

            return listaProyectos;


        }

        public void GenerarProyectos() {
            Proyectos proyecto = null;
            ProyectoManage pm = new ProyectoManage();

            string[] listaEmpresas = { "allegro", "velneo", "SAP", "naturgy", "santander", "mutuaMadrileña" }; //0-5
            for (int i = 0; i < 20; i++)
            {
                string empresaRandom = listaEmpresas[GeneraRandom(0, 5)];
                string anioDigitos = DateTime.Now.Year.ToString().Substring(2, 2);
                proyecto = new Proyectos("MTR" + i + empresaRandom + anioDigitos, empresaRandom, DateTime.Now.AddDays(GeneraRandom(1, 25)).AddMonths(GeneraRandom(1, 8)).ToString(), DateTime.Now.AddDays(GeneraRandom(1, 20)).AddMonths(GeneraRandom(1, 5)).ToString());
                proyecto.AñadirProyecto(proyecto);
                pm.InsertarProyecto(proyecto);
            }
        }

        private static int GeneraRandom(int min, int max)
        {
            return random.Next(min, max + 1);
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

        public void InsertarProyecto(Proyectos proyecto)
        {
            string sql = $"INSERT INTO mydb.proyecto ( codigopy, nombreproy, descproy,presupuesto,fec_inicio,fec_fin) " +
                $"VALUES ('{proyecto.Codigopy}', '{proyecto.Nombre}', '{proyecto.Descproy}', '{proyecto.Presupuesto}', '{proyecto.FechaInicio}','{proyecto.FechaFin}')";
            dbBroker.modificar(sql);
            listaProyectos.Add(proyecto);
        }

        public void ModificarProyecto(Proyectos proyecto)
        {
            string sql = $"UPDATE mydb.proyecto SET codigopy = '{proyecto.Codigopy}', nombreproy = '{proyecto.Nombre}',  fec_inicio = '{proyecto.FechaInicio}', fec_fin = '{proyecto.FechaFin}' WHERE codigopy = '{proyecto.Codigopy}'";
            dbBroker.modificar(sql);

            var proyectoExistente = listaProyectos.Find(p => p.Codigopy == proyecto.Codigopy);
            if (proyectoExistente != null)
            {
                proyectoExistente.Codigopy = proyecto.Codigopy;
                proyectoExistente.Nombre = proyecto.Nombre;
                proyectoExistente.FechaInicio = proyecto.FechaInicio;
                proyectoExistente.FechaFin = proyecto.FechaFin;
            }
        }

        public void EliminarProyecto(Proyectos proyecto)
        {
            string sql = $"DELETE FROM mydb.proyecto WHERE idproyecto = {proyecto.Id}";
            dbBroker.modificar(sql);
            listaProyectos.RemoveAll(p => p.Id == proyecto.Id);
        }

    }
}
