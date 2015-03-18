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
    public partial class FiltroArchivosMaster : System.Web.UI.Page
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
            // Introducir aquí el código de usuario para inicializar la página
            this.lblError.Visible = false;
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
                //Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,260, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.VerificarPermisos();
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

        #region Generar Plano ventas Credito y Contado
        private void lblGenerarArchivo_Click(object sender, System.EventArgs e)
        {
            #region Declaraciones
            string resultado = "";
            string[] archivo;
            int caso;
            #endregion

            #region generar archivo
            try
            {
                caso = int.Parse(rblTipoReporte.SelectedValue);
                //Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,261, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                switch (caso)
                {
                    case 1:
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 512, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        resultado = Servipunto.Estacion.Libreria.Planos.InterfazContables.PlanoMasterReporte(
                            Convert.ToDateTime(txtFechaInicial.Text),
                            int.Parse(txtTurno.Text.Trim()),
                            txtSeparador.Text
                            );
                        break;
                    case 2:
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 513, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        resultado = Servipunto.Estacion.Libreria.Planos.InterfazContables.PlanoMasterMapa(
                            txtSeparador.Text
                            );
                        break;
                    case 3:
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 514, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        resultado = Servipunto.Estacion.Libreria.Planos.InterfazContables.PlanoMasterTotalesElectronicos(
                            Convert.ToDateTime(txtFechaInicial.Text),
                            int.Parse(txtTurno.Text.Trim()),
                            txtSeparador.Text
                            );
                        break;

                    case 4:
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 515, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        resultado = Servipunto.Estacion.Libreria.Planos.InterfazContables.PlanoMasterPrecios(
                            txtSeparador.Text
                            );
                        break;

                    case 5:
                        Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 516, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                        resultado = Servipunto.Estacion.Libreria.Planos.InterfazContables.PlanoMasterCuentas(
                            txtSeparador.Text
                            );
                        break;


                }

                archivo = resultado.Split(",".ToCharArray());

                if (archivo[0].ToString() != "OK")
                {
                    this.SetError(resultado, false);
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
            #endregion

        }
        #endregion

        #region InicializarForma
        private void InicializarForma()
        {
            #region traduccion
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(886, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(933, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(909, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(42, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblGenerarArchivo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(893, Global.Idioma);
            #region poblar RadioButton  rblTipoReporte
            this.rblTipoReporte.Items.Clear();
            this.rblTipoReporte.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(934, Global.Idioma), "1"));
            this.rblTipoReporte.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(935, Global.Idioma), "2"));
            this.rblTipoReporte.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1210, Global.Idioma), "3"));
            this.rblTipoReporte.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(937, Global.Idioma), "4"));
            this.rblTipoReporte.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(938, Global.Idioma), "5"));            
            this.rblTipoReporte.SelectedValue = "1";
            #endregion
            #endregion
            //this.lblReporte.Text = "<b>Generar Archivo Plano de Facturas</b>";
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
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
            this.lblGenerarArchivo.Click += new System.EventHandler(this.lblGenerarArchivo_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

    }
}
