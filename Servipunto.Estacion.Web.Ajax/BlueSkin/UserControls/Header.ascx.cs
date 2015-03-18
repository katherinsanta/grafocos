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

//namespace Servipunto.Estacion.Web.BlueSkin.UserControls
namespace Servipunto.Cartera.Web.BlueSkin.UserControls
{
    public partial class Header : System.Web.UI.UserControl
    {
        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {           
            
            if (!this.IsPostBack)
            {
                this.InitializeForm();
            }            
        }
        #endregion        

        #region InitializeForm
        private void InitializeForm()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated && Request.QueryString["LogOff"] == null)
            {
                this.UserNameTD.Visible = true;
                this.LogOffTD.Visible = true;
                this.LogOnTD.Visible = false;
                if (Session["Usuario"] != null)
                {

                    this.lblUserName.Text = ((Servipunto.Estacion.Libreria.Usuario)Session["Usuario"]).Nombre;
                    this.lblUserName.ToolTip = ((Servipunto.Estacion.Libreria.Usuario)Session["Usuario"]).Rol;
                    this.lblCompania.Text = "";
                }
                else
                {
                    this.lblUserName.Text = "???";
                    this.lblCompania.Text = "";
                }
            }
            else
            {
                this.UserNameTD.Visible = false;
                this.LogOffTD.Visible = false;
                this.LogOnTD.Visible = true;
                this.lblCompania.Text = "";
            }
        }
        #endregion
    }
}