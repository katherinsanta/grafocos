using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Servipunto.Estacion.Web.Modules.Procesos
{
    public partial class InterfazRecaudoGDO : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Label lblError;

        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 374, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                #region traduccion                
                Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2162, Global.Idioma);
                Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2163, Global.Idioma);
                Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2164, Global.Idioma);
                Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2165, Global.Idioma);
                Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2166, Global.Idioma);
                Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2167, Global.Idioma);
                Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2168, Global.Idioma);
                Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2169, Global.Idioma);
                Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2170, Global.Idioma);
                #endregion
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
