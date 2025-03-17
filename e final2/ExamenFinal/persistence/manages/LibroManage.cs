using DataGridView.persistence;
using ExamenFinal.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.persistence.manages
{
    internal class LibroManage
    {
        private DataTable dataTable { get; set; }
        private List<Libro> listaLibros { get; set; }
        private DBBroker dbBroker = DBBroker.obtenerAgente();

        public LibroManage()
        {
            dataTable = new DataTable();
            listaLibros = new List<Libro>();
        }

        public List<Libro> LeerLibros()
        {

            Libro libro = null;

            List<Object> aux = DBBroker.obtenerAgente().leer("SELECT * FROM club_lectura.libro");

            foreach (List<Object> c in aux)
            {
                libro = new Libro(int.Parse(c[0].ToString()), c[1].ToString(), c[2].ToString(), int.Parse(c[3].ToString()),
                   int.Parse(c[4].ToString()));

                this.listaLibros.Add(libro);
            }

            return listaLibros;

        }

        public void InsertarLibro(Libro libro)
        {

            string sql = $"INSERT INTO club_lectura.libro ( TITULO, AUTOR, ANIO_PUBLICACION,ID_GENERO) " +
                $"VALUES ('{libro.titulo}', '{libro.autor}', {libro.anioPublicacion}, {libro.idGenero})";

            DBBroker.obtenerAgente().modificar(sql);
        }

        public void ModificarLibro(Libro libro)
        {
            string sql = $"UPDATE club_lectura.libro SET TITULO = '{libro.titulo}', AUTOR = '{libro.autor}',  ANIO_PUBLICACION = {libro.anioPublicacion}, ID_GENERO = {libro.idGenero} WHERE ID_LIBRO = {libro.idLibro}";
            dbBroker.modificar(sql);

            var libroExistente = listaLibros.Find(e => e.idLibro == libro.idLibro);
            if (libroExistente != null)
            {
                libroExistente.titulo = libro.titulo;
                libroExistente.autor = libro.autor;
                libroExistente.anioPublicacion = libro.anioPublicacion;
                libroExistente.idGenero = libro.idGenero;
            }
        }

        public void EliminarLibro(Libro libro)
        {
            string sql = $"DELETE FROM club_lectura.libro WHERE ID_LIBRO = {libro.idLibro}";
            dbBroker.modificar(sql);
            listaLibros.RemoveAll(p => p.idLibro == libro.idLibro);
        }
    }
}
