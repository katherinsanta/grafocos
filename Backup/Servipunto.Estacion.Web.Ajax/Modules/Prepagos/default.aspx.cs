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

namespace Servipunto.Estacion.Web.Modules.Prepagos
{
    public partial class _default : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Label label1;
        protected void Page_Load(object sender, EventArgs e)
        {
            traducir();
        }
        public void traducir() 
        {
            label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23853, Servipunto.Estacion.Web.Global.Idioma);
            lblAsing.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23854, Servipunto.Estacion.Web.Global.Idioma);
            lblCancelattion.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23855, Servipunto.Estacion.Web.Global.Idioma);
            lblReport.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23856, Servipunto.Estacion.Web.Global.Idioma);
        }
    }
}
