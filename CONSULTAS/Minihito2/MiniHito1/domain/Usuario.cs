using MiniHito1.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHito1.domain
{
    internal class Usuario
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }

        private UsuarioManage usuarioManage { get; set; } = new UsuarioManage();

        public Usuario(int idUsuario, string nombre, string password)
        {
            this.idUsuario = idUsuario;
            this.nombre = nombre;
            this.password = password;
        }

        public Usuario(string nombre, string password)
        {
            this.nombre = nombre;
            this.password = password;
        }

        public Usuario() { }

        public List<Usuario> LeerUsuarios()
        {
            return usuarioManage.LeerUsuarios();
        }

        public void InsertarUsuario(Usuario usuario)
        {
            usuarioManage.InsertarUsuario(usuario);
        }

        public void ModificarUsuario(Usuario usuario)
        {
            usuarioManage.ModificarUsuario(usuario);
        }

        public void EliminarUsuairo(Usuario usuario) 
        {
            usuarioManage.EliminarUsuario(usuario);
        }

        public int getIdByName(string nombre)
        {
            return usuarioManage.GetIdByName(nombre);
        }

    }
}
