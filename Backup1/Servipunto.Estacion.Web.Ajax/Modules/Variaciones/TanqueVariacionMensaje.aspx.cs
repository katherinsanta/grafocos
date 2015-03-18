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

namespace Servipunto.Estacion.Web.Modules.Variaciones
{
    public partial class TanqueVariacionMensaje : System.Web.UI.Page
    {
        #region Declaraciones        
        protected string _id = null;
        protected Libreria.Configuracion.Tanques.TanqueVariacionMensaje _objTanqueMensaje = null;
        //protected System.Web.UI.WebControls.Label Label1;
        //protected System.Web.UI.WebControls.Label Label2;
        //protected System.Web.UI.WebControls.Label Label3;        
        //protected System.Web.UI.WebControls.Panel pnlForm;
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

            try
            {
                this.lblError.Visible = false;
                if (!this.IsPostBack)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdTanque"].Replace(" ", "+")));
                    txtIdTanque.Text = this._id;
                    this.lblFormTitle.Text = "<b>"+Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2101, Global.Idioma)+" "+ txtIdTanque.Text + "</b>";
                    this.InicializarForma();
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
            const string opcion = "Mensajes";
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

        #region CargarMensajes
        /// <summary>
        /// Lista los mensajes configurados en el sistema para el tanque
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void CargarMensajes()
        {
            try
            {
                DataSet ds = Libreria.Configuracion.Tanques.TanqueVariacionMensajes.ObtenerItems(int.Parse(txtIdTanque.Text));
                this.lstMensajes.DataSource = ds;
                this.lstMensajes.DataKeyField = "idVariacionTanqueMensaje";
                this.lstMensajes.DataBind();
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
            {
                lblGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1001, Global.Idioma);
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 569, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.CargarMensajes();

            }
        }
        #endregion

        #region Guardar
        /// <summary>
        /// Adiciona o edita registros de mensaje en la base de datos
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void Guardar()
        {
            try
            {
                if (!this.Validar())
                    return;

                #region Capturar datos
                this._objTanqueMensaje = new Servipunto.Estacion.Libreria.Configuracion.Tanques.TanqueVariacionMensaje();
                this._objTanqueMensaje.CodigoTanque = int.Parse(this.txtIdTanque.Text);
                this._objTanqueMensaje.ValorInicial = decimal.Parse(this.txtValorInicial.Text);
                this._objTanqueMensaje.ValorFinal = decimal.Parse(this.txtValorFinal.Text);
                this._objTanqueMensaje.Mensaje = this.txtMensaje.Text;
                #endregion

                #region Insertar
                if (lblGuardar.Text == Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1001, Global.Idioma))
                {
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 570, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    Libreria.Configuracion.Tanques.TanqueVariacionMensajes.Adicionar(this._objTanqueMensaje);
                    LimpiarCampos();
                }
                #endregion

                #region Actualizar
                else
                {
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 571, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    _objTanqueMensaje.CodigoMensaje = int.Parse(txtIdMensaje.Text);
                    _objTanqueMensaje.Modificar();
                    LimpiarCampos();
                }
                #endregion
            }
            catch (Exception ex)
            {
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1940, Global.Idioma) + ex.Message, false);
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

            this.CargarMensajes();
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
            txtValorInicial.Text = txtValorInicial.Text.Trim().Replace(".", ",");
            txtValorFinal.Text = txtValorFinal.Text.Trim().Replace(".", ",");
            try
            {
                Decimal.Parse(txtValorInicial.Text);
                Decimal.Parse(txtValorFinal.Text);
            }
            catch
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2102, Global.Idioma), false);
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

        #region Limpiar Campos
        /// <summary>
        /// Limpia los controles de texto en el formulario
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void LimpiarCampos()
        {
            txtIdMensaje.Text = "";
            txtValorInicial.Text = "";
            txtValorFinal.Text = "";
            txtMensaje.Text = "";
            lblGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1001, Global.Idioma);
        }
        #endregion

        #region eventos de los controles

        #region lblGuardar_Click
        private void lblGuardar_Click(object sender, System.EventArgs e)
        {
            this.Guardar();
        }
        #endregion

        #region lstMensajes_EditCommand
        private void lstMensajes_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                lblGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                txtIdMensaje.Text = lstMensajes.DataKeys[e.Item.ItemIndex].ToString();
                txtValorInicial.Text = e.Item.Cells[0].Text;
                txtValorFinal.Text = e.Item.Cells[1].Text;
                txtMensaje.Text = e.Item.Cells[2].Text;

            }
        }
        #endregion

        #region lblCancelar_Click
        private void lblCancelar_Click(object sender, System.EventArgs e)
        {
            LimpiarCampos();
        }
        #endregion

        #region lstMensajes_DeleteCommand
        private void lstMensajes_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 572, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                Libreria.Configuracion.Tanques.TanqueVariacionMensajes.Eliminar(int.Parse(lstMensajes.DataKeys[e.Item.ItemIndex].ToString()));
            }
            catch (Exception ex)
            {
                this.SetError(lblError.Text +=  ex.Message, false);
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
            this.CargarMensajes();
        }
        #endregion

        #endregion

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1004, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(572, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1003, Global.Idioma);
            
            //lblFormTitle.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1662, Global.Idioma);
            lblBack.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);            
            lblCancelar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1002, Global.Idioma);            
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
            this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
            this.lblCancelar.Click += new System.EventHandler(this.lblCancelar_Click);
            this.lstMensajes.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.lstMensajes_EditCommand);
            this.lstMensajes.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.lstMensajes_DeleteCommand);
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion

        #region lstMensajes_DataBinding
        protected void lstMensajes_DataBinding(object sender, EventArgs e)
        {
            lstMensajes.Columns[0].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1003, Global.Idioma);
            lstMensajes.Columns[1].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1004, Global.Idioma);
            lstMensajes.Columns[2].HeaderText = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1005, Global.Idioma);
            
        }
        #endregion
    }
}
