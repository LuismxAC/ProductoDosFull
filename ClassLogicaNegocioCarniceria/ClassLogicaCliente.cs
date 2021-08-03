using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiAccesoSQL;
using System.Data;
using System.Data.SqlClient;

using ClassCapaEntidades;

namespace ClassLogicaNegocioCarniceria
{
    public class ClassLogicaCliente
    {
        private ClassAccesoSQL Objacceso = new ClassAccesoSQL
        (
            @"Data Source=DESKTOP-H5Q2S4F\MSSQLSERVER01; Initial Catalog=PedidosCarniceria; Integrated Security=true;"
        );

        public Boolean InsertaCliente(Cliente nuevo, ref string message, ref string icon, ref string title)
        {
            SqlParameter[] params1 = new SqlParameter[5];
            params1[0] = new SqlParameter
            {
                ParameterName = "nombre",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 90,
                Value = nuevo.Nombre
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "app",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 90,
                Value = nuevo.App
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "apm",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 90,
                Value = nuevo.ApM
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "celular",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 20,
                Value = nuevo.Celular
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "correo",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 150,
                Value = nuevo.Correo
            };

            string sentencia = "insert into Cliente values(@nombre,@app,@apm,@celular,@correo)";

            Boolean salida = false;
            salida = Objacceso.InsertParametros(sentencia,
                Objacceso.AbrirConexion(ref message, ref icon, ref title), ref message, ref icon, ref title, params1);
            return salida;
        }

        public string[] CompruebaExistenciaCli(Cliente cli, ref string m, ref string i, ref string t)
        {
            SqlConnection cnxTemp = null;
            SqlParameter[] pSQL = new SqlParameter[1];
            pSQL[0] = new SqlParameter
            {
                ParameterName = "correo",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 150,
                Value = cli.Correo
            };
            string q1 = "SELECT COUNT(*), Nombre, App, ApM, correo, celular, id_Cliente FROM Cliente WHERE Correo = @correo GROUP BY Nombre, App, ApM, correo,celular, id_Cliente; ";
            string[] status = null;

            cnxTemp = Objacceso.AbrirConexion(ref m, ref i, ref t);
            SqlDataReader atrapa = null;
            atrapa = Objacceso.ConsultaDRP(q1, cnxTemp, ref m, ref i, ref t, pSQL);

            if (atrapa != null)
            {
                while (atrapa.Read())
                {
                    if ((int)atrapa[0] > 0)
                    {
                        status = new string[7];
                        status[0] = atrapa[0].ToString();
                        status[1] = atrapa[1].ToString();
                        status[2] = atrapa[2].ToString();
                        status[3] = atrapa[3].ToString();
                        status[4] = atrapa[4].ToString();
                        status[5] = atrapa[5].ToString();
                        status[6] = atrapa[6].ToString();
                        m = "Un momento";
                        t = "Ya estas registrado";
                        i = "success";
                    }
                    else
                    {
                        status = null;
                    }
                }
            }
            cnxTemp.Close();
            cnxTemp.Dispose();
            return status;
        }
    }




}
