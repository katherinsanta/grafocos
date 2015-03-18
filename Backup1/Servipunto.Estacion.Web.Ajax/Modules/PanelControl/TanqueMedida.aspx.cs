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
	/// Descripción breve de TanqueMedida.
	/// </summary>
	public class TanqueMedida : System.Web.UI.Page
	{
		#region Declaracion Variables
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.WebControls.ImageButton btnFechaInicio;
		protected System.Web.UI.WebControls.Label lblTituloGenerales;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCompras;
		protected System.Web.UI.WebControls.TextBox txtSaldoInicial;
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected Libreria.Configuracion.Tanques.TanqueVariacion _objTanqueVariacion = null;
		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.TextBox txtIdTanque;
		protected System.Web.UI.WebControls.Calendar FechaInicio;
        protected System.Web.UI.WebControls.Calendar Calendar1;
		protected System.Web.UI.WebControls.TextBox txtAgua;
		protected System.Web.UI.WebControls.LinkButton lblNuevo;
		protected System.Web.UI.WebControls.LinkButton lblGuardarMedidas;
		protected System.Web.UI.WebControls.LinkButton lblBuscar;
		protected System.Web.UI.WebControls.TextBox txtSaldoFinal;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected AjaxControlToolkit.TabPanel TabPanelBasicoInicial;
        protected AjaxControlToolkit.TabPanel TabPanelBasicoFinal;
        protected AjaxControlToolkit.CalendarExtender CalendarExtender1;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label lblExisteMedida;

        
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
            ViewState["Control"] = "0";
            ViewState["Fecha"] = "1";
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
            lblTituloGenerales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion( 1447, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1444, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1448, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1449, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1445, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1446, Global.Idioma);
            lblNuevo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma);
            lblGuardarMedidas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lblBuscar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1443, Global.Idioma);
            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            
            TabPanelBasicoInicial.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1447, Global.Idioma);
            TabPanelBasicoFinal.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1444, Global.Idioma);
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion        
		#region Page Load Event
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.lblError.Visible = false;
			try
			{
				if (!this.IsPostBack)
				{
                    if (ViewState["Control"].ToString() != "1")
                    {
                        this._id = DecryptText(Convert.ToString(Request.QueryString["IdTanque"].Replace(" ", "+")));
                        txtIdTanque.Text = this._id;
                        this.InicializarForma();
                        CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    }
				}
			}
			catch(Exception)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma), true);
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

		#region Limpiar textos
		private void LimpiarTextos()
		{
			txtSaldoInicial.Text = "";
			txtAgua.Text = "";
			txtCompras.Text = "";
			txtSaldoFinal.Text = "";
			this._mode = WebApplication.FormMode.New;
			this.lblFormTitle.Text = "<b>"+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1938, Global.Idioma)+ this.txtIdTanque.Text + "</b>";
		}

		#endregion

		#region ObtenerObjetoTanque
		private bool ObtenerObjetoTanque()
		{
			try
			{
                //txtFecha.Text = FechaInicio.SelectedDate.ToString("dd/MM/yyyy");
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,134, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				this._id = DecryptText(Convert.ToString(Request.QueryString["IdTanque"].Replace(" ","+") ));
				this._objTanqueVariacion = Libreria.Configuracion.Tanques.TanqueVariaciones.ObtenerItem(int.Parse(this._id),DateTime.Parse(txtFecha.Text));
				if (this._objTanqueVariacion == null)
				{					
					
					this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._id + "]", true);
					LimpiarTextos();
					//btnFechaInicio.Visible = true;	
                    ViewState["Fecha"] = "1";
                    lblExisteMedida.Text = "1";
					return false;
				}
				else
				{

					txtIdTanque.Text = _objTanqueVariacion.CodigoTanque.ToString();
					txtFecha.Text = _objTanqueVariacion.Fecha.ToString("dd/MM/yyyy");
					txtSaldoInicial.Text = _objTanqueVariacion.SaldoInicial.ToString();
					txtAgua.Text = _objTanqueVariacion.LecturaInicialAgua.ToString();
					txtCompras.Text = _objTanqueVariacion.Compras.ToString();
					txtSaldoFinal.Text = _objTanqueVariacion.SaldoFinal.ToString();
					this._mode = WebApplication.FormMode.Edit;
					this.lblFormTitle.Text = "<b> "+ Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1939, Global.Idioma)+ this.txtIdTanque.Text + "</b>";; 
					btnFechaInicio.Visible = false;
                    ViewState["Fecha"] = "0";
                    lblExisteMedida.Text = "0";
					return true;
				}
			}
			catch (FormatException)
			{
				this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._id + "]", true);
				return false;
			}
		}

		private void lblBuscar_Click(object sender, System.EventArgs e)
		{
			this.ObtenerObjetoTanque();
		}

		#endregion

		#region Inicialización del Formulario
		private void InicializarForma()
		{
            ViewState["Control"] = "1";
			this.FechaInicio.SelectedDate = DateTime.Now;
			txtFecha.Text = FechaInicio.SelectedDate.ToString("dd/MM/yyyy");
			this.lblFormTitle.Text = "<b>"+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1938, Global.Idioma) + this.txtIdTanque.Text + "</b>";
			this.VerificarPermisos();
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
			this.lblNuevo.Click += new System.EventHandler(this.lblNuevo_Click);
			this.lblGuardarMedidas.Click += new System.EventHandler(this.lblGuardarMedidas_Click);
			this.lblBuscar.Click += new System.EventHandler(this.lblBuscar_Click);
            this.FechaInicio.SelectionChanged += new System.EventHandler(this.FechaInicio_SelectionChanged1);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Guardar
		private void Guardar()
		{
			if (this.Validar())
			{
				try
				{
					txtCompras.Text = txtCompras.Text.Trim().Replace(".",",");
					txtSaldoFinal.Text = txtSaldoFinal.Text.Trim().Replace(".",",");
					txtSaldoInicial.Text = txtSaldoInicial.Text.Trim().Replace(".",",");
					txtAgua.Text = txtAgua.Text.Trim().Replace(".",",");                    

					//if (this._mode == WebApplication.FormMode.New)
					this._objTanqueVariacion = new Servipunto.Estacion.Libreria.Configuracion.Tanques.TanqueVariacion();
					if(lblExisteMedida.Text == "1")
					{
						#region Insertar	
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,135, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objTanqueVariacion.CodigoTanque = int.Parse(txtIdTanque.Text.Trim());
						this._objTanqueVariacion.Fecha = DateTime.Parse(txtFecha.Text.Trim());
						this._objTanqueVariacion.SaldoInicial = Decimal.Parse(txtSaldoInicial.Text.Trim());
						this._objTanqueVariacion.LecturaInicialAgua = Decimal.Parse(txtAgua.Text.Trim());
						this._objTanqueVariacion.Compras = Decimal.Parse(txtCompras.Text.Trim());
						this._objTanqueVariacion.SaldoFinal = Decimal.Parse(txtSaldoFinal.Text.Trim());
							
						Libreria.Configuracion.Tanques.TanqueVariaciones.Adicionar(this._objTanqueVariacion);
						#endregion
					}
					else
					{
						#region Modificar
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,136, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objTanqueVariacion.CodigoTanque = int.Parse(txtIdTanque.Text.Trim());
						this._objTanqueVariacion.Fecha = DateTime.Parse(txtFecha.Text.Trim());
						this._objTanqueVariacion.SaldoInicial = Decimal.Parse(txtSaldoInicial.Text.Trim());
						this._objTanqueVariacion.LecturaInicialAgua = Decimal.Parse(txtAgua.Text.Trim());
						this._objTanqueVariacion.Compras = Decimal.Parse(txtCompras.Text.Trim());
						this._objTanqueVariacion.SaldoFinal = Decimal.Parse(txtSaldoFinal.Text.Trim());
						this._objTanqueVariacion.Modificar();
						#endregion
					}
					Response.Redirect("Tanques.aspx");
					
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
			}

		}


		private void lblGuardarMedidas_Click(object sender, System.EventArgs e)
		{
			this.Guardar();
		}
		#endregion

		#region Validar

		private bool Validar()
		{
			decimal numero;
			this.ClearError();
			try
			{
				if(txtCompras.Text.Trim().Length == 0)
					txtCompras.Text = "0";

				if(txtSaldoFinal.Text.Trim().Length == 0)
					txtSaldoFinal.Text = "0";

				if(txtSaldoInicial.Text.Trim().Length == 0)
					txtSaldoInicial.Text = "0";

				if(txtAgua.Text.Trim().Length == 0)
					txtAgua.Text = "0";

				numero = Decimal.Parse(txtCompras.Text.Trim());
				numero = Decimal.Parse(txtSaldoFinal.Text.Trim());
				numero = Decimal.Parse(txtSaldoInicial.Text.Trim());
				numero = Decimal.Parse(txtAgua.Text.Trim());
				return true;
			}
			catch(Exception)
			{
				this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1940, Global.Idioma) , false);
				return false;
			}
		}
		#endregion

		#region calendario
		private void btnFechaInicio_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			FechaInicio.Visible = !FechaInicio.Visible;
		}

		private void FechaInicio_SelectionChanged(object sender, System.EventArgs e)
		{
			
            
		}

		#endregion 

		#region nuevo
		private void lblNuevo_Click(object sender, System.EventArgs e)
		{
			LimpiarTextos();
			this._mode = WebApplication.FormMode.New;
			//btnFechaInicio.Visible = true;
            ViewState["Fecha"] = "1";
            lblExisteMedida.Text = "1";
		}
		#endregion

        protected void FechaInicio_SelectionChanged1(object sender, EventArgs e)
        {
            txtFecha.Text = FechaInicio.SelectedDate.ToString("dd/MM/yyyy");//.ToString("dddd, MMMM dd yyyy", new System.Globalization.CultureInfo("es-CO", false));
            FechaInicio.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");//.ToString("dddd, MMMM dd yyyy", new System.Globalization.CultureInfo("es-CO", false));
            FechaInicio.Visible = false;
      

        }

	}
}
