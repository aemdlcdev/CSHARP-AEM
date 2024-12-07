using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPV.persistence;
using TPV.persistence.manages;

namespace TPV.domain
{
    internal class Ticket
    {
        public int idTicket { get; set; }
        public string cosumiciones { get; set; }
        public double importe { get; set; }
        public int codCliente { get; set; }

        private TicketsManage ticketsManage;

        public Ticket(int idTicket, string cosumiciones, double importe)
        {
            this.idTicket = idTicket;
            this.cosumiciones = cosumiciones;
            this.importe = importe;
        }

        public Ticket(string cosumiciones, double total, int codCliente)
        {
            this.cosumiciones = cosumiciones;
            this.importe = total;
            this.codCliente = codCliente;
        }

        public Ticket()
        {
        }

        public void InsertarTicket(Ticket ticket)
        {
            ticketsManage = new TicketsManage();
            ticketsManage.InsertarTicket(ticket);
        }
    }
}
