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
        public string name { get; set; }
        public string email { get; set; }
        public int codCliente { get; set; }

        private TicketsManage ticketsManage;

        public Ticket(int idTicket, string cosumiciones, double importe, int codCliente)
        {
            this.idTicket = idTicket;
            this.cosumiciones = cosumiciones;
            this.importe = importe;

            this.codCliente = codCliente;
            
        }

        public Ticket(int idTicket, string cosumiciones, double importe, string name, string email, int codCliente)
        {
            this.idTicket = idTicket;
            this.cosumiciones = cosumiciones;
            this.importe = importe;
            this.name = name;
            this.email = email;
            this.codCliente = codCliente;

        }

        public Ticket(string cosumiciones, double importe, string name, string email, int codCliente)
        {
            this.idTicket = idTicket;
            this.cosumiciones = cosumiciones;
            this.importe = importe;
            this.name = name;
            this.email = email;
            this.codCliente = codCliente;

        }

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

        public List<Ticket> LeerTickets()
        { 
            ticketsManage = new TicketsManage();
            return ticketsManage.LeerTickets();
        }

        public void InsertarTicket(Ticket ticket)
        {
            ticketsManage = new TicketsManage();
            ticketsManage.InsertarTicket(ticket);
        }
    }
}
