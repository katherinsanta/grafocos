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
using System.Data.SqlClient;

namespace Servipunto.Estacion.Reportes
{
	public class FiltroVentasArticulo : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.RadioButtonList TipoReporte;
		protected System.Web.UI.WebControls.Label lblTipoReporte;
		protected System.Web.UI.WebControls.DropDownList ddlAno;
		protected System.Web.UI.WebControls.DropDownList ddlMes;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
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
				{
					this.lblError.Visible = false;
					this.EjecutarSP();
				}
			}
			else
			{
				this.VerificarPermisos();
				this.InicializarForma();
			}
		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Interfaz Contable";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Generacion Archivo Plano de Ventas por Articulo");
			
			if (!permiso)
			{
				this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.");
				this.MyForm.Visible = false;
				return false;
			}
			
			return true;
		}
		#endregion

		#region EjecutarSP
		private void EjecutarSP()
		{
			this.lblError.Visible = false;
			try
			{
				SqlConnection Conexion = new SqlConnection(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString);
				
				if(Conexion.State == ConnectionState.Closed)
					Conexion.Open();

				string Directorio = Server.MapPath("../."); 
				string [] arreglo = System.IO.Directory.GetFiles(Directorio);

				string sqlcomando = "exec SP_Call_PlainGenerator '" + 
					this.FechaInicio.SelectedDate.ToString("yyyyMMdd") + "', '" +
					this.FechaInicio.SelectedDate.ToString("yyyyMMdd") + "', '" 
					+ Request.Form["txtSeparador"] + "','" + Directorio + "'"
					+ ",3, " + 0 + ", " + Request.Form["txtNum_Tur"];

				SqlCommand Comando = new SqlCommand(sqlcomando,Conexion);
				Comando.CommandType = CommandType.Text;
				Comando.ExecuteNonQuery();
				arreglo = System.IO.Directory.GetFiles(Directorio);
				Conexion.Close();
				
				arreglo = System.IO.Directory.GetFiles(Directorio);

				if(arreglo.Length > 0)
				{
					Response.Clear();
					Response.ContentType = "text/plain";
					Response.AppendHeader( "Content-Disposition", "attachment; filename =" + arreglo[0].Substring(arreglo[0].LastIndexOf("\\") + 1)); 
					Response.WriteFile(arreglo[0]);
					Response.End();
				}
				else
				{
					this.SetError("No se creo el archivo.");
				}

			}
			catch(Exception)
			{
				SetError("Error al generar el archivo...");
			}
		}
		#endregion

		#region InicializarForma
		private void InicializarForma()
		{
			this.lblReporte.Text = "<b>Generar Archivo Plano de Ventas por Artículo</b>";
			this.FechaInicio.SelectedDate = DateTime.Now;
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
