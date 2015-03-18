using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servipunto.Estacion.Web.Ajax.Modules.PanelControl
{
    public partial class FactoresSurtidor : System.Web.UI.Page
    {
        #region Sección de Declaraciones       
        private Libreria.Configuracion.Surtidor _objSurtidor = null;
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
            

            if (!this.Page.IsPostBack)
            {
                if (this.VerificarPermisos())
                {
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 94, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();

                    this.Visualizar();
                }
            }
            else
            {
             //   this.Eliminar();
            }
        }
        #endregion

        #region ObtenerObjetoSurtidor
        private bool ObtenerObjetoSurtidor()
        {
            try
            {

                this._idSurtidor = lblHide.Text;

                this._objSurtidor = Libreria.Configuracion.Surtidores.ObtenerItem(Convert.ToInt16(this._idSurtidor));
                if (this._objSurtidor == null)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._idSurtidor + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._idSurtidor + "]", true);
                return false;
            }
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Panel de Control";
            const string opcion = "Factores";
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
            
            this.AgregarAccion(ref htmlAcciones, "default.aspx", "Volver" );
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

                this.lblTitle.Text = "Factores Surtidor";
                    Libreria.Configuracion.Factores objFactores = new Libreria.Configuracion.Factores(0, false);
                    Results.DataSource = objFactores;
                    Results.DataBind();
                    objFactores = null;
                
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