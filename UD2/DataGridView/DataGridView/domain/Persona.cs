using DataGridView.persistence;
using System.Collections.Generic;

namespace DataGridView
{
    public class Persona
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }

        private PersonasManage pm { get; set; }
        private List<Persona> listaPersonas { get; set; }

        public Persona(int id, string nombre, string apellidos, int edad)
        {
            pm = new PersonasManage();
            this.id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
        }

        public List<Persona> GetPersonas()
        {
            listaPersonas = pm.LeerPersonas();
            return listaPersonas;
        }

        public void InsertarPersona(Persona persona)
        {
            pm.InsertarPersona(persona);
        }

        public void ModificarPersona(Persona persona)
        {
            pm.ModificarPersona(persona);
        }

        public void EliminarPersona(Persona persona)
        {
            pm.EliminarPersona(persona);
        }

        public int LastId()
        {
            return pm.LastId();
        }
    }
}
