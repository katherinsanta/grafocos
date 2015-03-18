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



namespace Servipunto.Estacion.Web.Modules.Comerciales
{
	/// <summary>
	/// Summary description for Creditos.
	/// </summary>
	public class Creditos : System.Web.UI.Page
	{
        #region Sección de Declaraciones
        protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label Display;
        protected System.Web.UI.WebControls.Repeater Results;
        protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;
        protected string _id = null;
        protected System.Web.UI.WebControls.Panel pnlForm;
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
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 302, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    this.Visualizar();
                }
            }
            else
            {
                this.Eliminar();
            }
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
            const string modulo = "Comerciales";
            const string opcion = "Creditos";
            //Este fragmento de codigo se comentarea dado que no se tiene la opcion de creditos registrada en el BD
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
            if (nuevo)
            {
                //this.AgregarAccion(ref htmlAcciones, "Credito.aspx?Placa=" + Request.QueryString["Placa"], "Crear un nuevo crédito");
                this.AgregarAccion(ref htmlAcciones, "Credito.aspx?Creacion=1&Placa=" + Request.QueryString["Placa"], Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1441, Global.Idioma));
            }
            if (eliminar)
                this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(775, Global.Idioma));

            this.AgregarAccion(ref htmlAcciones, "Automotores.aspx?IdCliente=" + EncryptText(Session["IdCliente"].ToString()) + "&IdNombreCliente=" + EncryptText(Session["NombreCliente"].ToString()), Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));
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
                this._id = DecryptText(Convert.ToString(Request.QueryString["Placa"].Replace(" ", "+")));
                Display.Text = "<b>Placa del Vehiculo: " + this._id + "</b>";
                //Al datagrid Results se le envía los resultados de la búsqueda
                //Esta busqueda se define en la libreria
                //Results.DataSource = new Servipunto.Estacion.Libreria.Comercial.AutoCombustibles(Request.QueryString["Placa"]);
                Results.DataSource = new Servipunto.Estacion.Libreria.Comercial.Creditos(0, this._id, Request.QueryString["Numero"]);
                Results.DataBind();
            }
            catch (Exception ex)
            {
                SetError(ex.Message /*+ "<br><br>" + ex.StackTrace*/, false);

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

        #region Eliminar Creditos
        private void Eliminar()
        {
            if (Request.Form["chkID"] != null)
            {
                int i;
                string[] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 305, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.lblError.Visible = true;
                this.lblError.Text = "";
                for (i = 0; i <= aSelectedItems.Length - 1; i++)
                {
                    try
                    {
                        Libreria.Comercial.Creditos.Eliminar(0, aSelectedItems[i]);
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
