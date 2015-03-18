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
using Servipunto.Estacion.Web;
using DataDynamics.ActiveReports.Export.Pdf;

namespace Servipunto.Estacion.Reportes
{
	public class FiltroArticulo : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Calendar FechaFin;
		protected System.Web.UI.WebControls.RadioButtonList TipoReporte;
		protected System.Web.UI.WebControls.Panel pnlcodArticulo;
		protected System.Web.UI.WebControls.RadioButtonList rbltipoArticulo;
		protected System.Web.UI.WebControls.DropDownList cboArticulo;
		protected System.Web.UI.WebControls.Label lblArticulo;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.RadioButtonList rbFormato;
		protected System.Web.UI.WebControls.Label lblEmpleado;
		protected System.Web.UI.WebControls.DropDownList ddlEmpleado;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
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

            return true;
        }
        #endregion

		#region EjecutarReporte
		/// <summary>
		/// Ejecuta el reporte seleccionado
		/// </summary>
		/// Modificación: Se creo un nuevo parametro de consulta "CodigoEmpleado" para las ventas de canastilla
		/// Referencia Documental:  Automatizacion > Solicitud_Cambio _Administrativo_002_GR_SC
		/// Fecha:  26/08/2008
		/// Autor:  Elvis Astaiza Gutierrez
		private void EjecutarReporte()
		{
			if (this.Validar())
			{
				try
				{
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,320, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					DataDynamics.ActiveReports.ActiveReport report = null;
					if(this.rbltipoArticulo.SelectedValue == "Combustible")
					{
                        if (this.TipoReporte.SelectedValue == "Detallado")
                        {
                            if (lblReporte.Text == "<b>Item Sales Report</b>")
                                report = new Servipunto.Estacion.Web.Modules.Rpt.VentasArticuloDetallado(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), cboArticulo.SelectedValue, 1);
                            else
                                report = new Servipunto.Estacion.Web.Modules.Rpt.VentasArticuloDetallado(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), cboArticulo.SelectedValue, 0);
                        }
                        else if (this.TipoReporte.SelectedValue == "Resumido")
                        {
                            if (lblReporte.Text == "<b>Item Sales Report</b>")
                                report = new Servipunto.Estacion.Web.Modules.Rpt.VentasArticuloResumido(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), cboArticulo.SelectedValue, 1);
                            else
                                report = new Servipunto.Estacion.Web.Modules.Rpt.VentasArticuloResumido(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), cboArticulo.SelectedValue, 0);
                        }
					}
					else
					{
                        if (this.TipoReporte.SelectedValue == "Detallado")
                        {
                            if (lblReporte.Text == "<b>Item Sales Report</b>")
                                report = new Servipunto.Estacion.Web.Modules.Rpt.VentasCanastillaDetallado(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), cboArticulo.SelectedValue, ddlEmpleado.SelectedValue, ddlEmpleado.SelectedItem.Text, 1);
                            else
                                report = new Servipunto.Estacion.Web.Modules.Rpt.VentasCanastillaDetallado(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), cboArticulo.SelectedValue, ddlEmpleado.SelectedValue, ddlEmpleado.SelectedItem.Text, 0);
                        }
                        else if (this.TipoReporte.SelectedValue == "Resumido")
                        {
                            if (lblReporte.Text == "<b>Item Sales Report</b>")
                                report = new Servipunto.Estacion.Web.Modules.Rpt.VentasCanastillaResumido(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), cboArticulo.SelectedValue, ddlEmpleado.SelectedValue, ddlEmpleado.SelectedItem.Text, 1);
                            else
                                report = new Servipunto.Estacion.Web.Modules.Rpt.VentasCanastillaResumido(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), cboArticulo.SelectedValue, ddlEmpleado.SelectedValue, ddlEmpleado.SelectedItem.Text, 0);
                        }
					}
					Session["LastReport"] = report;
					Session["Formato"] = rbFormato.SelectedValue;
					Response.Redirect("../Visor/PDF.aspx",false);
				}
				catch (Exception ex)
				{
					this.SetError(ex.Message,false);
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

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Generales";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas Articulo");
			
			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}
			
			return true;
		}
		#endregion

		#region InicializarForma
		private void InicializarForma()
		{
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23710, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1127, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(32, Global.Idioma);
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(35, Global.Idioma);
            lblEmpleado.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(542, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            #region poblar RadioButton  TipoReporte
            this.TipoReporte.Items.Clear();
            this.TipoReporte.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(33, Global.Idioma), "Detallado"));
            this.TipoReporte.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(34, Global.Idioma), "Resumido"));
            this.TipoReporte.SelectedValue = "Resumido";
            this.rbltipoArticulo.Items.Clear();
            this.rbltipoArticulo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(96, Global.Idioma), "Canastilla"));
            this.rbltipoArticulo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(526, Global.Idioma), "Combustible"));
            this.rbltipoArticulo.SelectedValue = "Combustible";
            #endregion
            ViewState["Control"] = "1";
            #endregion            
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
			this.CargarEmpleados();
			this.CargarArticulos(Servipunto.Estacion.Libreria.TipoArticulo.Combustible);
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
			this.rbltipoArticulo.SelectedIndexChanged += new System.EventHandler(this.rbltipoArticulo_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region CargarArticulos
		private void CargarArticulos(Servipunto.Estacion.Libreria.TipoArticulo tipoArticulo)
		{
			Servipunto.Estacion.Libreria.Articulos objArticulos = new Servipunto.Estacion.Libreria.Articulos(tipoArticulo);
			
			this.cboArticulo.DataSource = objArticulos;
			this.cboArticulo.DataTextField = "Descripcion";
			this.cboArticulo.DataValueField = "IdArticulo";
			this.cboArticulo.DataBind();

            this.cboArticulo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0")); 
			
			objArticulos = null;
		}
		#endregion

		#region CargarEmpleados
		/// <summary>
		/// FaltaDocumentar
		/// </summary>
		private void CargarEmpleados()
		{
			Servipunto.Estacion.Libreria.Configuracion.Empleados objEmpleados = new Servipunto.Estacion.Libreria.Configuracion.Empleados();
		
			this.ddlEmpleado.DataSource = objEmpleados;
			this.ddlEmpleado.DataTextField = "NombreEmpleado";
			this.ddlEmpleado.DataValueField = "CodigoEmpleado";
			this.ddlEmpleado.DataBind();

            this.ddlEmpleado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0")); 
			
			ddlEmpleado = null;
		}
		#endregion

		#region Cambio en la Selección del Articulo
		private void rbltipoArticulo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.rbltipoArticulo.SelectedValue == "Combustible")
			{
				lblEmpleado.Visible = false;
				ddlEmpleado.Visible = false;
				this.CargarArticulos(Servipunto.Estacion.Libreria.TipoArticulo.Combustible);
			}
			else
			{
				lblEmpleado.Visible = true;
				ddlEmpleado.Visible = true;
				this.CargarArticulos(Servipunto.Estacion.Libreria.TipoArticulo.Canastilla);				
			}
		}
		#endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }
	}
}
