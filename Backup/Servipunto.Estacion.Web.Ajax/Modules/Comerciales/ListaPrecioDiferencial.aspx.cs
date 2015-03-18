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

namespace Servipunto.Estacion.Web.Modules.Comerciales
{
	public class ListaPrecioDiferencial : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblFormTitle;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected System.Web.UI.WebControls.LinkButton lbGuardar;
		protected System.Web.UI.WebControls.DropDownList ddlArticulo;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected Libreria.Comercial.AutoCombustible _objCombustible = null;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Label Label1;		
		#endregion

		#region Page Load Event
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
			if (!this.IsPostBack)
				this.InicializarForma();
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
			this.lbGuardar.Click += new System.EventHandler(this.lbGuardar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Inicialización del Formulario
		private void InicializarForma()
        {
            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma);
			#region Modo de Inserción
			try
			{
                this.lblFormTitle.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2068, Global.Idioma) + "</b>";
				this.lblBack.NavigateUrl = "ListaPreciosDiferenciales.aspx";
                this.lbGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
				if(Request.QueryString["IdLista"] != null && Request.QueryString["IdLista"] != "")
					txtCodigo.Text = Request.QueryString["IdLista"];
			}				
			catch(Exception ex)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message, false);
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
			#endregion
		}
		#endregion

		#region Boton Guardar
		private void lbGuardar_Click(object sender, System.EventArgs e)
		{
			if(txtCodigo.Text == "")
			{
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2065, Global.Idioma), false);
				return;
			}
			else
			{
				try
				{
					if(int.Parse(txtCodigo.Text) < 1)
					{
                        SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2066, Global.Idioma), false);
						return;
					}
				}
				catch(Exception ex)
				{
                    SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2067, Global.Idioma), false);
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
					return;
				}
			}
			Response.Redirect("PrecioDiferencial.aspx?IdLista=" + txtCodigo.Text + "&Cod=1");
		}
		#endregion
	}
}
