using ExamenFinal.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal.domain
{
    
    internal class Socio
    {
        public int idSocio { get; set; }
        public string nombreSocio { get; set; }
        public string fec_nacimiento { get; set; }
        public string email {  get; set; }
        public int tlfno { get; set; }

        SocioManage sm;

        public Socio() 
        {
            sm = new SocioManage();
        }

        public Socio (int idSocio, string nombreSocio, string fec_nacimiento, string email, int tlfno)
        {
            this.idSocio = idSocio;
            this.nombreSocio = nombreSocio;
            this.fec_nacimiento = fec_nacimiento;
            this.email = email;
            this.tlfno = tlfno;
            sm = new SocioManage();
        }

        public Socio (string nombreSocio, string fec_nacimiento, string email, int tlfno)
        {
            this.nombreSocio=nombreSocio;
            this.fec_nacimiento=fec_nacimiento;
            this.email = email;
            this.tlfno = tlfno;
            sm = new SocioManage();
        }

        public List<Socio> LeerSocios() 
        {
            return sm.LeerSocios();
        }

        public void InsertarSocio(Socio socio)
        {
            sm.InsertarSocio(socio);
        }

        public void ModificarSocio(Socio socio) 
        {
            sm.ModificarSocio(socio);
        }

        public void EliminarSocio(Socio socio)
        {
            sm.EliminarSocio(socio);
        }

    }
}
