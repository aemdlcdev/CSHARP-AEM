using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPV.domain
{
    internal class Usuario
    {
        private int idUsuario { get; set; } 
        public String nombre { get; set; }
        public String password { get; set; }

        private int idRol { get; set; }

        public Usuario(int idUsuario, String nombre, String password, int idRol)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.password = password;
            this.idRol = idRol;
        }

    }
}
