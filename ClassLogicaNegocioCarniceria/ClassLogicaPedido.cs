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
    public class ClassLogicaPedido
    {
        private ClassAccesoSQL Objacceso = new ClassAccesoSQL
       (
           @"Data Source=DESKTOP-H5Q2S4F\MSSQLSERVER01; Initial Catalog=PedidosCarniceria; Integrated Security=true;"
       );
        public Boolean AbrirPedido(Pedido nuevo, ref string message, ref string icon, ref string title)
        {
            SqlParameter[] params1 = new SqlParameter[4];
            params1[0] = new SqlParameter
            {
                ParameterName = "fcli",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.FCliente
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "fcar",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.FCarnicero
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "env",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = nuevo.Envio
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "pag",
                SqlDbType = SqlDbType.NVarChar,
                Direction = ParameterDirection.Input,
                Size = 50,
                Value = nuevo.Pago
            };

            string sqlInsert = "INSERT INTO Pedido (FechaHora, F_Cliente, F_Carnicero, Envio, Pago) VALUES (GETDATE(), @fcli, @fcar, @env, @pag)";
            Boolean salida = false;
            salida = Objacceso.InsertParametros(sqlInsert, Objacceso.AbrirConexion(ref message, ref icon, ref title), ref message, ref icon, ref title, params1);
            return salida;
        }
        public DataTable PedidosGrid(int id, ref string m, ref string i, ref string t)
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter
            {
                ParameterName = "idcli",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            };
            string query2 = "SELECT id_Pedido AS Pedido, FechaHora, CONCAT(Cliente.Nombre, ' ', App, ' ', ApM) AS Cliente, Carnicero.Nombre AS Carnicero, Envio, Pago FROM Pedido INNER JOIN Cliente ON Pedido.F_Cliente = Cliente.id_Cliente INNER JOIN Carnicero ON Pedido.F_Carnicero = Carnicero.id_Carnicero WHERE F_Cliente = @idcli";
            DataSet atrapa = null;
            DataTable tablaSalida = null;

            atrapa = Objacceso.ConsultaDSP(query2, Objacceso.AbrirConexion(ref m, ref i, ref t), ref m, ref i, ref t, par);

            if (atrapa != null)
            {
                tablaSalida = atrapa.Tables[0];
                if (atrapa.Tables[0].Rows.Count == 0)
                {
                    tablaSalida.Rows.Add(tablaSalida.NewRow());
                }

            }
            return tablaSalida;
        }
    }
}
