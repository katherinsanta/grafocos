using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace  Servipunto.Estacion.Web.Modules.Procesos
{
    public partial class FiltroPlanoMelisa : System.Web.UI.Page
    {
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
                //Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion ,207, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                this.InicializarForma();
            }
        }

        #region InicializarForma
        private void InicializarForma()
        {
            //#region traduccion
            //this.lblReporte.Text = "<b>" + Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(498, Global.Idioma) + "</b>";
            //Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(231, Global.Idioma);
            //Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1000, Global.Idioma);
            //lblGuardarFacturas.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(893, Global.Idioma);
            //#region poblar RadioButton  rbtTipo
            //this.rbtTipo.Items.Clear();
            //this.rbtTipo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(34, Global.Idioma), Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(34, Global.Idioma)));
            //this.rbtTipo.Items.Insert(0, new ListItem(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(33, Global.Idioma), Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(33, Global.Idioma)));
            //this.rbtTipo.SelectedValue = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(34, Global.Idioma);
            //#endregion
            //#endregion
            txtFechaInicial.Text = DateTime.Now.ToShortDateString();
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


        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Procesos";
            const string opcion = "Interfaz Contable";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "PlanoInsepec");

            if (!permiso)
            {
                this.SetError(Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1754, Global.Idioma), true);
                return false;
            }

            return true;
        }
        #endregion

        #region EjecutarExportar
        /// <summary>
        /// Ejecuta el reporte para que se genere los archivos planos de lecturas o ventas		
        /// Fecha: 11/02/2009
        /// Autor: Rodrigo Figueroa Rivera
        /// </summary>
        /// Referencia Documental: Automatizacion > Automatizacion de Islas_DT_SC_16
        private void EjecutarExportar()
        {
            string resultado;
            string[] archivo;
            this.lblError.Visible = false;
            try
            {

                Servipunto.Estacion.Libreria.Planos.InterfazContables objInterfazContables = new Servipunto.Estacion.Libreria.Planos.InterfazContables();

                if (rbtTipo.SelectedValue == "Contado")
                {
                    resultado = objInterfazContables.PlanosMelissa(
                        "C:\\Servipunto\\Planos\\TemporalPlanos",
                        Convert.ToDateTime(txtFechaInicial.Text),
                         1);
                }
                else
                {
                    resultado = objInterfazContables.PlanosMelissa(
                        "C:\\Servipunto\\Planos\\TemporalPlanos",
                        Convert.ToDateTime(txtFechaInicial.Text),
                         2);

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
            this.lblGuardarFacturas.Click += new System.EventHandler(this.lblGuardarFacturas_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void lblGuardarFacturas_Click(object sender, System.EventArgs e)
        {
            this.EjecutarExportar();
        }

        protected void lblGuardarFacturas_Click1(object sender, EventArgs e)
        {

        }
    }
}