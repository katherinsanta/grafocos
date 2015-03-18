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
	public class Isla : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.Label lblHide2;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Button btnCrear;
		protected System.Web.UI.WebControls.TextBox txtId;
		protected System.Web.UI.WebControls.DropDownList cboImpresora;

		protected WebApplication.FormMode _mode;
		protected Libreria.Configuracion.Isla _objIsla = null;
		protected Libreria.Configuracion.Estacion _objEstacion = null;
		protected string _id = null;
		protected string _idEstacion = null;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;

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
            if (Request.QueryString["IdIsla"] == null && this.lblHide.Text == "")
				this._mode = WebApplication.FormMode.New;
			else 
				this._mode = WebApplication.FormMode.Edit;
			

			if (!this.IsPostBack)
			{
				if (this._id == null & this._mode == WebApplication.FormMode.Edit )
				{
					this._id = DecryptText(Convert.ToString(Request.QueryString["IdIsla"].Replace(" ","+") ));
					this._idEstacion = DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ","+") ));
                    this.lblHide.Text = this._id;
                    this.lblHide2.Text = this._idEstacion;

				}
				this.InicializarForma();
                Traduccir();
			}
			else
				if (Request.Form["AcceptButton"] != null)
					this.Guardar();			
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Islas";
			bool permiso;

			if (this._mode == WebApplication.FormMode.New)
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			else
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}			
			return true;
		}
		#endregion

		#region ObtenerObjetoIsla
		private bool ObtenerObjetoIsla()
		{
			try
			{
                this._id = lblHide.Text; //DecryptText(Convert.ToString(Request.QueryString["IdIsla"].Replace(" ","+") ));
				this._objIsla = Libreria.Configuracion.Islas.ObtenerItem(Convert.ToInt16(this._id));
				if (this._objIsla == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._id + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._id + "]", true);
                return false;
			}
		}
		#endregion

		#region ObtenerObjetoEstacion
		private bool ObtenerObjetoEstacion()
		{
			try
			{
                if (Request.QueryString["Id"] == null)
                    this._idEstacion = lblHide2.Text; //(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
                else
                {
                    this._idEstacion = DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
                    lblHide2.Text = DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
                }

				this._objEstacion = Libreria.Configuracion.Estaciones.ObtenerItem(Convert.ToInt16(this._idEstacion));
				if (this._objEstacion == null)
				{
                    lblHide2.Text = this._idEstacion;
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._id + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._id + "]", true);
                return false;
			}
		}
		#endregion

		#region Inicialización del Formulario
		private void InicializarForma()
		{
			if (this.VerificarPermisos())
			{
				try
				{
					this.CargarImpresoras();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						if (this.ObtenerObjetoEstacion())
						{
							this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1741,Global.Idioma) + "</b>";
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
                            btnCrear.Text= Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
							this.lblBack.NavigateUrl = "Islas.aspx?Id=" + Request.QueryString["Id"];
						}
						else
                            this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma), false);
                        
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoIsla())
						{
							//Visualización de Datos						
							this.txtId.Text = this._objIsla.IdIsla.ToString();
							//this.cboImpresora.SelectedValue = this._objIsla.Pos.IdPos.ToString();

							this.txtId.Enabled = false;

							this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1724,Global.Idioma) + ":<b>" + this._objIsla.IdIsla.ToString() + "</b>";
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                            btnCrear.Text= Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
							this.lblBack.NavigateUrl = "Islas.aspx?Id=" + Request.QueryString["Id"];
						}
						else
                            this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) , false);
                        
						#endregion
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
		}
		#endregion

		#region Guardar
		private void Guardar()
		{
			if (this.Validar())
			{
				try
				{
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Insertar
						if (this.ObtenerObjetoEstacion())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,71, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objIsla = new Libreria.Configuracion.Isla();
							this._objIsla.IdIsla = Convert.ToInt16(this.txtId.Text);
							this._objIsla.IdEstacion = this._objEstacion.IdEstacion;							
							this._objIsla.Descripcion = "Isla " + this._objIsla.IdIsla;
							
							Libreria.Configuracion.Islas.Adicionar(this._objIsla);
							Response.Redirect("Islas.aspx?Id=" + Request.QueryString["Id"]);
						}
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoIsla())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,72, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							//this._objIsla.Pos.IdPos = Convert.ToInt16(this.cboImpresora.SelectedValue);
							//this._objIsla.Modificar();
                            Response.Redirect("Islas.aspx?Id=" + EncryptText(lblHide.Text));
						}
						#endregion
					}					
				}
				catch (Exception ex)
				{
					this.lblError.Visible = true;
					this.lblError.Text = ex.Message;
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
				finally 
				{
					this._objIsla = null;
				}
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
			this.ClearError();
			if (this.txtId.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtId.Text.Trim()))
				{
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1809, Global.Idioma), false);
					return false;
				}
			}
			else
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1810, Global.Idioma), false);
                return false;
			}
			return true;
		}
		#endregion

		#region CargarImpresoras
		private void CargarImpresoras()
		{
			Servipunto.Estacion.Libreria.HardWareDetection.PrintersDetection Printers = 
				new Servipunto.Estacion.Libreria.HardWareDetection.PrintersDetection();

			foreach(string printername in Printers.PrintersNames())
				this.cboImpresora.Items.Add(new ListItem(printername, printername));
	
			if (this.cboImpresora.Items.Count == 0)
			{
                this.cboImpresora.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1830, Global.Idioma));
				this.AcceptButton.Disabled = true;
                btnCrear.Enabled = false;
			}
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

        private void Traduccir()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1400, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1740, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);

        }
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion
    }
}
