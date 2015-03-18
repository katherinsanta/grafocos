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
using Servipunto.Estacion.Web;

namespace Servipunto.Estacion.Reportes
{
	public class ModificarNITVentas : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Panel pnlcodArticulo;
		protected System.Web.UI.WebControls.TextBox txtNuevoNIT;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblNombre;
        protected System.Web.UI.WebControls.Label lblInicial;
        protected System.Web.UI.WebControls.Label lblFinal;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label lblNewNIT;
        protected System.Web.UI.WebControls.Label lblPrefijo;
        protected System.Web.UI.WebControls.Label lblConsInicial;
        protected System.Web.UI.WebControls.Label lblConsFinal;
		protected System.Web.UI.HtmlControls.HtmlTableCell SeccionResultados;
		protected System.Web.UI.WebControls.LinkButton lbResultado;
		protected System.Web.UI.WebControls.TextBox txtConsecInicial;
		protected System.Web.UI.WebControls.TextBox txtConsecFinal;
		protected System.Web.UI.WebControls.TextBox txtPrefijo;
		protected System.Web.UI.WebControls.Calendar FechaInicial;
		protected System.Web.UI.WebControls.Calendar FechaFinal;
		protected System.Web.UI.WebControls.CheckBox cbFecha;
		protected System.Web.UI.WebControls.Repeater Results;
		
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
			if(!this.IsPostBack)
			{
				this.VerificarPermisos();
				this.FechaInicial.SelectedDate = DateTime.Now;
				this.FechaFinal.SelectedDate = DateTime.Now;
				cbFecha_CheckedChanged(null, null);
				this.Buscar();
			}

			if (Request.Form["__EVENTTARGET"] == "lbResultado")
			{
				CambiarNIT();
				this.Buscar();
			}
            Traducir();
			
		}
		#endregion

		#region SetError
		private void SetError(string message)
		{
			this.lblError.Visible = true;
			this.lblError.Text = message;
		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Facturacion";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar Sin NIT");
			
			if (!permiso)
			{
                this.SetError("<b>Access Denied.</b><br><br>Your user account does not have sufficient privileges to access this page.");
				this.MyForm.Visible = false;
				return false;
			}
			
			return true;
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
			this.txtNuevoNIT.TextChanged += new System.EventHandler(this.txtNuevoNIT_TextChanged);
			this.cbFecha.CheckedChanged += new System.EventHandler(this.cbFecha_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Cargar Repeater
		private void Buscar()
		{
			try
			{
				SqlConnection Conexion = new SqlConnection(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString);
				
				if(Conexion.State == ConnectionState.Closed)
					Conexion.Open();

				DataTable Ventas = new DataTable("Ventas");
				SqlDataAdapter Adapter = new SqlDataAdapter("SP_Bol_VentasNit",Conexion);
				Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
				Adapter.SelectCommand.Parameters.Add("@Rpt",1);
				Adapter.SelectCommand.Parameters.Add("@DC",1);
				Adapter.SelectCommand.Parameters.Add("@IniDate",((DateTime)Session["FechaInicial"]));
				Adapter.SelectCommand.Parameters.Add("@EndDate",((DateTime)Session["FechaFinal"]));
				Adapter.SelectCommand.Parameters.Add("@IniConsec",System.Data.SqlTypes.SqlInt32.Null);
				Adapter.SelectCommand.Parameters.Add("@EndConsec",System.Data.SqlTypes.SqlInt32.Null);
				Adapter.SelectCommand.Parameters.Add("@Nit",System.Data.SqlTypes.SqlString.Null);
				Adapter.SelectCommand.Parameters.Add("@Prefijo",System.Data.SqlTypes.SqlString.Null);

				Adapter.Fill(Ventas);

				Results.DataSource = Ventas;
				Results.DataBind();
				Conexion.Close();
			}
			catch(Exception)
			{
                SetError("Error connecting to database.");
			}
		}
		#endregion

		#region Cuando se presiona enter en el cuadro de texto
		private void txtNuevoNIT_TextChanged(object sender, System.EventArgs e)
		{
			Buscar();
		}
		#endregion

		#region Cambiar el Nit a las ventas
		private void CambiarNIT()
		{
			if(this.txtNuevoNIT.Text == "")
			{
                SetError("You must enter a NIT.");
				return;
			}

			try
			{
				if(!this.cbFecha.Checked)
				{
					if(this.txtConsecInicial.Text != "")
						int.Parse(this.txtConsecInicial.Text);
					if(this.txtConsecFinal.Text != "")
						int.Parse(this.txtConsecFinal.Text);
				}
			}
			catch(Exception)
			{
                SetError("The consecutive must be numeric.");
				return;
			}

			try
			{
				SqlConnection Conexion = new SqlConnection(Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString);
				
				if(Conexion.State == ConnectionState.Closed)
					Conexion.Open();
				
				string sqlcomando;

				if(this.cbFecha.Checked)
					sqlcomando = "exec SP_Bol_VentasNit 0, 1, '" + this.FechaInicial.SelectedDate.ToString("yyyyMMdd") + "', '" + this.FechaFinal.SelectedDate.ToString("yyyyMMdd") + "',0,0, " + this.txtNuevoNIT.Text + ", '"+ this.txtPrefijo.Text + "'";
				else
					sqlcomando = "exec SP_Bol_VentasNit 0, 0, '2006-01-01', '2006-01-03'," + this.txtConsecInicial.Text + "," + this.txtConsecFinal.Text + ", '" + this.txtNuevoNIT.Text + "'" + ", '"+ this.txtPrefijo.Text + "'";
				
				SqlCommand Comando = new SqlCommand(sqlcomando,Conexion);
				Comando.CommandType = CommandType.Text;
				Comando.ExecuteNonQuery();				
				Conexion.Close();
			}
			catch(Exception ex)
			{
                SetError("Failed to execute store procedure in the database. " + ex.Message);

				#region registro del log de errores
				try
				{
					Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 
						2, Convert.ToInt64(Session["IdSuceso"].ToString()),   	
						ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno al actualizar los datos. ");
				}
				catch(Exception exx)
				{
                    lblError.Text += " The system could not store the log of an error that occurred in the system. Previous Error: " + ex.Message + " ErrorPresente: " + exx.Message;
					this.SetError(lblError.Text);

				}
				#endregion

			}
		}
		#endregion

		#region Actualización por fechas
		private void cbFecha_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbFecha.Checked)
			{
				this.txtConsecInicial.Enabled = false;
				this.txtConsecFinal.Enabled = false;
				this.FechaInicial.Enabled = true;
				this.FechaFinal.Enabled = true;
			}
			else
			{
				this.txtConsecInicial.Enabled = true;
				this.txtConsecFinal.Enabled = true;
				this.FechaInicial.Enabled = false;
				this.FechaFinal.Enabled = false;
			}
		}
		#endregion

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 14/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            lblInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(249, Global.Idioma)+":";
            lblFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(253, Global.Idioma)+":";
            lbResultado.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(788, Global.Idioma) + "...";
            lblReporte.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23722, Global.Idioma);
            lblNombre.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23722, Global.Idioma);
            lblNewNIT.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23724, Global.Idioma)+":";
            lblPrefijo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1513, Global.Idioma)+":";
            lblConsInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1514, Global.Idioma)+":";
            lblConsFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1515, Global.Idioma)+":";
            cbFecha.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23723, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(38, Global.Idioma);
        }
        #endregion
	}
}