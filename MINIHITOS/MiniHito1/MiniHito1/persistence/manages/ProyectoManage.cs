using DataGridView.persistence;
using MiniHito1.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito1.persistence.manages
{
    internal class ProyectoManage
    {
        private DataTable dataTable { get; set; }
        private List<Proyectos> listaProyectos { get; set; }

        private DBBroker dbBroker = DBBroker.obtenerAgente();
        public ProyectoManage()
        {
            dataTable = new DataTable();
            listaProyectos = new List<Proyectos>();

        }

        public List<Proyectos> LeerProyectos()
        {

            Proyectos proyecto = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM mydb.proyectsso");

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
            string sql = $"UPDATE mydb.proyecto SET codigopy = '{proyecto.Codigopy}', nombreproy = '{proyecto.Nombre}',  fec_inicio = '{proyecto.FechaInicio}', fec_fin = '{proyecto.FechaFin}' WHERE idpersona = {proyecto.Id}";
            dbBroker.modificar(sql);

            var proyectoExistente = listaProyectos.Find(p => p.Id == proyecto.Id);
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
