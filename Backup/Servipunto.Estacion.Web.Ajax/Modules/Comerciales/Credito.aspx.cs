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

namespace Servipunto.Estacion.Web.Modules.Comerciales
{
    public partial class Credito : System.Web.UI.Page
    {
        #region Definición de Variables
        
        private DataTable Financieras;
        private DataTable TipoPorcen;  
        private Servipunto.Estacion.Libreria.Comercial.Creditos objPersonal;
        protected Libreria.Comercial.Credito objCredito = null;  
        protected WebApplication.FormMode _mode;  
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
            // Put user code to initialize the page here
            Financieras = new DataTable();
            TipoPorcen = new DataTable();

            if (lblHide.Text == "")
                lblHide.Text =  Request.QueryString["Creacion"].ToString();

            if (lblHide2.Text == "")
                lblHide2.Text = Request.QueryString["Placa"].ToString();


            if (lblHide.Text == "1")
                _mode = WebApplication.FormMode.New;
            else
                _mode = WebApplication.FormMode.Edit;

            if (!this.Page.IsPostBack)
            {
                //Definición del comportamiento para el evento Guardar Tipos de Porcentajes, se define solo 1 vez
                lbGuardarTiposPorcentajes.Attributes.Add("onclick", "return confirm('" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2026, Global.Idioma) + "')");
                //Inicializo las variables de sesion que manejaran los indices de los dropdownlist
                this.Session["IndiceFinanciera"] = 0;
                this.Session["IndicePorcentaje"] = 0;
                //if (this.VerificarPermisos())
                this.Visualizar();
                this.Session["Financieras"] = Financieras;
                this.Session["TiposPorcen"] = TipoPorcen;
            }
            else
            {
                txtEnt_Consig.Text = Request.Form["txtEnt_Consig"];
                //this.Eliminar();
                //Datos de las financieras
                Financieras = (DataTable)this.Session["Financieras"];
                //Visualizacion en linea de el DropDownList
                ddlFinanciera.Items.Clear();
                ddlFinanciera.DataSource = Financieras;
                ddlFinanciera.DataValueField = "Codigo";
                ddlFinanciera.DataTextField = "Nombre";               
                ddlFinanciera.DataBind();
                this.Session["IndiceFinanciera"] = ddlFinanciera.SelectedIndex;

                //Datos de los porcentajes de participacion por financieras
                TipoPorcen = (DataTable)this.Session["TiposPorcen"];
                //Visulizacion en linea del DropDownList ddlPorcentaje
                ddlPorcentaje.DataSource = TipoPorcen;
                ddlPorcentaje.DataValueField = "Tipo";
                ddlPorcentaje.DataTextField = "Tipo";               
                ddlPorcentaje.DataBind();
                this.Session["IndicePorcentaje"] = ddlPorcentaje.SelectedIndex;
                if (ddlPorcentaje.Items.Count == 0)
                {
                    this.Session["IndicePorcentaje"] = 0;
                    ddlPorcentaje.Items.Add(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2025, Global.Idioma));
                }
                lblError.Visible = false;
            }

            if (ddlFinanciera.Items.Count == 0)
            {
                this.Session["IndiceFinanciera"] = 0;
                ddlFinanciera.Items.Add(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2025, Global.Idioma));
            }
            if (ddlPorcentaje.Items.Count == 0)
            {
                this.Session["IndicePorcentaje"] = 0;
                ddlPorcentaje.Items.Add(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2025, Global.Idioma));
            }

            //Parametrizo la ultima posicion para la creacion de una financiera
            ddlFinanciera.Items.Add(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma));
            //ddlFinanciera.SelectedIndex = (int)this.Session["IndiceFinanciera"];

            //Parametrizo la ultima posicion para la creacion de los tipos de porcentajes
            ddlPorcentaje.Items.Add(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma));
            //ddlPorcentaje.SelectedIndex = (int)this.Session["IndicePorcentaje"];

        }
        #endregion

        #region Visualizar
        private void Visualizar()
        {
            try
            {
                this._id = DecryptText(Convert.ToString(lblHide2.Text.Replace(" ", "+")));


                if (lblHide.Text.ToString() == "0")//Presentacion de credito
                {

                    lblFormTitle.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2027, Global.Idioma) + ": " + this._id + "</b>";
                    //Al datagrid Results se le envía los resultados de la búsqueda
                    //Esta busqueda se define en la libreria
                    objPersonal = new Servipunto.Estacion.Libreria.Comercial.Creditos(0, this._id, Request.QueryString["Numero"]);
                    lblNumero.Text = objPersonal[0].Numero.ToString();
                    txtEnt_Consig.Text = objPersonal[0].EntConsig;
                    lblFinanciera.Text = objPersonal[0].Financiera.ToString().Trim();

                    lblPlaca.Text = objPersonal[0].PlacaAutomotor;
                    txtTipoCredito.Text = objPersonal[0].Tipo;
                    txtMontoCredito.Text = objPersonal[0].Monto.ToString();
                    txtSaldoCredito.Text = objPersonal[0].Saldo.ToString();

                    //Cargo los datos de las financieras
                    Financieras = objPersonal.ObtenerFinancieras();
                    //Visualizacion en linea de el DropDownList
                    ddlFinanciera.DataSource = Financieras;
                    ddlFinanciera.DataValueField = "Codigo";
                    ddlFinanciera.DataTextField = "Nombre";
                    ddlFinanciera.DataBind();
                    //Resta 1 al indice dado que este empieza desde 0
                    ddlFinanciera.SelectedIndex = Convert.ToInt32(objPersonal[0].Financiera) - 1;
                    this.Session["IndiceFinanciera"] = ddlFinanciera.SelectedIndex;

                    //Cargo los datos de los Tipos de Porcentaje
                    TipoPorcen = objPersonal.ObtenerTipoPorcen(ddlFinanciera.SelectedIndex + 1);
                    //Visulizacion en linea del dropdownlist
                    ddlPorcentaje.DataSource = TipoPorcen;
                    ddlPorcentaje.DataValueField = "Tipo";
                    ddlPorcentaje.DataTextField = "Tipo";
                    ddlPorcentaje.DataBind();
                    //ddlPorcentaje.SelectedValue = (objPersonal[0].Porcentaje).ToString();
                    ddlPorcentaje.SelectedValue = (objPersonal[0].TipoPorcentaje).ToString();
                    lblPorcentaje.Text = (objPersonal[0].Porcentaje).ToString();
                    this.Session["IndicePorcentaje"] = ddlPorcentaje.SelectedIndex;
                }
                else //Creacion de Credito
                {
                    //Cargo los datos de las financieras
                    this.lblFormTitle.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2028, Global.Idioma) + "</b>";
                    lblNumero.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2029, Global.Idioma);
                    txtEnt_Consig.Text = "";
                    lblFinanciera.Text = "";

                    lblPlaca.Text = this._id;
                    //					txtTipoCredito.Text = "";
                    //					txtMontoCredito.Text = "";
                    //					txtSaldoCredito.Text = "";


                    objPersonal = new Servipunto.Estacion.Libreria.Comercial.Creditos();
                    Financieras = objPersonal.ObtenerFinancieras();
                    //Visualizacion en linea de el DropDownList
                    ddlFinanciera.DataSource = Financieras;
                    ddlFinanciera.DataValueField = "Codigo";
                    ddlFinanciera.DataTextField = "Nombre";
                    ddlFinanciera.DataBind();
                    //Resta 1 al indice dado que este empieza desde 0
                    ddlFinanciera.SelectedIndex = 0;
                    this.Session["IndiceFinanciera"] = ddlFinanciera.SelectedIndex;

                    //Cargo los datos de los Tipos de Porcentaje
                    TipoPorcen = objPersonal.ObtenerTipoPorcen(ddlFinanciera.SelectedIndex + 1);
                    //Visulizacion en linea del dropdownlist
                    ddlPorcentaje.DataSource = TipoPorcen;
                    ddlPorcentaje.DataValueField = "Tipo";
                    ddlPorcentaje.DataTextField = "Tipo";
                    ddlPorcentaje.DataBind();
                    ddlPorcentaje.SelectedIndex = 0;
                    lblPorcentaje.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma);
                    this.Session["IndicePorcentaje"] = ddlPorcentaje.SelectedIndex;

                }
            }
            catch (Exception ex)
            {
                SetError(ex.Message /*+ "<br><br>" + ex.StackTrace*/, false);
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

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2021, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2030, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(295, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(342, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2023, Global.Idioma);
            Label6.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2024, Global.Idioma);
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(424, Global.Idioma);
            Label8.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(624, Global.Idioma);
            Label9.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1504, Global.Idioma);
            Label10.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2032, Global.Idioma);
            Label11.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(263, Global.Idioma);

            Label12.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1068, Global.Idioma);
            Label13.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(960, Global.Idioma);
            Label14.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2033, Global.Idioma);
            Label15.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2034, Global.Idioma);
            Label16.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(424, Global.Idioma);
            Label17.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(342, Global.Idioma);
            Label18.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1504, Global.Idioma);
            Label19.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2033, Global.Idioma);
                        
            
            lbGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lbBack1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            rbEstadoFinanciera1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1131, Global.Idioma);
            rbEstadoFinanciera.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1130, Global.Idioma);
            lbCancelarFinanciera.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1002, Global.Idioma);
            lbGuardarFinanciera.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
            lbCancelarTiposPorcentajes.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1002, Global.Idioma);
            lbGuardarTiposPorcentajes.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
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
            this.lbGuardar.Click += new System.EventHandler(this.lbGuardar_Click);
            this.lbBack1.Click += new System.EventHandler(this.lbBack1_Click);
            this.ddlFinanciera.SelectedIndexChanged += new System.EventHandler(this.ddlFinanciera_SelectedIndexChanged);
            this.ddlPorcentaje.SelectedIndexChanged += new System.EventHandler(this.ddlPorcentaje_SelectedIndexChanged);
            this.lbGuardarFinanciera.Click += new System.EventHandler(this.lbGuardarFinanciera_Click);
            this.lbCancelarFinanciera.Click += new System.EventHandler(this.lbCancelarFinanciera_Click);
            this.lbGuardarTiposPorcentajes.Click += new System.EventHandler(this.lbGuardarTiposPorcentajes_Click);
            this.lbCancelarTiposPorcentajes.Click += new System.EventHandler(this.lbCancelarTiposPorcentajes_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region Botones que guardan los datos
        private void lbGuardar_Click(object sender, System.EventArgs e)
        {
            if (ValidarCredito())//Antes de grabar los datos del crédito, valido la información ingresada por el usuario
            {
                try
                {
                    objCredito = new Libreria.Comercial.Credito();
                    objCredito.EntConsig = txtEnt_Consig.Text;
                    objCredito.PlacaAutomotor = lblPlaca.Text;
                    objCredito.Tipo = txtTipoCredito.Text;
                    objCredito.Financiera = Convert.ToString(ddlFinanciera.SelectedIndex + 1);
                    objCredito.TipoPorcentaje = ddlPorcentaje.SelectedValue;
                    objCredito.Monto = Convert.ToDecimal(txtMontoCredito.Text);
                    objCredito.Saldo = Convert.ToDecimal(txtSaldoCredito.Text);

                    //Quiere decir si la forma es nueva, los datos son nuevos por ende se inserta
                    if (this._mode == WebApplication.FormMode.New)
                    {
                        #region Insertar Credito
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 303, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        Libreria.Comercial.Creditos.Adicionar(this.objCredito);
                        #endregion
                    }
                    else //Quiere decir que la forma presenta datos, los datos son modificados, por ende se modifica
                    {
                        #region Modificar Credito
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 304, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        objCredito.Numero = Convert.ToInt32(lblNumero.Text);
                        objCredito.Modificar();
                        #endregion
                    }
                    Response.Redirect("Creditos.aspx?Placa=" + lblHide2.Text);
                }
                catch (Exception ex)
                {
                    this.SetError(lblError.Text += Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message, false);
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
        private void lbBack1_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Creditos.aspx?Placa=" + lblHide2.Text);
        }
        #endregion

        #region Actividades para Financiera
        private void ddlFinanciera_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //Cuando el indice es inferior al ultimo, se muestran los datos que se traen desde el DataTable
            pnlDatosFinancieras.Visible = true;
            //Se realiza el proceso de grabado sobre el nuevo
            if ((bool)(ddlFinanciera.SelectedValue == Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma)) || (bool)(ddlFinanciera.SelectedValue == Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2025, Global.Idioma)))
            {
                //Registro los campos texto en el form			
                //Cuando la financiera es nueva, no tiene porcentajes de participación
                LimpiarControles();
                //En este caso, como la financiera es nueva, es necesario borrar los datos del DataTable
                TipoPorcen.Clear();
                ddlPorcentaje.DataSource = TipoPorcen;
                ddlPorcentaje.DataBind();
                ddlPorcentaje.Items.Add(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma));
                this.Session["TiposPorcen"] = TipoPorcen;
                this.Session["IndicePorcentaje"] = ddlPorcentaje.SelectedIndex;

            }
            else
            {
                pnlResultados.Enabled = true;
                DataRow drDatosFinanciera = Financieras.NewRow();
                drDatosFinanciera = Financieras.Rows[ddlFinanciera.SelectedIndex];
                txtNombreFinanciera.Text = drDatosFinanciera["Nombre"].ToString();
                lblCodigoFinanciera.Text = drDatosFinanciera["Codigo"].ToString();
                if ((string)drDatosFinanciera["Estado"] == "A")//Activa
                {
                    rbEstadoFinanciera1.Checked = false;
                    rbEstadoFinanciera.Checked = true;
                }
                else
                {
                    rbEstadoFinanciera.Checked = false;
                    rbEstadoFinanciera1.Checked = true;
                }
                lblFechaUltActFinanciera.Text = drDatosFinanciera["Fech_Ult_Actu"].ToString();
                //Cuando cambia el indice de la financiera, se debe volver a cargar los tipos de porcentajes
                objPersonal = new Servipunto.Estacion.Libreria.Comercial.Creditos();
                TipoPorcen = objPersonal.ObtenerTipoPorcen(ddlFinanciera.SelectedIndex + 1);
                //Indica que el DataTable no contiene entradas de Tipos de porcentaje
                if (TipoPorcen.Rows.Count == 0)
                {
                    ddlPorcentaje.DataSource = TipoPorcen;
                    ddlPorcentaje.DataBind();
                    ddlPorcentaje.Items.Add(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2025, Global.Idioma));
                    lblPorcentaje.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1867, Global.Idioma);
                }
                else
                {
                    ddlPorcentaje.DataSource = TipoPorcen;
                    ddlPorcentaje.DataValueField = "Tipo";
                    ddlPorcentaje.DataTextField = "Tipo";
                    ddlPorcentaje.DataBind();
                    lblPorcentaje.Text = TipoPorcen.Rows[ddlPorcentaje.SelectedIndex].ItemArray.GetValue(3).ToString();
                }
                //Parametrizo la ultima posicion para la creacion de los tipos de porcentajes
                ddlPorcentaje.Items.Add(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma));
                //Almaceno el DataTable en la variable de sesion
                this.Session["TiposPorcen"] = TipoPorcen;
                this.Session["IndicePorcentaje"] = ddlPorcentaje.SelectedIndex;
            }

            this.Session["IndiceFinanciera"] = ddlFinanciera.SelectedIndex;
            pnlDatosPorcentajes.Visible = false;
        }

        //Se define una función que se encarga de limpiar las controles
        private void LimpiarControles()
        {
            txtNombreFinanciera.Text = "";
            lblCodigoFinanciera.Text = Convert.ToString(Financieras.Rows.Count + 1);
            rbEstadoFinanciera.Checked = false;
            rbEstadoFinanciera1.Checked = false;
            lblFechaUltActFinanciera.Text = "";
        }

        private void lbGuardarFinanciera_Click(object sender, System.EventArgs e)
        {
            if (ValidarFinanciera())//Antes de la grabación, valido la información ingresada por el usuario
            {
                //Codigo para realizar la grabacion de la nueva financiera o la modificacion sobre la BD
                pnlDatosFinancieras.Visible = false;
                pnlResultados.Enabled = true;
                //Adiciono los registros nuevos al DataTable si son nuevos
                if ((bool)(ddlFinanciera.SelectedValue == Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma)) || (bool)(ddlFinanciera.SelectedValue == Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2025, Global.Idioma)))
                {
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 307, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    DataRow drFinanciera = Financieras.NewRow();
                    drFinanciera["Codigo"] = lblCodigoFinanciera.Text;
                    drFinanciera["Nombre"] = txtNombreFinanciera.Text;
                    //Se deja abierta la opcion de mostrar este dato, significa que el DataTable todavia lee este registro de la BD
                    drFinanciera["Num_Creditos"] = 0;
                    drFinanciera["Estado"] = (rbEstadoFinanciera.Checked) ? "A" : "I";
                    drFinanciera["Cupo"] = 0;
                    drFinanciera["Utilizado"] = 0;
                    //Adicion del registro en el DataTable Financieras
                    Financieras.Rows.Add(drFinanciera);
                }
                else
                {
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 308, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    //Son datos modificados
                    DataRow drFinanciera = Financieras.NewRow();
                    //Resto 1 dado que el indice del ddl es diferente al indice de la DataTable
                    drFinanciera = Financieras.Rows[Convert.ToInt32(ddlFinanciera.SelectedIndex)];
                    drFinanciera["Codigo"] = lblCodigoFinanciera.Text;
                    drFinanciera["Nombre"] = txtNombreFinanciera.Text;
                    drFinanciera["Num_Creditos"] = 0;
                    drFinanciera["Estado"] = (rbEstadoFinanciera.Checked) ? "A" : "I";
                    drFinanciera["Cupo"] = 0;
                    drFinanciera["Utilizado"] = 0;
                }
                //Instancia un objeto temporal para poder acceder a la funcion insertar financieras
                objPersonal = new Servipunto.Estacion.Libreria.Comercial.Creditos();
                objPersonal.AgregarModificarFinancieras(ref Financieras);
                lblFinanciera.Text = lblCodigoFinanciera.Text;
                this.Session["Financieras"] = Financieras;
                //Visualizacion en linea de el DropDownList
                ddlFinanciera.DataSource = Financieras;
                ddlFinanciera.DataValueField = "Codigo";
                ddlFinanciera.DataTextField = "Nombre";
                this.Session["IndiceFinanciera"] = ddlFinanciera.SelectedIndex;
                ddlFinanciera.DataBind();
                ddlFinanciera.SelectedIndex = (int)this.Session["IndiceFinanciera"];
                ddlFinanciera.Items.Add(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma));
            }
        }

        private void lbCancelarFinanciera_Click(object sender, System.EventArgs e)
        {
            //Cancela la accion de ingresar o modificar una financiera
            pnlDatosFinancieras.Visible = false;
            pnlResultados.Enabled = true;
            LimpiarControles();
            this.Session["IndiceFinanciera"] = lblFinanciera.Text.Length == 0 ? 0 : Convert.ToInt32(lblFinanciera.Text.ToString());
            ddlFinanciera.SelectedIndex = Convert.ToInt32(this.Session["IndiceFinanciera"]) - 1;
            //Recarga la información de los porcentajes definidos para la Financiera
            ddlPorcentaje.SelectedIndex = Convert.ToInt32(this.Session["IndicePorcentaje"]) - 1;
        }
        #endregion

        #region Actividades para Porcentajes

        private void ddlPorcentaje_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //Muestra y oculta los paneles para realizar la visualizacion de los datos
            pnlDatosFinancieras.Visible = false;
            pnlDatosPorcentajes.Visible = true;
            //Se realiza el proceso de grabado sobre el nuevo
            if ((bool)(ddlPorcentaje.SelectedValue == Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma)) || (bool)(ddlPorcentaje.SelectedValue == Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2025, Global.Idioma)))
            {
                lblFinancieraPorcentaje.Text = ddlFinanciera.SelectedItem.Text;
                txtTipoPorcentaje.Enabled = true;
                txtPorcentaje.Enabled = true;
                //pnlResultados.Enabled=false;
                LimpiarControles1();
                lblPorcentaje.Text = "waiting...";
            }
            else
            {
                txtTipoPorcentaje.Enabled = false;
                txtPorcentaje.Enabled = true;
                DataRow drTipoPorcentaje = TipoPorcen.Rows[ddlPorcentaje.SelectedIndex];
                txtPorcentaje.Text = drTipoPorcentaje["Porcentaje"].ToString(); ;

                lblFinancieraPorcentaje.Text = ddlFinanciera.SelectedItem.ToString();
                lblFechaActualizacionPorcentaje.Text = drTipoPorcentaje["Fech_Ult_Actu"].ToString();
                txtTipoPorcentaje.Text = ddlPorcentaje.SelectedItem.ToString();
                //Almaceno el indice seleccionado en su respectiva variable de sesion
                this.Session["IndicePorcentaje"] = ddlPorcentaje.SelectedIndex;
                lblPorcentaje.Text = drTipoPorcentaje["Porcentaje"].ToString();
            }
        }

        private void LimpiarControles1()
        {
            txtTipoPorcentaje.Text = "";
            txtPorcentaje.Text = "";
        }

        private void lbGuardarTiposPorcentajes_Click(object sender, System.EventArgs e)
        {
            if (ValidarPorcentaje())//Valido los datos ingresados por el usuario, antes de almacenarlos en la BD
            {
                pnlDatosPorcentajes.Visible = false;
                pnlResultados.Enabled = true;
                {
                    //Si el estado del DropDrownList es Nuevo, el texto  seleccionado, quiere decir que es un registro nuevo
                    if ((bool)(ddlPorcentaje.SelectedValue == Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma)) || (bool)(ddlPorcentaje.SelectedValue == Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2025, Global.Idioma)))
                    {
                        //Realizo una busqueda de el tipo de porcentaje ingresado
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 491, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        string filtro = "Financiera = " + (ddlFinanciera.SelectedIndex + 1) + " AND Tipo = '" + txtTipoPorcentaje.Text + "'";
                        DataRow[] drActuales = TipoPorcen.Select(filtro);
                        if (drActuales.Length > 0)//Quiere decir que esta repetido
                        {
                            lblError.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2035, Global.Idioma);
                            lblError.Visible = true;
                            ddlPorcentaje.SelectedValue = (drActuales[0].ItemArray.GetValue(2)).ToString();
                            lblPorcentaje.Text = ddlPorcentaje.SelectedValue.ToString();
                        }
                        else
                        {
                            DataRow drPorcentaje = TipoPorcen.NewRow();
                            drPorcentaje["Financiera"] = ddlFinanciera.SelectedIndex + 1;
                            drPorcentaje["Tipo"] = txtTipoPorcentaje.Text;
                            drPorcentaje["Porcentaje"] = Convert.ToDecimal(txtPorcentaje.Text);
                            //Adiciono el registro en el DataTable
                            TipoPorcen.Rows.Add(drPorcentaje);
                        }
                    }
                    else//De lo contrario, quiere decir que hay que evaluar la actualizacion
                    {
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 492, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        DataRow drPorcentaje = TipoPorcen.NewRow();
                        drPorcentaje = TipoPorcen.Rows[Convert.ToInt32(ddlPorcentaje.SelectedIndex)];
                        drPorcentaje["Financiera"] = ddlFinanciera.SelectedIndex + 1;
                        drPorcentaje["Tipo"] = txtTipoPorcentaje.Text;
                        drPorcentaje["Porcentaje"] = Convert.ToDecimal(txtPorcentaje.Text);
                        //se hace para que el lbGuardarTiposPorcentajes si esta en falso quiere decir que esta en proceso de grabacion
                        string strScript = "<script language=JavaScript> alert ('"+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2036, Global.Idioma)+"')</script>";
                        string strKey = "strKey1";
                        if (!Page.IsStartupScriptRegistered(strKey))
                            Page.RegisterStartupScript(strKey, strScript);
                    }
                    //Instancia un objeto temporal para poder acceder a la función insertar Tipos_porcen
                    objPersonal = new Servipunto.Estacion.Libreria.Comercial.Creditos();
                    objPersonal.AgregarModificarPorcentajes(ref TipoPorcen);
                    //Despues de la inserción o modificacion, actualizo la información del DataTable que muestra los porcentajes actualizados
                    TipoPorcen = objPersonal.ObtenerTipoPorcen(ddlFinanciera.SelectedIndex + Global.Idioma);
                    //Actualizo el valor almacenado en TiposPorcen para visualizar de nuevo el DropDownList
                    this.Session["TiposPorcen"] = TipoPorcen;
                    ddlPorcentaje.DataSource = TipoPorcen;
                    ddlPorcentaje.DataValueField = "Tipo";
                    ddlPorcentaje.DataTextField = "Tipo";
                    this.Session["IndicePorcentaje"] = ddlPorcentaje.SelectedIndex;
                    ddlPorcentaje.DataBind();
                    ddlPorcentaje.SelectedIndex = (int)this.Session["IndicePorcentaje"];
                    ddlPorcentaje.Items.Add("Nuevo");
                    lblPorcentaje.Text = TipoPorcen.Rows[ddlPorcentaje.SelectedIndex].ItemArray.GetValue(3).ToString();
                }
            }
        }

        private void lbCancelarTiposPorcentajes_Click(object sender, System.EventArgs e)
        {
            pnlResultados.Enabled = true;
            pnlDatosPorcentajes.Visible = false;
        }

        #endregion

        #region Validaciones
        #region Validaciones para los porcentajes
        private bool ValidarPorcentaje()
        {
            //Definicion para el Tipo de porcentaje, el cual debe ser una letra o tener algun identificador válido
            if (this.txtTipoPorcentaje.Text.Trim().Length != 0)
            {
                if (this.txtTipoPorcentaje.Text.Trim().Length > 1)
                {

                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1957, Global.Idioma), false);
                    return false;
                }
            }
            else
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1958, Global.Idioma), false);
                return false;
            }
            //Definición para el Porcentaje ingresado, el cual debe ser un valor válido, si queda con ingreso vacío, graba 0	
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
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2037, Global.Idioma), false);
                        return false;
                    }
                }
            }
            else
            {
                this.txtPorcentaje.Text = "0";
            }
            //Si todos los datos son correctos se retorna el estado OK!
            return true;
        }
        #endregion

        #region Validaciones para las financieras
        private bool ValidarFinanciera()
        {
            //Definición para el Nombre de la Financiera, el cual debe contener algo, dado que es el nombre que se almacenara en Financieras
            if (this.txtNombreFinanciera.Text.Trim().Length == 0)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(424, Global.Idioma) + " " + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1972, Global.Idioma), false);
                return false;
            }
            //Definición para los botones de Activo e Inactivo
            if (this.rbEstadoFinanciera.Checked == false && this.rbEstadoFinanciera1.Checked == false)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2038, Global.Idioma), false);
                return false;
            }
            //Si todos los datos son correctos se retorna el estado OK!
            return true;
        }
        #endregion

        #region Validaciones para el Crédito
        private bool ValidarCredito()
        {
            //Definición para el Tipo de Crédito, por defecto irá KIT, pero este se puede modificar
            if (this.txtTipoCredito.Text.Trim().Length == 0)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2039, Global.Idioma), false);
                return false;
            }
            //Definición para el Monto del Crédito ingresado, el cual debe ser una valor válido y no puede ser una cadena vacía
            if (this.txtMontoCredito.Text.Trim().Length != 0)
            {
                if (!Libreria.Aplicacion.IsNumeric(this.txtMontoCredito.Text.Trim()))
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2040, Global.Idioma), false);
                    return false;
                }
                else
                {
                    if (Decimal.Parse(this.txtMontoCredito.Text.Trim()) < 0)
                    {
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2041, Global.Idioma), false);
                        return false;
                    }
                }
            }
            else
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2042, Global.Idioma), false);
                return false;
            }
            //Definición para el Saldo del crédito ingresado, el cual debe ser un valor válido y no puede ser una cadena vacía
            if (this.txtSaldoCredito.Text.Trim().Length != 0)
            {
                if (!Libreria.Aplicacion.IsNumeric(this.txtSaldoCredito.Text.Trim()))
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2043, Global.Idioma), false);
                    return false;
                }
                else
                {
                    if (Decimal.Parse(this.txtSaldoCredito.Text.Trim()) < 0)
                    {
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2044, Global.Idioma), false);
                        return false;
                    }
                }
            }
            else
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2045, Global.Idioma), false);
                return false;
            }
            //Si todos los datos son correctos se retorna el estado OK!
            return true;
        }
        #endregion
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
    }
}
