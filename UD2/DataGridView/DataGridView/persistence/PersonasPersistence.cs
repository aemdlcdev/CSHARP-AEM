using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataGridView.persistence
{
    internal class PersonasPersistence
    {
        private DataTable dataTable { get; set; }

        public PersonasPersistence()
        {
            dataTable = new DataTable();
           
        }

        // SIMULACION DE LECTURA BASE DE DATOS

        public static List<Persona> LeerPersonas() 
        { 
            List<Persona> personas = new List<Persona>();

            personas.Add(new Persona("Alejandro", "Esteban", 20));
            personas.Add(new Persona("Pablo", "Velasco", 19));
            personas.Add(new Persona("Javier", "García", 21));
            personas.Add(new Persona("Marta", "González", 22));
            personas.Add(new Persona("Lucía", "Martínez", 23));
            personas.Add(new Persona("Sara", "Gómez", 24));

            return personas;

        }
        
    }
}
