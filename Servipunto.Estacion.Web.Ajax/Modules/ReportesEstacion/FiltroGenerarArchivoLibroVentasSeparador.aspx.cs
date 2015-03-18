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
	public class FiltroGenerarArchivoLibroVentasSeparador : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.RadioButtonList TipoReporte;
		protected System.Web.UI.WebControls.Label lblTipoReporte;
		protected System.Web.UI.WebControls.DropDownList ddlAno;
		protected System.Web.UI.WebControls.DropDownList ddlMes;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Calendar FechaFin;
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
			const string opcion = "Facturacion";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Exportar Ventas Archivo Plano");
			
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
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,358, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				SqlConnection Conexion = new SqlConnection(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString);				
				if(Conexion.State == ConnectionState.Closed)
					Conexion.Open();

				string Directorio = Server.MapPath("../."); 
				string [] arreglo = System.IO.Directory.GetFiles(Directorio);

				string sqlcomando = "exec SP_Call_PlainGenerator '" + 
					this.FechaInicio.SelectedDate.ToString("yyyyMMdd") + "', '" +
					this.FechaFin.SelectedDate.ToString("yyyyMMdd") + "', '" 
					+ Request.Form["txtSeparador"] + "','" + Directorio + "'" + ", 6,0,0";


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
			catch(Exception ex)
			{
				SetError("Error al generar el archivo... " + ex.Message);

				#region registro del log de errores
				try
				{
					Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
						2, Convert.ToInt64(Session["IdSuceso"].ToString()),   	
						ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno exportando la tabla ventas a un archivo plano. ");
				}
				catch(Exception exx)
				{
					lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
					this.SetError(lblError.Text);

				}
				#endregion



			}
		}
		#endregion

		#region InicializarForma
		private void InicializarForma()
		{
			this.lblReporte.Text = "<b>Exportar Tabla de Ventas a un Archivo Plano</b>";
			this.FechaInicio.SelectedDate = DateTime.Now;
			this.FechaFin.SelectedDate = DateTime.Now;
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
