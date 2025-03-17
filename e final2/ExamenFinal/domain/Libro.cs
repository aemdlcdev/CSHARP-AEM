using Examen.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal.domain
{
    internal class Libro
    {
        public int idLibro { get; set; }
        public string titulo { get; set; }
        public string autor {  get; set; }
        public int anioPublicacion { get; set; }

        public int idGenero { get; set; }

        private LibroManage lm;
        public Libro() 
        {
            lm = new LibroManage();
        }

        public Libro(int idLibro, string titulo, string autor, int anioPublicacion, int idGenero) 
        {
            this.idLibro = idLibro;
            this.titulo = titulo;
            this.autor = autor;
            this.anioPublicacion = anioPublicacion;
            this.idGenero = idGenero;
            lm = new LibroManage();
        }

        public Libro(string titulo, string autor, int anioPublicacion, int idGenero)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anioPublicacion = anioPublicacion;
            this.idGenero = idGenero;
            lm = new LibroManage();
        }

        public List<Libro> LeerLibros()
        {
            return lm.LeerLibros();
        }

        public void InsertarLibro(Libro libro)
        {
            lm.InsertarLibro(libro);
        }

        public void ModificarLibro(Libro libro) 
        {
            lm.ModificarLibro(libro);
        }

        public void EliminarLibro(Libro libro) 
        {
            lm.EliminarLibro(libro);
        }



    }
}
