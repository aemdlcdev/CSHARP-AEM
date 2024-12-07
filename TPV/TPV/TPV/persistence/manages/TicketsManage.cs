using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPV.domain;

namespace TPV.persistence.manages
{
    internal class TicketsManage
    {
        private DataTable dataTable { get; set; }
        private List<Ticket> listaTickets { get; set; }

        private DBBroker dbBroker = DBBroker.obtenerAgente();
        private NumberFormatInfo nfi = new NumberFormatInfo();

        public TicketsManage()
        {
            dataTable = new DataTable();
            listaTickets = new List<Ticket>();
            nfi.NumberDecimalSeparator = ".";
        }

        public List<Ticket> LeerTickets()
        {

            Ticket ticket = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM tpv.ticket");

            foreach (List<Object> c in aux)
            {
                ticket = new Ticket(int.Parse(c[0].ToString()), c[1].ToString(), double.Parse(c[2].ToString()));

                this.listaTickets.Add(ticket);
            }
            return listaTickets;
        }

        public void InsertarTicket(Ticket ticket)
        {
            DBBroker.obtenerAgente().modificar("INSERT INTO tpv.ticket (consumiciones, importe, codcliente) VALUES ('" + ticket.cosumiciones + "', " + ticket.importe.ToString(nfi) + ", " + ticket.codCliente + ")");
        }

    }
}
