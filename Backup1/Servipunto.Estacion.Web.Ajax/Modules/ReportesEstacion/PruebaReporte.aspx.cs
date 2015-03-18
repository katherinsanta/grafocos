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
	/// Descripción breve de PruebaReporte.
	/// </summary>
	public class PruebaReporte : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Calendar FechaFin;
		protected System.Web.UI.WebControls.RadioButtonList TipoReporte;
		protected System.Web.UI.WebControls.Panel pnlcodArticulo;
		protected System.Web.UI.WebControls.TextBox txtEmpleado;
		protected System.Web.UI.WebControls.CheckBox cbTodosEmpleados;
		protected System.Web.UI.WebControls.TextBox txtTurno;
		protected System.Web.UI.WebControls.TextBox txtManguera;
		protected System.Web.UI.WebControls.CheckBox cbTodosTurnos;
		protected System.Web.UI.WebControls.DropDownList cboIsla;
		protected System.Web.UI.WebControls.CheckBox cbTodasManguera;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.Label lblError;

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
			if (this.IsPostBack)
			{
				//if (Request.Form["__EVENTTARGET"].Length == 0)
					//this.EjecutarReporte();
			}
			else
			{
				this.VerificarPermisos();
				this.InicializarForma();
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

			if(!this.cbTodosEmpleados.Checked)
			{
				try
				{
					int.Parse(this.txtEmpleado.Text);
				}
				catch(Exception)
				{
					this.SetError("Debe ingresar un codigo de empleado valido!");
					return false;
				}
			}

			if(!this.cbTodosTurnos.Checked)
			{
				try
				{
					int.Parse(this.txtTurno.Text);
				}
				catch(Exception)
				{
					this.SetError("Debe ingresar un codigo de turno valido!");
					return false;
				}
			}

			if(!this.cbTodasManguera.Checked)
			{
				try
				{
					int.Parse(this.txtManguera.Text);
				}
				catch(Exception)
				{
					this.SetError("Debe ingresar un codigo de manguera valido!");
					return false;
				}
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

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas Empleado");
			
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
					if(this.txtEmpleado.Text == "")
						this.txtEmpleado.Text = "0";
					if(this.txtTurno.Text == "")
						this.txtTurno.Text = "0";
					if(this.txtManguera.Text == "")
						this.txtManguera.Text = "0";
//					DataDynamics.ActiveReports.ActiveReport report = null;
//					if (this.TipoReporte.SelectedValue == "Detallado")
//						report = new Servipunto.Estacion.Web.Modules.Rpt.VentasPorEmpleadoTurnoIslaManguera(this.FechaInicio.SelectedDate, this.FechaFin.SelectedDate, int.Parse( this.txtEmpleado.Text ), this.cbTodosEmpleados.Checked, int.Parse( this.txtTurno.Text ), this.cbTodosTurnos.Checked, int.Parse( cboIsla.SelectedValue ),int.Parse( this.txtManguera.Text ), this.cbTodasManguera.Checked);
//					else if (this.TipoReporte.SelectedValue == "Resumido")
//						report = new Servipunto.Estacion.Web.Modules.Rpt.VentasPorEmpleadoTurnoIslaMangueraResumido(this.FechaInicio.SelectedDate, this.FechaFin.SelectedDate, int.Parse( this.txtEmpleado.Text ), this.cbTodosEmpleados.Checked, int.Parse( this.txtTurno.Text ), this.cbTodosTurnos.Checked, int.Parse( cboIsla.SelectedValue ),int.Parse( this.txtManguera.Text ), this.cbTodasManguera.Checked);
//					Session.Add("LastReport", report);
					Response.Redirect("../Visor/ActiveReportViewer.aspx?" + "rpt=VENTAS_EMPLEADO" + "&fechaInicio=" + this.FechaInicio.SelectedDate.ToShortDateString() + "&fechaFin=" + this.FechaFin.SelectedDate.ToShortDateString() + "&empleado=" + int.Parse( this.txtEmpleado.Text ) + "&todosEmpleados=" + this.cbTodosTurnos.Checked + "&turno=" + int.Parse( this.txtTurno.Text ) + "&todosTurnos=" + this.cbTodosTurnos.Checked + "&isla=" + int.Parse( cboIsla.SelectedValue ) + "&manguera=" +  int.Parse( this.txtManguera.Text ) + "&todasMangueras=" + this.cbTodasManguera.Checked + "&formato=pdf");
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
			this.lblReporte.Text = "<b>Reporte de Ventas por Empleado</b>";
			this.FechaInicio.SelectedDate = System.DateTime.Now;
			this.FechaFin.SelectedDate = System.DateTime.Now;
			CargarIslas();
			cbTodos_CheckedChanged(null,null);
			cbTodosTurnos_CheckedChanged(null,null);
			cbTodasManguera_CheckedChanged(null,null);
		}
		#endregion

		#region CargarIslas
		private void CargarIslas()
		{
			for (int i = 1; i <= 10; i++)
			{
				this.cboIsla.Items.Add(new ListItem(i.ToString(), i.ToString()));
			}
			this.cboIsla.Items.Insert(0, new ListItem("(todas las islas)", "0"));
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
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Seleccionar los checks de todo
		private void cbTodos_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbTodosEmpleados.Checked)
				this.txtEmpleado.Enabled = false;
			else
				this.txtEmpleado.Enabled = true;
		}


		private void cbTodosTurnos_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbTodosTurnos.Checked)
				this.txtTurno.Enabled = false;
			else
				this.txtTurno.Enabled = true;		
		}


		private void cbTodasManguera_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbTodasManguera.Checked)
				this.txtManguera.Enabled = false;
			else
				this.txtManguera.Enabled = true;		
		}
		#endregion

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			this.EjecutarReporte();
		}
	}
}
