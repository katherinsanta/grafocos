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
    public partial class OtroIngreso : System.Web.UI.Page
    {
        protected WebApplication.FormMode _mode;
        protected Libreria.Configuracion.ConceptoOtroIngreso _objConceptoOtroIngreso = null;
        protected string _id = null;
        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            try
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
                else
                    if (Request.Form["AcceptButton"] != null)
                        this.Guardar();
            }
            catch (Exception ex)
            {
                lblError.Text += "Error cargando el formulario";

                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + " !ERROR APP! " + ex.StackTrace, "Error cargando el formulario de Conceptos de Otros Ingresos");
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
            const string opcion = "Concepto Otros Ingresos";
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

        #region ObtenerObjetoOtroIngreso
        private bool ObtenerObjetoOtroIngreso()
        {
            try
            {
                this._id = lblHide.Text; // DecryptText(Convert.ToString(Request.QueryString["Id"].Replace(" ", "+")));
                this._objConceptoOtroIngreso = Libreria.Configuracion.ConceptoOtrosIngresos.ObtenerItem(Convert.ToInt32(this._id));
                if (this._objConceptoOtroIngreso == null)
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

        #region Inicialización del Formulario
        private void InicializarForma()
        {
            if (this.VerificarPermisos())
            {
                this.lblBack.NavigateUrl = "OtrosIngresos.aspx";
                if (this._mode == WebApplication.FormMode.New)
                {
                    #region Modo de Inserción
                    this.lblFormTitle.Text = "<b>Creación de un Concepto de otro Ingreso</b>";
                    this.Button1.Text = "Crear";
                    #endregion
                }
                else
                {
                    #region Modo de Edición
                    if (this.ObtenerObjetoOtroIngreso())
                    {
                        //Visualización de Datos
                        this.txtCodigo.Text = this._objConceptoOtroIngreso.IdConceptoOtroIngreso.ToString();
                        this.txtCodigo.Enabled = false;
                        this.txtNombre.Text = this._objConceptoOtroIngreso.NombreOtroIngreso;
                        

                        this.lblFormTitle.Text = "Otro Ingreso: <b>" + this._objConceptoOtroIngreso.NombreOtroIngreso + " (" + this._objConceptoOtroIngreso.IdConceptoOtroIngreso.ToString() + ")</b>";
                        this.Button1.Text = "Guardar";
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
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 31, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this._objConceptoOtroIngreso = new Libreria.Configuracion.ConceptoOtroIngreso();                        
                        this._objConceptoOtroIngreso.NombreOtroIngreso = this.txtNombre.Text.Trim();
                        Libreria.Configuracion.ConceptoOtrosIngresos.Adicionar(this._objConceptoOtroIngreso);
                        #endregion
                    }
                    else
                    {
                        #region Modificar
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 32, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        if (this.ObtenerObjetoOtroIngreso())
                        {
                            this._objConceptoOtroIngreso.IdConceptoOtroIngreso = Int32.Parse(this.txtCodigo.Text);
                            this._objConceptoOtroIngreso.NombreOtroIngreso = this.txtNombre.Text.Trim();                            
                            this._objConceptoOtroIngreso.Modificar();
                        }
                        #endregion
                    }
                    Response.Redirect("OtrosIngresos.aspx");
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
                            ex.Message + " !ERROR APP! " + ex.StackTrace, "Error guardando los datos de el concepto del Otros ingresos");
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
                    this._objConceptoOtroIngreso = null;
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
            if (this.txtNombre.Text.Trim().Length == 0)
            {
                this.SetError("El nombre no puede ser una cadena vacia!", false);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
