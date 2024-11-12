using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataGridView.persistence
{
    internal class PersonasManage
    {
        private DataTable dataTable { get; set; }
        private List<Persona> listaPersonas { get; set; }

        private DBBroker dbBroker = DBBroker.obtenerAgente();
        public PersonasManage()
        {
            dataTable = new DataTable();
            listaPersonas = new List<Persona>();

        }


        public List<Persona> LeerPersonas() 
        {

            Persona persona = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM mydb.persona");

            foreach (List<Object> c in aux) 
            {
                persona = new Persona(int.Parse(c[0].ToString()) ,c[1].ToString(), c[2].ToString(), Convert.ToInt32(c[3]));
                this.listaPersonas.Add(persona);
            }

            return listaPersonas;

        }

        public void InsertarPersona(Persona persona)
        {
            string sql = $"INSERT INTO persona (idpersona, nombre, apellido, edad) VALUES ({persona.id}, '{persona.Nombre}', '{persona.Apellidos}', {persona.Edad})";
            dbBroker.modificar(sql);
            listaPersonas.Add(persona);
        }

        public void ModificarPersona(Persona persona)
        {
            string sql = $"UPDATE mydb.persona SET nombre = '{persona.Nombre}', apellido = '{persona.Apellidos}', edad = {persona.Edad} WHERE idpersona = {persona.id}";
            dbBroker.modificar(sql);

            var personaExistente = listaPersonas.Find(p => p.id == persona.id);
            if (personaExistente != null)
            {
                personaExistente.Nombre = persona.Nombre;
                personaExistente.Apellidos = persona.Apellidos;
                personaExistente.Edad = persona.Edad;
            }
        }

        public void EliminarPersona(Persona persona)
        {
            string sql = $"DELETE FROM persona WHERE idpersona = {persona.id}";
            dbBroker.modificar(sql);
            listaPersonas.RemoveAll(p => p.id == persona.id);
        }

        public int LastId()
        {
            int lastID = 0;
            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT MAX(idpersona) FROM mydb.persona");

            foreach (List<Object> c in aux)
            {
                lastID = int.Parse(c[0].ToString());
            }
            return lastID;
        }
    }
}
