using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal.domain
{
    internal class Prestamo
    {
        int idSocio {  get; set; }
        int idLibro { get; set; }
        string fecPrestamo { get; set; }
        string fecDevolucion { get; set; }

    }
}
