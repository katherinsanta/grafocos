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
    public partial class IdentificadorConductor : System.Web.UI.Page
    {
        #region Sección de Declaraciones

        protected Libreria.Configuracion.IdentificadorConductor _objIdentificadorConductor = null;
        protected static bool editar;
        #endregion

        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (Request.QueryString["IdConductor"] != null && lblHide.Text == "")
                lblHide.Text = DecryptText(Request.QueryString["IdConductor"].Replace(" ", "+"));

            string datoenc = EncryptText("7702090028836");
            if (Request.QueryString["Numero"] != null && lblNumero.Text == "")
                lblNumero.Text = DecryptText(Request.QueryString["Numero"].Replace(" ", "+"));


            if (!this.IsPostBack)
                this.InicializarForma();
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
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region Inicialización del Formulario
        private void InicializarForma()
        {
            this.lblBack.NavigateUrl = "Conductores.aspx";


            if (lblNumero.Text != "")
                editar = true;
            else
                editar = false;

            if (!editar)
            {
                #region Modo de Inserción
                this.lblFormTitle.Text = "<b>Asignar Nuevo Identificador Conductor: " + lblHide.Text + "</b>";
                this.lbGuardar.Text = "Crear";
                #endregion
            }
            else
            {
                #region Modo de Edición
                if (ObtenerObjetoIdentificadorConductor())
                {
                    txtNumero.Enabled = false;
                    txtNumero.Text = _objIdentificadorConductor.Numero.ToString();
                    ddlAutorizado.SelectedValue = _objIdentificadorConductor.Estado == "Activo" ? "Si" : "No";
                    this.lblFormTitle.Text = "<b>Modificar Identificador Conductor: " +  lblHide.Text + ", Identificador:" + lblNumero.Text + "</b>";
                    this.lbGuardar.Text = "Modificar";
                }
                #endregion
            }

        }
        #endregion

        #region Obtener IdentificadorConductor
        private bool ObtenerObjetoIdentificadorConductor()
        {
            try
            {
                if (lblNumero.Text != "" && lblHide.Text != "")
                    _objIdentificadorConductor = Libreria.Configuracion.IdentificadoresConductor.ObtenerItem(Convert.ToInt32(lblHide.Text), lblNumero.Text);
                else
                    _objIdentificadorConductor = null;

                if (this._objIdentificadorConductor == null)
                {
                    this.SetError("Elemento No Encontrado [" + lblHide.Text + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError("Ingreso Invalido a la página! [" + lblHide.Text + "]", true);
                return false;
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
                    if (!editar)
                    {
                        #region Insertar
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 315, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this._objIdentificadorConductor = new Libreria.Configuracion.IdentificadorConductor();
                        this._objIdentificadorConductor.IdConductor = Convert.ToInt32(lblHide.Text);
                        this._objIdentificadorConductor.Numero = txtNumero.Text;                        
                        this._objIdentificadorConductor.Estado = ddlAutorizado.SelectedValue;
                        Libreria.Configuracion.IdentificadoresConductor.Adicionar(this._objIdentificadorConductor);
                        Response.Redirect("IdentificadoresConductor.aspx?Idconductor=" + EncryptText(lblHide.Text));
                        #endregion
                    }
                    else
                    {
                        #region Editar
                        if (this.ObtenerObjetoIdentificadorConductor())
                        {
                            Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 316, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                            this._objIdentificadorConductor.IdConductor = Convert.ToInt32(lblHide.Text);
                            this._objIdentificadorConductor.Numero = txtNumero.Text;                            
                            this._objIdentificadorConductor.Estado = ddlAutorizado.SelectedValue;
                            this._objIdentificadorConductor.Modificar();
                            Response.Redirect("IdentificadoresConductor.aspx?IdConductor=" + EncryptText(lblHide.Text));
                        }
                        #endregion
                    }


                }
                catch (Exception ex)
                {
                    this.lblError.Visible = true;
                    this.lblError.Text = ex.Message;
                    return;
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


            if (txtNumero.Text == "")
            {
                this.SetError("Debe ingresar un numero!", false);
                return false;
            }



            return true;
        }
        #endregion



        #region Boton Guardar
        private void lbGuardar_Click(object sender, System.EventArgs e)
        {
            Guardar();
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
