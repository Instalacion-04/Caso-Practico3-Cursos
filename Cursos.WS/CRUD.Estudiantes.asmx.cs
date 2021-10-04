using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Cursos.WS.Models;


namespace Cursos.WS
{
    /// <summary>
    /// Descripción breve de CRUD_Estudiantes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class CRUD_Estudiantes : System.Web.Services.WebService
    {


        #region CRUD Estudiantes

        [WebMethod(Description ="Obtención de datos desde la BD")]
        public List<estudiante> ObtenerDatos()
        {
            using (cursosEntities conexion=new cursosEntities())
            {
                var query = (from a in conexion.estudiantes select a);
                return query.ToList();
            }
        }

        [WebMethod(Description = "Insertar datos en la BD")]
        public string InsertarDatos(string Nombre,string Apellidos,string Carrera, string Curso, 
            string Duración,string FolioCurso)
        {
           
            try
            {
                using (cursosEntities conexion = new cursosEntities())
                {
                    estudiante nuevo = new estudiante();
                    nuevo.nombre = Nombre;
                    nuevo.apellidos = Apellidos;
                    nuevo.carrera = Carrera;
                    nuevo.nombre_curso = Curso;
                    nuevo.duracion = Duración;
                    nuevo.foliocurso = FolioCurso;
                    conexion.estudiantes.Add(nuevo);
                    conexion.SaveChanges(); //Agrega el registro a la BD
                    return "--Registro Exitoso--";
                }
            }
            catch (Exception)
            {
                return "--Error--No se guardaron datos";
            }
         
        }



        [WebMethod(Description = "Modificar datos en la BD")]
        public string ModificarDatos(int Id,string Nombre, string Apellidos, string Carrera, string Curso,
            string Duración, string FolioCurso)
        {

            try
            {
                using (cursosEntities conexion = new cursosEntities())
                {
                    var query =(from a in conexion.estudiantes where a.id==Id select a).FirstOrDefault();
                    if (query != null)
                    {
                        query.nombre = Nombre;
                        query.apellidos = Apellidos;
                        query.carrera = Carrera;
                        query.nombre_curso = Curso;
                        query.duracion = Duración;
                        query.foliocurso = FolioCurso;
                        conexion.SaveChanges(); //Agrega el registro a la BD
                        return "--Datos Modificados--";
                    }
                    else
                    {
                        return "--A ocurrido un error--";
                    }
                   
                }
            }
            catch (Exception)
            {
                return "--Error--No se guardaron cambios";
            }

        }

        [WebMethod(Description = "Eliminar datos en la BD")]
        public string EliminarDatos(int Id)
        {

            try
            {
                using (cursosEntities conexion = new cursosEntities())
                {
                    var query = (from a in conexion.estudiantes where a.id == Id select a).FirstOrDefault();
                    if (query != null)
                    {
                        conexion.estudiantes.Remove(query);
                        conexion.SaveChanges(); //Agrega el registro a la BD
                        return "--Datos Eliminados--";
                    }
                    else
                    {
                        return "--A ocurrido un error--";
                    }

                }
            }
            catch (Exception)
            {
                return "--Error--No se guardaron cambios";
            }

        }

        [WebMethod(Description = "Buscar datos en la BD")]

        public List<estudiante> BuscarDatos(int Id)
        {
                using (cursosEntities conexion = new cursosEntities())
                {
                    var query = (from a in conexion.estudiantes where a.id == Id select a);
                    return query.ToList(); 
                }
        }

        #endregion



    }
}
