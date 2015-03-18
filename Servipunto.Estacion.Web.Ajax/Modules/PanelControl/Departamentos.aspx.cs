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
    /// <summary>
    /// Descripción breve de Departamentos.
    /// </summary>
    public class Departamentos : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Repeater Results;
        protected System.Web.UI.HtmlControls.HtmlForm MyForm;
        protected System.Web.UI.WebControls.Label lblError;
        protected System.Web.UI.WebControls.Label lblNombre;
        protected System.Web.UI.HtmlControls.HtmlGenericControl Acciones;
        protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenUpdate;
        protected System.Web.UI.WebControls.DropDownList cboPais;
        protected System.Web.UI.WebControls.LinkButton lnkNuevo;
        protected System.Web.UI.WebControls.LinkButton lnkEliminar;
        protected System.Web.UI.WebControls.Panel pnlForm;
        protected System.Web.UI.WebControls.Label Label1;
        Servipunto.Estacion.Libreria.Configuracion.Pais _objPais = null;
        protected string _idPais = null;

        #region PageLoad
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
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 164, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                    this.CargarPais();
                    lnkNuevo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1537, Global.Idioma);
                    lnkEliminar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1542, Global.Idioma);
                }
            }
        }
        #endregion

        #region Método VerificarPermisos
        private bool VerificarPermisos()
        {

            const string modulo = "Panel de Control";
            const string opcion = "Lugares";

            bool consultar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Consultar");
            bool nuevo = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Nuevo");
            bool eliminar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Eliminar");
            bool modificar = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Modificar");

            if (!consultar)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                this.lblError.Visible = true;
                this.Results.Visible = false;
                this.Acciones.Visible = false;
                return false;
            }

            string htmlAcciones = "";
            //if (nuevo)
            //    this.AgregarAccion(ref htmlAcciones, "Departamento.aspx?IdPais=" + this.cboPais.SelectedValue, Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1537, Global.Idioma));
            //if (eliminar)
            //    this.AgregarAccion(ref htmlAcciones, "javascript:document.forms[0].submit();", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1542, Global.Idioma));

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
            currentHtml += "<a href='" + hRef + "'>" + title + "</a>";
        }

        #endregion

        #region Cargar Paises
        private void CargarPais()
        {
            try
            {
                Servipunto.Estacion.Libreria.Configuracion.Paises objPaises = new Servipunto.Estacion.Libreria.Configuracion.Paises();
                cboPais.DataSource = objPaises;
                cboPais.DataValueField = "IdPais";
                cboPais.DataTextField = "Nombre";
                cboPais.DataBind();
                objPaises = null;
                Label1.Text = Libreria.Configuracion.PalabrasIdioma.Traduccion(725, Global.Idioma);
                
                if (this.cboPais.Items.Count == 0)
                    this.cboPais.Items.Add(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1867, Global.Idioma));
                else
                {
                    if (Request.QueryString["IdPais"] != null)
                        this.cboPais.SelectedValue = Request.QueryString["IdPais"];

                    this.CargarDepartamentos();
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

        #region Método CargarDepartamentos
        private void CargarDepartamentos()
        {
            Servipunto.Estacion.Libreria.Configuracion.Departamentos objDepartamentos = new Servipunto.Estacion.Libreria.Configuracion.Departamentos(Convert.ToInt32(this.cboPais.SelectedValue));

            this.Results.DataSource = objDepartamentos;
            this.Results.DataBind();
            objDepartamentos = null;
        }
        #endregion

        #region Método Eliminar
        private void Eliminar()
        {
            if (Request.Form["chkID"] != null)
            {
                int i;
                string[] aSelectedItems = Request.Form["chkID"].Split(",".ToCharArray());
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 167, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.lblError.Visible = true;
                this.lblError.Text = "";
                for (i = 0; i <= aSelectedItems.Length - 1; i++)
                {
                    try
                    {
                        Libreria.Configuracion.Departamentos.Remover(Convert.ToInt32(aSelectedItems[i]));
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
                this.CargarDepartamentos();
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

        #region Método para Obtener un Pais
        private bool ObtenerElemento()
        {
            try
            {
                this._objPais = Libreria.Configuracion.Paises.Obtener(Convert.ToInt32(this.cboPais.SelectedValue));
                if (this._objPais == null)
                {
                    this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1762, Global.Idioma) + " [" + this._objPais + "]", true);
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1756, Global.Idioma) + "! [" + this._objPais + "]", true);
                return false;
            }
        }
        #endregion

        #region Evento cboPais
        private void cboPais_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.CargarDepartamentos();
        }
        #endregion

        #region  Link Nuevo
        private void lnkNuevo_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Departamento.aspx?IdPais=" + this.cboPais.SelectedValue);
        }
        #endregion

        #region  Link Eliminar
        private void lnkEliminar_Click(object sender, System.EventArgs e)
        {
            this.Eliminar();
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
            this.cboPais.SelectedIndexChanged += new System.EventHandler(this.cboPais_SelectedIndexChanged);
            this.lnkNuevo.Click += new System.EventHandler(this.lnkNuevo_Click);
            this.lnkEliminar.Click += new System.EventHandler(this.lnkEliminar_Click);
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
            return Servipunto.Libreria.Cryptography.DecryptQueryString(strText, "!#$a892q");
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
            return Servipunto.Libreria.Cryptography.EncryptQueryString(strText, "!#$a892q");
        }
        #endregion
    }
}
