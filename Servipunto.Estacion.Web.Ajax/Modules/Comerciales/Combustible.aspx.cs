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
	public class Combustible : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
		protected System.Web.UI.WebControls.Label lblFormTitle;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected System.Web.UI.WebControls.LinkButton lbGuardar;
		protected System.Web.UI.WebControls.DropDownList ddlArticulo;
		protected Libreria.Comercial.AutoCombustible _objCombustible = null;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Label Label1;
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

            if (Request.QueryString["Placa"] != null)
                this.lblHide.Text = Request.QueryString["Placa"];

			if (!this.IsPostBack)
				this.InicializarForma();
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
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(263, Global.Idioma);

            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lbGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, 1);
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
			CargarArticulos();

			#region Modo de Inserción
            this.lblFormTitle.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2020, Global.Idioma) +"</b>";
			this.lblBack.NavigateUrl = "Combustibles.aspx?Placa=" + lblHide.Text;
            this.lbGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
			#endregion
		}
		#endregion

		#region Guardar
		private void Guardar()
		{
			if (this.Validar())
			{
				try
				{
					#region Insertar
					Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,299, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objCombustible = 
						new Libreria.Comercial.AutoCombustible();
						this._objCombustible.CodigoArticulo = int.Parse(ddlArticulo.SelectedValue);
						this._objCombustible.PlacaAuto = DecryptText(Convert.ToString(lblHide.Text.Replace(" ","+")));
						Libreria.Comercial.AutoCombustibles.Adicionar(this._objCombustible);
					#endregion

					Response.Redirect("Combustibles.aspx?Placa=" + lblHide.Text);
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
                        lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1760, Global.Idioma) + ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1759, Global.Idioma) +exx.Message;
                    }
                    #endregion   
					return;
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

			if(ddlArticulo.SelectedIndex == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1937,Global.Idioma), false);
				return false;
			}

			return true;
		}
		#endregion

		#region Cargar Articulos
		private void CargarArticulos()
		{
			try
			{
				ddlArticulo.DataSource = new Libreria.Articulos(Servipunto.Estacion.Libreria.TipoArticulo.Combustible);
				ddlArticulo.DataTextField = "Descripcion";
				ddlArticulo.DataValueField = "IdArticulo";				
				ddlArticulo.DataBind();
                ddlArticulo.Items.Insert(0, new ListItem(Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "0"));
			}
			catch(Exception ex)
			{
				SetError("Error al cargar los articulos",false);
                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1757, Global.Idioma) + ex.StackTrace, Libreria.Configuracion.PalabrasIdioma.Traduccion(1758, Global.Idioma));
                }
                catch (Exception exx)
                {
                    lblError.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1760, Global.Idioma) +ex.Message + Libreria.Configuracion.PalabrasIdioma.Traduccion(1759, Global.Idioma) + exx.Message;
                }
                #endregion   

			}
			
		}
		#endregion

		#region Boton Guardar
		private void lbGuardar_Click(object sender, System.EventArgs e)
		{
			Guardar();
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
	}
}
