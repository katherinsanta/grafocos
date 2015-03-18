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
using Servipunto.Estacion.Web;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Export.Pdf;

namespace Servipunto.Estacion.Reportes
{
	public class FiltroMesReal : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.DropDownList cboMes;
		protected System.Web.UI.WebControls.Label lblError;
        
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Panel pnlForm;
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

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Periodo de Tiempo Real";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Ventas Mes Especifico");
			
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
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,336, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				DataDynamics.ActiveReports.ActiveReport report = null;
				//Por defecto el reporte es resumido
				string strYear = DateTime.Now.Year.ToString();
				string strFechaInicial = strYear+"/"+this.cboMes.SelectedValue.ToString()+"/01";
				string strFechaFinal = null;
				
				if (Convert.ToInt32(this.cboMes.SelectedValue) == 1 || Convert.ToInt32(this.cboMes.SelectedValue) == 3 || Convert.ToInt32(this.cboMes.SelectedValue) == 5 || Convert.ToInt32(this.cboMes.SelectedValue) == 7 || Convert.ToInt32(this.cboMes.SelectedValue) == 8 || Convert.ToInt32(this.cboMes.SelectedValue) == 10 || Convert.ToInt32(this.cboMes.SelectedValue) == 12)
					strFechaFinal = strYear+"/"+this.cboMes.SelectedValue.ToString()+"/31";
				else
				if (Convert.ToInt32(this.cboMes.SelectedValue) == 2)
					strFechaFinal = strYear+"/"+this.cboMes.SelectedValue.ToString()+"/28";
				else
				if (Convert.ToInt32(this.cboMes.SelectedValue) == 4 || Convert.ToInt32(this.cboMes.SelectedValue) == 6 || Convert.ToInt32(this.cboMes.SelectedValue) == 9 || Convert.ToInt32(this.cboMes.SelectedValue) == 11)
					strFechaFinal = strYear+"/"+this.cboMes.SelectedValue.ToString()+"/30";
								
				report = new Servipunto.Estacion.Web.Modules.Rpt.VentasMesRealResumido(Convert.ToDateTime(strFechaInicial), Convert.ToDateTime(strFechaFinal), Convert.ToInt32(this.cboMes.SelectedValue));
				//Actualiza la variable de sesión
				Session.Add("LastReport", report);
				//Envía el reporte al pdf
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
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(178, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(243, Global.Idioma);
            
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            #region poblar RadioButton  cboMes
            this.cboMes.Items.Clear();
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2291, Global.Idioma), "1"));
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2292, Global.Idioma), "2"));
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2293, Global.Idioma), "3"));
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2294, Global.Idioma), "4"));
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2295, Global.Idioma), "5"));
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2296, Global.Idioma), "6"));
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2297, Global.Idioma), "7"));
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2298, Global.Idioma), "8"));
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2299, Global.Idioma), "9"));
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2300, Global.Idioma), "10"));
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2301, Global.Idioma), "11"));
            this.cboMes.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2302, Global.Idioma), "12"));
            this.cboMes.SelectedValue = "1";
            #endregion
            ViewState["Control"] = "1";
            #endregion            
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	}
}
