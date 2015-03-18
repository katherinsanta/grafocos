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

namespace Servipunto.Estacion.Web.Modules.Prepagos
{
    public partial class Creaciones : System.Web.UI.Page
    {        
        #region Sección de Declaraciones

        private Libreria.Configuracion.Surtidor _objSurtidor = null;
        protected string _idSurtidor = null;

        #endregion

        #region Page Load Event
        private void Page_Load(object sender, System.EventArgs e)
        {           
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
                this.Eliminar();
            }
        }
        #endregion

        #region ObtenerObjetoSurtidor
        private bool ObtenerObjetoSurtidor()
        {
            return false;
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            try
            {

                const string modulo = "Prepagos";
                const string opcion = "Nuevo";
                bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "consultar");
                bool nuevo = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Crear");
                bool eliminar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "eliminar");
                bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

                //Revisión de permiso de consulta
                if (!consultar)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                    return false;
                }

                //Configuración de Acciones
                string htmlAcciones = "";
                if (nuevo)
                    this.AgregarAccion(ref htmlAcciones, "Creacion.aspx", Libreria.Configuracion.PalabrasIdioma.Traduccion(23592, Global.Idioma));
                if (eliminar)
                    this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Libreria.Configuracion.PalabrasIdioma.Traduccion(23593, Global.Idioma));

                this.AgregarAccion(ref htmlAcciones, "default.aspx", Libreria.Configuracion.PalabrasIdioma.Traduccion(1474, Global.Idioma));
                this.Acciones.InnerHtml = htmlAcciones + "<br><br>";

                //Configuración del permiso de modificación
                if (modificar)
                    this.HiddenUpdate.Value = "Allow";
                else
                    this.HiddenUpdate.Value = "Deny";

                return true;
            }
            catch (Exception ex)
            {

                lblError.Visible = true;
                lblError.Text = "No posee permisos o su sesion esta activa en otro computador";
                return true;
            }
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
//                Servipunto.Estacion.Libreria.Pagos p = new Servipunto.Estacion.Libreria.Pagos();
                Servipunto.Estacion.Libreria.Prepagos.CreacionPrepagos obj = new Servipunto.Estacion.Libreria.Prepagos.CreacionPrepagos();
                //Servipunto.Estacion.Libreria.Prepagos.CreacionPrepagos obj = null;// new Servipunto.Estacion.Libreria.Prepagos.CreacionPrepagos();
                Results.DataSource = obj;
                Results.DataBind();
                obj = null;
                
            }
            
            catch (Exception ex) 
            {
                this.SetError(lblError.Text += " Error cargando el formulario de listado de prepagos " + ex.Message, false);

                #region registro del log de errores
                try
                {
                    Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                        2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                        ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno cargando el formulario de listado de caras.");
                }
                catch (Exception exx)
                {
                    lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                    this.SetError(lblError.Text, false);
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
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 97, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();

                this.lblError.Visible = true;
                this.lblError.Text = "";
                for (i = 0; i <= aSelectedItems.Length - 1; i++)
                {
                    try
                    {
                        Libreria.Prepagos.CreacionPrepagos.Eliminar(Convert.ToInt32(aSelectedItems[i]));
                    }
                    catch (Exception ex)
                    {
                        this.lblError.Text = this.lblError.Text + ex.Message + " <br>";
                        #region registro del log de errores
                        try
                        {
                            Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                                2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                                ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno eliminando datos de las caras. ");
                        }
                        catch (Exception exx)
                        {
                            lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                            this.SetError(lblError.Text, false);
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
           // if (hideForm)
                //this.MyForm.Visible = false;
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
