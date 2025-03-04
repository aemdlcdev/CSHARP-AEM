using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniHito1.persistence.manages;

namespace MiniHito1.domain
{
    internal class ProyectoEmpleado
    {
        public int idProyecto { get; set; }
        public int idEmpleado { get; set; }
        public string fecha { get; set; }
        public float costes { get; set; }
        public int horas { get; set; }

        private ProyectoEmpleadoManage pem;

        public ProyectoEmpleado()
        {
            pem = new ProyectoEmpleadoManage();
        }

        public ProyectoEmpleado(int idProyecto, int idEmpleado, string fecha, float costes, int horas)
        {
            this.idProyecto = idProyecto;
            this.idEmpleado = idEmpleado;
            this.fecha = fecha;
            this.costes = costes;
            this.horas = horas;

            this.pem = new ProyectoEmpleadoManage();

        }

        public List<ProyectoEmpleado> LeerProyectoEmpleado()
        {
            return pem.LeerProyectoEmpleado();
        }

        public void InsertarProyectoEmpleado(ProyectoEmpleado pe)
        {
            pem.InsertarProyectoEmpleado(pe);

        }
    }
}
