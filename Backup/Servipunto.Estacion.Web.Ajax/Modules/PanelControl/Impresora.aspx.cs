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
	public class Impresora : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHidePos;
        protected System.Web.UI.WebControls.Label lblHideCapturador;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;		
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected WebApplication.FormMode _mode;
        protected System.Web.UI.WebControls.Button btnCrear;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist2;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist3;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist4;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist5;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist6;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist7;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist8;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist9;
		protected System.Web.UI.WebControls.DropDownList ddlAbrirTurno;
		protected System.Web.UI.WebControls.DropDownList ddlFormasPagoCierre;
		protected System.Web.UI.WebControls.DropDownList ddlImprimirTiquetesCanastilla;
		protected System.Web.UI.WebControls.DropDownList ddlLectMecanciasCierre;
		protected System.Web.UI.WebControls.DropDownList ddlImprimirTiquetesEfectivo;
		protected System.Web.UI.WebControls.DropDownList ddlLectMecanciasX;
		protected System.Web.UI.WebControls.DropDownList ddlBolsaCierreTurno;
		protected System.Web.UI.WebControls.DropDownList ddlNVehiculosCierre;
		protected System.Web.UI.WebControls.DropDownList ddlCanastillaCierreTurno;
		protected System.Web.UI.WebControls.DropDownList ddlNVehiculosX;
		protected System.Web.UI.WebControls.DropDownList ddlChequesCierreTurno;
		protected System.Web.UI.WebControls.DropDownList ddlCreditoDirectoCierre;
		protected System.Web.UI.WebControls.DropDownList ddlDetalleTanquesCierreTurno;
		protected System.Web.UI.WebControls.DropDownList ddlCreditoDirectoX;
		protected System.Web.UI.WebControls.DropDownList ddlDetalleVentasCierre;
		protected System.Web.UI.WebControls.DropDownList ddlReporteX;
		protected System.Web.UI.WebControls.DropDownList ddlCanastillaX;
		protected System.Web.UI.WebControls.DropDownList ddlChequesX;
		protected System.Web.UI.WebControls.DropDownList ddlFormasPagoX;
		protected System.Web.UI.WebControls.DropDownList ddlVentasNoCierre;
		protected System.Web.UI.WebControls.DropDownList ddlVentasNoImpresasCierre;
		protected System.Web.UI.WebControls.DropDownList ddlDetalleVentasX;
		protected System.Web.UI.WebControls.DropDownList ddlBolsaTurnoX;
		protected System.Web.UI.WebControls.DropDownList ddlReporteCierre;
		protected System.Web.UI.WebControls.TextBox txtNombreImpresora;
		protected System.Web.UI.WebControls.TextBox txtCantCanastilla;
		protected System.Web.UI.WebControls.TextBox txtCantCheques;
		protected System.Web.UI.WebControls.TextBox txtCantCreditoDirecto;
		protected System.Web.UI.WebControls.TextBox txtCantEfectivo;
		protected System.Web.UI.WebControls.TextBox txtCantTarjetaCredito;
		protected System.Web.UI.WebControls.TextBox txtCantDebitoAhorros;
		protected System.Web.UI.WebControls.TextBox txtCantDebitoCorriente;
		protected System.Web.UI.WebControls.TextBox txtNumeroPos;
		protected System.Web.UI.WebControls.DropDownList ddlTipoImpresora;
		protected System.Web.UI.WebControls.DropDownList ddlNombreImpresora;
		protected System.Web.UI.WebControls.DropDownList ddlImprimeFidelizado;
		protected System.Web.UI.WebControls.DropDownList ddlImprimirVentaEnCero;
		protected System.Web.UI.WebControls.DropDownList ddlImprimirCupoDisponible;
		protected System.Web.UI.WebControls.DropDownList ddlImprimirTiqueteCopia;
        protected System.Web.UI.WebControls.DropDownList ddlImprimirIqueteValidacionSuic;
		protected System.Web.UI.WebControls.DropDownList ddlPuerto;
        //Fecha:        17-03-2011
        //Autor:        Miguel Cantor L.
        //Descripción:  Se añade el control ddlMensajes para definir el tipo de presentación para los mensajes
        //Presentes:    N/A
        protected System.Web.UI.WebControls.DropDownList ddlMensajes;
		protected Libreria.Configuracion.Impresora _objImpresora = null;
        
        protected System.Web.UI.WebControls.Label Label1;
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
        protected System.Web.UI.WebControls.Label Label23;
        protected System.Web.UI.WebControls.Label Label24;
        protected System.Web.UI.WebControls.Label Label25;
        protected System.Web.UI.WebControls.Label Label26;
        protected System.Web.UI.WebControls.Label Label27;
        protected System.Web.UI.WebControls.Label Label28;
        protected System.Web.UI.WebControls.Label Label29;
        protected System.Web.UI.WebControls.Label Label30;
        protected System.Web.UI.WebControls.Label Label31;
        protected System.Web.UI.WebControls.Label Label32;
        protected System.Web.UI.WebControls.Label Label33;
        protected System.Web.UI.WebControls.Label Label34;
        protected System.Web.UI.WebControls.Label Label35;
        protected System.Web.UI.WebControls.Label Label36;
        protected System.Web.UI.WebControls.Label Label37;
        protected System.Web.UI.WebControls.Label Label38;
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
            if ((Request.QueryString["Edit"] == null || Request.QueryString["Edit"] == "0") && lblHidePos.Text == "")
                this._mode = WebApplication.FormMode.New;
            else
            {
                this._mode = WebApplication.FormMode.Edit;
                if (lblHidePos.Text == "")
                {
                    lblHidePos.Text = Request.QueryString["IdPos"];
                    lblHideCapturador.Text = Request.QueryString["IdCapturador"];
                }
            }

            if (!this.IsPostBack)
            {
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
			this.ddlTipoImpresora.SelectedIndexChanged += new System.EventHandler(this.ddlTipoImpresora_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Impresoras";
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

		#region ObtenerObjetoImpresora
		private bool ObtenerObjetoImpresora()
		{
			try
			{
                if (lblHidePos.Text == "")
                {
                    lblHidePos.Text = Request.QueryString["IdPos"];
                    lblHideCapturador.Text = Request.QueryString["IdCapturador"];
                }

                this._objImpresora = Libreria.Configuracion.Impresoras.ObtenerItem(int.Parse(lblHidePos.Text));
				if (this._objImpresora == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._objImpresora + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objImpresora + "]", true);
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
                    RadioButtonTraduccion();
					if(lblHidePos.Text == "" || lblHideCapturador.Text == "")
						this.lblBack.NavigateUrl = "Impresoras.aspx";
					else
                        this.lblBack.NavigateUrl = "Impresoras.aspx?IdPos=" + lblHidePos.Text +
							"&IdCapturador=" + lblHideCapturador.Text;

                    this.ddlNombreImpresora.Items.Add(new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1831, Global.Idioma), "-1"));

					Servipunto.Estacion.Libreria.HardWareDetection.PrintersDetection Printers = 
						new Servipunto.Estacion.Libreria.HardWareDetection.PrintersDetection();

					foreach(string printername in Printers.PrintersNames())
						this.ddlNombreImpresora.Items.Add(new ListItem(printername, printername));
                    
                    if ( lblHidePos.Text == "")
                        this.txtNumeroPos.Text = Request.QueryString["IdPos"];
                    else
                        this.txtNumeroPos.Text = lblHidePos.Text; // Request.QueryString["IdPos"];
					
					this.CargarPuertos();
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
                        this.lblFormTitle.Text = "<b>" + Libreria.Configuracion.PalabrasIdioma.Traduccion(1728, Global.Idioma) +"</b>";
                        this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
                        btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma); 
						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoImpresora())
						{
							//Visualización de Datos
							this.txtNumeroPos.Enabled = false;
							#region Asignacion de variables

							if(Printers.PrinterIndex(this._objImpresora.Imp_Nom) == -1)
								this.ddlNombreImpresora.SelectedIndex = 0;
							else
								this.ddlNombreImpresora.SelectedIndex = Printers.PrinterIndex(this._objImpresora.Imp_Nom) + 1;

							this.txtCantCanastilla.Text = this._objImpresora.ImprimeCantidadCopiasCanastilla.ToString();
							this.txtCantCheques.Text = this._objImpresora.ImprimeCantidadCopiasCheques.ToString();
							this.txtCantCreditoDirecto.Text = this._objImpresora.ImprimeCantidadCopiasCreditoDirecto.ToString();
							this.txtCantEfectivo.Text = this._objImpresora.ImprimeCantidadCopiasEfectivo.ToString();
							this.txtCantTarjetaCredito.Text = this._objImpresora.ImprimeCantidadCopiasTarCredito.ToString();
							this.txtCantDebitoAhorros.Text = this._objImpresora.ImprimeCantidadCopiasTarDebitoAhorro.ToString();
							this.txtCantDebitoCorriente.Text = this._objImpresora.ImprimeCantidadCopiasTarDebitoCorriente.ToString();
							this.ddlAbrirTurno.SelectedValue = this._objImpresora.Imp_Abrir_Turno?"1":"0";
							this.ddlImprimirTiquetesCanastilla.SelectedValue = this._objImpresora.Imp_Canas?"1":"0";
							this.ddlImprimirTiquetesEfectivo.SelectedValue = this._objImpresora.Imp_Comb?"1":"0";
							this.ddlBolsaCierreTurno.SelectedValue = this._objImpresora.ImprimeBolsasDeTurnoRptC?"1":"0";
							this.ddlCanastillaCierreTurno.SelectedValue = this._objImpresora.ImprimeCanastillaRptC?"1":"0";
							this.ddlChequesCierreTurno.SelectedValue = this._objImpresora.ImprimeChequesRptC?"1":"0";
							this.ddlDetalleTanquesCierreTurno.SelectedValue = this._objImpresora.ImprimeDetalleTanquesRptC?"1":"0";
							this.ddlDetalleVentasCierre.SelectedValue = this._objImpresora.ImprimeDetalleVentasRptC?"1":"0";
							this.ddlReporteX.SelectedValue = this._objImpresora.ImprimeEquix?"1":"0";
							this.ddlCanastillaX.SelectedValue = this._objImpresora.ImprimirCanastillaRptX?"1":"0";
							this.ddlChequesX.SelectedValue = this._objImpresora.ImprimirChequesRptX?"1":"0";
							this.ddlFormasPagoX.SelectedValue = this._objImpresora.ImprimirFormasDePagoRptX?"1":"0";
							this.ddlTipoImpresora.SelectedValue = this._objImpresora.Tipo;
							this.ddlFormasPagoCierre.SelectedValue = this._objImpresora.ImprimeFormasDePagRptC?"1":"0";
							this.ddlLectMecanciasCierre.SelectedValue = this._objImpresora.ImprimeLectsMecanicasRptC?"1":"0";
							this.ddlLectMecanciasX.SelectedValue = this._objImpresora.ImprimeLectsMecanicasRptX?"1":"0";
							this.ddlNVehiculosCierre.SelectedValue = this._objImpresora.ImprimeVehiculosAtendidosRptC?"1":"0";
							this.ddlNVehiculosX.SelectedValue = this._objImpresora.ImprimeVehiculosAtendidosRptX?"1":"0";
							this.ddlCreditoDirectoCierre.SelectedValue = this._objImpresora.ImprimeVentasCreDirectoRptC?"1":"0";
							this.ddlCreditoDirectoX.SelectedValue = this._objImpresora.ImprimeVentasCreDirectoRptX?"1":"0";
							this.ddlVentasNoImpresasCierre.SelectedValue = this._objImpresora.ImprimeVentasNoImpresasEnCierre?"1":"0";
							this.ddlDetalleVentasX.SelectedValue = this._objImpresora.ImprimeVentasRptX?"1":"0";
							this.ddlBolsaTurnoX.SelectedValue = this._objImpresora.ImprimirBolsasTurnoRptX?"1":"0";
							this.ddlReporteCierre.SelectedValue = this._objImpresora.ImprimirCierreDeTurno?"1":"0";
							this.ddlVentasNoCierre.SelectedValue = this._objImpresora.ImprimirTiquetes?"1":"0";
							this.ddlImprimeFidelizado.SelectedValue = this._objImpresora.ImprimeTiqueteFidelizado?"1":"0";
							this.ddlImprimirVentaEnCero.SelectedValue = this._objImpresora.ImprimirVentaEnCero?"1":"0";
							this.ddlImprimirCupoDisponible.SelectedValue = this._objImpresora.ImprimirCupoDisponible?"1":"0";
							this.ddlImprimirTiqueteCopia.SelectedValue = this._objImpresora.ImprimirTiqueteCopia?"1":"0";
                            this.ddlImprimirIqueteValidacionSuic.SelectedValue = this._objImpresora.ImprimirTiqueteValidacionSuic ? "1" : "0";
							try
							{
                                //Fecha:        17-03-2011
                                //Autor:        Miguel Cantor L.
                                //Descripción:  Se añade a la validacion el control ddlMensajes y la asignacion de un valor.
                                //              SOLO DEBE MOSTRARSE CUANDO EL TIPO DE IMPRESORA ES DATAFONO
                                //Presentes:    N/A

                                //Fecha:        16-03-2011
                                //Autor:        Miguel Cantor L.
                                //Descripción:  Cambia la validación del tipo de impresora para mostrar/ocultar el puerto (De Wayne Fujitsu a Datafono)
                                //Presentes:    Luisa Maca
								if(ddlTipoImpresora.SelectedValue == "D")
								{
									this.ddlPuerto.Visible = true;
                                    this.ddlPuerto.SelectedValue = this._objImpresora.Puerto;
                                    ddlMensajes.Visible = true;
                                    this.ddlMensajes.SelectedValue = this._objImpresora.Mensajes.ToString();
								}
							}
							catch(Exception)
							{
							}

							#endregion
                            this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(145, Global.Idioma) +": <b>" + this._objImpresora.Imp_Nom + "</b>";
                            this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma); ;
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma); ;
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,113, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objImpresora = new Libreria.Configuracion.Impresora();
						this.CargarDatos();
						Libreria.Configuracion.Impresoras.Adicionar(this._objImpresora);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoImpresora())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,114, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this.CargarDatos();
							this._objImpresora.Modificar();
						}
						#endregion
					}
					if(lblHidePos.Text  == "" || lblHideCapturador.Text == "")
						Response.Redirect("Impresoras.aspx");
					else
						Response.Redirect("Impresoras.aspx?IdPos=" + lblHidePos.Text +
							"&IdCapturador=" + lblHideCapturador.Text);
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
					this._objImpresora = null;
				}
			}
			else
			{
				this.lblError.Visible = true;
			}
		}
		#endregion

		#region Función cargar datos
		private void CargarDatos()
		{
			this._objImpresora.Imp_Nom = this.ddlNombreImpresora.SelectedValue;
			this._objImpresora.ImprimeCantidadCopiasCanastilla = Int16.Parse(this.txtCantCanastilla.Text);
			this._objImpresora.ImprimeCantidadCopiasCheques = Int16.Parse(this.txtCantCheques.Text);
			this._objImpresora.ImprimeCantidadCopiasCreditoDirecto = Int16.Parse(this.txtCantCreditoDirecto.Text);
			this._objImpresora.ImprimeCantidadCopiasEfectivo = Int16.Parse(this.txtCantEfectivo.Text);
			this._objImpresora.ImprimeCantidadCopiasTarCredito = Int16.Parse(this.txtCantTarjetaCredito.Text);
			this._objImpresora.ImprimeCantidadCopiasTarDebitoAhorro = Int16.Parse(this.txtCantDebitoAhorros.Text);
			this._objImpresora.ImprimeCantidadCopiasTarDebitoCorriente = Int16.Parse(this.txtCantDebitoCorriente.Text);
			this._objImpresora.NumeroDePos = Int16.Parse(this.txtNumeroPos.Text);
			this._objImpresora.Imp_Abrir_Turno = this.ddlAbrirTurno.SelectedValue=="1"?true:false;
			this._objImpresora.Imp_Canas = this.ddlImprimirTiquetesCanastilla.SelectedValue=="1"?true:false;
			this._objImpresora.Imp_Comb = this.ddlImprimirTiquetesEfectivo.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeBolsasDeTurnoRptC = this.ddlBolsaCierreTurno.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeCanastillaRptC = this.ddlCanastillaCierreTurno.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeChequesRptC = this.ddlChequesCierreTurno.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeDetalleTanquesRptC = this.ddlDetalleTanquesCierreTurno.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeDetalleVentasRptC = this.ddlDetalleVentasCierre.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeEquix = this.ddlReporteX.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimirCanastillaRptX = this.ddlCanastillaX.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimirChequesRptX = this.ddlChequesX.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimirFormasDePagoRptX = this.ddlFormasPagoX.SelectedValue=="1"?true:false;
			this._objImpresora.Tipo = this.ddlTipoImpresora.SelectedValue;
			this._objImpresora.ImprimeFormasDePagRptC = this.ddlFormasPagoCierre.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeLectsMecanicasRptC = this.ddlLectMecanciasCierre.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeLectsMecanicasRptX = this.ddlLectMecanciasX.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeVehiculosAtendidosRptC = this.ddlNVehiculosCierre.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeVehiculosAtendidosRptX = this.ddlNVehiculosX.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeVentasCreDirectoRptC = this.ddlCreditoDirectoCierre.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeVentasCreDirectoRptX = this.ddlCreditoDirectoX.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeVentasNoImpresasEnCierre = this.ddlVentasNoImpresasCierre.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimeVentasRptX = this.ddlDetalleVentasX.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimirBolsasTurnoRptX = this.ddlBolsaTurnoX.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimirCierreDeTurno = this.ddlReporteCierre.SelectedValue=="1"?true:false;
			this._objImpresora.ImprimirTiquetes = this.ddlVentasNoCierre.SelectedValue =="1"?true:false;
			this._objImpresora.ImprimeTiqueteFidelizado = this.ddlImprimeFidelizado.SelectedValue =="1"?true:false;
			this._objImpresora.ImprimirVentaEnCero = this.ddlImprimirVentaEnCero.SelectedValue == "1"? true:false;
			this._objImpresora.ImprimirCupoDisponible = (ddlImprimirCupoDisponible.SelectedValue=="0"?false:true);
			this._objImpresora.ImprimirTiqueteCopia = (this.ddlImprimirTiqueteCopia.SelectedValue == "1"? true:false);
            this._objImpresora.ImprimirTiqueteValidacionSuic = (this.ddlImprimirIqueteValidacionSuic.SelectedValue == "1" ? true : false);

            //Fecha:        17-03-2011
            //Autor:        Miguel Cantor L.
            //Descripción:  Se añade a la validacion el control ddlMensajes y la asignacion de un valor.
            //              SOLO DEBE MOSTRARSE CUANDO EL TIPO DE IMPRESORA ES DATAFONO
            //Presentes:    N/A

            //Fecha:        16-03-2011
            //Autor:        Miguel Cantor L.
            //Descripción:  Cambia la validación del tipo de impresora para mostrar/ocultar el puerto (De Wayne Fujitsu a Datafono)
            //Presentes:    Luisa Maca
			if(ddlTipoImpresora.SelectedValue == "D")
                this._objImpresora.Puerto = this.ddlPuerto.SelectedValue;
                this._objImpresora.Mensajes = char.Parse(this.ddlMensajes.SelectedValue);
		}
		#endregion

		#region Validar
		private bool Validar()
		{
			this.ClearError();

			if(this.ddlNombreImpresora.SelectedIndex == 0)
			{
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1832, Global.Idioma), false);
					return false;
			}

			if (this.txtCantCanastilla.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtCantCanastilla.Text.Trim()))
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
			if (this.txtCantCheques.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtCantCheques.Text.Trim()))
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
			if (this.txtCantCreditoDirecto.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtCantCreditoDirecto.Text.Trim()))
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
			if (this.txtCantEfectivo.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtCantEfectivo.Text.Trim()))
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
			if (this.txtCantTarjetaCredito.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtCantTarjetaCredito.Text.Trim()))
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
			if (this.txtCantDebitoAhorros.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtCantDebitoAhorros.Text.Trim()))
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
			if (this.txtCantDebitoCorriente.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtCantDebitoCorriente.Text.Trim()))
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
			if (this.txtNumeroPos.Text.Trim().Length != 0)
			{
				if (!Libreria.Aplicacion.IsNumeric(this.txtNumeroPos.Text.Trim()))
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

		#region CargarPuertos
		private void CargarPuertos()
		{
			Libreria.Configuracion.Puertos objPuertos = new Libreria.Configuracion.Puertos();

			this.ddlPuerto.DataSource = objPuertos;
			this.ddlPuerto.DataTextField = "IdPuerto";
			this.ddlPuerto.DataValueField = "IdPuerto";
			this.ddlPuerto.DataBind();

			if (this.ddlPuerto.Items.Count == 0)
                this.ddlPuerto.Items.Add(Libreria.Configuracion.PalabrasIdioma.Traduccion(1820, Global.Idioma));
		}
		#endregion

		private void ddlTipoImpresora_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            //Fecha:        17-03-2011
            //Autor:        Miguel Cantor L.
            //Descripción:  Se añade a la validacion el control ddlMensajes
            //              SOLO DEBE MOSTRARSE CUANDO EL TIPO DE IMPRESORA ES DATAFONO
            //Presentes:    N/A

            //Fecha:        16-03-2011
            //Autor:        Miguel Cantor L.
            //Descripción:  Cambia la validación del tipo de impresora para mostrar/ocultar el puerto (De Wayne Fujitsu a Datafono)
            //Presentes:    Luisa Maca
            if (ddlTipoImpresora.SelectedValue == "D")
            {
                ddlPuerto.Visible = true;
                ddlMensajes.Visible = true;
            }
            else
            {
                ddlPuerto.Visible = false;
                ddlMensajes.Visible = false;
            }
		}

        private void Traduccir()
        {
            Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1315, Global.Idioma);
            Label2.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1316, Global.Idioma);
            Label38.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1317, Global.Idioma);
            Label3.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1318, Global.Idioma);
            Label4.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1319, Global.Idioma);
            Label5.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(485, Global.Idioma);
            Label6.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1320, Global.Idioma);
            Label7.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1322, Global.Idioma);
            Label8.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1324, Global.Idioma);
            Label9.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1325, Global.Idioma);
            Label10.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1326, Global.Idioma);
            Label11.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1739, Global.Idioma);
            Label12.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1327, Global.Idioma);
            Label13.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1328, Global.Idioma);
            Label14.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1329, Global.Idioma);
            Label15.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1330, Global.Idioma);
            Label16.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1331, Global.Idioma);
            Label17.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1332, Global.Idioma);
            Label18.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1333, Global.Idioma);
            Label19.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1334, Global.Idioma);
            Label20.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1336, Global.Idioma);
            Label21.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1338, Global.Idioma);
            Label22.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1340, Global.Idioma);
            Label23.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1341, Global.Idioma);
            Label24.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1342, Global.Idioma);
            Label25.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1344, Global.Idioma);
            Label26.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1345, Global.Idioma);
            Label27.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1346, Global.Idioma);
            Label28.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1347, Global.Idioma);
            Label29.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1348, Global.Idioma);
            Label30.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1349, Global.Idioma);
            Label31.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1350, Global.Idioma);
            Label32.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1351, Global.Idioma);
            Label33.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1324, Global.Idioma);
            Label34.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1354, Global.Idioma);
            Label35.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1355, Global.Idioma);
            Label36.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1356, Global.Idioma);
            Label37.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1357, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma);
        }
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  ddlAbrirTurno
            this.ddlAbrirTurno.Items.Clear();
            this.ddlAbrirTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlAbrirTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlAbrirTurno.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlTipoImpresora
            this.ddlTipoImpresora.Items.Clear();
            this.ddlTipoImpresora.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1833, Global.Idioma), "M"));
            this.ddlTipoImpresora.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1834, Global.Idioma), "T"));
            this.ddlTipoImpresora.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1835, Global.Idioma), "L"));
            this.ddlTipoImpresora.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1836, Global.Idioma), "I"));
            this.ddlTipoImpresora.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1837, Global.Idioma), "W"));
            this.ddlTipoImpresora.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1838, Global.Idioma), "P"));
            //Fecha:        16-03-2011
            //Autor:        Miguel Cantor L.
            //Descripción:  Se añade mel tipo de impresora DATAFONO
            //Presentes:    Luisa Maca
            this.ddlTipoImpresora.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23736, Global.Idioma), "D"));
            this.ddlTipoImpresora.SelectedValue = "M";
            #endregion
            #region poblar RadioButton  ddlFormasPagoCierre
            this.ddlFormasPagoCierre.Items.Clear();
            this.ddlFormasPagoCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlFormasPagoCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlFormasPagoCierre.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlImprimirTiquetesCanastilla
            this.ddlImprimirTiquetesCanastilla.Items.Clear();
            this.ddlImprimirTiquetesCanastilla.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlImprimirTiquetesCanastilla.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlImprimirTiquetesCanastilla.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlLectMecanciasCierre
            this.ddlLectMecanciasCierre.Items.Clear();
            this.ddlLectMecanciasCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlLectMecanciasCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlLectMecanciasCierre.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlImprimirTiquetesEfectivo
            this.ddlImprimirTiquetesEfectivo.Items.Clear();
            this.ddlImprimirTiquetesEfectivo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlImprimirTiquetesEfectivo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlImprimirTiquetesEfectivo.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlLectMecanciasX
            this.ddlLectMecanciasX.Items.Clear();
            this.ddlLectMecanciasX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlLectMecanciasX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlLectMecanciasX.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlBolsaCierreTurno
            this.ddlBolsaCierreTurno.Items.Clear();
            this.ddlBolsaCierreTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlBolsaCierreTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlBolsaCierreTurno.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlNVehiculosCierre
            this.ddlNVehiculosCierre.Items.Clear();
            this.ddlNVehiculosCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlNVehiculosCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlNVehiculosCierre.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlCanastillaCierreTurno
            this.ddlCanastillaCierreTurno.Items.Clear();
            this.ddlCanastillaCierreTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlCanastillaCierreTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlCanastillaCierreTurno.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlNVehiculosX
            this.ddlNVehiculosX.Items.Clear();
            this.ddlNVehiculosX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlNVehiculosX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlNVehiculosX.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlChequesCierreTurno
            this.ddlChequesCierreTurno.Items.Clear();
            this.ddlChequesCierreTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlChequesCierreTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlChequesCierreTurno.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlCreditoDirectoCierre
            this.ddlCreditoDirectoCierre.Items.Clear();
            this.ddlCreditoDirectoCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlCreditoDirectoCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlCreditoDirectoCierre.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlDetalleTanquesCierreTurno
            this.ddlDetalleTanquesCierreTurno.Items.Clear();
            this.ddlDetalleTanquesCierreTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlDetalleTanquesCierreTurno.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlDetalleTanquesCierreTurno.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlCreditoDirectoX
            this.ddlCreditoDirectoX.Items.Clear();
            this.ddlCreditoDirectoX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlCreditoDirectoX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlCreditoDirectoX.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlDetalleVentasCierre
            this.ddlDetalleVentasCierre.Items.Clear();
            this.ddlDetalleVentasCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlDetalleVentasCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlDetalleVentasCierre.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlVentasNoImpresasCierre
            this.ddlVentasNoImpresasCierre.Items.Clear();
            this.ddlVentasNoImpresasCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlVentasNoImpresasCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlVentasNoImpresasCierre.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlReporteX
            this.ddlReporteX.Items.Clear();
            this.ddlReporteX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlReporteX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlReporteX.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlDetalleVentasX
            this.ddlDetalleVentasX.Items.Clear();
            this.ddlDetalleVentasX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlDetalleVentasX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlDetalleVentasX.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlCanastillaX
            this.ddlCanastillaX.Items.Clear();
            this.ddlCanastillaX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlCanastillaX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlCanastillaX.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlBolsaTurnoX
            this.ddlBolsaTurnoX.Items.Clear();
            this.ddlBolsaTurnoX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlBolsaTurnoX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlBolsaTurnoX.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlChequesX
            this.ddlChequesX.Items.Clear();
            this.ddlChequesX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlChequesX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlChequesX.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlReporteCierre
            this.ddlReporteCierre.Items.Clear();
            this.ddlReporteCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlReporteCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlReporteCierre.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlFormasPagoX
            this.ddlFormasPagoX.Items.Clear();
            this.ddlFormasPagoX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlFormasPagoX.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlFormasPagoX.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlVentasNoCierre
            this.ddlVentasNoCierre.Items.Clear();
            this.ddlVentasNoCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlVentasNoCierre.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlVentasNoCierre.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlImprimeFidelizado
            this.ddlImprimeFidelizado.Items.Clear();
            this.ddlImprimeFidelizado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlImprimeFidelizado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlImprimeFidelizado.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlImprimirVentaEnCero
            this.ddlImprimirVentaEnCero.Items.Clear();
            this.ddlImprimirVentaEnCero.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlImprimirVentaEnCero.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlImprimirVentaEnCero.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlImprimirCupoDisponible
            this.ddlImprimirCupoDisponible.Items.Clear();
            this.ddlImprimirCupoDisponible.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlImprimirCupoDisponible.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlImprimirCupoDisponible.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlImprimirTiqueteCopia
            this.ddlImprimirTiqueteCopia.Items.Clear();
            this.ddlImprimirTiqueteCopia.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.ddlImprimirTiqueteCopia.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.ddlImprimirTiqueteCopia.SelectedValue = "0";
            #endregion
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
