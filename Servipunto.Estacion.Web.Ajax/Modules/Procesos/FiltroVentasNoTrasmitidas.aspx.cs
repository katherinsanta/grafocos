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
    public partial class FiltroVentasNoTrasmitidas : System.Web.UI.Page
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
                CalendarExtender2.Format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                if (Request.Form["__EVENTTARGET"].Length == 0)
                {
                    this.lblError.Visible = false;
                }
            }
            else
            {
                Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 260, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
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

        #region Generar Plano ventas no transmitidas hacia un tercero
        private void lblGenerarArchivo_Click(object sender, System.EventArgs e)
        {
            #region Declaraciones
            string resultado;
            string[] archivo;
            #endregion

            #region generar archivo
            txtUltimoConsecutivo.Text = "";
            if (rbnTransmitir.SelectedValue != "1" && rbnTransmitir.SelectedValue != "0")
            {
                this.SetError(Libreria.Configuracion.PalabrasIdioma.Traduccion(2149, Global.Idioma),false);
                return;
            }
            try
            {
                if (rbnTransmitir.SelectedValue == "1")
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 517, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                else
                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 518, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();

                resultado = Servipunto.Estacion.Libreria.Planos.InterfazContables.PlanoVentasNoTransmitidas(
                    Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text),
                    txtSeparador.Text
                    );
                archivo = resultado.Split(",".ToCharArray());

                if (rbnTransmitir.SelectedValue == "1")
                {
                    Servipunto.Estacion.Libreria.Ventas.PlanoVentasNoTransmitidas(Convert.ToDateTime(txtFechaInicial.Text), Convert.ToDateTime(txtFechaFin.Text),
                        int.Parse(archivo[2].ToString().Trim())
                        );
                }

                if (archivo[0].ToString() != "OK")
                {
                    this.SetError(resultado,false);
                    return;
                }

                rbnTransmitir.ClearSelection();
                Response.Clear();
                txtUltimoConsecutivo.Text = archivo[2].ToString().Trim();
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
            this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(882, Global.Idioma) + "</b>";
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(31, Global.Idioma);
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(36, Global.Idioma);
            Label3.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(909, Global.Idioma);
            Label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(910, Global.Idioma);
            Label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            lblGenerarArchivo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(893, Global.Idioma);
            #region poblar RadioButton  rbnTransmitir
            this.rbnTransmitir.Items.Clear();
            this.rbnTransmitir.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1730, Global.Idioma), "1"));
            this.rbnTransmitir.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1807, Global.Idioma), "0"));
            this.rbnTransmitir.SelectedValue = "0";
            #endregion
            #endregion
            //this.lblReporte.Text = "<b>Generar Archivo Plano de Facturas</b>";
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
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

        private void FechaInicio_SelectionChanged(object sender, System.EventArgs e)
        {
            rbnTransmitir.ClearSelection();
        }

        private void FechaFin_SelectionChanged(object sender, System.EventArgs e)
        {
            rbnTransmitir.ClearSelection();
        }


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
            this.FechaInicio.SelectionChanged += new System.EventHandler(this.FechaInicio_SelectionChanged);
            this.FechaFin.SelectionChanged += new System.EventHandler(this.FechaFin_SelectionChanged);
            this.lblGenerarArchivo.Click += new System.EventHandler(this.lblGenerarArchivo_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

    }
}
