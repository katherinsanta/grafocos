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
    /// Summary description for ConfVentaGratis.
    /// </summary>
    public class ConfVentaGratis : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblHide;
        protected System.Web.UI.WebControls.Label lblFormTitle;
        protected System.Web.UI.WebControls.LinkButton lblGuardar;
        protected System.Web.UI.WebControls.HyperLink lblBack;
        protected System.Web.UI.WebControls.TextBox txtFrecuencia;
        protected System.Web.UI.WebControls.DropDownList ddlTipoAutomotor;
        protected System.Web.UI.WebControls.TextBox txtAcumulado;
        protected System.Web.UI.WebControls.RadioButtonList rblEstado;
        protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.WebControls.Calendar cldFecInicial;
        protected System.Web.UI.WebControls.Calendar cldFecFinal;
        protected System.Web.UI.WebControls.DropDownList ddlHorInicial;
        protected System.Web.UI.WebControls.DropDownList ddlHorFinal;
        protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
        protected WebApplication.FormMode _mode;
        protected Servipunto.Estacion.Libreria.Configuracion.Alarma _objAlarma = null;
        protected Servipunto.Estacion.Libreria.TiposDeAutomotor _objTipoAutomotor = null;
        protected Servipunto.Estacion.Libreria.FormasPago _objFormasPago = null;
        protected Servipunto.Estacion.Libreria.Articulos _objArticulos = null;
        protected System.Web.UI.WebControls.DropDownList ddlCodForPagConf;
        protected System.Web.UI.WebControls.DropDownList ddlTiempoAlarma;
        protected System.Web.UI.WebControls.DropDownList ddlPuerto;
        protected Servipunto.Estacion.Libreria.FormaPago _objFormaPago = null;
        protected System.Web.UI.WebControls.TextBox txtPorcentaje;
        protected System.Web.UI.WebControls.TextBox txtValorMaximo;
        protected System.Web.UI.WebControls.ListBox lstCodForPagConf;
        protected System.Web.UI.WebControls.DropDownList ddlTipoAlarma;
        protected System.Web.UI.WebControls.TextBox txtRutaArchivoAudio;
        protected System.Web.UI.WebControls.TextBox txtvalorMinimo;
        protected System.Web.UI.WebControls.DropDownList ddlArticulos;
        protected System.Web.UI.WebControls.Panel pnlForm;
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
        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.TextBox txtFechaInicial;
        protected System.Web.UI.WebControls.TextBox txtFechaFinal;
        protected AjaxControlToolkit.CalendarExtender CalendarExtender1;
        protected AjaxControlToolkit.CalendarExtender CalendarExtender2;
        protected Servipunto.Estacion.Libreria.Configuracion.Puertos _objPuertos = null;
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
            ViewState["ControlMaster"] = "0";
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
        #region Page Load
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (this.VerificarPermisos())
            {
                try
                {
                    if (Request.QueryString["IdConfVentaGratis"] == null && lblHide.Text == "")
                        this._mode = WebApplication.FormMode.New;
                    else
                    {
                        this._mode = WebApplication.FormMode.Edit;
                        if (lblHide.Text == "")
                            lblHide.Text = Request.QueryString["IdConfVentaGratis"];
                    }


                    if (!this.IsPostBack)
                    {
                        if (ViewState["ControlMaster"].ToString() != "1")
                        {
                            CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            CalendarExtender2.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            //Es necesario cargar los combos con la información general para todas las configuraciones
                            //Tipos de Automotor
                            _objTipoAutomotor = new Servipunto.Estacion.Libreria.TiposDeAutomotor();
                            ddlTipoAutomotor.DataSource = _objTipoAutomotor.Tipos();
                            ddlTipoAutomotor.DataBind();
                            //La primera posicion del ddltipoAutomotor es vacia, por ende la cambio a Todos
                            ddlTipoAutomotor.Items.Insert(0, Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma));
                            //Tipos de Formas de Pago
                            _objFormasPago = new Servipunto.Estacion.Libreria.FormasPago();
                            //La primera posición del lstCodForPagConf es de Todas, dado que no existe en Formas de Pago, se hace desde aqui
                            lstCodForPagConf.Items.Add(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma));
                            ListItem lista = new ListItem();
                            foreach (Servipunto.Estacion.Libreria.FormaPago objFormaPago in _objFormasPago)
                            {
                                ddlCodForPagConf.Items.Add(new ListItem(objFormaPago.Nombre, objFormaPago.IdFormaPago.ToString()));
                                //lista.Attributes.Add(objFormaPago.IdFormaPago.ToString(),objFormaPago.Nombre);
                                //ddlCodForPagConf.Items.Add(objFormaPago.Nombre.Trim());                                
                                //Actualizo el ListBox
                                lstCodForPagConf.Items.Add(objFormaPago.Nombre.Trim());
                            }
                            //ddlCodForPagConf.Items.Add(lista);
                            //Puertos
                            _objPuertos = new Servipunto.Estacion.Libreria.Configuracion.Puertos();
                            foreach (Servipunto.Estacion.Libreria.Configuracion.Puerto objPuerto in _objPuertos)
                            {
                                ddlPuerto.Items.Add(objPuerto.IdPuerto);
                            }
                            _objFormaPago = null;
                            //Por defecto selecciono la ultima forma de pago de configuracion
                            ddlCodForPagConf.SelectedIndex = ddlCodForPagConf.Items.Count -1;
                            //Por defecto el acumulado se envía en 0
                            txtAcumulado.Text = "0";
                            //Por último carga la forma con su respectivo modo

                            _objArticulos = new Servipunto.Estacion.Libreria.Articulos(Servipunto.Estacion.Libreria.TipoArticulo.Combustible);
                            ddlArticulos.DataSource = _objArticulos;
                            ddlArticulos.DataTextField = "Descripcion";
                            ddlArticulos.DataValueField = "IdArticulo";
                            //if (ddlArticulos.SelectedValue == "0")
                            //    ddlArticulos.Items.Insert(0, Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma));
                            ddlArticulos.DataBind();
                            //La primera posicion del ddltipoAutomotor es vacia, por ende la cambio a Todos
                            ddlArticulos.Items.Insert(0, Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma));
                            this.InicializarForma();
                        }
                    }
                }
                catch (Exception ex)
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
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            lblGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1492, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1493, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1503, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(583, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1486, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1495, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1504, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1505, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Global.Idioma);
            Label11.Text = "F.P. " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(844, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1405, Global.Idioma);
            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(622, Global.Idioma);
            Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1500, Global.Idioma);
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1506, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(452, Global.Idioma);
            Label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(458, Global.Idioma);


            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
        #endregion
        #region Traducir RadioButton
        private void RadioButtonTraduccion()
        {
            #region poblar RadioButton  ddlTipoAlarma
            this.ddlTipoAlarma.Items.Clear();
            this.ddlTipoAlarma.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1945, Global.Idioma), "1"));
            this.ddlTipoAlarma.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1946, Global.Idioma), "2"));
            this.ddlTipoAlarma.SelectedValue = "1";
            #endregion
            #region poblar RadioButton  rblEstado
            this.rblEstado.Items.Clear();
            this.rblEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma), "1"));
            this.rblEstado.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma), "0"));
            this.rblEstado.SelectedValue = "0";
            #endregion
            #region poblar RadioButton  ddlHorInicial
            this.ddlHorInicial.Items.Clear();
            this.ddlHorInicial.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "24"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("12 a.m.", "0"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("1 a.m.", "1"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("2 a.m.", "2"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("3 a.m.", "3"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("4 a.m.", "4"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("5 a.m.", "5"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("6 a.m.", "6"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("7 a.m.", "7"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("8 a.m.", "8"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("9 a.m.", "9"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("10 a.m.", "10"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("11 a.m.", "11"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("12 p.m.", "12"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("1 p.m.", "13"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("2 p.m.", "14"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("3 p.m.", "15"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("4 p.m.", "16"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("5 p.m.", "17"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("6 p.m.", "18"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("7 p.m.", "19"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("8 p.m.", "20"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("9 p.m.", "21"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("10 p.m.", "22"));
            this.ddlHorInicial.Items.Insert(0, new ListItem("11 p.m.", "23"));
            this.ddlHorInicial.SelectedValue = "24";
            #endregion
            #region poblar RadioButton  ddlHorFinal
            this.ddlHorFinal.Items.Clear();
            this.ddlHorFinal.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma), "24"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("12 a.m.", "0"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("1 a.m.", "1"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("2 a.m.", "2"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("3 a.m.", "3"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("4 a.m.", "4"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("5 a.m.", "5"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("6 a.m.", "6"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("7 a.m.", "7"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("8 a.m.", "8"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("9 a.m.", "9"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("10 a.m.", "10"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("11 a.m.", "11"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("12 p.m.", "12"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("1 p.m.", "13"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("2 p.m.", "14"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("3 p.m.", "15"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("4 p.m.", "16"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("5 p.m.", "17"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("6 p.m.", "18"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("7 p.m.", "19"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("8 p.m.", "20"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("9 p.m.", "21"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("10 p.m.", "22"));
            this.ddlHorFinal.Items.Insert(0, new ListItem("11 p.m.", "23"));
            this.ddlHorFinal.SelectedValue = "24";
            #endregion
        }
        #endregion
        #region Método de Inicialización de Forma
        private void InicializarForma()
        {
            if (this.VerificarPermisos())
            {
                RadioButtonTraduccion();
                if (Request.UrlReferrer != null)
                    this.lblBack.NavigateUrl = Request.UrlReferrer.ToString();
                else
                    this.lblBack.NavigateUrl = "ConfVentasGratis.aspx";
                ViewState["ControlMaster"] = "1";
                if (this._mode == WebApplication.FormMode.New)
                    this.InicializarModoInsercion();
                else
                    this.InicializarModoEdicion();
            }
        }
        #endregion

        #region Método Inicializar Modo de Edición
        private void InicializarModoEdicion()
        {
            if (this.ObtenerElemento())
            {
                this.txtFrecuencia.Text = this._objAlarma.Frecuencia.ToString();
                //El tip de automotor que tiene esa configuracion en especial
                this.ddlTipoAutomotor.SelectedValue = this._objAlarma.TipoAutomotor.ToString();
                this.txtAcumulado.Text = this._objAlarma.Acumulado.ToString();
                this.rblEstado.SelectedValue = this._objAlarma.Estado == false ? "0" : "1";
                this.ddlPuerto.SelectedValue = this._objAlarma.Puerto.ToString().Trim();
                string strCodForPag;
                strCodForPag = this._objAlarma.CodForPag;
                string[] ParametrosSeleccionados = strCodForPag.Split(',');
                for (int i = 0; i < ParametrosSeleccionados.Length; i++)
                {
                    if (ParametrosSeleccionados[i] != "")
                        this.lstCodForPagConf.Items[Convert.ToInt16(ParametrosSeleccionados[i])].Selected = true;
                }
                this.ddlCodForPagConf.SelectedIndex = this._objAlarma.CodForPagConf - 1;
                //this.cldFecInicial.SelectedDate = this._objAlarma.FecInicial;
                //this.cldFecFinal.SelectedDate = this._objAlarma.FecFinal;
                this.txtFechaInicial.Text = this._objAlarma.FecInicial.ToShortDateString();
                this.txtFechaFinal.Text = this._objAlarma.FecFinal.ToShortDateString();
                this.ddlHorInicial.SelectedIndex = this._objAlarma.HorInicial == 24 ? 0 : this._objAlarma.HorInicial + 1;
                this.ddlHorFinal.SelectedIndex = this._objAlarma.HorFinal == 24 ? 0 : this._objAlarma.HorFinal + 1; ;
                this.ddlTiempoAlarma.SelectedValue = this._objAlarma.TiempoAlarma.ToString();
                this.txtPorcentaje.Text = this._objAlarma.Porcentaje.ToString();
                this.txtValorMaximo.Text = this._objAlarma.ValorMaximo.ToString();
                this.ddlTipoAlarma.SelectedValue = this._objAlarma.TipoAlarma.ToString();
                this.ddlArticulos.SelectedValue = this._objAlarma.CodigoArticulo == 0 ? "0" : this._objAlarma.CodigoArticulo.ToString();
                this.txtvalorMinimo.Text = this._objAlarma.ValorMinimo.ToString();
                if (_objAlarma.TipoAlarma == 1)
                {
                    ddlPuerto.Enabled = true;
                    ddlTiempoAlarma.Enabled = true;
                }
                else
                {
                    ddlPuerto.Enabled = false;
                    ddlTiempoAlarma.Enabled = false;
                }
                this.txtRutaArchivoAudio.Text = this._objAlarma.RutaArchivoAudio;
                this.lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(999, Global.Idioma) + " No: " + this._objAlarma.IdConfVentaGratis.ToString();
            }
        }
        #endregion

        #region Método Obtener Elemento
        private bool ObtenerElemento()
        {
            try
            {
                this._objAlarma = Libreria.Configuracion.Alarmas.Obtener(Convert.ToByte(lblHide.Text));
                if (this._objAlarma == null)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._objAlarma + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objAlarma + "]", true);
                return false;
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

        #region Método Inicializar Modo de Inserción
        private void InicializarModoInsercion()
        {
            this.lblFormTitle.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1491, Global.Idioma) + "</b>";
            //this.Acciones.Visible = false;
            //Inicializo para que todas las formas de pago de lstCodForPagConf quede seleccionada por defecto
            lstCodForPagConf.Items[0].Selected = true;
            //Inicializo los calendarios con la fecha de hoy
            //this.cldFecInicial.SelectedDate = DateTime.Now;
            //this.cldFecFinal.SelectedDate = DateTime.Now;
            this.txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            this.txtFechaFinal.Text = DateTime.Now.ToShortDateString();
        }
        #endregion

        #region Método VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Panel de Control";
            const string opcion = "Conf. Venta Gratis";
            bool permiso;

            //Se comenta dado que no se ha realizado la insercion en Permisos
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
            this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
            this.ddlTipoAlarma.SelectedIndexChanged += new System.EventHandler(this.ddlTipoAlarma_SelectedIndexChanged);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region Método Guardar
        private void Guardar()
        {
            if (ValidarDatos())
            {
                try
                {
                    if (this._mode == WebApplication.FormMode.New)
                    {
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 147, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this.Insertar();
                        Response.Redirect("ConfVentasGratis.aspx");
                    }
                    else
                    {
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 148, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this.Modificar();
                        Response.Redirect("ConfVentasGratis.aspx");
                    }
                }
                catch (Exception ex)
                {
                    this.SetError(ex.Message, false);
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
                finally
                {
                    this._objAlarma = null;
                }
            }
        }
        #endregion

        #region Método Modificar
        private void Modificar()
        {
            if (this.ObtenerElemento())
            {
                this._objAlarma.Frecuencia = Convert.ToInt32(this.txtFrecuencia.Text);
                this._objAlarma.Acumulado = Convert.ToInt32(this.txtAcumulado.Text);
                this._objAlarma.Puerto = ddlPuerto.SelectedValue.ToString().Trim();
                //this._objAlarma.FecInicial = this.cldFecInicial.SelectedDate;
                //this._objAlarma.FecFinal = this.cldFecFinal.SelectedDate;
                this._objAlarma.FecInicial = Convert.ToDateTime(this.txtFechaInicial.Text);
                this._objAlarma.FecFinal = Convert.ToDateTime(this.txtFechaFinal.Text);
                this._objAlarma.HorInicial = this.ddlHorInicial.SelectedIndex == 0 ? 24 : this.ddlHorInicial.SelectedIndex - 1;
                this._objAlarma.HorFinal = this.ddlHorFinal.SelectedIndex == 0 ? 24 : this.ddlHorFinal.SelectedIndex - 1;
                this._objAlarma.TipoAutomotor = this.ddlTipoAutomotor.SelectedValue;
                this._objAlarma.Estado = this.rblEstado.SelectedItem.Value == "0" ? false : true;
                this._objAlarma.TipoAlarma = Byte.Parse(this.ddlTipoAlarma.SelectedValue);
                this._objAlarma.RutaArchivoAudio = this.txtRutaArchivoAudio.Text;
                string strCodForPag;
                strCodForPag = "";
                for (int i = 0; i < lstCodForPagConf.Items.Count; i++)
                {
                    if (lstCodForPagConf.Items[i].Selected)
                        strCodForPag += i.ToString() + ",";
                }
                if (strCodForPag.Length == 0)//quiere decir que no selecciono ninguna forma de pago por defecto si pasa esto... se envia 0 = Todas
                    strCodForPag = "0";
                this._objAlarma.CodForPag = strCodForPag;
                this._objAlarma.CodForPagConf = this.ddlCodForPagConf.SelectedIndex + 1;
                this._objAlarma.TiempoAlarma = Convert.ToInt16(this.ddlTiempoAlarma.SelectedValue);
                this._objAlarma.Porcentaje = Convert.ToInt32(this.txtPorcentaje.Text);
                this._objAlarma.ValorMaximo = Convert.ToDecimal(this.txtValorMaximo.Text);
                this._objAlarma.CodigoArticulo = ddlArticulos.SelectedValue == Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma) ? 0 : Convert.ToInt32(ddlArticulos.SelectedValue);
                _objAlarma.ValorMinimo = Convert.ToDecimal(txtvalorMinimo.Text);
                this._objAlarma.Modificar();
            }
        }
        #endregion

        #region Método Insertar
        private void Insertar()
        {
            this._objAlarma = new Libreria.Configuracion.Alarma();
            _objAlarma.Frecuencia = Convert.ToInt32(txtFrecuencia.Text);
            _objAlarma.Acumulado = Convert.ToInt32(txtAcumulado.Text);
            _objAlarma.Puerto = ddlPuerto.SelectedValue.ToString().Trim();
            //_objAlarma.FecInicial = cldFecInicial.SelectedDate;
            //_objAlarma.FecFinal = cldFecFinal.SelectedDate;
            _objAlarma.FecInicial = Convert.ToDateTime(this.txtFechaInicial.Text);
            _objAlarma.FecFinal = Convert.ToDateTime(this.txtFechaFinal.Text);            
            _objAlarma.HorInicial = ddlHorInicial.SelectedIndex == 0 ? 24 : ddlHorInicial.SelectedIndex - 1;
            _objAlarma.HorFinal = ddlHorFinal.SelectedIndex == 0 ? 24 : ddlHorFinal.SelectedIndex - 1;
            _objAlarma.TipoAutomotor = ddlTipoAutomotor.SelectedValue;
            _objAlarma.Estado = rblEstado.SelectedItem.Value == "0" ? false : true;
            string strCodForPag;
            strCodForPag = "";
            for (int i = 0; i < lstCodForPagConf.Items.Count; i++)
            {
                if (lstCodForPagConf.Items[i].Selected)
                    strCodForPag += i.ToString() + ",";
            }
            if (strCodForPag.Length == 0)//quiere decir que no selecciono ninguna forma de pago por defecto si pasa esto... se envia 0 = Todas
                strCodForPag = "0";
            _objAlarma.CodForPag = strCodForPag;
            //string y =
                _objAlarma.CodForPagConf=Convert.ToInt32(ddlCodForPagConf.SelectedItem.Value);
            _objAlarma.TiempoAlarma = Convert.ToInt16(ddlTiempoAlarma.SelectedValue);
            _objAlarma.Porcentaje = Convert.ToInt32(txtPorcentaje.Text);
            _objAlarma.ValorMaximo = Convert.ToDecimal(txtValorMaximo.Text);
            _objAlarma.TipoAlarma = Byte.Parse(this.ddlTipoAlarma.SelectedValue);
            _objAlarma.RutaArchivoAudio = txtRutaArchivoAudio.Text;
            _objAlarma.CodigoArticulo = ddlArticulos.SelectedValue == Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(82, Global.Idioma) ? 0 : Convert.ToInt32(ddlArticulos.SelectedValue);
            _objAlarma.ValorMinimo = Convert.ToDecimal(txtvalorMinimo.Text);
            Libreria.Configuracion.Alarmas.Adicionar(this._objAlarma);
        }
        #endregion

        private void lblGuardar_Click(object sender, System.EventArgs e)
        {
            this.Guardar();
        }

        #region Validación de Datos Ingresador por el Usuario
        private bool ValidarDatos()
        {
            //Definición para la frecuencia, debe ser numérico superior a 1
            if (this.txtFrecuencia.Text.Trim().Length != 0)
            {
                if (!Libreria.Aplicacion.IsNumeric(this.txtFrecuencia.Text.Trim()))
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1950, Global.Idioma), false);
                    return false;
                }
                else
                {
                    if (Decimal.Parse(this.txtFrecuencia.Text.Trim()) < 0)
                    {
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1951, Global.Idioma), false);
                        return false;
                    }
                }
            }
            else
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1952, Global.Idioma), false);
                return false;
            }
            //Definición para el Acumulado, debe ser numérico superior a 0
            if (this.txtAcumulado.Text.Trim().Length != 0)
            {
                if (!Libreria.Aplicacion.IsNumeric(this.txtAcumulado.Text.Trim()))
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1953, Global.Idioma), false);
                    return false;
                }
                else
                {
                    if (Decimal.Parse(this.txtAcumulado.Text.Trim()) < 0)
                    {
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1954, Global.Idioma), false);
                        return false;
                    }
                }
            }
            else
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1955, Global.Idioma), false);
                return false;
            }
            //Definición para el Porcentaje, debe ser numérico superior a 0
            if (this.txtPorcentaje.Text.Trim().Length != 0)
            {
                if (!Libreria.Aplicacion.IsNumeric(this.txtPorcentaje.Text.Trim()))
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1956, Global.Idioma), false);
                    return false;
                }
                else
                {
                    if (Decimal.Parse(this.txtPorcentaje.Text.Trim()) < 0)
                    {
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1957, Global.Idioma), false);
                        return false;
                    }
                }
            }
            else
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1958, Global.Idioma), false);
                return false;
            }
            //Definición para el valor máximo, debe ser numérico superior a 0
            if (this.txtValorMaximo.Text.Trim().Length != 0)
            {
                if (!Libreria.Aplicacion.IsNumeric(this.txtValorMaximo.Text.Trim()))
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1959, Global.Idioma), false);
                    return false;
                }
                else
                {
                    if (Decimal.Parse(this.txtValorMaximo.Text.Trim()) < 0)
                    {
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1960, Global.Idioma), false);
                        return false;
                    }
                }
            }
            else
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1961, Global.Idioma), false);
                return false;
            }
            //Rango de fechas valido
            if (Convert.ToDateTime(this.txtFechaFinal.Text) < Convert.ToDateTime(this.txtFechaInicial.Text))
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1962, Global.Idioma), false);
                return false;
            }

            //Archivo de audio
            /*
            if(this.ddlTipoAlarma.SelectedValue == "2" && txtRutaArchivoAudio.Text.Trim().Length <= 4)
            {
                this.SetError("El archivo de audio ingresado no es valido!, por favor ingrese una dirección de archivo de audio valida.", false);
                return false;
            }
            */

            return true;
        }
        #endregion

        #region ddlTipoAlarma_SelectedIndexChanged
        private void ddlTipoAlarma_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ddlTipoAlarma.SelectedValue == "1")
            {
                ddlPuerto.Enabled = true;
                ddlTiempoAlarma.Enabled = true;
            }
            else
            {
                ddlPuerto.Enabled = false;
                ddlTiempoAlarma.Enabled = false;
            }
        }
        #endregion
    }
}
