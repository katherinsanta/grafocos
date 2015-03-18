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

namespace Servipunto.Estacion.Web.Modules.Main
{
	/// <summary>
	/// Descripción breve de CambiarContrasena.
	/// </summary>
	public class CambiarContrasena : System.Web.UI.Page
	{
		#region Local Variables and Controls Declarations
		protected System.Web.UI.HtmlControls.HtmlForm LoginForm;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.HtmlControls.HtmlGenericControl InscriptionSection;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlTableCell SeccionMensaje;
		protected System.Web.UI.WebControls.TextBox txtConfirmar;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Button btnCrear;
        protected System.Web.UI.WebControls.Panel pnlForm;
		protected Libreria.Usuario _objUsuario = null;
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
            Traducir();
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
		#region Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{	
            
			if (!this.IsPostBack)
			{
				if(this.VerificarPermisos())
				{
					if (this.ObtenerElemento())
						this.lblFormTitle.Text = "Usuario: <b>" + this._objUsuario.Nombre + "</b>";
				}
			}
			else
				this.CambiarContrasenas();
		}
		#endregion

		#region Método VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Usuarios";
			
			bool cambiarcontrasena = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Cambiar Contrasena");
			
			if (!cambiarcontrasena)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);				
				this.SeccionMensaje.Visible = false;
				return false;
			}
			return true;
		}
		#endregion

		#region Método para Obtener una Referencia al Objeto
		private bool ObtenerElemento()
		{
			try
			{
				this._objUsuario = Libreria.Usuarios.Obtener(((Libreria.Usuario)Session["Usuario"]).IdUsuario);
				if (this._objUsuario == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._objUsuario + "]", true);
					this.lblError.Visible = true;
					this.AcceptButton.Disabled = true;
                    btnCrear.Enabled = false;

					return false;
				}
				else
					return true;
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
                    return false;
                }
                catch (Exception exx)
                {
                    lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1760, Global.Idioma) + ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1759, Global.Idioma) + exx.Message;
                    return false;
                }
                #endregion   
			}

		}
		#endregion

		#region Método CambiarContrasenas()
		private void CambiarContrasenas()
		{
			try
			{
				if (this.Validar())
				{
					if (this.txtPassword.Text.Trim() == this.txtConfirmar.Text.Trim())
					{
						if (this.ObtenerElemento())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,361, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objUsuario.Contrasena = this.txtConfirmar.Text.Trim();
							this._objUsuario.CambiarContrasena(this._objUsuario.Contrasena);
							this.lblError.Text = "<p><font color=blue><b>"+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2088, Global.Idioma)+"</b></font>";
							this.lblError.Visible = true;
                            this.pnlForm.Visible = false;
						}
					}
					else
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2089, Global.Idioma), true);
				}
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


		}
		#endregion

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2085, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2087, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2086, Global.Idioma);
            btnCrear.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(764, Global.Idioma);
            
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

		#region Método Validar
		private bool Validar()
		{
			this.lblError.Text = "";
			if (this.txtPassword.Text.Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2090, Global.Idioma), false);
				return false;
			}
			if (this.txtConfirmar.Text.Length == 0)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2091, Global.Idioma), false);
				return false;
			}

			return true;
		}
		#endregion

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
