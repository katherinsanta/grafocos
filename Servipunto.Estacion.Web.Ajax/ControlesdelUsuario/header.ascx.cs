using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Servipunto.Estacion.Web.Ajax.ControlesdelUsuario
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Servipunto.Estacion.Libreria.Usuario usu = (Servipunto.Estacion.Libreria.Usuario)(Session["Usuario"]);
            if (usu!= null)
            {
                
                lblUsuario.Text = usu.Nombre;
            }
        }

        protected void LnkCerrar_Click(object sender, EventArgs e)
        {
            Session["IdUsuario"] = null;
            Session["Usuario"] = null;
            Session.Clear();
         
            Response.Redirect("~/Modules/Main/Login.aspx");
        }
    }
}