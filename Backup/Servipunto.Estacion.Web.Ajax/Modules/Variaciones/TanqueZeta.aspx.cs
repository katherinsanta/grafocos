using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Servipunto.Estacion.Web.Modules.Variaciones
{
    public partial class TanqueZeta : System.Web.UI.Page
    {
        #region Declaracion Variables

        protected WebApplication.FormMode _mode;
        protected Libreria.Configuracion.Tanques.TanqueVariacion _objTanqueVariacion = null;
        protected string _fechaConsultada;
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
        /// <summary>
        /// Carga la pagina
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void Page_Load(object sender, System.EventArgs e)
        {
            this.lblError.Visible = false;
            try
            {
                if (!this.IsPostBack)
                {
                    _fechaConsultada = DecryptText(Convert.ToString(Request.QueryString["Fecha"].Replace(" ", "+")));
                    DateTime fechaInicio = new DateTime(1900, 1, 1);

                    if (_fechaConsultada != null)
                    {
                        try
                        {
                            fechaInicio = Convert.ToDateTime(_fechaConsultada);
                            txtFechaConsultada.Text = _fechaConsultada.Length == 0 ? "" : DateTime.ParseExact(_fechaConsultada.Substring(0, 10), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                        }
                        catch
                        {
                            fechaInicio = new DateTime(1900, 1, 1);
                            //txtFechaConsultada.Text = _fechaConsultada.Length == 0 ? "" : DateTime.ParseExact(_fechaConsultada.Substring(0, 10), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");

                        }



                    }
                    this.InicializarForma();
                }
                else
                {
                    //try
                    //{
                    //    if (TabContainer1.ActiveTabIndex == 2)
                    //    {
                    //        txtSaldoFinalItemCanastilla.Text = (Convert.ToDecimal(txtSaldoInicialItemCanastilla.Text) + Convert.ToDecimal(txtComprasItemCanastilla.Text) - Convert.ToDecimal(txtSalidasItemCanastilla.Text)).ToString();
                    //        GuardarInventarioItemCanastilla();
                            
                    //    }

                    //}
                    //catch
                    //{
                    //}

                }
            }
            catch (Exception ex)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message, false);

            }
        }
        #endregion

        #region VerificarPermisos
        /// <summary>
        /// Valida los permisos activos para el usuario en sesion
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private bool VerificarPermisos()
        {

            const string modulo = "Variaciones";
            const string opcion = "Zeta";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Administrar");

            if (!permiso)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                return false;
            }

            return true;
        }
        #endregion

        #region Limpiar textos
        /// <summary>
        /// Limpia los controles de texto en el formulario
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void LimpiarTextos()
        {
            txtSaldoInicial.Text = "";
            txtAgua.Text = "";
            txtCompras.Text = "";
            txtSaldoFinal.Text = "";
            txtTransito.Text = "";
            txtCompraFactura.Text = "";
            this._mode = WebApplication.FormMode.New;
            this.lblFormTitle.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2103, Global.Idioma) + "</b>";
        }

        #endregion

        #region Inicialización del Formulario
        /// <summary>
        /// Inicia el formulario cargando el entorno inicial de trabajo
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void InicializarForma()
        {
            if (this.VerificarPermisos())
                this.CargarZeta();

        }
        #endregion

        #region CargarTanques
        /// <summary>
        /// Lista los tanques configurados en el sitema con sus respectivos registros de entradas y salidas para la fecha
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void CargarTanques()
        {
            try
            {
                DataSet ds = Libreria.Configuracion.Tanques.TanqueVariaciones.RecuperarDatosEntradaVariacion(DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                this.dtgTanques.DataSource = ds.Tables[0];
                this.dtgTanques.DataKeyField = "idTanque";
                this.dtgTanques.DataBind();
                txtVariacionesRegistradas.Text = ds.Tables[1].Rows[0]["TotalConVariacionReal"].ToString();
            }
            catch (Exception ex)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1868, Global.Idioma) + ex.Message, false);
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

        #region CargarZeta
        /// <summary>
        /// Carga la jornada zeta consultada mostrado el estado listo para apertura o cierre
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void CargarZeta()
        {
            Libreria.Turnos.JornadaZeta objJornadaZeta = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItem(2);
            cldFechaInicio.Visible = false;
            dtgTanques.Visible = false;
            pnlEntrada.Visible = false;
            txtFecha.Enabled = false;
            imgFechaInicio.Visible = false;
            this.HabilitarEdicionMedidas(false);
            if (objJornadaZeta != null)
            {
                if (txtFechaConsultada.Text.Length > 0 && txtFechaConsultada.Text != objJornadaZeta.Fecha.ToString("dd/MM/yyyy")) //solo consultar
                {
                    objJornadaZeta = new Servipunto.Estacion.Libreria.Turnos.JornadaZeta();
                    txtFecha.Text = txtFechaConsultada.Text;
                    lnkbAbrirCerrarZeta.Visible = false;
                    lblEstadoZeta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2110, Global.Idioma);
                    dtgTanques.Visible = true;
                    pnlEntrada.Visible = false;
                    dtgTanques.Enabled = false;
                    dtgTanques.Columns[6].Visible = false;
                    dtgTanques.Columns[7].Visible = false;
                    this.CargarTanques();
                    return;
                }
            }

            else if (objJornadaZeta == null)
            {
                this.cldFechaInicio.SelectedDate = DateTime.Now;
                lblEstadoZeta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2111, Global.Idioma);
                lnkbAbrirCerrarZeta.Text = "Abrir zeta"; // Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2112, Global.Idioma);
                txtFecha.Text = cldFechaInicio.SelectedDate.ToString("dd/MM/yyyy");
                imgFechaInicio.Visible = true;
                txtFecha.Enabled = true;
                dtgTanques.Visible = false;
                pnlEntrada.Visible = false;
                return;
            }
            if (objJornadaZeta.Estado == "A")
            {
                lblEstadoZeta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2113, Global.Idioma);
                lnkbAbrirCerrarZeta.Text = "Cerrar Zeta"; // Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2114, Global.Idioma);
                txtFecha.Text = objJornadaZeta.Fecha.ToString("dd/MM/yyyy");
                dtgTanques.Visible = true;
                pnlEntrada.Visible = true;
            }
            else
            {
                lnkbAbrirCerrarZeta.Text = "Abrir zeta"; // Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2112, Global.Idioma);
                lblEstadoZeta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2115, Global.Idioma);
                txtFecha.Text = objJornadaZeta.Fecha.AddDays(1).ToString("dd/MM/yyyy");
            }
            this.CargarTanques();
            CargarArticulosCanastilla();

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
            this.lnkbAbrirCerrarZeta.Click += new System.EventHandler(this.lnkbAbrirCerrarZeta_Click);
            this.imgFechaInicio.Click += new System.Web.UI.ImageClickEventHandler(this.imgFechaInicio_Click);
            this.cldFechaInicio.SelectionChanged += new System.EventHandler(this.cldFechaInicio_SelectionChanged);
            this.dtgTanques.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dtgTanques_EditCommand);
            this.dtgTanques.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dtgTanques_DeleteCommand);
            this.lnkbActualiza1.Click += new System.EventHandler(this.lnkbActualiza1_Click);
            this.lnkbActualiza2.Click += new System.EventHandler(this.lnkbActualiza2_Click);
            this.lnkIActualizarInventarioCanastilla.Click += new EventHandler(this.lnkIActualizarInventarioCanastilla_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region Validar
        /// <summary>
        /// Valida que los datos ingresados sean correctos
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private bool Validar()
        {

            this.ClearError();
            try
            {
                if (txtCompras.Text.Trim().Length == 0)
                    txtCompras.Text = "0";

                if (txtSaldoFinal.Text.Trim().Length == 0)
                    txtSaldoFinal.Text = "0";

                if (txtSaldoInicial.Text.Trim().Length == 0)
                    txtSaldoInicial.Text = "0";

                if (txtAgua.Text.Trim().Length == 0)
                    txtAgua.Text = "0";

                Decimal.Parse(txtCompras.Text.Trim());
                Decimal.Parse(txtSaldoFinal.Text.Trim());
                Decimal.Parse(txtSaldoInicial.Text.Trim());
                Decimal.Parse(txtAgua.Text.Trim());
                return true;
            }
            catch (Exception)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1940, Global.Idioma), false);
                return false;
            }
        }

        /// <summary>
        /// Valida que las lecturas finales sean correctas
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  08/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private bool ValidarLecturasFinales()
        {
            string mensaje = "";
            string lecturaFinal;
            for (int i = 0; i < dtgTanques.Items.Count; i++)
            {
                lecturaFinal = dtgTanques.Items[i].Cells[5].Text;
                if (Decimal.Parse(lecturaFinal) == 0)
                    mensaje += "(" + dtgTanques.Items[i].Cells[0].Text.Trim() + ")";
            }

            if (mensaje.Length > 0 && txtAprobarMedidas.Text == "0")
            {
                txtAprobarMedidas.Text = "1";
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2117, Global.Idioma) + mensaje + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2118, Global.Idioma), false);
                return false;
            }
            else
                return true;
        }

        #endregion

        #region Eventos de los controles

        #region imgFechaInicio_Click
        private void imgFechaInicio_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            cldFechaInicio.Visible = !cldFechaInicio.Visible;
        }
        #endregion

        #region cldFechaInicio_SelectionChanged
        private void cldFechaInicio_SelectionChanged(object sender, System.EventArgs e)
        {
            txtFecha.Text = cldFechaInicio.SelectedDate.ToString("dd/MM/yyyy");//.ToString("dddd, MMMM dd yyyy", new System.Globalization.CultureInfo("es-CO", false));
            cldFechaInicio.Visible = false;
        }
        #endregion

        #region lnkbAbrirCerrarZeta_Click
        private void lnkbAbrirCerrarZeta_Click(object sender, System.EventArgs e)
        {
            this.AbrirOCerrarZeta();
        }
        #endregion

        #region dtgTanques_EditCommand
        private void dtgTanques_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            try
            {
                txtAprobarMedidas.Text = "0";
                bool gasOLiquido;
                if (e.CommandName == "Edit")
                {
                    if (e.Item.Cells[8].Text == "1")
                    {
                        lblSaldoInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1445, Global.Idioma) + ":";
                        lblSaldoFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1449, Global.Idioma) + ":";
                    }
                    else
                    {
                        lblSaldoInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1445, Global.Idioma) + ":";
                        lblSaldoFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1449, Global.Idioma) + ":";
                    }

                    txtIdTanque.Text = e.Item.Cells[0].Text;
                    txtSaldoInicial.Text = e.Item.Cells[2].Text;
                    txtAgua.Text = e.Item.Cells[3].Text;
                    txtCompras.Text = e.Item.Cells[6].Text;
                    txtSaldoFinal.Text = e.Item.Cells[7].Text;
                    txtTransito.Text = e.Item.Cells[4].Text;
                    txtCompraFactura.Text = e.Item.Cells[5].Text;
                    this.HabilitarEdicionMedidas(true);
                    gasOLiquido = e.Item.Cells[11].Text == "1" ? true : false;
                    txtCompras.Enabled = !gasOLiquido;
                    txtAgua.Enabled = !gasOLiquido;

                }
            }
            catch (Exception ex)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2116, Global.Idioma) + ex.Message, false);
            }
        }
        #endregion

        #region dtgTanques_DeleteCommand
        private void dtgTanques_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    txtIdTanque.Text = e.Item.Cells[0].Text;
                    this.HabilitarEdicionMedidas(false);
                    this.GuardarMedidasTanque();

                }
            }
            catch (Exception ex)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2116, Global.Idioma) + ex.Message, false);
            }
        }
        #endregion

        #region lnkbActualiza
        private void lnkbActualiza1_Click(object sender, System.EventArgs e)
        {
            this.GuardarMedidasTanque();
            TabContainer1.ActiveTabIndex = 0;
        }

        private void lnkbActualiza2_Click(object sender, System.EventArgs e)
        {
            this.GuardarMedidasTanque();
            TabContainer1.ActiveTabIndex = 1;

        }
        #endregion

        private void lnkIActualizarInventarioCanastilla_Click(object sender, System.EventArgs e)
        {
            this.GuardarInventarioItemCanastilla();
        }

        #endregion

        #region AbrirOCerrarZeta
        /// <summary>
        /// Abre o cierra una jornada zeta en el sistema
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void AbrirOCerrarZeta()
        {
            try
            {
                Libreria.Turnos.JornadaZeta objJornadaZeta;

                #region abrir


                if ((((Libreria.Usuario)Session["Usuario"]).CodigoEmpleado) == string.Empty)
                {
                    //this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2116, Global.Idioma) + "" , false);
                    this.SetError("Usuario actual no relacionado con un empleado, debe asociarlo a un empleado para abrir turno por la opcion panel de control->usuarios", false);
                    return;

                }

                if (lnkbAbrirCerrarZeta.Text == "Abrir zeta" /*Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2112, Global.Idioma)*/)
                {
                    objJornadaZeta = new Servipunto.Estacion.Libreria.Turnos.JornadaZeta();
                    objJornadaZeta.Fecha = DateTime.Parse(txtFecha.Text);
                    objJornadaZeta.Fecha_Real = DateTime.Now;
                    objJornadaZeta.Hora_Inicial = System.DateTime.Now;//System.DateTime.Now.ToString("yyyy-dd-MM HH:mm");
                    objJornadaZeta.Hora_Final = System.DateTime.Now;
                    objJornadaZeta.Estado = "A";
                    objJornadaZeta.CodigoEmpleado = (((Libreria.Usuario)Session["Usuario"]).CodigoEmpleado);
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 573, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    Libreria.Turnos.JornadasZeta.Adicionar(objJornadaZeta);
                    txtFechaConsultada.Text = txtFecha.Text;

                }
                #endregion

                #region cerrar
                else
                {
                    if (int.Parse(txtVariacionesRegistradas.Text) < dtgTanques.Items.Count)
                    {
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2119, Global.Idioma), false);
                        return;
                    }
                    if (!this.ValidarLecturasFinales())
                        return;
                    objJornadaZeta = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItem(2);
                    objJornadaZeta.Estado = "C";
                    objJornadaZeta.Hora_Final = System.DateTime.Now;
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 574, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    objJornadaZeta.Modificar();
                    txtAprobarMedidas.Text = "0";

                }
                #endregion

                this.CargarZeta();
            }
            catch (Exception ex)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2116, Global.Idioma) + ex.Message, false);
            }
        }
        #endregion

        #region GuardarMedidasTanque
        /// <summary>
        /// Adiciona o edita registros de entrada o salida en la base de datos
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void GuardarMedidasTanque()
        {
            if (this.Validar())
            {
                try
                {
                    /* txtSaldoInicial.Text = txtSaldoInicial.Text.Trim().Replace(".", ",");
                     txtAgua.Text = txtAgua.Text.Trim().Replace(".", ",");
                     txtCompras.Text = txtCompras.Text.Trim().Replace(".", ",");
                     txtSaldoFinal.Text = txtSaldoFinal.Text.Trim().Replace(".", ",");*/
                    this._objTanqueVariacion = Servipunto.Estacion.Libreria.Configuracion.Tanques.TanqueVariaciones.ObtenerItem(int.Parse(txtIdTanque.Text), DateTime.ParseExact(txtFecha.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
                    if (this._objTanqueVariacion == null)
                    {
                        #region Insertar
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 575, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this._objTanqueVariacion = new Servipunto.Estacion.Libreria.Configuracion.Tanques.TanqueVariacion();
                        this._objTanqueVariacion.CodigoTanque = int.Parse(txtIdTanque.Text.Trim());
                        this._objTanqueVariacion.Fecha = DateTime.Parse(txtFecha.Text.Trim());
                        this._objTanqueVariacion.SaldoInicial = Decimal.Parse(txtSaldoInicial.Text.Trim());
                        this._objTanqueVariacion.LecturaInicialAgua = Decimal.Parse(txtAgua.Text.Trim());
                        this._objTanqueVariacion.Compras = Decimal.Parse(txtCompras.Text.Trim());
                        this._objTanqueVariacion.SaldoFinal = Decimal.Parse(txtSaldoFinal.Text.Trim());
                        this._objTanqueVariacion.CompraFactura = Decimal.Parse(txtCompraFactura.Text.Trim());
                        this._objTanqueVariacion.Transito = Decimal.Parse(txtCompraFactura.Text.Trim()) - Decimal.Parse(txtCompras.Text.Trim());
                        Libreria.Configuracion.Tanques.TanqueVariaciones.Adicionar(this._objTanqueVariacion);
                        this.HabilitarEdicionMedidas(false);
                        #endregion
                    }
                    else
                    {
                        #region Modificar
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 575, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        //this._objTanqueVariacion.CodigoTanque = int.Parse(txtIdTanque.Text.Trim());
                        //this._objTanqueVariacion.Fecha = DateTime.Parse(txtFecha.Text.Trim());
                        this._objTanqueVariacion.SaldoInicial = Decimal.Parse(txtSaldoInicial.Text.Trim());
                        this._objTanqueVariacion.LecturaInicialAgua = Decimal.Parse(txtAgua.Text.Trim());
                        this._objTanqueVariacion.Compras = Decimal.Parse(txtCompras.Text.Trim());
                        this._objTanqueVariacion.SaldoFinal = Decimal.Parse(txtSaldoFinal.Text.Trim());
                        this._objTanqueVariacion.CompraFactura = Decimal.Parse(txtCompraFactura.Text.Trim());
                        this._objTanqueVariacion.Transito = this._objTanqueVariacion.CompraFactura - _objTanqueVariacion.Compras;
                        this._objTanqueVariacion.Modificar();
                        this.HabilitarEdicionMedidas(false);
                        #endregion
                    }
                    //Response.Redirect("Tanques.aspx");					
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
                this.CargarZeta();
            }
        }
        #endregion

        #region Habilitar edicion medidas
        /// <summary>
        /// Habilita la edicion para ingresar registros de medida de tanques
        /// </summary>
        /// <param name="estado">Define si se habilita o deshabilita la edicion</param>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void HabilitarEdicionMedidas(bool estado)
        {
            txtCompras.Enabled = estado;
            txtSaldoFinal.Enabled = estado;
            txtSaldoInicial.Enabled = estado;
            txtAgua.Enabled = estado;
            lnkbActualiza1.Enabled = estado;
            lnkbActualiza2.Enabled = estado;
            lblTituloDatosIniciales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2020, Global.Idioma) + " " + txtIdTanque.Text + "):";
            lblTituloDatosFinales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2021, Global.Idioma) + " " + txtIdTanque.Text + "):";
            txtTransito.Enabled = false;
            //txtTransito.Enabled = estado;
            if (!estado)
            {
                lblTituloDatosIniciales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2022, Global.Idioma);
                lblTituloDatosFinales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2022, Global.Idioma);
                this.LimpiarTextos();
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
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2107, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2108, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1446, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1448, Global.Idioma);
            lblSaldoFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1449, Global.Idioma);
            lblSaldoInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1445, Global.Idioma);

            lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2103, Global.Idioma);
            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            // lnkbAbrirCerrarZeta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2104, Global.Idioma);

            lblTituloDatosFinales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2103, Global.Idioma);
            lnkbActualiza1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);

            lblTituloDatosIniciales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1444, Global.Idioma);
            lnkbActualiza2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);


            lblEstadoZeta.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2105, Global.Idioma);
            TabPanel2.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1444, Global.Idioma);
            TabPanel1.HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1447, Global.Idioma);

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
        #region gdvVales_DataBinding
        protected void grdFacturas_DataBinding(object sender, EventArgs e)
        {
            dtgTanques.Columns[0].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(81, Global.Idioma);
            dtgTanques.Columns[1].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma);
            dtgTanques.Columns[2].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1445, Global.Idioma);
            dtgTanques.Columns[3].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2106, Global.Idioma);
            dtgTanques.Columns[4].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2107, Global.Idioma);
            dtgTanques.Columns[5].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2108, Global.Idioma);
            dtgTanques.Columns[6].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1448, Global.Idioma);
            dtgTanques.Columns[7].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1449, Global.Idioma);
            //dtgTanques.Columns[9].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            dtgTanques.Columns[10].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1242, Global.Idioma);
            dtgTanques.Columns[11].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2109, Global.Idioma);
        }
        #endregion


        #region Cargar Articulo Canastilla
        /// <summary>
        ///  Cargar Items de Canastilla
        /// </summary>
        protected void CargarArticulosCanastilla()
        {
            Servipunto.Estacion.Libreria.Articulos objCOI = new Servipunto.Estacion.Libreria.Articulos(Servipunto.Estacion.Libreria.TipoArticulo.Canastilla);
            ddlItemsCanastilla.DataSource = objCOI;
            this.ddlItemsCanastilla.DataTextField = "Descripcion";
            this.ddlItemsCanastilla.DataValueField = "IdArticulo";
            this.ddlItemsCanastilla.DataBind();
            ddlItemsCanastilla.Items.Insert(0, new ListItem("", "0"));
        }
        #endregion

        protected void ddlItemsCanastilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarInventarioItem();
            TabContainer1.TabIndex = 2;
        }

        /// <summary>
        /// Cargar Inventario Item Inventario de la jornada
        /// si no existe carga el ultimo saldo final como inicial de la fecha zeta actual
        /// 
        /// </summary>
        private void CargarInventarioItem()
        {
            //try
            //{
            //    short cod_art = Convert.ToInt16(ddlItemsCanastilla.SelectedValue);
            //    Libreria.Turnos.JornadaZeta objJornadaZeta = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItem(2);
            //    if (objJornadaZeta != null)
            //    {
            //        DateTime fecha = objJornadaZeta.Fecha;
            //        if (cod_art != 0)
            //        {
            //            DataSet datos = Libreria.Configuracion.ObtenerDataTableInventarioItemCanastilla(fecha, cod_art);
            //            if (datos.Rows.Count > 0)
            //            {
            //                txtSaldoInicialItemCanastilla.Text = datos.Rows[0].ItemArray.GetValue(2).ToString();
            //                txtSaldoFinalItemCanastilla.Text = datos.Rows[0].ItemArray.GetValue(3).ToString();
            //                txtComprasItemCanastilla.Text = datos.Rows[0].ItemArray.GetValue(4).ToString();
            //                txtSalidasItemCanastilla.Text = datos.Rows[0].ItemArray.GetValue(5).ToString();
            //            }
            //            else
            //            {

            //            }

            //        }
            //    }
            //}
            //catch
            //{
            //}

        }

        private void GuardarInventarioItemCanastilla()
        {
            //try
            //{
            //    if (ddlItemsCanastilla.SelectedValue == "0")
            //        return;

            //    short cod_art = Convert.ToInt16(ddlItemsCanastilla.SelectedValue);
            //    Libreria.Turnos.JornadaZeta objJornadaZeta = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItem(2);
            //    Libreria.InventarioItemsCanastilla objInvs = new Servipunto.Estacion.Libreria.InventarioItemsCanastilla(objJornadaZeta.Fecha, cod_art);

            //    try
            //    {
            //        txtSaldoFinalItemCanastilla.Text = (Convert.ToDecimal(txtSaldoInicialItemCanastilla.Text) + Convert.ToDecimal(txtComprasItemCanastilla.Text) - Convert.ToDecimal(txtSalidasItemCanastilla.Text)).ToString();

            //    }
            //    catch
            //    {
            //        return;
            //    }

            //    if (objInvs.Count > 0)
            //    {
            //        objInvs[0].Compras = Convert.ToDecimal(txtComprasItemCanastilla.Text);
            //        objInvs[0].SaldoInicial = Convert.ToDecimal(txtSaldoInicialItemCanastilla.Text);
            //        objInvs[0].SaldoFinal = Convert.ToDecimal(txtSaldoFinalItemCanastilla.Text);
            //        objInvs[0].Salidas = Convert.ToDecimal(txtSalidasItemCanastilla.Text);
            //        objInvs[0].Modificar();

            //    }
            //    else
            //    {
            //        Libreria.InventarioItemCanastilla objInv = new Servipunto.Estacion.Libreria.InventarioItemCanastilla();
            //        objInv.Cod_Art = cod_art;
            //        objInv.Fecha = objJornadaZeta.Fecha;
            //        objInv.Compras = Convert.ToDecimal(txtComprasItemCanastilla.Text);
            //        objInv.SaldoInicial = Convert.ToDecimal(txtSaldoInicialItemCanastilla.Text);
            //        objInv.SaldoFinal = Convert.ToDecimal(txtSaldoFinalItemCanastilla.Text);
            //        objInv.Salidas = Convert.ToDecimal(txtSalidasItemCanastilla.Text);
            //        Libreria.InventarioItemsCanastilla.Adicionar(objInv);
            //    }

            //    TabContainer1.ActiveTabIndex = 2;
            //}
            //catch
            //{

            //}
            
        }

    }
}
