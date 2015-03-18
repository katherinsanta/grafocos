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
	public class Lector : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
        protected System.Web.UI.WebControls.Button btnCrear;		
		protected System.Web.UI.WebControls.TextBox txtLector;
		protected System.Web.UI.WebControls.TextBox txtInterfaz;
		protected System.Web.UI.WebControls.DropDownList cboPuerto;
		protected System.Web.UI.WebControls.DropDownList cboVersion;
		protected System.Web.UI.WebControls.RadioButtonList optMonitoreo;

		protected WebApplication.FormMode _mode;
		protected Libreria.Configuracion.Lector _objLector = null;
		protected string _id = null;

        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;

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
            if (Request.QueryString["Id"] == null && lblHide.Text == "")
                this._mode = WebApplication.FormMode.New;
            else            
                this._mode = WebApplication.FormMode.Edit;                
            

			if (!this.IsPostBack)
			{
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
                    lblHide.Text = this._id;
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
			const string opcion = "Lectores";
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

		#region ObtenerObjetoLector
		private bool ObtenerObjetoLector()
		{
			try
			{
                this._id = lblHide.Text; // DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
				this._objLector = Libreria.Configuracion.Lectores.ObtenerItem(this._id);
				if (this._objLector == null)
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

		#region Inicialización del Formulario
		private void InicializarForma()
		{
			if (this.VerificarPermisos())
			{
				try
				{
					this.lblBack.NavigateUrl = "Lectores.aspx";
					this.CargarPuertos();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
                        this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1738, Global.Idioma) +"</b>";
                        this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma); ;
                        this.btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma); ;
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoLector())
						{
							//Visualización de Datos						
							this.txtLector.Text = this._objLector.IdLector;
							this.txtInterfaz.Text = this._objLector.IdInterfaz;
							this.cboPuerto.SelectedValue = this._objLector.IdPuerto;
							this.cboVersion.SelectedValue = this._objLector.Version.ToString();
							this.optMonitoreo.SelectedValue = this._objLector.Monitoreo?"1":"0";

							this.txtLector.Enabled = false;
							this.txtInterfaz.Enabled = false;

                            this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1299, Global.Idioma) + ": <b>" + this._objLector.IdLector + "</b>";
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                            this.btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma); 
						}
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,54, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();

						this._objLector = new Libreria.Configuracion.Lector();
						this._objLector.IdLector = this.txtLector.Text.Trim();
						this._objLector.IdInterfaz = this.txtInterfaz.Text.Trim();
						this._objLector.IdPuerto = this.cboPuerto.SelectedValue;
						this._objLector.Version = Convert.ToInt16(this.cboVersion.SelectedValue);
						this._objLector.Monitoreo = this.optMonitoreo.SelectedValue=="1"?true:false;
						
						Libreria.Configuracion.Lectores.Adicionar(this._objLector);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoLector())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,55, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objLector.IdLector = this.txtLector.Text.Trim();
							this._objLector.IdInterfaz = this.txtInterfaz.Text.Trim();
							this._objLector.IdPuerto = this.cboPuerto.SelectedValue;
							this._objLector.Version = Convert.ToInt16(this.cboVersion.SelectedValue);
							this._objLector.Monitoreo = this.optMonitoreo.SelectedValue=="1"?true:false;

							this._objLector.Modificar();
						}
						#endregion
					}
					Response.Redirect("Lectores.aspx");
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
					this._objLector = null;
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
			if (this.txtLector.Text.Trim().Length != 16)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1818, Global.Idioma), false);
				return false;
			}
			if (this.txtInterfaz.Text.Trim().Length != 16)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1819, Global.Idioma), false);
				return false;
			}
			return true;
		}
		#endregion

		#region CargarPuertos
		private void CargarPuertos()
		{
			Libreria.Configuracion.Puertos objPuertos = new Libreria.Configuracion.Puertos();

			this.cboPuerto.DataSource = objPuertos;
			this.cboPuerto.DataTextField = "IdPuerto";
			this.cboPuerto.DataValueField = "IdPuerto";
			this.cboPuerto.DataBind();

			if (this.cboPuerto.Items.Count == 0)
			{
                this.cboPuerto.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1820, Global.Idioma));
				this.AcceptButton.Disabled = true;
                this.btnCrear.Enabled = false;
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

        #region Traduccir
        private void Traduccir()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1299, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1300, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1301, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1302, Global.Idioma);
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1303, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma);
            optMonitoreo.Items[0].Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma);
            optMonitoreo.Items[1].Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1731, Global.Idioma);


        }
        #endregion
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion


    }
}
