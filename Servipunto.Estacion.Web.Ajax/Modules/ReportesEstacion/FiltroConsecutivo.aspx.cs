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
using Servipunto.Estacion.Web;

namespace Servipunto.Estacion.Reportes
{
	public class FiltroConsecutivo : System.Web.UI.Page
	{
		#region Declaración de Controles
		
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Calendar FechaFin;
		protected System.Web.UI.WebControls.CheckBox cbTodos;
		protected System.Web.UI.WebControls.TextBox txtConsecutivos;
		protected System.Web.UI.WebControls.CheckBox cbTodosSurtidores;
		protected System.Web.UI.WebControls.CheckBox cbTodosTurnos;
		protected System.Web.UI.WebControls.TextBox txtSurtidor;
		protected System.Web.UI.WebControls.TextBox txtTurno;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected AjaxControlToolkit.CalendarExtender CalendarExtender1;
        protected AjaxControlToolkit.CalendarExtender CalendarExtender2;
        protected System.Web.UI.WebControls.TextBox txtFechaInicial;
        protected System.Web.UI.WebControls.TextBox txtFechaFin;
		#endregion

        #region Page_PreLoad Event
        /// <summary>
        /// Adaptacion de traduccion al formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_PreLoad(object sender, System.EventArgs e)
        {
            ViewState["Control"] = "0";
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
        #region Form Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (this.IsPostBack)
            {
                CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                CalendarExtender2.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (Request.Form["__EVENTTARGET"].Length == 0)
                    this.EjecutarReporte();
            }
            else
            {
                if (ViewState["Control"].ToString() != "1")
                {
                    this.VerificarPermisos();
                    this.InicializarForma();
                }
            }
        }
        #endregion

		#region Validar
		private bool Validar()
		{
            if (Convert.ToDateTime(this.txtFechaInicial.Text) > Convert.ToDateTime(this.txtFechaFin.Text))
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1962, Global.Idioma), false);
                return false;
            }
			
			try
			{
				if(!this.cbTodos.Checked)
					int.Parse(this.txtConsecutivos.Text);	
			}
			catch(Exception)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), false);
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

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas Consecutivo");
			
			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
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
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,354, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					if(this.txtConsecutivos.Text == "")
						this.txtConsecutivos.Text = "0";
					if(this.txtSurtidor.Text == "")
						this.txtSurtidor.Text = "0";
					if(this.txtTurno.Text == "")
						this.txtTurno.Text = "0";

					DataDynamics.ActiveReports.ActiveReport report =
                    new Servipunto.Estacion.Web.Modules.Rpt.VentasConsecutivo(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), int.Parse(this.txtConsecutivos.Text), this.cbTodos.Checked, int.Parse(this.txtSurtidor.Text), this.cbTodosSurtidores.Checked, int.Parse(this.txtTurno.Text), this.cbTodosTurnos.Checked);
					
					Session.Add("LastReport", report);
					Response.Redirect("../Visor/PDF.aspx",false);
				}
				catch (Exception ex)
				{
                    this.SetError(ex.Message, false);
                    #region registro del log de errores
                    try
                    {
                        Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                            2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                            ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1757, Global.Idioma) + ex.StackTrace, Libreria.Configuracion.PalabrasIdioma.Traduccion(1758, Global.Idioma));
                    }
                    catch (Exception exx)
                    {
                        lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1760, Global.Idioma) + ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1759, Global.Idioma) + exx.Message;
                    }
                    #endregion   
				}
			}
		}
		#endregion

		#region InicializarForma
		private void InicializarForma()
		{
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(389, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(390, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(75, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);            
            ViewState["Control"] = "1";
            #endregion            
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
			cbTodos_CheckedChanged(null,null);
			cbTodosSurtidores_CheckedChanged(null,null);
			cbTodosTurnos_CheckedChanged(null,null);
		}
		#endregion

        #region SetError and ClearError
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
            if (hideForm)
                this.pnlForm.Visible = false;

        }

        private void ClearError()
        {
            this.lblError.Text = "";
            this.lblError.Visible = false;
        }
        #endregion
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }

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
			this.cbTodosSurtidores.CheckedChanged += new System.EventHandler(this.cbTodosSurtidores_CheckedChanged);
			this.cbTodos.CheckedChanged += new System.EventHandler(this.cbTodos_CheckedChanged);
			this.cbTodosTurnos.CheckedChanged += new System.EventHandler(this.cbTodosTurnos_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Todos los Consecutivos
		private void cbTodos_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbTodos.Checked)
				this.txtConsecutivos.Enabled = false;
			else
				this.txtConsecutivos.Enabled = true;
		}
		#endregion

		#region Todos los Surtidores
		private void cbTodosSurtidores_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbTodosSurtidores.Checked)
				this.txtSurtidor.Enabled = false;
			else
				this.txtSurtidor.Enabled = true;
		}
		#endregion

		#region Todos los Turnos
		private void cbTodosTurnos_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbTodosTurnos.Checked)
				this.txtTurno.Enabled = false;
			else
				this.txtTurno.Enabled = true;
		}
		#endregion
	}
}
