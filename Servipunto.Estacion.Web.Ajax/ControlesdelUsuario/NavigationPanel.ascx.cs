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
using Servipunto.Estacion.Web.Ajax.lib;


namespace Servipunto.Estacion.Web.Ajax.ControlesdelUsuario
{
    public partial class NavigationPanel : System.Web.UI.UserControl
    {
        private string _grupo;

        public string Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }
        NavigationPane Panel = new NavigationPane();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
                //if (Grupo!=null)
                //{
                    Panel.Group = "PaginaPrincipal";
                    construir();
                    
                //}
                
            }                
        }
        public void construir() 
        {
            //Panel.Group = Grupo;
            GenerarPanel(Panel.ObtenerPanel());

        }

        public void GenerarPanel(string htmlPanel)
        {
           PanelNavegacion.InnerHtml = htmlPanel;

        }
    }
}