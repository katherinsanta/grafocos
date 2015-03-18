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
    public partial class Zetas : System.Web.UI.Page
    {

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
            Traducir();
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
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 30/06/2010
        /// Modificador : Rodrigo Cerquera
        /// </summary>
        private void Traducir()
        {
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            lblTituloGenerales.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(281, Global.Idioma);
            btnBuscar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(763, Global.Idioma);
            
            //Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1012, Global.Idioma);
        }
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
            try
            {
                lblError.Visible = false;
                if (!this.Page.IsPostBack)
                {
                    if (this.VerificarPermisos())
                    {
                      //  CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                      //  CalendarExtender2.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 576, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        txtFechaInicial.Text = DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy").Replace("-", "/");
                        txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy").Replace("-", "/");
                        this.Visualizar();                        
                    }
                }
            }
            catch (Exception ex)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message, false);
                
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
            const string opcion = "Zeta";
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
            if (modificar)
                this.AgregarAccion(ref htmlAcciones, "TanqueZeta.aspx?Fecha=", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1011, Global.Idioma));
            this.AgregarAccion(ref htmlAcciones, "default.aspx", Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma));
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
        /// <summary>
        /// Lista los periodos zeta configurados en el sistema entre un rango de fechas determinado
        /// </summary>
        /// Referencia Documental:  Automatizacion > Automatizacion_Administrativo_Variaciones_GA_CUS_CPR 
        /// Fecha:  03/09/2008
        /// Autor:  Elvis Astaiza Gutierrez
        private void Visualizar()
        {
            try
            {
                Results.DataSource = Servipunto.Estacion.Libreria.Turnos.JornadasZeta.ObtenerItemsRangoFecha(2, DateTime.Parse(txtFechaInicial.Text.Trim()), DateTime.Parse(txtFechaFinal.Text.Trim()));
                Results.DataBind();
            }
            catch (Exception ex)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1761, Global.Idioma) + ex.Message, false);
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

        #region btnBuscar_Click
        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            try
            {
                DateTime.Parse(txtFechaInicial.Text);
                DateTime.Parse(txtFechaFinal.Text);
                Visualizar();
            }
            catch (Exception)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2123, Global.Idioma), false);
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
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
    }
}
