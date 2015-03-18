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

namespace Servipunto.Estacion.Web.Ajax.Modules.PanelControl
{
    public partial class ConsolaTanque : System.Web.UI.Page
    {
        #region Sección de Declaraciones
        protected Libreria.Configuracion.Tanques.ConsolaTanque objConsola = null;
        protected string idConsola = null;
        protected WebApplication.FormMode _mode;
        protected System.Web.UI.WebControls.Label lblHide;
        //protected System.Web.UI.WebControls.DropDownList ddlTipoConsola;
        #endregion

        #region Page_PreLoad Event
        private void Page_PreLoad(object sender, System.EventArgs e)
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
        }
        #endregion

        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (Request.QueryString["IdConsola"] == null && lblHide.Text == "")
                this._mode = WebApplication.FormMode.New;
            else
                this._mode = WebApplication.FormMode.Edit;

            if (!this.IsPostBack)
            {

                if (this.idConsola == null & this._mode == WebApplication.FormMode.Edit)
                {
                    this.idConsola = DecryptText(Convert.ToString(Request.QueryString["IdConsola"].Replace(" ", "+")));
                    lblHide.Text = this.idConsola;
                }
                this.InicializarForma();
            }
            else
                if (Request.Form["AcceptButton"] != null)
                    this.Guardar();
        }
        #endregion

        #region SetError and ClearError
        private void SetError(string message, bool hideForm)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
            if (hideForm)
                this.Form.Visible = false;
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
            const string opcion = "Consola Tanques";
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

        #region ObtenerObjetoConsolaTanque
        private bool ObtenerObjetoConsolaTanque()
        {
            try
            {

                this.idConsola= lblHide.Text;
                this.objConsola = Libreria.Configuracion.Tanques.ConsolaTanques.ObtenerItem(Convert.ToInt32(this.idConsola));
                if (this.objConsola == null)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this.idConsola + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this.idConsola + "]", true);
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

                    CargarTiposConsola();
                    if (this._mode == WebApplication.FormMode.New)
                    {
                        #region Modo de Inserción
                        this.filaCodigo.Visible = false;
                        this.lblFormTitle.Text = "<b>Creación de una Consola De Tanque</b>";
                        this.AcceptButton.Value = "Crear";
                       // btnCrear.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(1041, Global.Idioma);
                        #endregion
                    }
                    else
                    {
                        #region Modo de Edición

                        if (this.ObtenerObjetoConsolaTanque())
                        {
                            //Visualización de Datos				
                            //this.txtId.Text = this.objConsola.IdConsola.ToString();
                            this.txtNombre.Text = this.objConsola.Nombre;
                            this.txtProtocolo.Text = this.objConsola.Protocolo;
                            ddlTipoConsola.SelectedValue =(this.objConsola.Tipo).ToString();
                            this.txtDireccionIp.Text = this.objConsola.DireccionIP;
                            this.txtPuertoLogico.Text = this.objConsola.PuertoLogico;
                            this.txtPuertoSerial.Text = this.objConsola.PuertoSerial;
                            
                            this.lblFormTitle.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(619, Global.Idioma) + " <b>" + this.objConsola.IdConsola + "</b>";
                            this.AcceptButton.Value = "Guardar";
                            //btnCrear = Libreria.Configuracion.PalabrasIdioma.Traduccion(1062, Global.Idioma);
                        }
                        else
                            this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma), false);
                        #endregion
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
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 131, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this.objConsola = new Servipunto.Estacion.Libreria.Configuracion.Tanques.ConsolaTanque();
                        this.objConsola.Nombre=this.txtNombre.Text;
                        this.objConsola.Protocolo=this.txtProtocolo.Text;
                        this.objConsola.Tipo= this.ddlTipoConsola.SelectedValue;
                        this.objConsola.DireccionIP=this.txtDireccionIp.Text;
                        this.objConsola.PuertoLogico=this.txtPuertoLogico.Text;
                        this.objConsola.PuertoSerial=this.txtPuertoSerial.Text;
                        Libreria.Configuracion.Tanques.ConsolaTanques.Adicionar(this.objConsola);
                        #endregion
                    }
                    else
                    {
                        #region Modificar
                        if (this.ObtenerObjetoConsolaTanque())
                        {
                            Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 132, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                             this.objConsola.Nombre=this.txtNombre.Text;
                             this.objConsola.Protocolo=this.txtProtocolo.Text;
                             this.objConsola.Tipo=this.ddlTipoConsola.SelectedValue;
                             this.objConsola.DireccionIP=this.txtDireccionIp.Text;
                             this.objConsola.PuertoLogico=this.txtPuertoLogico.Text;
                             this.objConsola.PuertoSerial=this.txtPuertoSerial.Text;
                            this.objConsola.Modificar();
                        }
                        #endregion
                    }
                    Response.Redirect("ConsolaTanques.aspx");
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
            //if (this.txtCapacidad.Text.Trim().Length != 0)
            //{
            //    try
            //    {
            //        Decimal.Parse(txtCapacidad.Text);
            //    }
            //    catch
            //    {
            //         this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1809, Global.Idioma), false);
            //        return false;
            //    }
            //}
            //else
            //{
            //    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1810, Global.Idioma), false);
            //    return false;
            //}

            //try
            //{
            //    int articulo = int.Parse(cboArticulo.SelectedValue);
            //}
            //catch(Exception)
            //{
            //    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1937, Global.Idioma), false);
            //    return false;

            //}

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

        private void CargarTiposConsola()
        {
            ddlTipoConsola.Items.Clear();
            ddlTipoConsola.Items.Add(new ListItem("IP", "1"));
            ddlTipoConsola.Items.Add(new ListItem("Serial", "2"));

        }
        #endregion

        protected void ddlTipoConsola_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }
    }
}
