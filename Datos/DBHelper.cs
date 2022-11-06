using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting;
using Cine.Dominio;

namespace Cine.Datos
{
    internal class DBHelper
    {
        private SqlConnection conn;
        private string CadenaConexion = @"Data Source=PC;Initial Catalog=cineNov6;Integrated Security=True";
        private static DBHelper instancia;


        public DBHelper()
        {
            conn = new SqlConnection(CadenaConexion);
        }

        public static DBHelper ObtenerInstancia()
        {
            if (instancia == null)

                instancia = new DBHelper();
            return instancia;

        }

        public DataTable ConsultarDB(string NomProc)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = NomProc;
            cmd.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd.ExecuteReader());
            conn.Close();
            return tabla;
        }

        public DataTable ConsultarFunciones(string NomProc, DateTime fecha)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NomProc;
            SqlParameter param = new SqlParameter();
            param.ParameterName = "fecha";
            param.Value = fecha;
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.Date;
            cmd.Parameters.Add(param);
            tabla.Load(cmd.ExecuteReader());
            conn.Close();
            return tabla;
        }

        public bool GrabarCliente(Cliente oCliente)
        {
            bool ok = true;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GRABAR_CLIENTE";
            cmd.Parameters.AddWithValue("@nombre", oCliente.Nombre);
            cmd.Parameters.AddWithValue("@apellido",oCliente.Apellido);
            cmd.Parameters.AddWithValue("@dni",oCliente.Dni);
            cmd.Parameters.AddWithValue("@calle",oCliente.Calle);
            cmd.Parameters.AddWithValue("@altura",oCliente.Altura);
            cmd.Parameters.AddWithValue("@email",oCliente.Email);
            cmd.Parameters.AddWithValue("@telefono",oCliente.Telefono);
            cmd.ExecuteNonQuery();
            conn.Close();
            return ok;
        }

        public bool GrabarFuncion(Funcion oFuncion)
        {
            bool ok = true;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GRABAR_FUNCION";
            cmd.Parameters.AddWithValue("@idPelicula", oFuncion.Pelicula);
            cmd.Parameters.AddWithValue("@fecha", oFuncion.Fecha);
            cmd.Parameters.AddWithValue("@precio", oFuncion.Precio);
            cmd.Parameters.AddWithValue("@idSala", oFuncion.Sala);
            cmd.ExecuteNonQuery();
            conn.Close();
            return ok;
            
        }
        
    }
}
