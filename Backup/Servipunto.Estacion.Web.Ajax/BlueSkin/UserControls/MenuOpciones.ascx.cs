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

namespace Servipunto.Cartera.Web.BlueSkin.UserControls
{
    public partial class MenuOpciones : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void EspecificarPanel(bool PanelPrincipal, bool PanelComerciales, bool PanelReportes, bool PanelDeControl)
        {
            trvPrincipal.Visible = PanelPrincipal;
            trvComerciales.Visible = PanelComerciales;
            trvReportes.Visible = PanelReportes;
            trvPanelDeControl.Visible = PanelDeControl;
        }

   }
}