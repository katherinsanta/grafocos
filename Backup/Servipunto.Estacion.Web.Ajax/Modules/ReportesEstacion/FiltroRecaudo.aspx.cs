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
	public class FiltroRecaudo : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Calendar FechaFin;
		protected System.Web.UI.WebControls.RadioButtonList TipoReporte;
		protected System.Web.UI.WebControls.Panel pnlcodArticulo;
		protected System.Web.UI.WebControls.TextBox txtCodigoCliente;
		protected System.Web.UI.WebControls.CheckBox cbTodos;
		protected System.Web.UI.WebControls.TextBox txtAutomotor;
		protected System.Web.UI.WebControls.TextBox txtFinanciera;
		protected System.Web.UI.WebControls.CheckBox cbTodosAutomotores;
		protected System.Web.UI.WebControls.CheckBox cbTodasFinancieras;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label8;
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
			this.txtCodigoCliente.Text = this.txtCodigoCliente.Text.Trim();
			this.txtAutomotor.Text = this.txtAutomotor.Text.Trim();
			this.txtFinanciera.Text = this.txtFinanciera.Text.Trim();

            if (Convert.ToDateTime(this.txtFechaInicial.Text) > Convert.ToDateTime(this.txtFechaFin.Text))
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1962, Global.Idioma), false);
                return false;
            }

			if(this.cbTodos.Checked == false && this.txtCodigoCliente.Text.Trim() == "")
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2337, Global.Idioma), false);
				return false;
			}

			if(this.cbTodosAutomotores.Checked == false && this.txtAutomotor.Text.Trim() == "")
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2338, Global.Idioma), false);
				return false;
			}

			if(this.cbTodasFinancieras.Checked == false && this.txtFinanciera.Text.Trim() == "")
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2339, Global.Idioma), false);
				return false;
			}
			return true;
		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Reportes de Recaudos de Ventas";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Recaudo Ventas");
			
			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                this.pnlForm.Visible = false;

                //this.MyForm.Visible = false;
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
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,360, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					if(this.txtFinanciera.Text == "")
						this.txtFinanciera.Text = "0";

					if (this.TipoReporte.SelectedValue == "Detallado")
                        report = new Servipunto.Estacion.Web.Modules.Rpt.VentasRecaudoClienteAutomotorFinancieraDetallado(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), int.Parse(this.txtFinanciera.Text), this.cbTodasFinancieras.Checked, this.txtAutomotor.Text, this.cbTodosAutomotores.Checked, this.txtCodigoCliente.Text, this.cbTodos.Checked);
					else if (this.TipoReporte.SelectedValue == "Resumido")
                        report = new Servipunto.Estacion.Web.Modules.Rpt.VentasRecaudoClienteAutomotorFinancieraResumido(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), int.Parse(this.txtFinanciera.Text), this.cbTodasFinancieras.Checked, this.txtAutomotor.Text, this.cbTodosAutomotores.Checked, this.txtCodigoCliente.Text, this.cbTodos.Checked);
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
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(420, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(256, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(32, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(362, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(424, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            #region poblar RadioButton  TipoReporte
            this.TipoReporte.Items.Clear();
            this.TipoReporte.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(33, Global.Idioma), "Detallado"));
            this.TipoReporte.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(34, Global.Idioma), "Resumido"));
            this.TipoReporte.SelectedValue = "Resumido";
            #endregion
            ViewState["Control"] = "1";
            #endregion            
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
			cbTodos_CheckedChanged(null,null);
			TodosAutomotores_CheckedChanged(null,null);
			TodasFinancieras_CheckedChanged(null,null);
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
			this.cbTodos.CheckedChanged += new System.EventHandler(this.cbTodos_CheckedChanged);
			this.cbTodosAutomotores.CheckedChanged += new System.EventHandler(this.TodosAutomotores_CheckedChanged);
			this.cbTodasFinancieras.CheckedChanged += new System.EventHandler(this.TodasFinancieras_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Seleccionar Todos los clientes o automotores o financieras
		private void cbTodos_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbTodos.Checked)
				this.txtCodigoCliente.Enabled = false;
			else
				this.txtCodigoCliente.Enabled = true;
		}
		

		private void TodosAutomotores_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbTodosAutomotores.Checked)
				this.txtAutomotor.Enabled = false;
			else
				this.txtAutomotor.Enabled = true;
		}


		private void TodasFinancieras_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbTodasFinancieras.Checked)
				this.txtFinanciera.Enabled = false;
			else
				this.txtFinanciera.Enabled = true;
		}
		#endregion
	}
}
