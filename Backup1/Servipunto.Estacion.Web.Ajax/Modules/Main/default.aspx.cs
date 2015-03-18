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

namespace Servipunto.Estacion.Web.Ajax.Modules.Main
{
    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1013, Global.Idioma);
            this.Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1048, Global.Idioma);
            this.Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(7, Global.Idioma);
            this.Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1051, Global.Idioma);
            this.Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1694, Global.Idioma);
            this.Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(4, Global.Idioma);            

        }
    }
}
