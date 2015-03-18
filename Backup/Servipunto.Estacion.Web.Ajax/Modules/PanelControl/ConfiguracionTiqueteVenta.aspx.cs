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
	/// Descripción breve de ConfiguracionTiqueteVenta.
	/// </summary>
	public class ConfiguracionTiqueteVenta : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblFormTitle;
		protected System.Web.UI.WebControls.HyperLink lblBack;
		protected System.Web.UI.WebControls.CheckBox chkRazonSocial;
		protected System.Web.UI.WebControls.CheckBox chkNit;
		protected System.Web.UI.WebControls.CheckBox ChkNombreEstacion;
		protected System.Web.UI.WebControls.CheckBox chkTituloTiquete;
		protected System.Web.UI.WebControls.CheckBox chkDireccion;
		protected System.Web.UI.WebControls.CheckBox chkTelefono;
		protected System.Web.UI.WebControls.CheckBox chkFechaHora;
		protected System.Web.UI.WebControls.CheckBox chkManguera;
		protected System.Web.UI.WebControls.CheckBox chkKilometraje;
		protected System.Web.UI.WebControls.CheckBox chkArticulo;
		protected System.Web.UI.WebControls.CheckBox chkMedidaPrecio;
		protected System.Web.UI.WebControls.CheckBox chkValorNeto;
		protected System.Web.UI.WebControls.CheckBox chkAbonoCuota;
		protected System.Web.UI.WebControls.CheckBox chkNombreCliente;
		protected System.Web.UI.WebControls.CheckBox chkAtendio;
		protected System.Web.UI.WebControls.CheckBox chkFechaProximaRevision;
		protected System.Web.UI.WebControls.CheckBox chkSlogan;
		protected System.Web.UI.WebControls.CheckBox chkNombreFidelizado;
		protected System.Web.UI.WebControls.CheckBox chkPuntosFidelizado;
		protected System.Web.UI.WebControls.CheckBox chkPuntosReservados;
		protected System.Web.UI.WebControls.CheckBox chkActualizacionPuntos;
		protected System.Web.UI.WebControls.CheckBox chkConsecutivoPlaca;
		protected System.Web.UI.WebControls.CheckBox chkTotal;
		protected System.Web.UI.HtmlControls.HtmlInputButton AcceptButton;
		protected System.Web.UI.HtmlControls.HtmlForm MyForm;
		protected WebApplication.FormMode _mode;
		protected Libreria.Configuracion.ConfiguracionTiqueteVenta _objConfiguracion = null;
		protected System.Web.UI.WebControls.LinkButton lkbEliminar;
		protected System.Web.UI.WebControls.CheckBox chkFormaPago;
		protected System.Web.UI.WebControls.CheckBox chkSurtidorCara;
		protected System.Web.UI.WebControls.CheckBox chkTurnoIsla;
		protected System.Web.UI.WebControls.CheckBox chkSubtotal;
		protected System.Web.UI.WebControls.CheckBox chkDescuento;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Button btnCrear;
		private bool permitir = false;
	

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
			Libreria.Configuracion.ConfiguracionesTiqueteVenta objConfiguracion = new Libreria.Configuracion.ConfiguracionesTiqueteVenta();
			try
			{
				if (objConfiguracion != null)
				{
					int n = 0;

					try
					{
						
						n = objConfiguracion.Count;
					}
					catch
					{
						n = 0;
					}
					if(objConfiguracion.Count > 0)
					{ 
						this._mode = WebApplication.FormMode.Edit;
						this.Session["IdConfiguracionTiqueteVenta"] = objConfiguracion[0].IdConfiguracion;
					}
					else
						this._mode = WebApplication.FormMode.New;

                    if (!this.IsPostBack)
                    {
                        this.InicializarForma();
                        Traducir();
                    }
                    else
                        if (Request.Form["AcceptButton"] != null)
                            this.Guardar();	
					
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

		#region Método VerificarPermisos
		private bool VerificarPermisos()
		{
			const string modulo = "Panel de Control";
			const string opcion = "ConfiguracionTiqueteVenta";
			bool permiso;

			if (this._mode == WebApplication.FormMode.New)
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
			else
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");
			
			if (permitir == true)
				permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Eliminar");
			
			if (!permiso)
			{
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
				return false;
			}			
			return true;
		}

		#endregion

		#region ObtenerObjetoConfiguracionTiqueteVenta
		private bool ObtenerObjetoConfiguracionTiqueteVenta()
		{
			try
			{
				Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,158, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
				this._objConfiguracion = Libreria.Configuracion.ConfiguracionesTiqueteVenta.ObtenerItem(Convert.ToInt32(Session["IdConfiguracionTiqueteVenta"].ToString()));
				if (this._objConfiguracion == null)
				{
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._objConfiguracion + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objConfiguracion + "]", true);
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
					this.lblBack.NavigateUrl = "Default.aspx";
					this.lblFormTitle.Text = "<b>Configuración Tiquete Venta</b>";
					try
					{

						Servipunto.Estacion.Libreria.Configuracion.Dat_Gene objDat_Gene = new Servipunto.Estacion.Libreria.Configuracion.Dat_Gene();
						objDat_Gene = Servipunto.Estacion.Libreria.Configuracion.Datos_Gene.ObtenerItem();
						
					}
					catch(Exception)
					{
                        throw new Exception(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1787, Global.Idioma));
						
					}

					//txtPuertoLecturaFidelizacion
					if (this._mode == WebApplication.FormMode.New)
					{
						#region Modo de Inserción
						this.AcceptButton.Value = "Crear";
                        btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);

						#endregion
					}
					else
					{
						#region Modo de Edición
						if (this.ObtenerObjetoConfiguracionTiqueteVenta())
						{
							//Visualización de Datos								
							this.chkRazonSocial.Checked = this._objConfiguracion.RazonSocial;
							this.chkNit.Checked = this._objConfiguracion.Nit;
							this.ChkNombreEstacion.Checked = this._objConfiguracion.NombreEstacion;
							this.chkTituloTiquete.Checked = this._objConfiguracion.TituloTiquete;
							this.chkDireccion.Checked = this._objConfiguracion.Direccion;
							this.chkTelefono.Checked = this._objConfiguracion.Telefono;	
							this.chkFechaHora.Checked = this._objConfiguracion.FechaHora;
							this.chkConsecutivoPlaca.Checked = this._objConfiguracion.ConsecutivoPlaca;						;
							this.chkTurnoIsla.Checked = this._objConfiguracion.TurnoIsla;
							this.chkSurtidorCara.Checked = this._objConfiguracion.SurtidorCara;
							this.chkManguera.Checked = this._objConfiguracion.Manguera;
							this.chkKilometraje.Checked = this._objConfiguracion.Kilometraje;
							this.chkArticulo.Checked = this._objConfiguracion.Articulo;
							this.chkMedidaPrecio.Checked = this._objConfiguracion.MedidaPrecio;
							this.chkValorNeto.Checked = this._objConfiguracion.ValorNeto;
							this.chkDescuento.Checked = this._objConfiguracion.Descuento;
							this.chkSubtotal.Checked = this._objConfiguracion.Subtotal;
							this.chkAbonoCuota.Checked = this._objConfiguracion.AbonoCuota;
							this.chkTotal.Checked = this._objConfiguracion.Total;
							this.chkFormaPago.Checked = this._objConfiguracion.Formapago;
							this.chkNombreCliente.Checked = this._objConfiguracion.NombreCliente;
							this.chkAtendio.Checked = this._objConfiguracion.Atendio;
							this.chkFechaProximaRevision.Checked = this._objConfiguracion.FechaProxMantenimiento;
							this.chkSlogan.Checked = this._objConfiguracion.Slogan;
							this.chkPuntosReservados.Checked = this._objConfiguracion.Puntosreservadosfidelizacion;
							this.AcceptButton.Value = "Guardar";
                            btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
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
						Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,159, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
						this._objConfiguracion = new Libreria.Configuracion.ConfiguracionTiqueteVenta();
						
						_objConfiguracion.IdConfiguracion = (short)1;
						this._objConfiguracion.RazonSocial = this.chkRazonSocial.Checked ;
						this._objConfiguracion.Nit = this.chkNit.Checked;
						this._objConfiguracion.NombreEstacion = this.ChkNombreEstacion.Checked;
						this._objConfiguracion.TituloTiquete = this.chkTituloTiquete.Checked; 
						this._objConfiguracion.Direccion = this.chkDireccion.Checked;
						this._objConfiguracion.Telefono = this.chkTelefono.Checked ;
						this._objConfiguracion.FechaHora = this.chkFechaHora.Checked;
						this._objConfiguracion.ConsecutivoPlaca = this.chkConsecutivoPlaca.Checked;
						this._objConfiguracion.TurnoIsla = chkTurnoIsla.Checked; 
						this._objConfiguracion.SurtidorCara = this.chkSurtidorCara.Checked;
						this._objConfiguracion.Manguera = this.chkManguera.Checked ;
						this._objConfiguracion.Kilometraje = this.chkKilometraje.Checked;
						this._objConfiguracion.Articulo = this.chkArticulo.Checked; 
						this._objConfiguracion.MedidaPrecio = this.chkMedidaPrecio.Checked ;
						this._objConfiguracion.ValorNeto = this.chkValorNeto.Checked;
						this._objConfiguracion.Descuento = this.chkDescuento.Checked; 
						this._objConfiguracion.Subtotal = this.chkSubtotal.Checked ;
						this._objConfiguracion.AbonoCuota = this.chkAbonoCuota.Checked ;
						this._objConfiguracion.Total = this.chkTotal.Checked;
						this._objConfiguracion.Formapago = this.chkFormaPago.Checked ;
						this._objConfiguracion.NombreCliente = this.chkNombreCliente.Checked ;
						this._objConfiguracion.Atendio = this.chkAtendio.Checked ;
						this._objConfiguracion.FechaProxMantenimiento = this.chkFechaProximaRevision.Checked;
						this._objConfiguracion.Slogan = this.chkSlogan.Checked;
						this._objConfiguracion.Puntosreservadosfidelizacion = this.chkPuntosReservados.Checked;
						
                        					
						
						Libreria.Configuracion.ConfiguracionesTiqueteVenta.Adicionar(this._objConfiguracion);
						#endregion
					}
					else
					{
						#region Modificar
						if (this.ObtenerObjetoConfiguracionTiqueteVenta())
						{
							Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,160, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
							this._objConfiguracion.RazonSocial = this.chkRazonSocial.Checked ;
							this._objConfiguracion.Nit = this.chkNit.Checked;
							this._objConfiguracion.NombreEstacion = this.ChkNombreEstacion.Checked;
							this._objConfiguracion.TituloTiquete = this.chkTituloTiquete.Checked; 
							this._objConfiguracion.Direccion = this.chkDireccion.Checked;
							this._objConfiguracion.Telefono = this.chkTelefono.Checked ;
							this._objConfiguracion.FechaHora = this.chkFechaHora.Checked;
							this._objConfiguracion.ConsecutivoPlaca = this.chkConsecutivoPlaca.Checked;
							this._objConfiguracion.TurnoIsla = chkTurnoIsla.Checked; 
							this._objConfiguracion.SurtidorCara = this.chkSurtidorCara.Checked;
							this._objConfiguracion.Manguera = this.chkManguera.Checked ;
							this._objConfiguracion.Kilometraje = this.chkKilometraje.Checked;
							this._objConfiguracion.Articulo = this.chkArticulo.Checked; 
							this._objConfiguracion.MedidaPrecio = this.chkMedidaPrecio.Checked ;
							this._objConfiguracion.ValorNeto = this.chkValorNeto.Checked;
							this._objConfiguracion.Descuento = this.chkDescuento.Checked; 
							this._objConfiguracion.Subtotal = this.chkSubtotal.Checked ;
							this._objConfiguracion.AbonoCuota = this.chkAbonoCuota.Checked ;
							this._objConfiguracion.Total = this.chkTotal.Checked;
							this._objConfiguracion.Formapago = this.chkFormaPago.Checked ;
							this._objConfiguracion.NombreCliente = this.chkNombreCliente.Checked ;
							this._objConfiguracion.Atendio = this.chkAtendio.Checked ;
							this._objConfiguracion.FechaProxMantenimiento = this.chkFechaProximaRevision.Checked;
							this._objConfiguracion.Slogan = this.chkSlogan.Checked;
							this._objConfiguracion.Puntosreservadosfidelizacion = this.chkPuntosReservados.Checked;						

							this._objConfiguracion.Modificar();
						}
						#endregion
					}
					Response.Redirect("Default.aspx");
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
					this._objConfiguracion = null;
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

		#region Evento Eliminar
		private void lkbEliminar_Click(object sender, System.EventArgs e)
		{
			try
			{
				permitir = true;
				if (this.VerificarPermisos())
				{
					Libreria.Configuracion.ConfiguracionesTiqueteVenta.Eliminar(Convert.ToInt32(this.Session["IdConfiguracionTiqueteVenta"].ToString()));
					Response.Redirect("Default.aspx");
				}

			}
			catch (Exception ex)
			{
				this.lblError.Text = this.lblError.Text + ex.Message + " <br>";

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

        private void Traducir()
        {
            chkRazonSocial.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1147,Global.Idioma);
            chkNit.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1150,Global.Idioma);
            ChkNombreEstacion.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1623,Global.Idioma);
            chkTituloTiquete.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1713, Global.Idioma);
            chkDireccion.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(855, Global.Idioma);
            chkTelefono.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(856, Global.Idioma);
            chkFechaHora.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1626, Global.Idioma);
            chkConsecutivoPlaca.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1627, Global.Idioma);
            chkTurnoIsla.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1628, Global.Idioma);
            chkSurtidorCara.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1629, Global.Idioma);
            chkManguera.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1630, Global.Idioma);
            chkKilometraje.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1631, Global.Idioma);            
            chkArticulo.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1632, Global.Idioma);
            chkMedidaPrecio.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1633, Global.Idioma);
            chkValorNeto.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1634, Global.Idioma);
            chkDescuento.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1635, Global.Idioma);
            chkSubtotal.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1636, Global.Idioma);
            chkAbonoCuota.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1637, Global.Idioma);
            chkTotal.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1638, Global.Idioma);
            chkFormaPago.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1639, Global.Idioma);
            chkNombreCliente.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1640, Global.Idioma);
            chkAtendio.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1641, Global.Idioma);
            chkFechaProximaRevision.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1642, Global.Idioma);
            chkSlogan.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1643, Global.Idioma);
            chkNombreFidelizado.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1644, Global.Idioma);
            chkPuntosFidelizado.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1645, Global.Idioma);
            chkPuntosReservados.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1646, Global.Idioma);
            chkActualizacionPuntos.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1647, Global.Idioma);
            lkbEliminar.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(775, Global.Idioma);
            lblBack.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(975, Global.Idioma);
            lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1620, Global.Idioma); 
        }

        protected void chkNit_CheckedChanged(object sender, EventArgs e)
        {

        }
        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion
    }
}
