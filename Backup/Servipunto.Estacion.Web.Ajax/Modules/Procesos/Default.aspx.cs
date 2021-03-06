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
    public partial class Default : System.Web.UI.Page
    {
        #region Evento que Carga La Pagina
        private void Page_Load(object sender, System.EventArgs e)
        {
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1711, Global.Idioma);
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(867, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(868, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(869, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(870, Global.Idioma);
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
            // Put user code to initialize the page here
        }

        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Default";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Default");

            if (!permiso)
            {
                this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta p�gina.");
                return false;
            }

            return true;
        }
        #endregion

        #region SetError
        private void SetError(string message)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
        }
        #endregion

    }
}
