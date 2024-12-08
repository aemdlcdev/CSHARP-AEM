using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPV.domain;

namespace TPV.persistence.manages
{
    internal class UsuarioManage
    {
        private DataTable dataTable { get; set; }
        private List<Usuario> listaUsuarios { get; set; }

        private DBBroker dbBroker = DBBroker.obtenerAgente();

        public UsuarioManage()
        {
            dataTable = new DataTable();
            listaUsuarios = new List<Usuario>();
        }

        public List<Usuario> LeerUsuarios()
        {

            Usuario usuario = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM tpv.usuario");

            foreach (List<Object> c in aux)
            {
                usuario = new Usuario(int.Parse(c[0].ToString()), c[1].ToString(), c[2].ToString(), int.Parse(c[3].ToString()));

                this.listaUsuarios.Add(usuario);
            }
            return listaUsuarios;
        }

        public List<Usuario> LeerUsuariosGestion()
        {

            Usuario usuario = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM tpv.usuario WHERE idrol = 2");

            foreach (List<Object> c in aux)
            {
                usuario = new Usuario(int.Parse(c[0].ToString()), c[1].ToString(), c[2].ToString(), int.Parse(c[3].ToString()));

                this.listaUsuarios.Add(usuario);
            }
            return listaUsuarios;
        }

        public void InsertarUsuario(Usuario usuario)
        {
            dbBroker.modificar("INSERT INTO tpv.usuario (nusuario, password, idrol) VALUES ('" + usuario.nombre + "', '" + usuario.password + "', " + usuario.idRol + ")");
        }

        public void ModificarUsuario(Usuario usuario)
        {
            dbBroker.modificar("UPDATE tpv.usuario SET nusuario = '" + usuario.nombre + "', password = '" + usuario.password + "'  WHERE idusuario = " + usuario.idUsuario);
        }

        public void EliminarUsuario(Usuario usuario)
        {
            dbBroker.modificar("DELETE FROM tpv.usuario WHERE idusuario = " + usuario.idUsuario);

        }
    }
}
