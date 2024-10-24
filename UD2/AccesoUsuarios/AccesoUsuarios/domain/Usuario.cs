using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoUsuarios
{
    internal class Usuario
    {
        public String Nombre { get; set; }
        public String Contrasena { get; set; }

        public Usuario(String nombre, String contrasena)
        {
            Nombre = nombre;
            Contrasena = contrasena;
        }

        public override string ToString()
        {
            return Nombre + " " +Contrasena;
        }

    }
}
