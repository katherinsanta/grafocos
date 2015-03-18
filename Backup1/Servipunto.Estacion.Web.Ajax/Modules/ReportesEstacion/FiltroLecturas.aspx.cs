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
	public class FiltroLecturas : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Calendar FechaFin;
		protected System.Web.UI.WebControls.TextBox txtManguera;
		protected System.Web.UI.WebControls.CheckBox cbTodas;
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
				if (Request.Form["__EVENTTARGET"].Length == 0)
					this.EjecutarReporte();
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

			try
			{
				if(!this.cbTodas.Checked)
					int.Parse(this.txtManguera.Text);	
			}
			catch(Exception)
			{
				this.SetError("El campo manguera debe ser numerico!");
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

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas Lecturas");
			
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
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,321, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					if(this.txtManguera.Text == "")
						this.txtManguera.Text = "0";
					DataDynamics.ActiveReports.ActiveReport report = 
					new Servipunto.Estacion.Web.Modules.Rpt.VentasLecturas(this.FechaInicio.SelectedDate, this.FechaFin.SelectedDate,int.Parse(this.txtManguera.Text),this.cbTodas.Checked);
					
					Session.Add("LastReport", report);
					Response.Redirect("../Visor/PDF.aspx",false);
				}
				catch (Exception ex)
				{
					this.SetError(ex.Message);

					#region registro del log de errores
					try
					{
						Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
							2, Convert.ToInt64(Session["IdSuceso"].ToString()),   	
							ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el reporte de ventas por lecturas. ");
					}
					catch(Exception exx)
					{
						lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
						this.SetError(lblError.Text);

					}
					#endregion



				}
			}
		}
		#endregion

		#region InicializarForma
		private void InicializarForma()
		{
			this.lblReporte.Text = "<b>Reporte de Ventas por Mangueras</b>";
			this.FechaInicio.SelectedDate = System.DateTime.Now;
			this.FechaFin.SelectedDate = System.DateTime.Now;
			cbTodas_CheckedChanged(null,null);
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
			this.cbTodas.CheckedChanged += new System.EventHandler(this.cbTodas_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Evento Todas las Islas
		private void cbTodas_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbTodas.Checked)
			{
				this.txtManguera.Enabled = false;
			}
			else
			{
				this.txtManguera.Enabled = true;
			}
		}
		#endregion
	}
}
