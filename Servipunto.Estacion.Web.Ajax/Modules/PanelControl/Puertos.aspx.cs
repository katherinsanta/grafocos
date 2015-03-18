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
    public class Puertos : System.Web.UI.Page
    {
        #region Sección de Declaraciones

        protected System.Web.UI.WebControls.Repeater Results;
        protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
        protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;

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
            ViewState["Control"] = "0";
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
            if (!this.Page.IsPostBack)
            {
                if (ViewState["Control"].ToString() != "1")
                {
                    if (Request.QueryString["Detect"] == "true")
                    {
                        this.DetectPorts();
                    }
                    else
                    {
                        if (this.VerificarPermisos())
                        {
                            Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 44, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                            this.Visualizar();
                        }
                    }
                }
            }
            else
            {
                this.Eliminar();
            }
        }
        #endregion

        #region Detectar Puertos
        private void DetectPorts()
        {
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 49, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                Servipunto.Estacion.Libreria.Configuracion.Puertos.Eliminar("0");
                Servipunto.Estacion.Libreria.HardWareDetection.SerialPortsDetection Ports = new Servipunto.Estacion.Libreria.HardWareDetection.SerialPortsDetection();
                for (int i = 1; i < 21; i++)
                {
                    if (Ports.Scan(i))
                    {

                        Servipunto.Estacion.Libreria.Configuracion.Puerto port = new Servipunto.Estacion.Libreria.Configuracion.Puerto();
                        port.IdPuerto = "COM" + i;
                        port.BaudRate = 9600;
                        port.DataBits = "8";
                        port.Parity = "None";
                        port.Stop = "1";
                        Servipunto.Estacion.Libreria.Configuracion.Puertos.Adicionar(port);

                    }
                }
                Response.Redirect("Puertos.aspx");
            }
            catch (Exception ex)
            {
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1815, Global.Idioma) + ex.Message, true);
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
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Panel de Control";
            const string opcion = "Puertos";
            bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Consultar");
            bool nuevo = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
            bool eliminar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Eliminar");
            bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

            //Revisión de permiso de consulta
            if (!consultar)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                return false;
            }

            //Configuración de Acciones
            string htmlAcciones = "";
            this.AgregarAccion(ref htmlAcciones, "Puertos.aspx?Detect=true", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1294, Global.Idioma));

            if (nuevo)
                this.AgregarAccion(ref htmlAcciones, "Puerto.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1295, Global.Idioma));
            if (eliminar)
                this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1296, Global.Idioma));

            this.AgregarAccion(ref htmlAcciones, "Default.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));
            this.Acciones.InnerHtml = htmlAcciones + "<br><br>";

            //Configuración del permiso de modificación
            if (modificar)
                this.HiddenUpdate.Value = "Allow";
            else
                this.HiddenUpdate.Value = "Deny";

            return true;
        }

        private void AgregarAccion(ref string currentHtml, string hRef, string title)
        {
            currentHtml += currentHtml.Length == 0 ? "" : "&nbsp;|&nbsp;";
            currentHtml += "<a  href='" + hRef + "'>" + title + "</a>";
        }
        #endregion

        #region Visualizar
        private void Visualizar()
        {
            try
            {
                ViewState["Control"] = "1";
                Libreria.Configuracion.Puertos objPuertos = new Libreria.Configuracion.Puertos();
                Results.DataSource = objPuertos;
                Results.DataBind();
                objPuertos = null;
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

        #region Eliminar
        private void Eliminar()
        {
            if (Request.Form["chkID"] != null)
            {
                int i;
                string[] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 47, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();

                this.lblError.Visible = true;
                this.lblError.Text = "";
                for (i = 0; i <= aSelectedItems.Length - 1; i++)
                {
                    try
                    {
                        Libreria.Configuracion.Puertos.Eliminar(aSelectedItems[i]);
                    }
                    catch (Exception ex)
                    {
                        this.lblError.Text = this.lblError.Text + ex.Message + " <br>";
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
                this.Visualizar();
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
    }
}
