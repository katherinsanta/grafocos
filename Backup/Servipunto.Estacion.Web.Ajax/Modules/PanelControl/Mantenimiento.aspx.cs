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

namespace Servipunto.Estacion.Web.Modules.PanelControl
{
	public class Mantenimiento : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.WebControls.TextBox txtBaseDatos;
		protected System.Web.UI.WebControls.Button btnCrearCopia;
		protected System.Web.UI.WebControls.TextBox txtRuta;
		protected System.Web.UI.WebControls.Button btnIndexar;
		protected System.Web.UI.WebControls.Button btnRestablecerLog;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Panel pnlForm;

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
			lblError.Text = "";
			if (!this.IsPostBack)
			{
				if (Request.UrlReferrer != null)
					this.lblBack.NavigateUrl = Request.UrlReferrer.ToString();
				else
					this.lblBack.NavigateUrl = "Default.aspx";

				this.InicializarForma();
                Traduccion();
			}
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
			this.btnCrearCopia.Click += new System.EventHandler(this.btnCrearCopia_Click);
			this.btnIndexar.Click += new System.EventHandler(this.btnIndexar_Click);
			this.btnRestablecerLog.Click += new System.EventHandler(this.btnRestablecerLog_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos(string accion)
		{
			const string modulo = "Panel de Control";
			const string opcion = "Mantenimiento";
			bool permiso;

			permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, accion);

			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}
			
			return true;
		}
		#endregion
		
		#region Inicialización del Formulario
		private void InicializarForma()
		{
            VerificarPermisos("Consultar Pag");
		}
		#endregion

		#region Validar
		private bool Validar()
		{/*
			this.ClearError();
			if (this.txtCodigo.Text.Trim().Length != 0)
			{
				try
				{
					Int16.Parse(this.txtCodigo.Text.Trim());
				}
				catch
				{
					this.SetError("El Codigo debe de ser un numero entero valido!", false);
					return false;
				}
			}
			else
			{
				this.SetError("El Codigo no puede ser una cadena vacia!", false);
				return false;
			}
			if (this.txtNombre.Text.Trim().Length == 0)
			{
				this.SetError("El nombre no puede ser una cadena vacia!", false);
				return false;
			}
			*/
			return true;
		}
		#endregion

		#region Método DecryptText
		/// <summary>
		/// Desencripta el query string 
		/// </summary>
		/// <param name="strText">texto a desencriptar</param>
		/// <returns>texto desencriptado</returns>
		private string DecryptText(string strText)
		{	
			return Servipunto.Libreria.Cryptography.DecryptQueryString(strText, "!#$a54?3");
		}
		#endregion

		#region Método EncryptText
		/// <summary>
		/// encripta el dato del querystring
		/// </summary>
		/// <param name="strText">texto a encriptar</param>
		/// <returns>texto encriptado</returns>
		public string EncryptText(string strText)
		{
			return Servipunto.Libreria.Cryptography.EncryptQueryString(strText, "!#$a54?3");
		}
		#endregion

		
		#region crear copia
		private void btnCrearCopia_Click(object sender, System.EventArgs e)
		{
			Libreria.Configuracion.Estacion objEstacion;
			Libreria.Configuracion.Estaciones objEstaciones;
			if (!this.VerificarPermisos("Crear Backup"))
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return;
			}


			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,520, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				objEstaciones =  new Servipunto.Estacion.Libreria.Configuracion.Estaciones();		
				objEstacion = objEstaciones[0];
				txtRuta.Text = "c:\\Servipunto\\BackUp\\" + DateTime.Now.ToString("yyyyMMdd.HHmmss" + "." + objEstacion.Nombre.Replace(" ","") + "." + txtBaseDatos.Text.ToUpper().Trim() + ".bk");
				Libreria.UtilidadesGenerales.CrearDirectorio(txtRuta.Text,2);
				Libreria.UtilidadesGenerales.Mantenimiento(txtBaseDatos.Text.Trim(), txtRuta.Text.Trim(),1);
			}
			catch(Exception ex)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1985, Global.Idioma) + ex.Message, false);
				return;
			}
            this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1986, Global.Idioma), false);
			//ShowMessage("Copia de seguridad generada con exito en: " + txtRuta.Text);
		}

		#endregion

		#region Mensajes

		private void ShowMessage(string Mensaje)
		{
			
			string strScript;;

			strScript = "<script language=JavaScript>alert('" + Mensaje + "');";
			strScript += "</script>";

			Page.RegisterClientScriptBlock("Msbox",strScript);
		}
		#endregion

		private void btnIndexar_Click(object sender, System.EventArgs e)
		{
			if (!this.VerificarPermisos("Indexar"))
			{
				this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1742,Global.Idioma), false);
				return;
			}

			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,521, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();		
				Libreria.UtilidadesGenerales.Mantenimiento(txtBaseDatos.Text.Trim(), txtRuta.Text.Trim(),2);

			}
			catch(Exception ex)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1987, Global.Idioma) + ex.Message, false);
				return;
			}
			this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1743,Global.Idioma) + "!",false);

		}

		private void btnRestablecerLog_Click(object sender, System.EventArgs e)
		{
			if (!this.VerificarPermisos("Log"))
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return;
			}


			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,522, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();		
				Libreria.UtilidadesGenerales.Mantenimiento(txtBaseDatos.Text.Trim(), txtRuta.Text.Trim(),3);

			}
			catch(Exception ex)
			{
				this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1744,Global.Idioma) + "! " + ex.Message,false);
				return;
			}
			this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1745,Global.Idioma) + "!",false);
		}

        private void Traduccion()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(506,Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1616,Global.Idioma);
            btnCrearCopia.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1617, Global.Idioma);
            btnIndexar.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1618, Global.Idioma);
            btnRestablecerLog.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1619, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(808, Global.Idioma);
        }

	}
}
