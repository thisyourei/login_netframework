using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;

namespace pruebitanetframework
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        OracleConnection conexion = new OracleConnection("DATA SOURCE = ORCL ; PASSWORD = Lala1234 ; USER ID = Administrador");

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            conexion.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM PERSONA WHERE USUARIO = :usuario AND CLAVE = :clave", conexion);

            comando.Parameters.Add(":usuario", txtUsuario.Text);
            comando.Parameters.Add(":clave", txtClave.Text);

            OracleDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                if (lector["ROL"].ToString()=="ADMIN")
                {
                    Server.Transfer("HomeAdmin.aspx");
                    conexion.Close();
                }

                if (lector["ROL"].ToString() == "NORMAL")
                {
                    Server.Transfer("HomeNormal.aspx");
                    conexion.Close();
                }
            }
            else
            {

            }

        }
    }
}