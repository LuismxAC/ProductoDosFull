using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassCapaEntidades;
using ClassLogicaNegocioCarniceria;

namespace WebProductoDos
{
    public partial class index : System.Web.UI.Page
    {
        ClassLogicaCliente objetoLogica = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objetoLogica = new ClassLogicaCliente();
                Session["objetoLogica"] = objetoLogica;
            }
            else
            {
                objetoLogica = (ClassLogicaCliente)Session["objetoLogica"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string m = "", i = "", t = "";
            Cliente tempC = new Cliente
            {
                Nombre = txtNombre.Text,
                App = txtApp.Text,
                ApM = txtApm.Text,
                Celular = txtTel.Text.ToString(),
                Correo = txtEmail.Text
            };
            string[] atrapa = objetoLogica.CompruebaExistenciaCli(tempC, ref m, ref i, ref t);

            if (atrapa != null)
            {
                Session["Datos"] = atrapa;
            }
            else
            {
                objetoLogica.InsertaCliente(tempC, ref m, ref i, ref t);
                string[] temp = objetoLogica.CompruebaExistenciaCli(tempC, ref m, ref i, ref t);
                Session["Datos"] = temp;
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "msg1", "msgboxr('" + m + "', '" + i + "', '" + t + "', 'InicioCli.aspx')", true);
        }
    }
}