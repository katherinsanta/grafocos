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
	public class FormaPago : System.Web.UI.Page
	{
		#region Sección de Declaraciones

		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblFormTitle;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
        protected AjaxControlToolkit.TabPanel TabPanelFilaCuentaSAP;
        protected AjaxControlToolkit.TabPanel TabPanelFilaCuentaEstandar;
		protected System.Web.UI.WebControls.TextBox txtId;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.RadioButtonList optTransmisionOnline;
		protected System.Web.UI.WebControls.RadioButtonList optConsecutivo;		

		protected WebApplication.FormMode _mode;
		protected System.Web.UI.WebControls.TextBox txtNumCuenta;
		protected System.Web.UI.WebControls.RadioButtonList optNatCuenta;
		protected System.Web.UI.WebControls.CheckBox chkTerCuenta;
		protected Libreria.Configuracion.FormaPago _objFormaPago = null;
		protected System.Web.UI.WebControls.Label lblTituloGenerales;
        protected System.Web.UI.WebControls.Label lblHide;
		//protected System.Web.UI.WebControls.HyperLink Hyperlink1;
		protected System.Web.UI.WebControls.Label Label1;
		//protected System.Web.UI.WebControls.HyperLink Hyperlink2;
		protected System.Web.UI.WebControls.LinkButton lblGuardar2;
		protected System.Web.UI.WebControls.LinkButton lblGuardar3;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;
		protected System.Web.UI.WebControls.LinkButton lblGuardar1;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.TextBox Textbox3;
		protected System.Web.UI.WebControls.TextBox Textbox4;
		protected System.Web.UI.WebControls.TextBox txtNumCuentaC;
		protected System.Web.UI.WebControls.TextBox txtAsignacionC;
		protected System.Web.UI.WebControls.TextBox txtTextoC;
		protected System.Web.UI.WebControls.TextBox txtDivisionC;
		protected System.Web.UI.WebControls.TextBox txtNumCuentaD;
		protected System.Web.UI.WebControls.TextBox txtAsignacionD;
		protected System.Web.UI.WebControls.TextBox txtTextoD;
		protected System.Web.UI.WebControls.TextBox txtDivisionD;
		protected System.Web.UI.WebControls.RadioButtonList optTraslados;
		protected System.Web.UI.WebControls.RadioButtonList optDetalleCierreTurno;        
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.Label Label10;
        protected System.Web.UI.WebControls.Label Label11;
        protected System.Web.UI.WebControls.Label Label12;
        protected System.Web.UI.WebControls.Label Label13;
        protected System.Web.UI.WebControls.Label Label14;
        protected System.Web.UI.WebControls.Label Label15;
        protected System.Web.UI.WebControls.Label Label16;
        protected System.Web.UI.WebControls.Label Label17;
        protected System.Web.UI.WebControls.Label Label18;
        protected System.Web.UI.WebControls.Label Label19;
        protected System.Web.UI.WebControls.Label Label20;
        protected System.Web.UI.WebControls.Label Label21;
        protected System.Web.UI.WebControls.Label Label22;
		protected string _id = null;
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
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1262, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1269, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1270, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1265, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1266, Global.Idioma);
            lblTituloGenerales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1272, Global.Idioma);
            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1273, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1274, Global.Idioma);
            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1277, Global.Idioma);
            chkTerCuenta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1278, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1808, Global.Idioma);
            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1811, Global.Idioma);
            Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1812, Global.Idioma);
            Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1280, Global.Idioma);
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1281, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1281, Global.Idioma);
            Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1282, Global.Idioma);
            Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1282, Global.Idioma);
            Label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1283, Global.Idioma);
            Label20.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1283, Global.Idioma);
            Label21.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1284, Global.Idioma);
            Label22.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1284, Global.Idioma);
            TabPanelFilaCuentaEstandar.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1271, Global.Idioma);
            TabPanelFilaCuentaSAP.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1279, Global.Idioma);
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
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
			this.lblGuardar1.Click += new System.EventHandler(this.lblGuardar1_Click);
			this.lblGuardar2.Click += new System.EventHandler(this.lblGuardar1_Click);
			this.lblGuardar3.Click += new System.EventHandler(this.lblGuardar1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Formas de Pago";
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

		#region ObtenerObjetoFormaPago
		private bool ObtenerObjetoFormaPago()
		{
			try
			{
                this._id = lblHide.Text;  //(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
				this._objFormaPago = Libreria.Configuracion.FormasPago.ObtenerItem(Convert.ToInt16(this._id));
				if (this._objFormaPago == null)
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
                    
					this.lblBack.NavigateUrl = "FormasPago.aspx";
                    this.lblGuardar2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                    this.lblGuardar3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                    RadioButtonTraduccion();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
                        this.lblFormTitle.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(  1268, Global.Idioma) + "</b>";
                        this.lblGuardar1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);                        
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoFormaPago())
						{
							//Visualización de Datos
							this.txtId.Text = this._objFormaPago.IdFormaPago.ToString();
							this.txtDescripcion.Text = this._objFormaPago.Descripcion;
							this.optTransmisionOnline.SelectedValue = this._objFormaPago.TransmisionOnline?"1":"0";
							this.optConsecutivo.SelectedValue = this._objFormaPago.RequiereConsecutivo?"1":"0";
							//Interface Contable
							if ( this._objFormaPago.NumCuenta.Equals("(sin definir)"))
								this.txtNumCuenta.Text = null;
							else
								this.txtNumCuenta.Text = this._objFormaPago.NumCuenta;
							this.optNatCuenta.SelectedValue = this._objFormaPago.NatCuenta?"1":"0";
							this.chkTerCuenta.Checked = this._objFormaPago.TerCuenta;

							this.txtId.Enabled = false;
							//Interfaz sap
							this.txtNumCuentaC.Text = this._objFormaPago.Num_CuentaCredito_Sap;
							this.txtAsignacionC.Text = this._objFormaPago.AsignacionCredito_Sap;
							this.txtTextoC.Text = this._objFormaPago.TextoCredito_Sap;
							this.txtDivisionC.Text = this._objFormaPago.DivisionCredito_Sap;
							this.txtNumCuentaD.Text = this._objFormaPago.Num_CuentaDebito_Sap;
							this.txtAsignacionD.Text = this._objFormaPago.AsignacionDebito_Sap;
							this.txtTextoD.Text = this._objFormaPago.TextoDebito_Sap;
							this.txtDivisionD.Text = this._objFormaPago.DivisionDebito_Sap;
							this.optTraslados.SelectedValue = this._objFormaPago.ReportaTraslados_Sap?"1":"0";
                            this.lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(980, Global.Idioma) +": <b>" + this._objFormaPago.Descripcion + " (" + this._objFormaPago.IdFormaPago.ToString() + ")</b>";
                            this.lblGuardar1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
							this.optDetalleCierreTurno.SelectedValue = this._objFormaPago.DetalleCierreTurno?"1":"0";;
						
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,27, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objFormaPago = new Libreria.Configuracion.FormaPago();
						this._objFormaPago.IdFormaPago = Convert.ToInt16(this.txtId.Text);
						this._objFormaPago.Descripcion = this.txtDescripcion.Text.Trim();
						this._objFormaPago.TransmisionOnline = this.optTransmisionOnline.SelectedValue=="1"?true:false;
						this._objFormaPago.RequiereConsecutivo = this.optConsecutivo.SelectedValue=="1"?true:false;
						//Interface Contable
						if (this.txtNumCuenta.Text.Equals(""))
							this._objFormaPago.NumCuenta = null;
						else
							this._objFormaPago.NumCuenta = this.txtNumCuenta.Text.Trim();
						this._objFormaPago.NatCuenta = this.optNatCuenta.SelectedValue=="1"?true:false;
						this._objFormaPago.TerCuenta = this.chkTerCuenta.Checked;
						//interfaz Sap
						this._objFormaPago.Num_CuentaCredito_Sap = this.txtNumCuentaC.Text.Trim();
						this._objFormaPago.AsignacionCredito_Sap = this.txtAsignacionC.Text.Trim();
						this._objFormaPago.TextoCredito_Sap = this.txtTextoC.Text.Trim();
						this._objFormaPago.DivisionCredito_Sap = this.txtDivisionC.Text.Trim();
						this._objFormaPago.Num_CuentaDebito_Sap = this.txtNumCuentaD.Text.Trim();
						this._objFormaPago.AsignacionDebito_Sap = this.txtAsignacionD.Text.Trim();
						this._objFormaPago.TextoDebito_Sap = this.txtTextoD.Text.Trim();
						this._objFormaPago.DivisionDebito_Sap = this.txtDivisionD.Text.Trim();
						this._objFormaPago.ReportaTraslados_Sap = this.optTraslados.SelectedValue=="1"?true:false;
						this._objFormaPago.DetalleCierreTurno = this.optDetalleCierreTurno.SelectedValue=="1"?true:false;

						Libreria.Configuracion.FormasPago.Adicionar(this._objFormaPago);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoFormaPago())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,28, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objFormaPago.Descripcion = this.txtDescripcion.Text.Trim();
							this._objFormaPago.TransmisionOnline = this.optTransmisionOnline.SelectedValue=="1"?true:false;
							this._objFormaPago.RequiereConsecutivo = this.optConsecutivo.SelectedValue=="1"?true:false;
							//Interface Contable
							if (this.txtNumCuenta.Text.Equals(""))
								this._objFormaPago.NumCuenta = null;
							else
								this._objFormaPago.NumCuenta = this.txtNumCuenta.Text.Trim();
							this._objFormaPago.NatCuenta = this.optNatCuenta.SelectedValue=="1"?true:false;
							this._objFormaPago.TerCuenta = this.chkTerCuenta.Checked;
							//interfaz Sap
							this._objFormaPago.Num_CuentaCredito_Sap = this.txtNumCuentaC.Text.Trim();
							this._objFormaPago.AsignacionCredito_Sap = this.txtAsignacionC.Text.Trim();
							this._objFormaPago.TextoCredito_Sap = this.txtTextoC.Text.Trim();
							this._objFormaPago.DivisionCredito_Sap = this.txtDivisionC.Text.Trim();
							this._objFormaPago.Num_CuentaDebito_Sap = this.txtNumCuentaD.Text.Trim();
							this._objFormaPago.AsignacionDebito_Sap = this.txtAsignacionD.Text.Trim();
							this._objFormaPago.TextoDebito_Sap = this.txtTextoD.Text.Trim();
							this._objFormaPago.DivisionDebito_Sap = this.txtDivisionD.Text.Trim();
							this._objFormaPago.ReportaTraslados_Sap = this.optTraslados.SelectedValue=="1"?true:false;
							this._objFormaPago.DetalleCierreTurno = this.optDetalleCierreTurno.SelectedValue=="1"?true:false;


							this._objFormaPago.Modificar();
						}
						#endregion
					}
					Response.Redirect("FormasPago.aspx");
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
					this._objFormaPago = null;
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
			if (this.txtDescripcion.Text.Trim().Length == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1788, Global.Idioma), false);
				return false;
			}
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

        #region Crear o Actualizar
        private void lblGuardar1_Click(object sender, System.EventArgs e)
		{
			Guardar();
        }
        #endregion
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  optTransmisionOnline
            this.optTransmisionOnline.Items.Clear();
            this.optTransmisionOnline.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.optTransmisionOnline.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.optTransmisionOnline.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  optConsecutivo
            this.optConsecutivo.Items.Clear();
            this.optConsecutivo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.optConsecutivo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.optConsecutivo.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  optDetalleCierreTurno
            this.optDetalleCierreTurno.Items.Clear();
            this.optDetalleCierreTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.optDetalleCierreTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.optDetalleCierreTurno.SelectedValue = "0";
            #endregion
            #region poblar RadioButton optNatCuenta
            this.optNatCuenta.Items.Clear();
            this.optNatCuenta.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1786, Global.Idioma), "1"));
            this.optNatCuenta.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1784, Global.Idioma), "0"));
            this.optNatCuenta.SelectedValue = "0";
            #endregion            
            #region poblar RadioButton  optTraslados
            this.optTraslados.Items.Clear();
            this.optTraslados.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.optTraslados.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.optTraslados.SelectedValue = "0";
            #endregion
        }
        #endregion


    }
}
