using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Servipunto.Estacion.AccesoDatos.HelperClasses;
using System.Web.UI.HtmlControls;

namespace Servipunto.Estacion.Web.Ajax.PaginaMaestra
{
    public partial class Prueba : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConectarBaseDatos();
        }

        private void ConectarBaseDatos()
        {
            string conexion = "";
            conexion = Servipunto.Libreria.Cryptography.Decrypt(System.Configuration.ConfigurationManager.AppSettings["administ"]);
            DbUtils.ActualConnectionString = conexion;
        }
    }
}
