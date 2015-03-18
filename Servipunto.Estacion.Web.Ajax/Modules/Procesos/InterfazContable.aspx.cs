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

namespace Servipunto.Estacion.Web.Modules.Procesos
{
    public partial class InterfazContable : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 201, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2135, Global.Idioma);
                Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2136, Global.Idioma);
                Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2137, Global.Idioma);
                Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2139, Global.Idioma);
                Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2138, Global.Idioma);
                #region verificar session
                if (Session["Usuario"] == null)
                {
                    if (Session["Usuario"] == null)
                    {
                        Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                    }

                }
                #endregion
            }
            catch (Exception) { }
        }
    }
}
