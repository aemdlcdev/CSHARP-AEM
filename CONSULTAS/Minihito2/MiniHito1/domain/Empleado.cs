using MiniHito1.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MiniHito1.domain
{
    internal class Empleado
    {
        public int idEmpleado { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public float csr { get; set; }
        public int idUsuario { get; set; }
        public int idRol { get; set; }

        private EmpleadoManage em { get; set; } = new EmpleadoManage();

        public Empleado (int idEmpleado, string nombre, string apellidos, float crs, int idUsuario, int idRol) 
        {
            this.idEmpleado = idEmpleado;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.csr = crs;
            this.idUsuario = idUsuario;
            this.idRol = idRol;
        }
        public Empleado(string nombre, string apellidos, float crs, int idUsuario, int idRol)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.csr = crs;
            this.idUsuario = idUsuario;
            this.idRol = idRol;
        }

        public Empleado() { }

        public List<Empleado> LeerEmpleados() 
        {
            return em.LeerEmpleados();
        }

        public void InsertarEmpleado(Empleado empleado)
        {
            em.InsertarEmpleado(empleado);
        }

        public void ModificarEmpleado(Empleado empleado) 
        {
            em.ModificarEmpleado(empleado);
        }

        public void EliminarEmpleado(Empleado empleado)
        {
            em.EliminarEmpleado(empleado);
        }

        override public string ToString()
        {
            return this.nombre + " " + this.apellidos;
        }

    }
}
