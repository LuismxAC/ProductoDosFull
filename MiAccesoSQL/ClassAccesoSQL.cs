using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace MiAccesoSQL
{
    public class ClassAccesoSQL
    {
        private string cadConexion;
        public ClassAccesoSQL(string cnx)
        {
            cadConexion = cnx;
        }
        public SqlConnection AbrirConexion(ref string message, ref string icon, ref string title)
        {
            SqlConnection cnx1 = new SqlConnection();
            cnx1.ConnectionString = cadConexion;
            try
            {
                cnx1.Open();
                message = "La conexion es correcta";
                icon = "success";
                title = "Conexion establecida";

            }
            catch (Exception bd)
            {

                cnx1 = null;
                message = "ERROR: " + bd.Message;
                icon = "error";
                title = "Ups! Algo salio mal";
            }
            return cnx1;
        }
        public DataSet ConsultaDataSet(string query, SqlConnection cnxAb, ref string message, ref string icon, ref string title)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            DataSet salida = new DataSet();

            if (cnxAb == null)
            {
                message = "No hay conexion a la base de datos";
                icon = "error";
                title = "Ups! Algo salio mal";
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = query;
                carrito.Connection = cnxAb;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(salida, "Consulta1");
                    message = "Todo salio bien";
                    icon = "success";
                    title = "Consulta ejecutada correctamente";
                }
                catch (Exception a)
                {
                    salida = null;
                    title = "Error: " + a.Message;
                    icon = "error";
                    message = "Ups! Algo salio mal";
                }
                cnxAb.Close();
                cnxAb.Dispose();
            }
            return salida;
        }
        public SqlDataReader ConsultaDataReader(string query, SqlConnection cnxAb, ref string message, ref string icon, ref string title)
        {
            SqlCommand carrito = null;
            SqlDataReader contenedor = null;

            if (cnxAb == null)
            {
                message = "No hay conexion a la base de datos";
                icon = "error";
                title = "Ups! Algo salio mal";
                contenedor = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = query;
                carrito.Connection = cnxAb;
                try
                {
                    contenedor = carrito.ExecuteReader();
                    icon = "success";
                    title = "Todo correcto";
                    message = "Consulta ejecutada";
                }
                catch (Exception e)
                {
                    contenedor = null;
                    icon = "error";
                    title = "Ups! Algo salio mal";
                    message = "ERROR: " + e.Message;
                }

            }
            return contenedor;
        }
        public Boolean InsertParametros(string query, SqlConnection cnxAb, ref string message, ref string icon, ref string title, SqlParameter[] par)
        {
            Boolean salida = false;
            SqlCommand cmd = null;
            if (cnxAb != null)
            {
                cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = cnxAb;
                foreach (SqlParameter p in par)
                {
                    cmd.Parameters.Add(p);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    message = "Se ha registrado correctamente";
                    icon = "success";
                    title = "Correcto";
                    salida = true;
                }
                catch (Exception ex)
                {
                    icon = "error";
                    title = "Ups! Algo salio mal";
                    message = "ERROR " + ex.Message;
                    salida = false;
                }
                cnxAb.Close();
                cnxAb.Dispose();
            }
            else
            {
                icon = "error";
                title = "Ups! Algo salio mal";
                message = "No hay conexion a la base de datos";
            }
            return salida;
        }
        public SqlDataReader ConsultaDRP(string query, SqlConnection cnxAb, ref string message, ref string icon, ref string title, SqlParameter[] p)
        {
            SqlCommand carrito = null;
            SqlDataReader contenedor = null;

            if (cnxAb == null)
            {
                message = "No hay conexion a la base de datos";
                icon = "error";
                title = "Ups! Algo salio mal";
                contenedor = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = query;
                carrito.Connection = cnxAb;
                foreach (SqlParameter pars in p)
                {
                    carrito.Parameters.Add(pars);
                }
                try
                {
                    contenedor = carrito.ExecuteReader();
                    icon = "success";
                    title = "Todo correcto";
                    message = "Consulta ejecutada";
                }
                catch (Exception e)
                {
                    contenedor = null;
                    icon = "error";
                    title = "Ups! Algo salio mal";
                    message = "ERROR: " + e.Message;
                }

            }
            return contenedor;
        }
        public DataSet ConsultaDSP(string query, SqlConnection cnxAb, ref string message, ref string icon, ref string title, SqlParameter[] p)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            DataSet salida = new DataSet();

            if (cnxAb == null)
            {
                message = "No hay conexion a la base de datos";
                icon = "error";
                title = "Ups! Algo salio mal";
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = query;
                carrito.Connection = cnxAb;
                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                foreach (SqlParameter pars in p)
                {
                    carrito.Parameters.Add(pars);
                }

                try
                {
                    trailer.Fill(salida, "Consulta1");
                    message = "Todo salio bien";
                    icon = "success";
                    title = "Consulta ejecutada correctamente";
                }
                catch (Exception a)
                {
                    salida = null;
                    title = "Error: " + a.Message;
                    icon = "error";
                    message = "Ups! Algo salio mal";
                }
                cnxAb.Close();
                cnxAb.Dispose();
            }
            return salida;
        }
    }
}
