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

namespace Servipunto.Estacion.Web.Modules.ReportesEstacion
{
    public partial class ReportesConductor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Traducir();
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 17/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            lblReporte.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23726, Global.Idioma);
            lblDesc.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23727, Global.Idioma);
            lblConsumo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23728, Global.Idioma);
            lblDescConsumo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23729, Global.Idioma);
            lblTiempos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23730, Global.Idioma);
            lblDescTiempos.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23731, Global.Idioma);
        }
        #endregion
    }
}
