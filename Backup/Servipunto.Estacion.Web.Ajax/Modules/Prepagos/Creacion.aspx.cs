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

namespace Servipunto.Estacion.Web.Modules.Prepagos
{
    public partial class Creacion : System.Web.UI.Page
    {
        #region * Page Load Event
        protected WebApplication.FormMode _mode;
        protected Libreria.Prepagos.CreacionPrepago _objCreacion = null;
        protected string _id = null;
        private void Page_Load(object sender, System.EventArgs e)
        {
            Traducir();
            if (Request.QueryString["IdCreacion"] == null && lblHide.Text == "")
                this._mode = WebApplication.FormMode.New;
            else
            {
                this._mode = WebApplication.FormMode.Edit;
                if ( lblHide.Text == "")
                    lblHide.Text = DecryptText(Convert.ToString(Request.QueryString["IdCreacion"].Replace(" ", "+")));
            }

            if (!this.IsPostBack)
            {
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdCreacion"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                }
                this.InicializarForma();
            }
            else
                if (Request.Form["AcceptButton"] != null)
                this.Guardar();
        }
        #endregion

        #region Traducir
        private void Traducir() 
        {
            lblValue.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23861, Servipunto.Estacion.Web.Global.Idioma);
            lblTotalValue.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23862, Servipunto.Estacion.Web.Global.Idioma);
            lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23857, Servipunto.Estacion.Web.Global.Idioma);
            lblQUANTITY.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23860, Servipunto.Estacion.Web.Global.Idioma);
            lblIniNumber.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23858, Servipunto.Estacion.Web.Global.Idioma);
            lblFinalNumber.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23859, Servipunto.Estacion.Web.Global.Idioma);
    
        }

        #endregion

        #region * Método de Inicialización del Formulario
        private void InicializarForma()
        {
            try
            {
                if (this.VerificarPermisos())
                {
                    //				if (Request.UrlReferrer != null)
                    //					this.lblBack.NavigateUrl = Request.UrlReferrer.ToString();
                    //				else
                    this.lblBack.NavigateUrl = "Creaciones.aspx";
                    CargarDenominaciones();
                    if (this._mode == WebApplication.FormMode.New)
                        this.InicializarModoInsercion();
                    else
                    {

                        this.InicializarModoEdicion();
                    }

                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error iniciando el formulario: " + ex.Message;
                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + " !ERROR APP! " + ex.StackTrace, "Error iniciando el formulario de perfil de usuario");
                }
                catch (Exception exx)
                {
                    lblError.Text = "El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                }
                #endregion

            }

        }
        #endregion

        #region Método VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Prepagos";
            const string opcion = "Nuevo";
            bool permiso;

            if (this._mode == WebApplication.FormMode.New)
                permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Crear");
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

        #region Método Inicializar Modo de Inserción
        private void InicializarModoInsercion()
        {
            this.lblFormTitle.Text = "<b>Creating a New Range of Prepaid</b>";
            //this.AcceptButton.Value = "Crear";

            
        }
        #endregion

        #region Método Inicializar Modo de Edición
        private void InicializarModoEdicion()
        {
            if (this.ObtenerElemento())
            {
                this.txtNumeroInicial.Text = this._objCreacion.NumeroInicialCreacion.ToString();;
                this.txtNumeroFinal.Text = this._objCreacion.NumeroFinalCreacion.ToString();
                this.txtCantidad.Text = this._objCreacion.CantidadPrepagosCreados.ToString();
                string val = this._objCreacion.Denominacion.ToString();
                this.ddlDenominaciones.Text = val;
                this.txtTotalDenominacion.Text = this._objCreacion.TotalDenominacion.ToString();
                this.lblFormTitle.Text = "RANGE: <b>" + this._objCreacion.IdCreacion.ToString(); ;
                //this.AcceptButton.Value = "Guardar";
            }
        }
        #endregion

        #region Método para Obtener una Referencia al Objeto
        private bool ObtenerElemento()
        {
            try
            {
                this._id = lblHide.Text; // DecryptText(Convert.ToString(Request.QueryString["IdCreacion"].Replace(" ", "+")));
                this._objCreacion = Libreria.Prepagos.CreacionPrepagos.Obtener(Convert.ToInt32(this._id));
                if (this._objCreacion== null)
                {
                    this.SetError("Elemento No Encontrado [" + this._id + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError("Ingreso Invalido a la página! [" + this._id + "]", true);
                return false;
            }
        }
        #endregion

        #region Método SetError
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Text = message;
            this.lblError.Visible = true;
            //if (hideForm)
            //    this.MyForm.Visible = false;
        }
        #endregion

        #region Método Guardar
        private void Guardar()
        {
            if (this.Validar())
            {
                try
                {
                    if (this._mode == WebApplication.FormMode.New)
                    {
                        this.Insertar();
                        this.GenerarPrepagos();
                        Response.Redirect("Creaciones.aspx");

                    }
                    else
                    {
                        this.Modificar();
                        Response.Redirect("Creaciones.aspx");
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
                            ex.Message + " !ERROR APP! " + ex.StackTrace, "Error guardando los perfiles de usuario");
                    }
                    catch (Exception exx)
                    {
                        lblError.Text = "El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                    }
                    #endregion
                    return;
                }
                finally
                {
                    this._objCreacion = null;
                }
            }
            else
            {
                SetError("Range building already exists within a range", false);

            }
        }
        #endregion

        #region Método Insertar
        private void Insertar()
        {
            Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 11, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
            this._objCreacion = new Libreria.Prepagos.CreacionPrepago();
            this._objCreacion.NumeroInicialCreacion = Convert.ToInt32(this.txtNumeroInicial.Text);
            this._objCreacion.NumeroFinalCreacion = Convert.ToInt32(this.txtNumeroFinal.Text);
            this._objCreacion.CantidadPrepagosCreados = Convert.ToInt32(this.txtCantidad.Text);
            this._objCreacion.Denominacion = Convert.ToDecimal(ddlDenominaciones.Text);
            this._objCreacion.TotalDenominacion = Convert.ToDecimal(ddlDenominaciones.Text) * Convert.ToInt32(this.txtCantidad.Text);
            this._objCreacion.Fecha = DateTime.Now;
            this._objCreacion.IdUsuario = ((Libreria.Usuario)Session["Usuario"]).IdUsuario;
            Libreria.Prepagos.CreacionPrepagos.Adicionar(this._objCreacion);
        }
        #endregion

        #region Método Modificar
        private void Modificar()
        {
            Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 12, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
            if (this.ObtenerElemento())
            {
                this._objCreacion.Denominacion = Convert.ToDecimal(this.ddlDenominaciones.Text);
                this._objCreacion.CantidadPrepagosCreados = Convert.ToInt32(this.txtCantidad.Text);
                this._objCreacion.NumeroInicialCreacion = Convert.ToInt32(this.txtNumeroInicial.Text);
                this._objCreacion.NumeroFinalCreacion = Convert.ToInt32(this.txtNumeroFinal.Text);
                this._objCreacion.TotalDenominacion = Convert.ToInt32(this.txtCantidad.Text) * Convert.ToDecimal(this.ddlDenominaciones.SelectedValue);
                this._objCreacion.Modificar();
            }
        }
        #endregion

        #region Método Validar
        private bool Validar()
        {
            //this.lblError.Text = "";
            //if (this.txtNombre.Text.Trim().Length == 0)
            //{
            //    this.SetError("El nombre del Perfil de Usuario no puede ser una cadena vacia.", false);
            //    return false;
            //}
            Libreria.Prepagos.CreacionPrepagos objPrepagos = new Servipunto.Estacion.Libreria.Prepagos.CreacionPrepagos();
            int numeroInicial = Convert.ToInt32(txtNumeroInicial.Text);
            int numeroFinal = Convert.ToInt32(txtNumeroFinal.Text);
            foreach (Libreria.Prepagos.CreacionPrepago objPrepago in objPrepagos)
            {
                if ( ( numeroInicial >= objPrepago.NumeroInicialCreacion && numeroInicial <= objPrepago.NumeroFinalCreacion) ||
                    (numeroFinal >= objPrepago.NumeroInicialCreacion && numeroFinal <= objPrepago.NumeroFinalCreacion))                
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

        private void CargarDenominaciones()
        {
            ddlDenominaciones.Items.Clear(); 
            Libreria.Prepagos.Denominaciones objDenominaciones = new Servipunto.Estacion.Libreria.Prepagos.Denominaciones();
            foreach (Libreria.Prepagos.Denominacion objdenominacion in objDenominaciones)
            {
                ddlDenominaciones.Items.Add(new ListItem(objdenominacion.ValorDenominacion.ToString(), objdenominacion.ValorDenominacion.ToString()));
                
            }
        }

        protected void txtNumeroFinal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtCantidad.Text = (Convert.ToInt32(txtNumeroFinal.Text) - Convert.ToInt32(txtNumeroInicial.Text) + 1).ToString();
                txtTotalDenominacion.Text = (Convert.ToDecimal(ddlDenominaciones.SelectedValue) * Convert.ToInt32(txtCantidad.Text)).ToString();
            }
            catch
            {
            }
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNumeroFinal.Text = (Convert.ToInt32(txtNumeroInicial.Text) + Convert.ToInt32(txtCantidad.Text)).ToString();
                txtTotalDenominacion.Text = (Convert.ToDecimal(ddlDenominaciones.SelectedValue) * Convert.ToInt32(txtCantidad.Text)).ToString();
            }
            catch
            {
            }
        }

        protected void txtTotalDenominacion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDenominaciones_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalDenominacion.Text = (Convert.ToDecimal(ddlDenominaciones.SelectedValue) * Convert.ToInt32(txtCantidad.Text)).ToString();
            }
            catch
            {
            }

        }

        private void GenerarPrepagos()
        {
            for (int i = _objCreacion.NumeroInicialCreacion; i <= _objCreacion.NumeroFinalCreacion; i++)
            {
                Libreria.Configuracion.Dat_Gene objDatoGeneral = Libreria.Configuracion.Datos_Gene.ObtenerItem();
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 11, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                Libreria.Prepagos.Prepago objPrepago = new Servipunto.Estacion.Libreria.Prepagos.Prepago();
                objPrepago.Cod_Cli = "";
                objPrepago.CodigoCentroVenta = objDatoGeneral.CodigoAlternoEstacion;
                objPrepago.Denominacion = Convert.ToDecimal(ddlDenominaciones.SelectedValue);
                objPrepago.EstadoPrepago = Libreria.EstadoPrepago.Creado;
                objPrepago.FechaAnulacion = new DateTime(1900, 1, 1);
                objPrepago.FechaAsignacion = new DateTime(1900, 1, 1);
                objPrepago.FechaCreacion = DateTime.Now;
                objPrepago.FechaRealUtilizacion = new DateTime(1900, 1, 1);
                objPrepago.FechaTurnoUtilizacion = new DateTime(1900, 1, 1);
                objPrepago.IdCompania = objDatoGeneral.CodEstacion.ToString(); ;
                objPrepago.IdUsuarioAsigno = "";
                objPrepago.IdUsuarioCreo = ((Libreria.Usuario)Session["Usuario"]).IdUsuario;
                objPrepago.IdUsuarioUtilizo = "";
                objPrepago.NumeroFinalTiqueteCreado = _objCreacion.NumeroFinalCreacion;
                objPrepago.NumeroInicialTiqueteCreado = _objCreacion.NumeroInicialCreacion;
                objPrepago.NumeroPrepago = i;
                objPrepago.NumeroTiqueteFinalAsignacion = 0;
                objPrepago.NumeroTiqueteInicialAsignacion = 0;
                objPrepago.Placa = "";
                Libreria.Prepagos.Prepagos.Adicionar(objPrepago);
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }

      
    }
}
