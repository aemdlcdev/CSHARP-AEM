using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito1.domain
{
    internal class Empleado : Usuario
    {

        int idEmpleado { get; set; }
        string nombre { get; set; }
        string apellidos { get; set; }
        double crs { get; set; }
        int idUsuario { get; set; }
        int idRol { get; set; }
    }
}
