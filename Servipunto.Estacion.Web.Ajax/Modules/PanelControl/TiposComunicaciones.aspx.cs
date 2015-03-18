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
	public class TiposComunicaciones : System.Web.UI.Page
	{
		#region Sección de Declaraciones
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblTituloGenerales;
		protected System.Web.UI.WebControls.LinkButton lbGeneral;
		protected System.Web.UI.WebControls.HyperLink lblBackGeneral;
		protected System.Web.UI.WebControls.Label lblTituloConfiguracion;
		protected System.Web.UI.WebControls.LinkButton lbConf;
		protected System.Web.UI.WebControls.HyperLink lblBackConf;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected System.Web.UI.HtmlControls.HtmlTableRow FilaDatosEnLinea;
		protected System.Web.UI.WebControls.DropDownList ddlDispositivo;
		protected System.Web.UI.WebControls.DropDownList ddlModo;
		protected System.Web.UI.WebControls.DropDownList ddlModoInicioEstacion;
		protected System.Web.UI.WebControls.DropDownList ddlEstado;
		protected System.Web.UI.WebControls.DropDownList ddlPeriodoRecepcion;
		protected System.Web.UI.WebControls.DropDownList ddlPeriodoEnvio;
		protected System.Web.UI.WebControls.DropDownList ddlTipo;
		protected System.Web.UI.WebControls.TextBox txtPuertoSerial;
		protected System.Web.UI.WebControls.TextBox txtServidorFTP;
		protected System.Web.UI.WebControls.TextBox txtUsuario;
		protected System.Web.UI.WebControls.TextBox txtIPServidor;
		protected System.Web.UI.WebControls.TextBox txtContraseña;
		protected System.Web.UI.WebControls.TextBox txtSocketServidor;
		protected System.Web.UI.WebControls.TextBox txtDirectorioVirtual;
		protected System.Web.UI.WebControls.TextBox txtTimeOut;
		protected System.Web.UI.WebControls.TextBox txtActiveTimeOut;
		protected System.Web.UI.WebControls.TextBox txtPuertoFTP;
		protected System.Web.UI.WebControls.TextBox PathFTP;
		protected System.Web.UI.WebControls.Repeater Results;
		protected System.Web.UI.WebControls.TextBox ArchivosEnvio;
		protected System.Web.UI.WebControls.TextBox ArchivosProcesados;
		protected System.Web.UI.WebControls.TextBox Generador;
		protected System.Web.UI.WebControls.TextBox Cliser;
		protected System.Web.UI.WebControls.TextBox txtRutaWebServiceCC;
		protected System.Web.UI.WebControls.TextBox txtIntervaloSincronizacionCC;		
		protected System.Web.UI.WebControls.CheckBox cbGasonet;
		protected System.Web.UI.WebControls.Label lblIpServidor;
		protected System.Web.UI.WebControls.Label lblCliser;
		protected Libreria.Configuracion.Comunicacion _objComunicacion = null;

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
        protected AjaxControlToolkit.TabPanel TabPanelGeneral;
        protected AjaxControlToolkit.TabPanel TabPanelLotes;
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
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            TabPanelGeneral.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1404, Global.Idioma);
            TabPanelLotes.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1424, Global.Idioma);
           

            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1406, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(342, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1407, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1408, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1417, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(750, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1410, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(533, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1411, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1420, Global.Idioma);

            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1412, Global.Idioma);
            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1421, Global.Idioma);
            Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1413, Global.Idioma);
            Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Global.Idioma);
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1414, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1375, Global.Idioma);
            Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1427, Global.Idioma);
            Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1426, Global.Idioma);
            Label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1428, Global.Idioma);
            Label20.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1429, Global.Idioma);

            Label21.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1430, Global.Idioma);
            Label22.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1922, Global.Idioma);
            Label23.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1432, Global.Idioma);
            Label24.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1433, Global.Idioma);
            
                       

            lblTituloGenerales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1405, Global.Idioma);
            lbGeneral.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lblBackGeneral.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblTituloConfiguracion.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(530, Global.Idioma);
            lbConf.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lblBackConf.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {

            #region poblar RadioButton  ddlModoInicioEstacion
            this.ddlModoInicioEstacion.Items.Clear();
            this.ddlModoInicioEstacion.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlModoInicioEstacion.Items.Insert(1, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(844, Global.Idioma), "Ventas"));
            this.ddlModoInicioEstacion.Items.Insert(2, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(569, Global.Idioma), "Manual"));
            this.ddlModoInicioEstacion.SelectedValue = "(Sin Definir)";
            #endregion            
            #region poblar RadioButton  ddlEstado
            this.ddlEstado.Items.Clear();
            this.ddlEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlEstado.Items.Insert(1, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "Activo"));
            this.ddlEstado.Items.Insert(2, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "Inactivo"));
            this.ddlEstado.SelectedValue = "(Sin Definir)";
            #endregion
            #region poblar RadioButton  ddlModo
            this.ddlModo.Items.Clear();
            this.ddlModo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma), "(Sin Definir)"));
            this.ddlModo.Items.Insert(1, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1855, Global.Idioma), "Autom&#225;tico"));
            this.ddlModo.Items.Insert(2, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(569, Global.Idioma), "Manual"));
            this.ddlModo.SelectedValue = "(Sin Definir)";
            #endregion            

        }
        #endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{    
			this.lbGeneral.Click += new System.EventHandler(this.lbGeneral_Click);
			this.ddlTipo.SelectedIndexChanged += new System.EventHandler(this.ddlTipo_SelectedIndexChanged);
			this.lbConf.Click += new System.EventHandler(this.lbConf_Click);
			this.cbGasonet.CheckedChanged += new System.EventHandler(this.cbGasonet_CheckedChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "Datos Generales";
			bool permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}			
			return true;
		}
		#endregion

		#region ObtenerObjetoComunicaciones
		private bool ObtenerObjetoComunicaciones()
		{
			try
			{
				this._objComunicacion = Libreria.Configuracion.Comunicaciones.ObtenerItem();
				if (this._objComunicacion == null)
				{
					this._objComunicacion = new Servipunto.Estacion.Libreria.Configuracion.Comunicacion();
					return true;
				}
				else
					return true;
			}
			catch (Exception ex)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objComunicacion + "]", true);
				return false;
			}
		}
		#endregion

		#region Inicialización del Formulario
		private void InicializarForma()
		{
			if (this.VerificarPermisos())
			{
                RadioButtonTraduccion();
			
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,127, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				if (this.ObtenerObjetoComunicaciones())
				{
					Session["ActiveTab"] = "General";
					try
					{
						//Visualización de Datos
						#region Carga Pestaña generales
						ddlDispositivo.SelectedValue = _objComunicacion.Dispositivo;
						txtPuertoSerial.Text = _objComunicacion.Puerto;
						ddlTipo.SelectedValue = _objComunicacion.TipoTransmision;

						if(_objComunicacion.TipoTransmision == "Linea" ||
							_objComunicacion.TipoTransmision == "Línea")
						{
							FilaDatosEnLinea.Visible = true;
							lblCliser.Text = "On Line";
						}
						else
						{
							FilaDatosEnLinea.Visible = false;
							lblCliser.Text = "CliServ";
						}

						txtServidorFTP.Text = _objComunicacion.FtpServerIp;

						cbGasonet.Checked = _objComunicacion.IsGasonet;

						if(_objComunicacion.IsGasonet)
						{
							txtIPServidor.Text = _objComunicacion.IpServidorGasonet;
							lblIpServidor.Text = "IP Servidor Gasonet:";
						}
						else
						{
							txtIPServidor.Text = _objComunicacion.OnLineServerIP;
							lblIpServidor.Text = "URL Web Service CComputo:";
						}

						txtSocketServidor.Text = _objComunicacion.OnLineServerSocket;
						txtTimeOut.Text = _objComunicacion.OnlineTimeOut.ToString();
						txtActiveTimeOut.Text = _objComunicacion.InActiveTimeOut.ToString();
						PathFTP.Text = _objComunicacion.RutaFTP;
						txtUsuario.Text = _objComunicacion.FtpUserName;						
						txtContraseña.Text = _objComunicacion.FtpUserPasswd;
						txtDirectorioVirtual.Text = _objComunicacion.FtpVirtualDirectory;
						txtPuertoFTP.Text = _objComunicacion.FtpPort.ToString();
					
						ddlModoInicioEstacion.SelectedValue = _objComunicacion.ModoInicioTransmisor;
						ddlEstado.SelectedValue = _objComunicacion.EstadoComunicaciones;
						txtIntervaloSincronizacionCC.Text = _objComunicacion.IntervaloSincronizacion.ToString();
						#endregion

						#region Cargar Pestaña Configuración
						ddlModo.SelectedValue = _objComunicacion.ModoTransmision;
						ddlPeriodoEnvio.SelectedValue = _objComunicacion.PeriodoAutoEnvio.ToString();
						ddlPeriodoRecepcion.SelectedValue = _objComunicacion.PeriodoAutoReception.ToString();
						ArchivosEnvio.Text = _objComunicacion.RutaEnvios;
						ArchivosProcesados.Text = _objComunicacion.RutaProcesados;
						Generador.Text = _objComunicacion.RutaGenerador;
						Cliser.Text = _objComunicacion.RutaCliserv_Online;
						#endregion
					}
					catch(Exception ex)
					{
						SetError(ex.Message, false);
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
		}
		#endregion

		#region Guardar
		private void Guardar()
		{
			if (this.Validar())
			{
				try
				{
						if (this.ObtenerObjetoComunicaciones())
						{
							#region Guardar Pestaña generales
							_objComunicacion.Dispositivo = ddlDispositivo.SelectedValue;
							_objComunicacion.Puerto = txtPuertoSerial.Text;
							_objComunicacion.TipoTransmision = ddlTipo.SelectedValue;
							_objComunicacion.FtpServerIp = txtServidorFTP.Text;

							_objComunicacion.IsGasonet = cbGasonet.Checked;

							if(cbGasonet.Checked)
								_objComunicacion.IpServidorGasonet = txtIPServidor.Text;
							else
								_objComunicacion.OnLineServerIP = txtIPServidor.Text;

							_objComunicacion.OnLineServerSocket = txtSocketServidor.Text;
							_objComunicacion.OnlineTimeOut = int.Parse(txtTimeOut.Text);
							_objComunicacion.InActiveTimeOut = int.Parse(txtActiveTimeOut.Text);
							_objComunicacion.RutaFTP = PathFTP.Text;
							_objComunicacion.FtpUserName = txtUsuario.Text;							
							if(txtContraseña.Text.Trim().Length != 0)
								_objComunicacion.FtpUserPasswd = txtContraseña.Text;
							_objComunicacion.FtpVirtualDirectory = txtDirectorioVirtual.Text;
							_objComunicacion.FtpPort = int.Parse(txtPuertoFTP.Text);						
							_objComunicacion.ModoInicioTransmisor = ddlModoInicioEstacion.SelectedValue;
							_objComunicacion.EstadoComunicaciones = ddlEstado.SelectedValue;
							_objComunicacion.IntervaloSincronizacion = Int16.Parse(txtIntervaloSincronizacionCC.Text.Trim());
							#endregion

							#region Guardar Pestaña Configuración
							_objComunicacion.ModoTransmision = ddlModo.SelectedValue;
							_objComunicacion.PeriodoAutoEnvio = int.Parse(ddlPeriodoEnvio.SelectedValue);
							_objComunicacion.PeriodoAutoReception = int.Parse(ddlPeriodoRecepcion.SelectedValue);
							_objComunicacion.RutaEnvios = ArchivosEnvio.Text;
							_objComunicacion.RutaProcesados = ArchivosProcesados.Text;
							_objComunicacion.RutaGenerador = Generador.Text;
							_objComunicacion.RutaCliserv_Online = Cliser.Text;
							#endregion

							if(Libreria.Configuracion.Comunicaciones.ObtenerItem() == null)
							{
								Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,128, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
								Servipunto.Estacion.Libreria.Configuracion.Comunicaciones.Adicionar(this._objComunicacion);
							}
							else
							{
								Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,129, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
								this._objComunicacion.Modificar();
							}

							Response.Redirect("default.aspx");
						}
				}
				catch (Exception ex)
				{
					SetError(ex.Message, false);
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
		#endregion

		#region Validar
		private bool Validar()
		{
			if(ddlDispositivo.SelectedIndex == 0)
			{
				Session["ActiveTab"] = "General";
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1923, Global.Idioma), false);
				return false;			
			}

			if(ddlTipo.SelectedIndex == 0)
			{
				Session["ActiveTab"] = "General";
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1924, Global.Idioma), false);
				return false;			
			}

			if(ddlTipo.SelectedValue == "Línea")
			{
				if(txtTimeOut.Text.Length != 0)
				{
					try
					{
						int.Parse(txtTimeOut.Text);
					}
					catch
					{
						Session["ActiveTab"] = "General";
                        SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1925, Global.Idioma), false);
						return false;
					}
				}
				else
				{
					Session["ActiveTab"] = "General";
                    SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1926, Global.Idioma), false);
					return false;
				}

				if(txtActiveTimeOut.Text.Length != 0)
				{
					try
					{
						int.Parse(txtActiveTimeOut.Text);
					}
					catch
					{
						Session["ActiveTab"] = "General";
                        SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1927, Global.Idioma), false);
						return false;
					}
				}
				else
				{
					Session["ActiveTab"] = "General";
                    SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1928, Global.Idioma), false);
					return false;
				}

				if(txtPuertoFTP.Text.Length != 0)
				{
					try
					{
						int.Parse(txtPuertoFTP.Text);
					}
					catch
					{
						Session["ActiveTab"] = "General";
                        SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1929, Global.Idioma), false);
						return false;
					}
				}
				else
				{
					Session["ActiveTab"] = "General";
                    SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1930, Global.Idioma), false);
					return false;
				}
			}

			if(ddlModoInicioEstacion.SelectedIndex == 0)
			{
				Session["ActiveTab"] = "General";
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1931, Global.Idioma), false);
				return false;			
			}

			if(ddlEstado.SelectedIndex == 0)
			{
				Session["ActiveTab"] = "General";
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1932, Global.Idioma), false);
				return false;			
			}

			if(ddlModo.SelectedIndex == 0)
			{
				Session["ActiveTab"] = "Lotes";
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1933, Global.Idioma), false);
				return false;			
			}

			if(ddlPeriodoRecepcion.SelectedIndex == 0)
			{
				Session["ActiveTab"] = "Lotes";
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1934, Global.Idioma), false);
				return false;			
			}

			if(ddlPeriodoEnvio.SelectedIndex == 0)
			{
				Session["ActiveTab"] = "Lotes";
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1935, Global.Idioma), false);
				return false;			
			}

			this.ClearError();
			return true;
		}
		#endregion

		#region Guarda Los datos ingresados
		private void lbGeneral_Click(object sender, System.EventArgs e)
		{
			Session["ActiveTab"] = "General";
			Guardar();
		}

		private void lbConf_Click(object sender, System.EventArgs e)
		{
			Session["ActiveTab"] = "Lotes";
			Guardar();
		}
		#endregion

		#region Mostrar / Ocultar Datos en Linea
		private void ddlTipo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["ActiveTab"] = "General";
			if(ddlTipo.SelectedValue == "Línea")
			{
				FilaDatosEnLinea.Visible = true;
				lblCliser.Text = "On Line";
			}
			else
			{
				FilaDatosEnLinea.Visible = false;
				lblCliser.Text = "CliServ";
			}
		}
		#endregion

		#region Cambio en Gasonet
		private void cbGasonet_CheckedChanged(object sender, System.EventArgs e)
		{
			ObtenerObjetoComunicaciones();
			if(cbGasonet.Checked)
			{
				txtIPServidor.Text = _objComunicacion.IpServidorGasonet;
				lblIpServidor.Text = "IP Servidor Gasonet:";
			}
			else
			{
				txtIPServidor.Text = _objComunicacion.OnLineServerIP;
				lblIpServidor.Text = "URL Web Service CComputo:";
			}			
		}
		#endregion
	}
}
