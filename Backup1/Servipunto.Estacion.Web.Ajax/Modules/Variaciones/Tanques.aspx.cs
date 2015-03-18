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
    public partial class Tanques : System.Web.UI.Page
    {
        #region Sección de Declaraciones
        protected System.Web.UI.WebControls.Repeater Results;
        protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblTitle;
        protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
        protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;
        
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
            #region verificar session
            if (Session["Usuario"] == null)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("~/Modules/Main/Login.aspx?SesionClose=1");
                }

            }
            #endregion
            try
            {
                if (!this.Page.IsPostBack)
                {
                    if (this.VerificarPermisos())
                    {
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 569, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        this.Visualizar();
                    }
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
            bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Consultar");
            bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Administrar");

            //Revisión de permiso de consulta
            if (!consultar)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                return false;
            }

            //Configuración de Acciones
            string htmlAcciones = "";
            this.AgregarAccion(ref htmlAcciones, "default.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));
            this.Acciones.InnerHtml = htmlAcciones + "<br><br>";

            //Configuración del permiso de modificación
            if (modificar)
                this.HiddenUpdate.Value = "Allow";
            else
                this.HiddenUpdate.Value = "Deny";

            return true;
        }

        /// <summary>
        /// Escribe opciones adicionales en el formulario asp
        /// </summary>
        /// <param name="currentHtml">Acciones Html</param>
        /// <param name="hRef">Formulario a vincular</param>
        /// <param name="title">Titulo visible de la accion</param>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void AgregarAccion(ref string currentHtml, string hRef, string title)
        {
            currentHtml += currentHtml.Length == 0 ? "" : "&nbsp;|&nbsp;";
            currentHtml += "<a href='" + hRef + "'>" + title + "</a>";
        }
        #endregion

        #region Visualizar
        /// <summary>
        /// Lista los tanques configurados en el sistema
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void Visualizar()
        {
            try
            {
                Results.DataSource = new Servipunto.Estacion.Libreria.Configuracion.Tanques.Tanques();
                Results.DataBind();
            }
            catch (Exception ex)
            {
                SetError(ex.Message, false);
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
