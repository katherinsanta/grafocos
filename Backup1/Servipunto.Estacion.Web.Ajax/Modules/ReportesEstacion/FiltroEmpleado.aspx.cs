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
	public class FiltroEmpleado : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
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

            if (!this.cbTodosEmpleados.Checked)
            {
                try
                {
                    int.Parse(this.txtEmpleado.Text);
                }
                catch (Exception)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2325, Global.Idioma),false);
                    return false;
                }
            }

            if (!this.cbTodosTurnos.Checked)
            {
                try
                {
                    int.Parse(this.txtTurno.Text);
                }
                catch (Exception)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2326, Global.Idioma), false);
                    return false;
                }
            }

            if (!this.cbTodasManguera.Checked)
            {
                try
                {
                    int.Parse(this.txtManguera.Text);
                }
                catch (Exception)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2327, Global.Idioma), false);
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
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,322, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					if(this.txtEmpleado.Text == "")
						this.txtEmpleado.Text = "0";
					if(this.txtTurno.Text == "")
						this.txtTurno.Text = "0";
					if(this.txtManguera.Text == "")
						this.txtManguera.Text = "0";
					DataDynamics.ActiveReports.ActiveReport report = null;
					//report = new Servipunto.Estacion.Web.Modules.Rpt.VentasporEmpleado(this.FechaInicio.SelectedDate, this.FechaFin.SelectedDate, int.Parse( this.txtEmpleado.Text ), this.cbTodosEmpleados.Checked, int.Parse( this.txtTurno.Text ), this.cbTodosTurnos.Checked, int.Parse( cboIsla.SelectedValue ),int.Parse( this.txtManguera.Text ), this.cbTodasManguera.Checked);
					if (this.TipoReporte.SelectedValue == "Detallado")
                        report = new Servipunto.Estacion.Web.Modules.Rpt.VentasPorEmpleadoTurnoIslaManguera(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), int.Parse(this.txtEmpleado.Text), this.cbTodosEmpleados.Checked, int.Parse(this.txtTurno.Text), this.cbTodosTurnos.Checked, int.Parse(cboIsla.SelectedValue), int.Parse(this.txtManguera.Text), this.cbTodasManguera.Checked);												
					else if (this.TipoReporte.SelectedValue == "Resumido")
                        report = new Servipunto.Estacion.Web.Modules.Rpt.VentasPorEmpleadoTurnoIslaMangueraResumido(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), int.Parse(this.txtEmpleado.Text), this.cbTodosEmpleados.Checked, int.Parse(this.txtTurno.Text), this.cbTodosTurnos.Checked, int.Parse(cboIsla.SelectedValue), int.Parse(this.txtManguera.Text), this.cbTodasManguera.Checked);
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
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(24, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(542, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(32, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(44, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
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
            this.cboIsla.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0"));
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
			this.cbTodosEmpleados.CheckedChanged += new System.EventHandler(this.cbTodos_CheckedChanged);
			this.cbTodosTurnos.CheckedChanged += new System.EventHandler(this.cbTodosTurnos_CheckedChanged);
			this.cbTodasManguera.CheckedChanged += new System.EventHandler(this.cbTodasManguera_CheckedChanged);
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
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }
	}
}
