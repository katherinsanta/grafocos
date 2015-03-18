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

namespace Servipunto.Estacion.Web.Modules.Procesos
{
    public partial class AjustePago : System.Web.UI.Page
    {
        #region Definicion de variables
        protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
        protected System.Web.UI.WebControls.Label lblFormTitle;
        protected System.Web.UI.HtmlControls.HtmlInputHidden SubmitSource;
        protected Libreria.Pago _objPago = null;
        protected Libreria.PagoAuditoria _objPagoAuditoria = null;
        protected Libreria.Venta _objVenta = null;
        protected int _codigoEfectivo = 0;
        protected Decimal _valorInicialEfectivo = 0;
        protected System.Web.UI.WebControls.TextBox txtTotal;
        protected System.Web.UI.WebControls.DropDownList cboFormasPago2;
        protected System.Web.UI.WebControls.Calendar CalendarioFechaInicio;
        protected System.Web.UI.WebControls.Button btnBuscar;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
        protected System.Web.UI.WebControls.TextBox txtTiquete;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
        protected System.Web.UI.WebControls.DropDownList cboIsla;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
        protected System.Web.UI.WebControls.DropDownList cboTurno;
        protected System.Web.UI.WebControls.ImageButton btnFechaInicio;
        protected System.Web.UI.WebControls.TextBox txtFecha;
        protected System.Web.UI.WebControls.TextBox txtTiqueteEncontrado;
        protected System.Web.UI.WebControls.TextBox txtCodigoInicial;
        protected System.Web.UI.WebControls.TextBox txtValorInicial;
        protected System.Web.UI.WebControls.TextBox txtIdPago;
        protected System.Web.UI.WebControls.Label lblTituloGenerales;
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.DropDownList cboFormasPago3;
        protected System.Web.UI.WebControls.DataGrid lstPagos;
        protected System.Web.UI.WebControls.DropDownList cboFormasPago;
        protected System.Web.UI.WebControls.TextBox txtObservacion;
        protected System.Web.UI.WebControls.TextBox txtValor;
        protected System.Web.UI.WebControls.TextBox txtObservacion2;
        protected System.Web.UI.WebControls.LinkButton btnGuardar;
        protected System.Web.UI.WebControls.LinkButton btnActualizarOriginal;
        protected System.Web.UI.WebControls.HyperLink lblBack;
        protected Decimal _sumatoria;
        protected Decimal _excedenteOriginal;

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

            this.lblError.Visible = false;
            if (!IsPostBack)
                this.InicializarForma();

        }
        #endregion

        #region * Método de Inicialización del Formulario
        private void InicializarForma()
        {
            CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
            CalendarExtender1.SelectedDate = System.DateTime.Today;
            txtFecha.Text = CalendarExtender1.SelectedDate.ToString();
            if (this.VerificarPermisos())
            {
                if (Request.UrlReferrer != null)
                    this.lblBack.NavigateUrl = Request.UrlReferrer.ToString();
                else
                    this.lblBack.NavigateUrl = "Roles.aspx";
                
                this.InicializarModoEdicion();
            }
        }
        #endregion

        #region Método VerificarPermisos
        private bool VerificarPermisos()
        {
            bool permiso;
            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar("Procesos", "Administración de pagos", "Pagos");
            if (!permiso)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);                
                return false;
            }
            return true;
        }
        #endregion

        #region Método Inicializar Modo de Edición
        private void InicializarModoEdicion()
        {

            this.lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(487, Global.Idioma); 
            this.lblError.Visible = false;
            this.CargarFormasPago();
            this.CargarIslas();

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
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(978, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(973, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(976, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(977, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(881, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(988, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(148, Global.Idioma);
            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(988, Global.Idioma);

            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(989, Global.Idioma);            

            btnBuscar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(763, Global.Idioma);

            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(487, Global.Idioma);

            btnActualizarOriginal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2185, Global.Idioma);
            lblTituloGenerales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2184, Global.Idioma);
                       
            TabPanelFilaTab1.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(978, Global.Idioma);
            TabPanelFilaTab2.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(990, Global.Idioma);
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

        #region Calcula el valor de cuota deacuerdo al Porcentaje de pago
        private decimal CalcularCuota(decimal totalVenta, decimal valorPago, decimal totalCuota)
        {
            decimal valorTemporal;

            if (totalVenta == 0 || totalCuota == 0)
                return 0;
            valorTemporal = (totalCuota * (valorPago * 100 / totalVenta)) / 100;
            return Math.Round(valorTemporal, 4);
        }

        #endregion

        #region Método Guardar
        private void Guardar()
        {
            try
            {
                if (!this.Validar())
                    return;
                //guarda el pago
                //decimal cuota=0;
                this._objPagoAuditoria = new Servipunto.Estacion.Libreria.PagoAuditoria();
                this._objPago = new Servipunto.Estacion.Libreria.Pago();
                this._objVenta = Libreria.Ventas.ObtenerItem(int.Parse(txtTiqueteEncontrado.Text), DateTime.Parse(txtFecha.Text), int.Parse(cboIsla.SelectedValue), int.Parse(cboTurno.SelectedValue));
                _objPago.CodigoFormaPago = int.Parse(cboFormasPago.SelectedValue);
                _objPago.Total = decimal.Parse(txtValor.Text);
                _objPago.ConsecutivoVenta = int.Parse(txtTiqueteEncontrado.Text);
                _objPago.Fecha = DateTime.Parse(txtFecha.Text);
                _objPago.FechaReal = DateTime.Parse(txtFecha.Text);
                _objPago.ConsecutivoVenta = _objVenta.Consecutivo;
                _objPago.PrefijoVenta = _objVenta.PrefijoVenta;
                _objPago.Cantidad = CalcularCuota(Decimal.Parse(txtTotal.Text), Decimal.Parse(txtValor.Text), _objVenta.Cantidad);
                _objPago.Descuento = CalcularCuota(Decimal.Parse(txtTotal.Text), Decimal.Parse(txtValor.Text), _objVenta.Descuento);
                _objPago.ValorNeto = CalcularCuota(Decimal.Parse(txtTotal.Text), Decimal.Parse(txtValor.Text), _objVenta.ValorNeto);
                _objPago.subTotal = CalcularCuota(Decimal.Parse(txtTotal.Text), Decimal.Parse(txtValor.Text), _objVenta.SubTotal);
                _objPago.Iva = CalcularCuota(Decimal.Parse(txtTotal.Text), Decimal.Parse(txtValor.Text), _objVenta.ValorIva);
                _objPago.TotalCuota = CalcularCuota(Decimal.Parse(txtTotal.Text), Decimal.Parse(txtValor.Text), _objVenta.TotalCuota);
                _objPago.CodigoArticulo = _objVenta.CodigoArticulo;

                if (btnGuardar.Text == Libreria.Configuracion.PalabrasIdioma.Traduccion(1001, Global.Idioma))
                {
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 378, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    Libreria.Pagos.Adicionar(_objPago);

                    _objPagoAuditoria.ValorInicial = _sumatoria + Decimal.Parse(txtValor.Text); //_valorInicialEfectivo;
                    _objPagoAuditoria.CodigoFormaPagoInicial = int.Parse(cboFormasPago2.SelectedValue);
                }
                else
                {
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 379, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    _objPago.IdPago = int.Parse(txtIdPago.Text);
                    _objPago.Modificar();
                    _objPagoAuditoria.ValorInicial = Decimal.Parse(txtValorInicial.Text);
                    _objPagoAuditoria.CodigoFormaPagoInicial = int.Parse(txtCodigoInicial.Text);

                }
                //guarda la auditoria					
                _objPagoAuditoria.Consecutivo = _objPago.ConsecutivoVenta;
                _objPagoAuditoria.ValorFinal = _objPago.Total;
                _objPagoAuditoria.CodigoFormaPagoFinal = _objPago.CodigoFormaPago;
                _objPagoAuditoria.IdUsuario = ((Libreria.Usuario)Session["Usuario"]).IdUsuario;
                _objPagoAuditoria.FechaCambio = DateTime.Now;
                _objPagoAuditoria.Observaciones = txtObservacion.Text;
                Libreria.PagosAuditoria.Adicionar(_objPagoAuditoria);

                //actualiza el valor del pago original
                _objPago.CodigoFormaPago = int.Parse(cboFormasPago2.SelectedValue);
                _objPago.Total = _sumatoria;
                _objPago.Cantidad = CalcularCuota(Decimal.Parse(txtTotal.Text), _sumatoria, _objVenta.Cantidad);
                _objPago.Descuento = CalcularCuota(Decimal.Parse(txtTotal.Text), _sumatoria, _objVenta.Descuento);
                _objPago.ValorNeto = CalcularCuota(Decimal.Parse(txtTotal.Text), _sumatoria, _objVenta.ValorNeto);
                _objPago.subTotal = CalcularCuota(Decimal.Parse(txtTotal.Text), _sumatoria, _objVenta.SubTotal);
                _objPago.Iva = CalcularCuota(Decimal.Parse(txtTotal.Text), _sumatoria, _objVenta.ValorIva);
                _objPago.TotalCuota = CalcularCuota(Decimal.Parse(txtTotal.Text), _sumatoria, _objVenta.TotalCuota);

                ////////////////////////
                //guarda la auditoria del pago original					
                //_objPagoAuditoria.Consecutivo = _objPago.ConsecutivoVenta;

                _objPagoAuditoria.ValorInicial = _excedenteOriginal;
                _objPagoAuditoria.CodigoFormaPagoInicial = int.Parse(cboFormasPago2.SelectedValue);
                _objPagoAuditoria.ValorFinal = _sumatoria;
                _objPagoAuditoria.CodigoFormaPagoFinal = _objPago.CodigoFormaPago;
                _objPagoAuditoria.IdUsuario = ((Libreria.Usuario)Session["Usuario"]).IdUsuario;
                _objPagoAuditoria.FechaCambio = DateTime.Now;
                _objPagoAuditoria.Observaciones = txtObservacion.Text;
                Libreria.PagosAuditoria.Adicionar(_objPagoAuditoria);


                ////////////////////////


                if (_codigoEfectivo != 0)
                {
                    _objPago.IdPago = _codigoEfectivo;
                    _objPago.ConsecutivoVenta = int.Parse(txtTiqueteEncontrado.Text);
                    _objPago.Modificar();
                }
                else
                {
                    _objPago.CodigoFormaPago = int.Parse(cboFormasPago2.SelectedValue);
                    _objPago.Total = _sumatoria;
                    Libreria.Pagos.Adicionar(_objPago);
                }

                this.Limpiar();
                this.BuscarPagos();

            }
            catch (Exception ex)
            {
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2171, Global.Idioma), false);
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
                this._objPago = null;
            }

        }
        #endregion

        #region Método Cargar Formas de pago
        private void CargarFormasPago()
        {
            this.lblError.Text = "";

            Libreria.Configuracion.FormasPago objFormasPago = new Servipunto.Estacion.Libreria.Configuracion.FormasPago();

            this.cboFormasPago.DataSource = objFormasPago;
            this.cboFormasPago.DataTextField = "Descripcion";
            this.cboFormasPago.DataValueField = "IdFormaPago";
            this.cboFormasPago.DataBind();
            this.cboFormasPago2.DataSource = objFormasPago;
            this.cboFormasPago2.DataTextField = "Descripcion";
            this.cboFormasPago2.DataValueField = "IdFormaPago";
            this.cboFormasPago2.DataBind();
            this.cboFormasPago3.DataSource = objFormasPago;
            this.cboFormasPago3.DataTextField = "Descripcion";
            this.cboFormasPago3.DataValueField = "IdFormaPago";
            this.cboFormasPago3.DataBind();

            objFormasPago = null;
        }
        #endregion

        #region Método Cargar Islas
        private void CargarIslas()
        {
            this.lblError.Text = "";

            Libreria.Configuracion.Islas objIslas = new Servipunto.Estacion.Libreria.Configuracion.Islas();

            this.cboIsla.DataSource = objIslas;
            this.cboIsla.DataTextField = "Descripcion";
            this.cboIsla.DataValueField = "IdIsla";
            this.cboIsla.DataBind();

            objIslas = null;
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
            this.btnFechaInicio.Click += new System.Web.UI.ImageClickEventHandler(this.btnFechaInicio_Click);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            //this.CalendarioFechaInicio.SelectionChanged += new System.EventHandler(this.CalendarioFechaInicio_SelectionChanged);
            this.btnActualizarOriginal.Click += new System.EventHandler(this.btnActualizarOriginal_Click);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.lstPagos.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.lstPagos_EditCommand);
            this.Load += new System.EventHandler(this.Page_Load);

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

        #region Método Buscar
        private void btnBuscar_Click(object sender, System.EventArgs e)
        {

            this.BuscarPagos();

        }
        private void BuscarPagos()
        {
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 377, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.Limpiar();
                txtTiqueteEncontrado.Text = "";
                this._objVenta = Libreria.Ventas.ObtenerItem(int.Parse(txtTiquete.Text), DateTime.Parse(txtFecha.Text), int.Parse(cboIsla.SelectedValue), int.Parse(cboTurno.SelectedValue));
                cboFormasPago2.SelectedValue = _objVenta.CodigoFormaPago.ToString();
                txtTotal.Text = _objVenta.Total.ToString();
                txtCodigoInicial.Text = _objVenta.CodigoFormaPago.ToString();
                txtTiqueteEncontrado.Text = _objVenta.Consecutivo.ToString();
                DataSet ds = Libreria.Pagos.ObtenerItems(_objVenta.Consecutivo);
                this.lstPagos.DataSource = ds;
                this.lstPagos.DataKeyField = "Id_Pagos";
                this.lstPagos.DataBind();

            }
            catch (Exception ex)
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2132, Global.Idioma)+": " + txtTiquete.Text + "! " + ex.Message, false);

            }

        }
        #endregion

        #region Limpiar textos
        private void Limpiar()
        {
            txtIdPago.Text = "";
            txtValor.Text = "";
            lblError.Visible = false;
            btnGuardar.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1001, Global.Idioma);
            _sumatoria = 0;
            txtCodigoInicial.Text = "";
            txtValorInicial.Text = "";
            txtObservacion.Text = "";
            txtObservacion2.Text = "";


        }

        #endregion

        #region Validar
        private bool Validar()
        {
            Decimal valor;
            _sumatoria = 0;
            _excedenteOriginal = 0;

            //valida si a encotrado algun tiquete
            if (txtTiqueteEncontrado.Text.Trim() == "")
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2172, Global.Idioma), false);
                return false;
            }
            //valida si intenta adicional el mismo modo de pago original
            if (cboFormasPago.SelectedValue == cboFormasPago2.SelectedValue)
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2173, Global.Idioma)+" '" + cboFormasPago.SelectedItem + "'!", false);
                return false;
            }

            //sino hay datos es porque va a crear el pago en efectivo y no hay nada que validar ningun caso
            if (lstPagos.Items.Count == 0)
            {
                _codigoEfectivo = 0;
                //_valorInicialEfectivo = Decimal.Parse(txtTotal.Text);
                _excedenteOriginal = Decimal.Parse(txtTotal.Text);
                _sumatoria = Decimal.Parse(txtTotal.Text) - Decimal.Parse(txtValor.Text);
                return true;
            }

            //valida que haya dijitado alguna observacion
            if (txtObservacion.Text.Trim() == "")
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2174, Global.Idioma)+" " + cboFormasPago.SelectedItem + "!", false);
                return false;
            }

            //valida si el valor de la forma de pago esta vacio
            if (txtValor.Text.Trim() == "")
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2175, Global.Idioma)+" " + cboFormasPago.SelectedItem + "!", false);
                return false;
            }
            //valida si no esta repitiendo la forma de pago
            for (int i = 0; i < lstPagos.Items.Count; i++)
            {
                if (lstPagos.Items[i].Cells[0].Text == cboFormasPago.SelectedValue && lstPagos.DataKeys[i].ToString() != txtIdPago.Text) //&& txtIdPago.Text != "")
                {
                    SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2176, Global.Idioma)+" '" + lstPagos.Items[i].Cells[1].Text.Trim() + "' "+Libreria.Configuracion.PalabrasIdioma.Traduccion(2177, Global.Idioma)+" '" + txtTiqueteEncontrado.Text.Trim() + "'!", false);
                    return false;
                }
                //guarda el codigo original de la venta para actualizarlo segun quede el nuevo el valor
                if (lstPagos.Items[i].Cells[0].Text == cboFormasPago2.SelectedValue)
                {
                    _codigoEfectivo = int.Parse(lstPagos.DataKeys[i].ToString());
                    _valorInicialEfectivo = Decimal.Parse(lstPagos.Items[i].Cells[2].Text.ToString());
                }


            }
            try
            {	//valida que no hayan caracteres especiales en el valor de la forma de pago
                valor = Decimal.Parse(txtValor.Text);
            }
            catch (Exception)
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2178, Global.Idioma)+" '" + cboFormasPago.SelectedItem + "'!", false);
                return false;

            }
            //valida que no se pase del valor de total de pagos
            for (int i = 0; i < lstPagos.Items.Count; i++)
            {
                if (lstPagos.Items[i].Cells[0].Text != txtCodigoInicial.Text && lstPagos.Items[i].Cells[0].Text != cboFormasPago.SelectedValue && lstPagos.Items[i].Cells[0].Text != cboFormasPago2.SelectedValue)
                    _sumatoria += Decimal.Parse(lstPagos.Items[i].Cells[2].Text);
                else
                    _excedenteOriginal = Decimal.Parse(lstPagos.Items[i].Cells[2].Text);
            }

            _sumatoria += Decimal.Parse(txtValor.Text);
            if (_sumatoria > Decimal.Parse(txtTotal.Text))
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2179, Global.Idioma)+" '" + _sumatoria.ToString() + "'!", false);
                return false;
            }
            _sumatoria = Decimal.Parse(txtTotal.Text) - _sumatoria;

            return true;

        }

        #endregion

        #region Manipular pagos
        private void lstPagos_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {

            if (e.CommandName == "Edit" && e.Item.Cells[0].Text != cboFormasPago2.SelectedValue)
            {
                btnGuardar.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                txtIdPago.Text = lstPagos.DataKeys[e.Item.ItemIndex].ToString();
                cboFormasPago.SelectedValue = e.Item.Cells[0].Text;
                txtValor.Text = e.Item.Cells[2].Text;

                txtCodigoInicial.Text = cboFormasPago.SelectedValue;
                txtValorInicial.Text = txtValor.Text;


            }
            else
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2180, Global.Idioma)+" '" + cboFormasPago2.SelectedItem + "' "+Libreria.Configuracion.PalabrasIdioma.Traduccion(2181, Global.Idioma)+"!", false);

        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            this.Guardar();

        }

        private void btnActualizarOriginal_Click(object sender, System.EventArgs e)
        {

            //valida si a encotrado algun tiquete
            if (txtTiqueteEncontrado.Text.Trim() == "")
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2182, Global.Idioma), false);
                return;
            }
            if (txtObservacion2.Text.Trim() == "")
            {
                SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2183, Global.Idioma), false);
                return;

            }

            try
            {	//actualiza la forma de pago original
                this._objVenta = new Servipunto.Estacion.Libreria.Venta();
                _objVenta.Consecutivo = int.Parse(txtTiqueteEncontrado.Text);
                _objVenta.CodigoFormaPago = int.Parse(cboFormasPago3.SelectedValue);
                _objVenta.Modificar();
                //guarda la auditia de la actualizacion
                this._objPagoAuditoria = new Servipunto.Estacion.Libreria.PagoAuditoria();
                _objPagoAuditoria.ValorInicial = Decimal.Parse(txtTotal.Text);
                _objPagoAuditoria.CodigoFormaPagoInicial = int.Parse(txtCodigoInicial.Text);
                _objPagoAuditoria.Consecutivo = _objVenta.Consecutivo;
                _objPagoAuditoria.ValorFinal = Decimal.Parse(txtTotal.Text);
                _objPagoAuditoria.CodigoFormaPagoFinal = _objVenta.CodigoFormaPago;
                _objPagoAuditoria.IdUsuario = ((Libreria.Usuario)Session["Usuario"]).IdUsuario;
                _objPagoAuditoria.FechaCambio = DateTime.Now;
                _objPagoAuditoria.Observaciones = txtObservacion2.Text;
                Libreria.PagosAuditoria.Adicionar(_objPagoAuditoria);
                Libreria.Pagos.Eliminar(0, _objVenta.Consecutivo);
                this.Limpiar();
                this.BuscarPagos();
            }
            catch (Exception ex)
            {
                SetError(ex.Message, false);
            }

        }


        private void btnFechaInicio_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            CalendarioFechaInicio.Visible = !CalendarioFechaInicio.Visible;
        }

        private void CalendarioFechaInicio_SelectionChanged(object sender, System.EventArgs e)
        {

            txtFecha.Text = CalendarioFechaInicio.SelectedDate.ToString();//.ToString("dddd, MMMM dd yyyy", new System.Globalization.CultureInfo("es-CO", false));
            CalendarioFechaInicio.Visible = false;

        }


        #endregion

        #region lstMensajes_DataBinding
        protected void lstMensajes_DataBinding(object sender, EventArgs e)
        {
            lstPagos.Columns[0].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(270, Global.Idioma);
            lstPagos.Columns[1].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma);
            lstPagos.Columns[2].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(989, Global.Idioma);                        
        }
        #endregion        
        
    }
}
