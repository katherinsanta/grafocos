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
	/// <summary>
	/// Descripción breve de TanqueVariacionMensaje.
	/// </summary>
	public class TanqueVariacionMensaje : System.Web.UI.Page
	{
		#region Declaraciones
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.TextBox txtValorInicial;
		protected System.Web.UI.WebControls.TextBox txtValorFinal;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected Libreria.Configuracion.Tanques.TanqueVariacionMensaje _objTanqueMensaje = null;
		protected System.Web.UI.WebControls.TextBox txtMensaje;
		protected System.Web.UI.WebControls.TextBox txtIdMensaje;
		protected System.Web.UI.WebControls.TextBox txtIdTanque;
		protected System.Web.UI.WebControls.DataGrid lstMensajes;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.WebControls.LinkButton lblGuardar;
		protected System.Web.UI.WebControls.LinkButton lblCancelar;
		protected System.Web.UI.WebControls.HyperLink lblBack;        
		protected System.Web.UI.HtmlControls.HtmlTableCell SeccionInicializar;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Panel pnlForm;
        
		protected string _id = null;

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
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1004, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1005, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1003, Global.Idioma);            
            lblCancelar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1002, Global.Idioma);
            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion        
		#region Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.lblError.Visible = false;
				if (!this.IsPostBack)
				{
					this._id = DecryptText(Convert.ToString(Request.QueryString["IdTanque"].Replace(" ","+") ));
					txtIdTanque.Text = this._id;
                    this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1055, Global.Idioma) + txtIdTanque.Text + "</b>";
					this.InicializarForma();
				}
			}
			catch(Exception ex)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message, true);
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

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Tanques";
			bool permiso;

			//if (this._mode == WebApplication.FormMode.New)
			//	permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			//else
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}			
			return true;
		}
		#endregion
		
		#region CargarMensajes
		private void CargarMensajes()
		{
			try
			{				
				DataSet ds = Libreria.Configuracion.Tanques.TanqueVariacionMensajes.ObtenerItems(int.Parse(txtIdTanque.Text));
				this.lstMensajes.DataSource = ds;
				this.lstMensajes.DataKeyField = "idVariacionTanqueMensaje";
				this.lstMensajes.DataBind();
			}
			catch(Exception ex)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1867, Global.Idioma) + ex.Message, false);

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

		#region Inicialización del Formulario
		private void InicializarForma()
		{
			if (this.VerificarPermisos())
			{
                    lblGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1001, Global.Idioma);
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,138, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					this.CargarMensajes();
					
			}
		}
		#endregion

		#region Guardar
		private void Guardar()
		{
			if (this.Validar())
			{
				/*try
				{
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Insertar
						this._objTanqueMensaje = new Servipunto.Estacion.Libreria.Configuracion.Tanques.Tanque();
						this._objTanqueMensaje.CapacidadTanque = Decimal.Parse(this.txtCapacidad.Text);
						Libreria.Configuracion.Tanques.Tanques.Adicionar(this._objTanqueMensaje);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoTanque())
						{
							this._objTanqueMensaje.CodigoTanque = int.Parse(this.txtId.Text);
							this._objTanqueMensaje.CapacidadTanque = Decimal.Parse(this.txtCapacidad.Text);
							this._objTanqueMensaje.Modificar();
						}
						#endregion
					}
					Response.Redirect("Tanques.aspx");
				}
				catch (Exception ex)
				{
					this.lblError.Visible = true;
					this.lblError.Text = ex.Message;
					return;
				}
				*/
			}
			else
			{
				this.lblError.Visible = true;
			}
		}
		#endregion

		#region Validar
		private bool Validar()
		{
			/*this.ClearError();
			if (this.txtCapacidad.Text.Trim().Length != 0)
			{
				try
				{
					Decimal.Parse(txtCapacidad.Text);
				}
				catch
				{
					this.SetError("El número del tanque debe ser numérico!", false);
					return false;
				}
			}
			else
			{
				this.SetError("El número del tanque no puede ser una cadena vacia!", false);
				return false;
			}*/
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
			this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
			this.lblCancelar.Click += new System.EventHandler(this.lblCancelar_Click);
			this.lstMensajes.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.lstMensajes_EditCommand);
			this.lstMensajes.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.lstMensajes_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lblGuardar_Click(object sender, System.EventArgs e)
		{
			txtValorInicial.Text = txtValorInicial.Text.Trim().Replace(".",",");
			txtValorFinal.Text = txtValorFinal.Text.Trim().Replace(".",",");
			try
			{
				this._objTanqueMensaje = new Servipunto.Estacion.Libreria.Configuracion.Tanques.TanqueVariacionMensaje();
				this._objTanqueMensaje.CodigoTanque = int.Parse(this.txtIdTanque.Text);
				this._objTanqueMensaje.ValorInicial = decimal.Parse(this.txtValorInicial.Text);
				this._objTanqueMensaje.ValorFinal = decimal.Parse(this.txtValorFinal.Text);
				this._objTanqueMensaje.Mensaje = this.txtMensaje.Text;

				#region Insertar
                if (lblGuardar.Text == Libreria.Configuracion.PalabrasIdioma.Traduccion(1001, Global.Idioma))
				{
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,139, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					Libreria.Configuracion.Tanques.TanqueVariacionMensajes.Adicionar(this._objTanqueMensaje);
					LimpiarCampos();
				}
					#endregion

				#region Actualizar
				else
				{
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,140, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
					_objTanqueMensaje.CodigoMensaje = int.Parse(txtIdMensaje.Text);
					_objTanqueMensaje.Modificar();
					LimpiarCampos();
				}
				#endregion
			}
			catch(Exception ex)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1940, Global.Idioma) + ex.Message, false);
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
			
			this.CargarMensajes();
			
		}

		private void lstMensajes_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if( e.CommandName == "Edit")
			{
                lblGuardar.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1941, Global.Idioma);
				txtIdMensaje.Text = lstMensajes.DataKeys[e.Item.ItemIndex].ToString();
				txtValorInicial.Text = e.Item.Cells[0].Text;
				txtValorFinal.Text = e.Item.Cells[1].Text;
				txtMensaje.Text = e.Item.Cells[2].Text;			

			}

		}

		#region Limpiar Camos
		private void LimpiarCampos()
		{
			txtIdMensaje.Text = "";
			txtValorInicial.Text = "";
			txtValorFinal.Text = "";
			txtMensaje.Text = "";
            lblGuardar.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1001, Global.Idioma) ;
		}
		#endregion

		private void lblCancelar_Click(object sender, System.EventArgs e)
		{			
			LimpiarCampos();
		}

		private void lstMensajes_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,141, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				Libreria.Configuracion.Tanques.TanqueVariacionMensajes.Eliminar(int.Parse(lstMensajes.DataKeys[e.Item.ItemIndex].ToString()));
			}
			catch(Exception ex)
			{
				this.SetError(lblError.Text += ex.Message,false);
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
			this.CargarMensajes();
		}

        protected void lstMensajes_ItemDataBound(object sender, DataGridItemEventArgs e)
        {            

        }

        protected void lstMensajes_DataBinding(object sender, EventArgs e)
        {
            
        }

	}
}
