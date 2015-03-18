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

namespace Servipunto.Estacion.Web.Modules.ReportesEstacion
{
	/// <summary>
	/// Descripción breve de ConfInterfaceContableSAP.
	/// </summary>
	public class ConfInterfaceContableSAP : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.WebControls.RadioButtonList optNCSubtotal;
		protected System.Web.UI.WebControls.TextBox txtNCSubtotal;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		//Declaración de variable que contiene la colección de objetos
		protected Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables;
		//Declaración de Variable que contiene 1 solo elemento de la colección de objetos
		protected Servipunto.Estacion.Libreria.InterfazContable objInterfazContable;
		protected System.Web.UI.WebControls.CheckBox chkNTSubtotal;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.LinkButton lbGuardar;
		protected System.Web.UI.WebControls.DropDownList DropDownList20;
		protected System.Web.UI.WebControls.DropDownList DropDownList19;
		protected System.Web.UI.WebControls.DropDownList DropDownList18;
		protected System.Web.UI.WebControls.DropDownList DropDownList17;
		protected System.Web.UI.WebControls.DropDownList DropDownList16;
		protected System.Web.UI.WebControls.DropDownList DropDownList15;
		protected System.Web.UI.WebControls.DropDownList DropDownList14;
		protected System.Web.UI.WebControls.TextBox TextBox12;
		protected System.Web.UI.WebControls.DropDownList DropDownList13;
		protected System.Web.UI.WebControls.DropDownList DropDownList12;
		protected System.Web.UI.WebControls.TextBox TextBox11;
		protected System.Web.UI.WebControls.TextBox TextBox10;
		protected System.Web.UI.WebControls.TextBox TextBox13;
		protected System.Web.UI.WebControls.TextBox TextBox14;
		protected System.Web.UI.WebControls.TextBox TextBox15;
		protected System.Web.UI.WebControls.DropDownList DropDownList21;
		protected System.Web.UI.WebControls.DropDownList DropDownList22;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.WebControls.Label Label1;
		//Declaración de variable que se encarga de contener el estado de la forma
		protected WebApplication.FormMode _mode;
		#endregion
	
		#region Form Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
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
		#endregion
	
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		

		

	}
}
