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
    public partial class FiltroPlanoFacturas : System.Web.UI.Page
    {

        #region Form Load Event
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
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 207, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.InicializarForma();
            }
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
        #region EjecutarSP
        private void EjecutarSP()
        {
            string resultado;
            string[] archivo;
            this.lblError.Visible = false;
            try
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 208, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();
                resultado = objInterfazContables.PlanoFacturasEstandar(
                    "c:\\TemporalPlanos",
                    Convert.ToDateTime(txtFechaInicial.Text),
                    int.Parse(txtIsla.Text.Trim()),
                    int.Parse(txtTurno.Text.Trim())
                    );


                archivo = resultado.Split(",".ToCharArray());
                if (archivo[0].ToString() != "OK")
                {
                    this.SetError(resultado,false);
                    return;
                }

                Response.Clear();
                Response.ContentType = "text/plain";
                Response.AppendHeader("Content-Disposition", "attachment; filename =" + archivo[1].Substring(archivo[1].LastIndexOf("\\") + 1));
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

        #region InicializarForma
        private void InicializarForma()
        {
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(922, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1724, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(926, Global.Idioma);
            lblGuardar.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(927, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            #endregion
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
        }
        #endregion

        #region Método GuardarPlanoTotales
        private void GuardarPlanoTotales()
        {
            //se hace el mismo procedimiento para la generación del plano
            string resultado;
            string[] archivo;

            this.lblError.Visible = false;
            try
            {
                Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 208, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                resultado = objInterfazContables.PlanoTotalesEstandar("TotalesCuenta-" + Convert.ToDateTime(txtFechaInicial.Text).ToString("dd-MM-yyyy") + ".txt",
                    "c:\\TemporalPlanos",
                    Convert.ToDateTime(txtFechaInicial.Text),
                    int.Parse(txtIsla.Text.Trim()),
                    int.Parse(txtTurno.Text.Trim()),
                    "|"
                    );


                archivo = resultado.Split(",".ToCharArray());
                if (archivo[0].ToString() != "OK")
                {
                    this.SetError(resultado,false);
                    return;
                }

                Response.Clear();
                Response.ContentType = "text/plain";
                Response.AppendHeader("Content-Disposition", "attachment; filename =" + archivo[1].Substring(archivo[1].LastIndexOf("\\") + 1));
                Response.WriteFile(archivo[1]);
                Response.End();
            }
            catch (Exception ex)
            {
                SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2133, Global.Idioma) + ex.Message, false);
            }

        }
        #endregion

        #region LimpiarDirectorio
        /// <summary>
        /// Borra los archivos de planos existentes en el directorio de la aplicación
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
            this.lblGuardarFacturas.Click += new System.EventHandler(this.lblGuardarFacturas_Click);
            this.lblGuardar.Click += new System.EventHandler(this.lblGuardar_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }

        private void lblGuardarFacturas_Click(object sender, System.EventArgs e)
        {
            this.EjecutarSP();
        }

        private void lblGuardar_Click(object sender, System.EventArgs e)
        {
            this.GuardarPlanoTotales();
        }
        #endregion
    }
}
