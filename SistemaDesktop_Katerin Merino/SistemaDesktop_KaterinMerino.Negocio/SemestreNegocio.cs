using SistemaDesktop_KaterinMerino.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDesktop_KaterinMerino.Negocio;
using SistemaDesktop_KaterinMerino.Entidad;

namespace SistemaDesktop_KaterinMerino.Negocio
{
    public class SemestreNegocio
    {
        //Metodo Listar
        public static DataTable Listar()
        {
            SemestreDatos objSemestre = new SemestreDatos();
            return objSemestre.Listar();

        }

        //Metodo Buscar
        public static DataTable Buscar(string Busqueda)
        {
            SemestreDatos objSemestre = new SemestreDatos();
            return objSemestre.Buscar(Busqueda);
        }

        //Metodo Insertar
        public static string Insertar(string Nombre, int Anio, string Estado)
        {
            SemestreDatos objSemestreD = new SemestreDatos();

            string Existe = objSemestreD.Existe(Nombre);

            if (Existe.Equals("1"))
            {
                return "El Semestre ya existe en la BD....";
            }
            else
            {
                SemestreEntidad objSesmestreE = new SemestreEntidad();
                objSesmestreE.Nombre = Nombre;
                objSesmestreE.Anio = Anio;
                objSesmestreE.Estado = Estado;
                return objSemestreD.Insertar(objSesmestreE);
            }
        }

        //Metodo Actualizar
        public static string Actualizar(int Id, string NombreAnterior, string Nombre, int Anio, string Estado)
        {
            SemestreDatos objSemestreD = new SemestreDatos();
            SemestreEntidad obj = new SemestreEntidad();

            if (NombreAnterior.Equals(Nombre))
            {
                obj.SemestreId = Id;
                obj.Nombre = Nombre;
                obj.Anio = Anio;
                obj.Estado = Estado;

                return objSemestreD.Actualizar(obj);
            }
            else
            {
                string Existe = objSemestreD.Existe(Nombre);

                if (Existe.Equals("1"))
                {
                    return "El Semestre ya existe en la BD....";
                }
                else
                {
                    SemestreEntidad objSesmestreE = new SemestreEntidad();
                    objSesmestreE.SemestreId = Id;
                    objSesmestreE.Nombre = Nombre;
                    objSesmestreE.Anio = Anio;
                    objSesmestreE.Estado = Estado;
                    return objSemestreD.Actualizar(objSesmestreE);
                }
            }
        }

        //Metodo Eliminar
        public static string Eliminar(int Id)
        {
            SemestreDatos objSemestre = new SemestreDatos();
            return objSemestre.Eliminar(Id);
        }

        //Metodo Activar
        public static string Activar(int Id)
        {
            SemestreDatos objSemestre = new SemestreDatos();
            return objSemestre.Activar(Id);
        }

        //Metodo Desactivar
        public static string Desactivar(int Id)
        {
            SemestreDatos objSemestre = new SemestreDatos();
            return objSemestre.Desactivar(Id);
        }
    }
}
