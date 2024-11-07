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
        private List<Persona> personas { get; set; }

        public Persona()
        {
            pm = new PersonasManage();
        }

        public Persona(int id)
        {
            this.id = id;
        }

        public Persona(string nombre, string apellidos, int edad)
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Edad = edad;
        }

        public List<Persona> GetPersonas()
        {
            personas = pm.LeerPersonas();
            return personas;
        }
    }
}
