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

namespace Servipunto.Estacion.Web.Modules.PanelControl
{
    public partial class ConfiguracionZetaAutomatico : System.Web.UI.Page
    {
        #region Sección de Declaraciones
        protected WebApplication.FormMode _mode;
        protected Libreria.Configuracion.ConfiguracionZetaAutomatica _objConfiguracionZetaAutomatico = null;
        protected string _id = null;

        #endregion

        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            try
            {

                if (!this.IsPostBack)
                {

                    this.InicializarForma();
                }
               
            }
            catch (Exception ex)
            {
                lblError.Text += "Error cargando el formulario";

                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + " !ERROR APP! " + ex.StackTrace, "Error cargando el formulario de compañia");
                }
                catch (Exception exx)
                {
                    lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
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

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Panel de Control";
            const string opcion = "Companias";
            bool permiso;

            if (this._mode == WebApplication.FormMode.New)
                permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
            else
                permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

            if (!permiso)
            {
                this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.", true);
                return false;
            }

            return true;
        }
        #endregion

        #region ObtenerObjetoConfiguracionZeta
        private bool ObtenerObjetoConfiguracionZeta()
        {
            try
            {

                Libreria.Configuracion.ConfiguracionesZetaAutomatico objConfiguraciones = new Servipunto.Estacion.Libreria.Configuracion.ConfiguracionesZetaAutomatico();
                if (objConfiguraciones.Count > 0)
                {
                    _objConfiguracionZetaAutomatico = objConfiguraciones[0];
                    return true;
                }
                else
                    return false;
            }
            catch (FormatException)
            {
                this.SetError("Ingreso Invalido a la página! [" + this._id + "]", true);
                return false;
            }
        }
        #endregion

        #region Inicialización del Formulario
        private void InicializarForma()
        {

            if (this.VerificarPermisos())
            {
                this.lblBack.NavigateUrl = "default.aspx";
                this.lblFormTitle.Text = "<b>Configuración Zeta Automatica</b>";
                this._mode = WebApplication.FormMode.New;
                chkZetaAutomatico.Checked = false;
                if (ObtenerObjetoConfiguracionZeta())
                {
                    chkZetaAutomatico.Checked = true;
                    #region Modo de Edición
                    //Visualización de Datos
                    this.ddlHoraInicio.SelectedValue = _objConfiguracionZetaAutomatico.HoraInicio.Hour.ToString();
                    this.ddlHoraFinal.SelectedValue = _objConfiguracionZetaAutomatico.HoraFinal.Hour.ToString();
                    this.ddlMinutoInicio.SelectedValue = _objConfiguracionZetaAutomatico.HoraInicio.Minute.ToString();
                    this.ddlMinutoFinal.SelectedValue = _objConfiguracionZetaAutomatico.HoraFinal.Minute.ToString();
                    this.txtCodigoEmpleado.Text = _objConfiguracionZetaAutomatico.CodigoEmpleado;
                    
                    Libreria.Empleado emp = Libreria.Empleados.Obtener(this.txtCodigoEmpleado.Text);
                    if (emp != null)
                        txtNombreEmpleado.Text = emp.Nombre;


                    this._mode = WebApplication.FormMode.Edit;
                    chkZetaAutomatico.Checked = true;
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
                    if (!chkZetaAutomatico.Checked)
                    {
                        #region Insertar
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 31, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this._objConfiguracionZetaAutomatico = new Servipunto.Estacion.Libreria.Configuracion.ConfiguracionZetaAutomatica();
                        this._objConfiguracionZetaAutomatico.HoraInicio = new DateTime(1900, 1, 1, Convert.ToInt32(ddlHoraInicio.SelectedValue), Convert.ToInt32(ddlMinutoInicio.SelectedValue), 0);
                        this._objConfiguracionZetaAutomatico.HoraFinal = new DateTime(1900, 1, 1, Convert.ToInt32(ddlHoraFinal.SelectedValue), Convert.ToInt32(ddlMinutoFinal.SelectedValue), 0);
                        this._objConfiguracionZetaAutomatico.FechaCreacion = DateTime.Now;
                        this._objConfiguracionZetaAutomatico.Usuario = ((Libreria.Usuario)Session["Usuario"]).IdUsuario;
                        this._objConfiguracionZetaAutomatico.FechaActualizacion = DateTime.Now;
                        this._objConfiguracionZetaAutomatico.CodigoEmpleado = txtCodigoEmpleado.Text.TrimEnd();   
                        Libreria.Configuracion.ConfiguracionesZetaAutomatico.Adicionar(this._objConfiguracionZetaAutomatico);
                        #endregion
                    }
                    else
                    {
                        #region Modificar
                        ObtenerObjetoConfiguracionZeta();
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 32, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this._objConfiguracionZetaAutomatico.HoraInicio = new DateTime(1900, 1, 1, Convert.ToInt32(ddlHoraInicio.SelectedValue.ToString()), Convert.ToInt32(ddlMinutoInicio.SelectedValue.ToString()), 0);
                        this._objConfiguracionZetaAutomatico.HoraFinal = new DateTime(1900, 1, 1, Convert.ToInt32(ddlHoraFinal.SelectedValue.ToString()), Convert.ToInt32(ddlMinutoFinal.SelectedValue.ToString()), 0);
                        this._objConfiguracionZetaAutomatico.FechaActualizacion = DateTime.Now;
                        this._objConfiguracionZetaAutomatico.CodigoEmpleado = txtCodigoEmpleado.Text.TrimEnd(); 
                        this._objConfiguracionZetaAutomatico.Modificar();
                        #endregion
                    }
                    Response.Redirect("default.aspx");
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
                            ex.Message + " !ERROR APP! " + ex.StackTrace, "Error guardando los datos de las compañias");
                    }
                    catch (Exception exx)
                    {
                        lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                    }
                    #endregion

                    return;
                }
                finally
                {
                    this._objConfiguracionZetaAutomatico = null;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
