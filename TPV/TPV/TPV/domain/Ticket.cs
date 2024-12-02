using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPV.domain
{
    internal class Ticket
    {
        public int idTicket { get; set; }
        public string cosumiciones { get; set; }
        public double importe { get; set; }

        public Ticket(int idTicket, string cosumiciones, double importe)
        {
            this.idTicket = idTicket;
            this.cosumiciones = cosumiciones;
            this.importe = importe;
        }

    }
}
