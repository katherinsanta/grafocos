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
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Export.Pdf;

namespace Servipunto.Estacion.Reportes
{
	public class SubFiltroCodigoEmpleado : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Panel pnlcodArticulo;
		protected System.Web.UI.WebControls.TextBox txtCodigoEmpleado;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.HtmlControls.HtmlTableCell SeccionResultados;
		protected System.Web.UI.WebControls.ImageButton ibBuscar;
		protected System.Web.UI.WebControls.Repeater Results;

		#endregion
	
		#region Form Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{

			Buscar();
		}
		#endregion

		#region SetError
		private void SetError(string message)
		{
			this.lblError.Visible = true;
			this.lblError.Text = message;
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

		#region Cargar Repeater
		private void Buscar()
		{
			Servipunto.Estacion.Libreria.Empleados objEmpleados = new Servipunto.Estacion.Libreria.Empleados();

				Results.DataSource = objEmpleados;
				Results.DataBind();
				this.SeccionResultados.Visible = true;
		}
		#endregion
	}
}
