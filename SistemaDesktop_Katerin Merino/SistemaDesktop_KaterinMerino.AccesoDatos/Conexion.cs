using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDesktop_KaterinMerino.AccesoDatos
{
    public class Conexion
    {
        private string BD; // nombre de la base de datos
        private string Server; // nombre del servicio /ip/dominio/ localhost
        private string User;  //usuario motor BD (SA)
        private string clave;  // Clave del usuario del moto SGBD
        private bool Autenticacion;  // Windows y SQL
        private static Conexion cnx = null; // para saber si hay conexion


        private Conexion()  //constructor
        {
            this.BD = "db_sistema";
            this.Server = "LENOVO\\SQLEXPRESS";
            this.User = "";
            this.clave = "";
            this.Autenticacion = true; //windows
        }

        public SqlConnection EstablecerConexion()
        {
            SqlConnection cadenaconex = new SqlConnection();

            try
            {
                //cadenaconex.ConnectionString = "Server=" + this.Server + "," + 1433 + " ; " + "Database = " + this.BD + ";";
                cadenaconex.ConnectionString = "Server=" + this.Server + " ; " + "Database = " + this.BD + ";";

                if (this.Autenticacion) //seguridad de windows cuando es true
                {
                    cadenaconex.ConnectionString = cadenaconex.ConnectionString + "Integrated Security=SSPI";

                }
                else // auttenticacion SQL
                {
                    cadenaconex.ConnectionString = cadenaconex.ConnectionString + "User Id=" + this.User + ";" + "Password=" + this.clave;
                }

            }
            catch (Exception ex)
            {
                cadenaconex = null;
                throw ex;
            }
            return cadenaconex;

        }

        public static Conexion getInstance()
        {
            if (cnx == null)
            {
                cnx = new Conexion();
            }
            return cnx;
        }
    }
}
