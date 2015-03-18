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

namespace Servipunto.Estacion.Web.Modules.Procesos
{
    public partial class FiltroTrasladosSAP : System.Web.UI.Page
    {
        #region load
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
            // Introducir aqu� el c�digo de usuario para inicializar la p�gina
            if (this.IsPostBack)
            {
                CalendarExtender1.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (Request.Form["__EVENTTARGET"].Length == 0)
                {
                    this.lblError.Visible = false;
                }
            }
            else
            {
                this.VerificarPermisos();
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 263, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.InicializarForma();
            }
        }
        #endregion


        #region InicializarForma
        private void InicializarForma()
        {
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2157, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblGenerarArchivo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(893, Global.Idioma);
            
            #endregion
            //this.lblReporte.Text = "<b>Generar Archivo Plano de Facturas</b>";
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
        }
        #endregion

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Interfaz Contable";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Generacion Archivo Plano de Facturas");

            if (!permiso)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);                                
                return false;
            }

            return true;
        }
        #endregion

        #region Generar Plano
        private void lblGenerarArchivo_Click(object sender, System.EventArgs e)
        {
            #region Declaraciones
            string _separador = txtSeparador.Text;
            string _fecha = Convert.ToDateTime(txtFechaInicial.Text).ToString("yyyy/MM/dd");
            string _a�o = Convert.ToDateTime(txtFechaInicial.Text).Year.ToString();
            string resultado;
            string[] archivo;
            #endregion
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 264, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                if (_a�o == "1")
                {
                    this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(1871, Global.Idioma),false);
                    return;
                }
                resultado = Servipunto.Estacion.Libreria.Planos.InterfazContables.PlanoTrasladosSap("", Server.MapPath("../."), Convert.ToDateTime(txtFechaInicial.Text), _separador);
                archivo = resultado.Split(",".ToCharArray());

                if (archivo[0].ToString() != "OK")
                {
                    this.SetError(resultado,false);
                    return;
                }

                Response.Clear();
                Response.ContentType = "text/plain";
                Response.AppendHeader("Content-Disposition", "attachment; filename =" + archivo[1].Substring(archivo[1].LastIndexOf("\\") + Global.Idioma));
                Response.WriteFile(archivo[1]);
                Response.End();

            }
            catch (Exception ex)
            {
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma) + ex.Message, false);
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

        #region LimpiarDirectorio
        /// <summary>
        /// Borra los archivos de planos existentes en el directorio de la aplicaci�n
        /// </summary>
        private void LimpiarDirectorio()
        {
            try
            {
                string[] arreglo = System.IO.Directory.GetFiles(Server.MapPath("../."));
                foreach (string c in arreglo)
                    System.IO.File.Delete(c);
            }
            catch (Exception)
            {

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

        #region C�digo generado por el Dise�ador de Web Forms
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: llamada requerida por el Dise�ador de Web Forms ASP.NET.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// M�todo necesario para admitir el Dise�ador. No se puede modificar
        /// el contenido del m�todo con el editor de c�digo.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGenerarArchivo.Click += new System.EventHandler(this.lblGenerarArchivo_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

    }
}
