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
    public partial class IdentificadoresConductor : System.Web.UI.Page
    {
        #region Sección de Declaraciones

        protected System.Web.UI.WebControls.Label lblTitle;

        #endregion

        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                if (this.VerificarPermisos())
                {
                    if (Request.QueryString["IdConductor"] != null && lblIdConductor.Text == "")
                        lblIdConductor.Text = DecryptText(Request.QueryString["IdConductor"]);

                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 314, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    this.Visualizar();
                }
            }
            else
            {
                this.Eliminar();
            }
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Comerciales";
            const string opcion = "PreciosDiferenciales";
            bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Consultar");
            bool nuevo = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
            bool eliminar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Eliminar");
            bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

            //Revisión de permiso de consulta
            if (!consultar)
            {
                this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta no tiene privilegios suficientes para ingresar a esta página.", true);
                return false;
            }

            //Configuración de Acciones
            string htmlAcciones = "";
            if (nuevo)
                this.AgregarAccion(ref htmlAcciones, "IdentificadorConductor.aspx?IdConductor=" + EncryptText(lblIdConductor.Text), "Crear un nuevo Identificador");
            if (eliminar)
                this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", "Eliminar los identificadores seleccionados");

            this.AgregarAccion(ref htmlAcciones, "Default.aspx", "Volver");
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
            currentHtml += "<a href='" + hRef + "'>" + title + "</a>";
        }
        #endregion

        #region Visualizar
        private void Visualizar()
        {
            try
            {
                if (lblIdConductor.Text != "")
                {
                    Libreria.Configuracion.Conductor objConductor = Libreria.Configuracion.Conductores.ObtenerItem(lblIdConductor.Text);
                    Results.DataSource = new Servipunto.Estacion.Libreria.Configuracion.IdentificadoresConductor(objConductor.IdConductor);
                    Results.DataBind();
                }
            }
            catch (Exception ex)
            {
                SetError(ex.Message /*+ "<br><br>" + ex.StackTrace*/, false);
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
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 317, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.lblError.Visible = true;
                this.lblError.Text = "";
                for (i = 0; i < aSelectedItems.Length; i++)
                {
                    try
                    {
                        if (aSelectedItems[i] != "0")
                            Libreria.Configuracion.IdentificadoresConductor.Eliminar(aSelectedItems[i]);
                        else
                            SetError("La lista 0 no se puede eliminar", false);
                    }
                    catch (Exception ex)
                    {
                        this.lblError.Text = this.lblError.Text + ex.Message + " <br>";
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
