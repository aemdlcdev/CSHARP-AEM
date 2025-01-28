using DataGridView.persistence;
using MiniHito1.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito1.persistence.manages
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

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM mydb.usuario");

            foreach (List<Object> c in aux)
            {
                usuario = new Usuario(int.Parse(c[0].ToString()), c[1].ToString(), c[2].ToString());

                this.listaUsuarios.Add(usuario);
            }

            return listaUsuarios;

        }

        public void InsertarUsuario(Usuario usuario)
        {
            string sql = $"INSERT INTO mydb.usuario ( nombreusuario, passusuario) " +
                $"VALUES ('{usuario.nombre}', '{usuario.password}')";
            dbBroker.modificar(sql);
            listaUsuarios.Add(usuario);
        }

        public void ModificarUsuario(Usuario usuario)
        {
            string sql = $"UPDATE mydb.usuario SET nombreusuario = '{usuario.nombre}', passusuario = '{usuario.password}' WHERE idusuario = '{usuario.idUsuario}'";
            dbBroker.modificar(sql);

            var usuarioExistente = listaUsuarios.Find(u => u.idUsuario == u.idUsuario);
            if (usuarioExistente != null)
            {
                usuarioExistente.nombre = usuario.nombre;
                usuarioExistente.password = usuario.password;
            }
        }

        public void EliminarUsuario(Usuario usuario)
        {
            string sql = $"DELETE FROM mydb.usuario WHERE idusuario = {usuario.idUsuario}";
            dbBroker.modificar(sql);
            listaUsuarios.RemoveAll(p => p.idUsuario == usuario.idUsuario);
        }

        public int GetIdByName(string nombre)
        {
            Usuario usuario = null;
            List<Usuario> auxu = new List<Usuario>();
            List<Object> aux = DBBroker.obtenerAgente().leer($"SELECT * FROM mydb.usuario WHERE nombreusuario = '{nombre}'");

            foreach (List<Object> c in aux)
            {
                usuario = new Usuario(int.Parse(c[0].ToString()), c[1].ToString(), c[2].ToString());

                auxu.Add(usuario);
            }
            
            return auxu.FirstOrDefault().idUsuario;

        }
    }
}
