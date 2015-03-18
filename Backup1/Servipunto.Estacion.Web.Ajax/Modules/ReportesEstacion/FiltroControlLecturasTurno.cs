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
	public class FiltroControlLecturasTurno : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Calendar FechaFin;
		protected System.Web.UI.WebControls.RadioButtonList TipoReporte;
		protected System.Web.UI.WebControls.CheckBox cbTodos;
		protected System.Web.UI.WebControls.DropDownList ddlCara;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.RadioButtonList rbFormato;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;

		#endregion
	
		#region Form Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (this.IsPostBack)
			{
				if (Request.Form["__EVENTTARGET"].Length == 0)
					this.EjecutarReporte();
			}
			else
			{
				this.InicializarForma();
				this.VerificarPermisos();
			}
		}
		#endregion

		#region Validar
		private bool Validar()
		{
			if (this.FechaInicio.SelectedDate > this.FechaFin.SelectedDate)
			{
				this.SetError("La fecha inicial no puede ser superior a la final!");
				return false;
			}
			return true;
		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Generales";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas Cara");
			
			if (!permiso)
			{
				this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.");
				this.MyForm.Visible = false;
				return false;
			}
			
			return true;
		}
		#endregion

		#region EjecutarReporte
		private void EjecutarReporte()
		{
			if (this.Validar())
			{
				try
				{
					DataDynamics.ActiveReports.ActiveReport report = null;
					if (this.TipoReporte.SelectedValue == "Detallado")
						report = new Servipunto.Estacion.Web.Modules.Rpt.VentasCaraDetallado(this.FechaInicio.SelectedDate, this.FechaFin.SelectedDate, int.Parse(this.ddlCara.SelectedValue));
					else if (this.TipoReporte.SelectedValue == "Resumido")
						report = new Servipunto.Estacion.Web.Modules.Rpt.VentasCaraResumido(this.FechaInicio.SelectedDate, this.FechaFin.SelectedDate,  int.Parse(this.ddlCara.SelectedValue));
					
					Session.Add("LastReport", report);
					Session["Formato"] = rbFormato.SelectedValue;
					Response.Redirect("../Visor/PDF.aspx",false);
				}
				catch (Exception ex)
				{
					this.SetError(ex.Message);
				}
			}
		}
		#endregion

		#region InicializarForma
		private void InicializarForma()
		{
			this.lblReporte.Text = "<b>Reporte de Ventas por Cara</b>";
			this.FechaInicio.SelectedDate = System.DateTime.Now;
			this.FechaFin.SelectedDate = System.DateTime.Now;
			CargarCaras();
		}
		#endregion

		#region Cargar Caras
		private void CargarCaras()
		{
			for (int i = 1; i <= 20; i++)
			{
				this.ddlCara.Items.Add(new ListItem(i.ToString(), i.ToString()));
			}
			this.ddlCara.Items.Insert(0, new ListItem("(Todas las caras)", "0"));
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
	}
}
