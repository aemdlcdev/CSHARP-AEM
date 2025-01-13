using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataGridView.persistence
{
    internal class PersonasManage
    {
        private List<Persona> listaPersonas { get; set; }

        private string jsonPath; // Path del JSON

        public PersonasManage()
        {
            listaPersonas = new List<Persona>();
            jsonPath = "example.json"; 
        }


        // TODOS LOS ATRIBUTOS DE LA CLASE SE TIENEN QUE LLAMAR IGUAL QUE EN EL JSON!!!!

        public List<Persona> LeerPersonas()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(jsonPath) || !File.Exists(jsonPath))
                {
                    throw new ArgumentException("Hay un error en la ruta o el archivo no existe.");
                }

                // Leo el contenido del JSON
                string jsonContent = File.ReadAllText(jsonPath);

                // Deserializo el JSON
                var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonContent);
                listaPersonas = rootObject.people;

                // Asignar la lista de personas ordenadas por ID con LINQ
                listaPersonas = listaPersonas.OrderBy(p => p.id).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deserializar el JSON: {ex.Message}");
            }

            return listaPersonas;
        }

        public void InsertarPersona(Persona persona)
        {
            listaPersonas.Add(persona);
            GuardarPersonas();
        }

        public void ModificarPersona(Persona persona)
        {
            var personaExistente = listaPersonas.Find(p => p.id == persona.id);
            if (personaExistente != null)
            {
                personaExistente.Nombre = persona.Nombre;
                personaExistente.Apellidos = persona.Apellidos;
                personaExistente.Edad = persona.Edad;
                GuardarPersonas();
            }
        }

        public void EliminarPersona(Persona persona)
        {
            listaPersonas.RemoveAll(p => p.id == persona.id);
            GuardarPersonas();
        }

        public int LastId()
        {
            return listaPersonas.Any() ? listaPersonas.Max(p => p.id) : 0;
        }

        private void GuardarPersonas()
        {
            var rootObject = new RootObject { people = listaPersonas };
            string jsonContent = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText(jsonPath, jsonContent);
        }
    }
    public class RootObject
    {
        public List<Persona> people { get; set; } // Se tiene que llamar igual que en mi JSON
    }
}
