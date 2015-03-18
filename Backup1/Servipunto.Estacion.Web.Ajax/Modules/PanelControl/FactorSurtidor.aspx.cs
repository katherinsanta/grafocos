using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servipunto.Estacion.Web.Ajax.Modules.PanelControl
{
    public partial class FactorSurtidor : System.Web.UI.Page
    {
        #region Sección de Declaraciones

        protected WebApplication.FormMode _mode;

        protected Libreria.Configuracion.Surtidor _objSurtidor = null;
        protected Libreria.Configuracion.Factor _objFactor = null;
        protected string _id = null;
        protected string _idSurtidor = null;
        #endregion

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
            if (Request.QueryString["IdFactor"] == null && lblHide.Text == "")
            {
                this._mode = WebApplication.FormMode.New;

                lblHide.Text = DecryptText(Convert.ToString(Request.QueryString["IdFactor"].Replace(" ", "+")));
                    
                
            }
            else
                this._mode = WebApplication.FormMode.Edit;

            if (!this.IsPostBack)
            {
                if (this._id == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this._id = DecryptText(Convert.ToString(Request.QueryString["IdFactor"].Replace(" ", "+")));
                    lblHide.Text = this._id;
                    
                }
                this.InicializarForma();
            }
            //else
            //    if (Request.Form["AcceptButton"] != null)
            //        this.Guardar();
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
            const string opcion = "FactorSurtidor";
            bool permiso;

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

        #region ObtenerObjetoCara
        private bool ObtenerObjetoSurtidor()
        {
            try
            {
                this._id = lblHide.Text; // (Convert.ToString(Request.QueryString["IdCara"].Replace(" ", "+")));
                this._objSurtidor = Libreria.Configuracion.Surtidores.ObtenerItem(Convert.ToInt16(this._id));
                if (this._objSurtidor == null)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._id + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._id + "]", true);
                return false;
            }
        }
        #endregion

        #region ObtenerObjetoFactor
        private bool ObtenerObjetoFactor()
        {
            try
            {

                this._objFactor = Libreria.Configuracion.Factores.ObtenerItem(Convert.ToInt16(lblHide.Text));
                if (this._objFactor == null)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._id + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._id + "]", true);
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

                    #region Modo de Edición
                    if (this.ObtenerObjetoFactor())
                    {
                        //Visualización de Datos						
                        this.txtId.Text = this._objFactor.IdSurtidor.ToString();
                        this.txtValorVenta.Text = this._objFactor.ValorVenta.ToString().Substring(1);
                        ddlOperadorValorVenta.Text = this._objFactor.ValorVenta.ToString().Substring(0,1);
                        this.txtPrecioVenta.Text = this._objFactor.PrecioVenta.ToString().Substring(1);
                        ddlOperadorPrecio.Text = this._objFactor.PrecioVenta.ToString().Substring(0, 1);                        
                        this.txtCantidadVenta.Text = this._objFactor.CantidadVenta.ToString().Substring(1);
                        ddlOperadorCantidadVenta.Text = this._objFactor.CantidadVenta.ToString().Substring(0, 1);                        
                        this.txtValorPredeterminado.Text = this._objFactor.Preset.ToString().Substring(1);
                        ddlOperadorValorPreset.Text = this._objFactor.Preset.ToString().Substring(0, 1);
                        this.txtValorLectura.Text = this._objFactor.valorLectura.ToString().Substring(1);
                        ddlOperadorValorLectura.Text = this._objFactor.valorLectura.ToString().Substring(0, 1);
                        this.txtPrecioProgramado.Text = this._objFactor.PrecioProgramado.ToString().Substring(1);
                        ddlOperadorPrecioProgramado.Text = this._objFactor.PrecioProgramado.ToString().Substring(0, 1);
                        this.txtId.Enabled = false;
                        btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                        this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma) +   ": <b>" + this._objFactor.IdSurtidor.ToString() + "</b>";
                        //this.AcceptButton.Value = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                        this.lblBack.NavigateUrl = "factoresSurtidor.aspx";
                    }
                    else
                        this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma), false);
                    #endregion

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

        #region Guardar
        private void Guardar()
        {
            if (this.Validar())
            {
                try
                {
                    #region Modificar
                    if (this.ObtenerObjetoFactor())
                    {
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 96, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this._objFactor.ValorVenta = ddlOperadorValorVenta.Text + (txtValorVenta.Text);
                        this._objFactor.PrecioVenta = ddlOperadorPrecio.Text +  (txtPrecioVenta.Text);
                        this._objFactor.CantidadVenta = ddlOperadorCantidadVenta.Text + (txtCantidadVenta.Text);
                        this._objFactor.Preset = ddlOperadorValorPreset.Text + (txtValorPredeterminado.Text);
                        this._objFactor.valorLectura = ddlOperadorValorLectura.Text + (txtValorLectura.Text);
                        this._objFactor.PrecioProgramado = ddlOperadorPrecioProgramado.Text+(txtPrecioProgramado.Text);
                        this._objFactor.Modificar();
                    }
                    #endregion

                    Response.Redirect("FactoresSurtidor.aspx");
                      
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
                    this._objFactor = null;
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
            //Número de la cara
            if (this.txtId.Text.Trim().Length != 0)
            {
                if (!Libreria.Aplicacion.IsNumeric(this.txtId.Text.Trim()))
                {
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1809, Global.Idioma), false);
                    return false;
                }
            }
            else
            {
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1810, Global.Idioma), false);
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

        #region btnCrear_Click
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        #endregion
    }
}