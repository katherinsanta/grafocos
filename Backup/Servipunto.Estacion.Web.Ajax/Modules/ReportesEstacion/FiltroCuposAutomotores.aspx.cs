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
	public class FiltroCuposAutomotores : System.Web.UI.Page
	{
		#region Declaración de Controles

		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Panel pnlcodArticulo;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.DropDownList ddlOrden;
		protected System.Web.UI.WebControls.DropDownList ddlTipo;
		protected System.Web.UI.WebControls.TextBox txtCodigoCliente;
		protected System.Web.UI.WebControls.CheckBox cbTodos;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;        
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
        #region InicializarForma
        private void InicializarForma()
        {
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(258, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(272, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(35, Global.Idioma);            
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            #region poblar RadioButton  ddlTipo
            this.ddlTipo.Items.Clear();
            this.ddlTipo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(273, Global.Idioma), "-1"));
            this.ddlTipo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(322, Global.Idioma), "0"));
            this.ddlTipo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(323, Global.Idioma), "1"));
            this.ddlTipo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(324, Global.Idioma), "2"));
            this.ddlTipo.SelectedValue = "-1";
            #endregion
            ViewState["Control"] = "1";
            #endregion
            
        }
        #endregion
		#region EjecutarReporte
		private void EjecutarReporte()
		{
				try
				{
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,347, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					DataDynamics.ActiveReports.ActiveReport report = null;
					report = new Servipunto.Estacion.Web.Modules.Rpt.InformacionCuposAutomotores(txtCodigoCliente.Text, ddlTipo.SelectedValue);
					Session.Add("LastReport", report);
					Session["Formato"] = ddlOrden.SelectedValue;
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

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Reportes";
			const string opcion = "Automotores";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "CuposAutomotores");
			
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Check Box
		private void cbTodos_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbTodos.Checked)
			{
				this.txtCodigoCliente.Enabled = false;
			}
			else
			{
				this.txtCodigoCliente.Enabled = true;
			}		
		}
		#endregion
	}
}
