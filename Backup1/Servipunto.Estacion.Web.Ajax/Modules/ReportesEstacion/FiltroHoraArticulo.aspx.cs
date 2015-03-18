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

namespace Servipunto.Estacion.Web.Modules.ReportesEstacion
{
	/// <summary>
	/// Descripción breve de FiltroHoraArticulo.
	/// </summary>
	public class FiltroHoraArticulo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.DropDownList cboHora;
		protected System.Web.UI.WebControls.RadioButtonList TipoReporte;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
		protected System.Web.UI.WebControls.Calendar FechaFin;
		protected System.Web.UI.WebControls.DropDownList cboArticulos;
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
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (this.IsPostBack)
			{
                CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                CalendarExtender2.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
				if (Request.Form["__EVENTTARGET"].Length == 0)
					this.EjecutarReporte();
				if(Cache["EstadoSeleccion"] != null)
					this.cboHora.SelectedIndex = (int)Cache["EstadoSeleccion"];
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

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Periodo de Tiempo";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas Hora Especifica");
			
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
			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,331, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				DataDynamics.ActiveReports.ActiveReport report = null;
				if (this.TipoReporte.SelectedValue == "Detallado")
                    report = new Servipunto.Estacion.Web.Modules.Rpt.VentasHoraArticuloDetallado(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), Convert.ToInt32(this.cboHora.SelectedValue), Convert.ToInt32(this.cboArticulos.SelectedValue));
				else if (this.TipoReporte.SelectedValue == "Resumido")
                    report = new Servipunto.Estacion.Web.Modules.Rpt.VentasHoraArticulo(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text), Convert.ToInt32(this.cboHora.SelectedValue), Convert.ToInt32(this.cboArticulos.SelectedValue));

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
		#endregion

		#region InicializarForma
		private void InicializarForma()
		{
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(179, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(181, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(32, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            #region poblar RadioButton  TipoReporte
            this.TipoReporte.Items.Clear();
            this.TipoReporte.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(33, Global.Idioma), "Detallado"));
            this.TipoReporte.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(34, Global.Idioma), "Resumido"));
            this.TipoReporte.SelectedValue = "Resumido";
            #endregion
            #region poblar RadioButton  cboHora
            this.cboHora.Items.Clear();
            this.cboHora.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "24"));
            this.cboHora.Items.Insert(0, new ListItem("12 a.m.", "0"));
            this.cboHora.Items.Insert(0, new ListItem("1 a.m.", "1"));
            this.cboHora.Items.Insert(0, new ListItem("2 a.m.", "2"));
            this.cboHora.Items.Insert(0, new ListItem("3 a.m.", "3"));
            this.cboHora.Items.Insert(0, new ListItem("4 a.m.", "4"));
            this.cboHora.Items.Insert(0, new ListItem("5 a.m.", "5"));
            this.cboHora.Items.Insert(0, new ListItem("6 a.m.", "6"));
            this.cboHora.Items.Insert(0, new ListItem("7 a.m.", "7"));
            this.cboHora.Items.Insert(0, new ListItem("8 a.m.", "8"));
            this.cboHora.Items.Insert(0, new ListItem("9 a.m.", "9"));
            this.cboHora.Items.Insert(0, new ListItem("10 a.m.", "10"));
            this.cboHora.Items.Insert(0, new ListItem("11 a.m.", "11"));
            this.cboHora.Items.Insert(0, new ListItem("12 p.m.", "12"));
            this.cboHora.Items.Insert(0, new ListItem("1 p.m.", "13"));
            this.cboHora.Items.Insert(0, new ListItem("2 p.m.", "14"));
            this.cboHora.Items.Insert(0, new ListItem("3 p.m.", "15"));
            this.cboHora.Items.Insert(0, new ListItem("4 p.m.", "16"));
            this.cboHora.Items.Insert(0, new ListItem("5 p.m.", "17"));
            this.cboHora.Items.Insert(0, new ListItem("6 p.m.", "18"));
            this.cboHora.Items.Insert(0, new ListItem("7 p.m.", "19"));
            this.cboHora.Items.Insert(0, new ListItem("8 p.m.", "20"));
            this.cboHora.Items.Insert(0, new ListItem("9 p.m.", "21"));
            this.cboHora.Items.Insert(0, new ListItem("10 p.m.", "22"));
            this.cboHora.Items.Insert(0, new ListItem("11 p.m.", "23"));
            this.cboHora.SelectedValue = "24";
            #endregion
            ViewState["Control"] = "1";
            #endregion            
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
			CargarArticulos();
		}
		#endregion

		#region CargarArticulos
		private void CargarArticulos()
		{
			Servipunto.Estacion.Libreria.Articulos objArticulos = new Servipunto.Estacion.Libreria.Articulos(Servipunto.Estacion.Libreria.TipoArticulo.Combustible);			
			cboArticulos.DataSource = objArticulos;
			cboArticulos.DataTextField = "Descripcion";
			cboArticulos.DataValueField = "IdArticulo";
			cboArticulos.DataBind();
            cboArticulos.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "0"));
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
			this.FechaInicio.SelectionChanged += new System.EventHandler(this.FechaInicio_SelectionChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Cuando se selecciona una fecha diferente en el calendario
		private void FechaInicio_SelectionChanged(object sender, System.EventArgs e)
		{
			Cache["EstadoSeleccion"] = this.cboHora.SelectedIndex;
		}
		#endregion

	
	
		
	}

}
