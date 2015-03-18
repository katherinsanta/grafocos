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

namespace Servipunto.Estacion.Web.Modules.ReportesEstacion
{
    public partial class FiltroOtrosIngresos : System.Web.UI.Page
    {
        #region Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                if (Request.Form["__EVENTTARGET"].Length == 0)
                    this.EjecutarReporte();


            }
            else
            {
                this.InicializarForma();
                this.VerificarPermisos();
                this.Traducir();
            }

        }
        #endregion
        #region InicializarForma
        private void InicializarForma()
        {
            this.lblReporte.Text = "<b>Other New Incomes Report</b>";
            this.FechaInicio.SelectedDate = System.DateTime.Now;
            this.FechaFin.SelectedDate = System.DateTime.Now;
            

        }
        #endregion
        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Auditoria";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Otros Ingresos");

            if (!permiso)
            {
                this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.");
                this.pnlForm.Visible = false;
                return false;
            }

            return true;
        }
        #endregion
        #region Selecciona el de tipo reporte segun la la fecah de:
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FechaDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FechaDe.SelectedValue == "1")
            {
                TipoReporte.Enabled = true;
                TipoReporte.SelectedIndex = 0;

            }
            else {
                TipoReporte.SelectedIndex = 1;
                TipoReporte.Enabled = false;
                
            
            }

        }
        #endregion
        #region SetError
        private void SetError(string message)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
        }
        #endregion
        #region Validar
        private bool Validar()
        {
            if (this.FechaInicio.SelectedDate > this.FechaFin.SelectedDate)
            {
                this.SetError("La fecha inicial no puede ser superior a la final!");
                return false;
            }

            return true;
        }
        #endregion
        #region EjecutarReporte
        private void EjecutarReporte()
        {
            if (this.Validar())
            {
                try
                {
                    string fechaInicial;
                    string fechaFinal;
                    fechaInicial = FechaInicio.SelectedDate.ToShortDateString();
                    fechaFinal = FechaFin.SelectedDate.ToShortDateString();

                    Session["IdSuceso"] = Servipunto.Auditoria.Libreria.Sucesos.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion, 489, ((Libreria.Usuario)Session["Usuario"]).IdUsuario.ToString(), "U").ToString();
                   
                    DataDynamics.ActiveReports.ActiveReport report = null;
                  
                    report = new Servipunto.Estacion.Web.Modules.Rpt.OtrosIngresos(FechaDe.SelectedValue, 
                                                                                   TipoReporte.SelectedValue,
                                                                                   DateTime.Parse(fechaInicial),
                                                                                   DateTime.Parse(fechaFinal)                                                                                           
                                                                                   );
                    

                    Session["LastReport"] = report;
                    Session["Formato"] = rbFormato.SelectedValue;
                    Response.Redirect("../Visor/PDF.aspx", false);
                }
                catch (Exception ex)
                {
                    this.SetError(ex.Message);
                    #region registro del log de errores
                    try
                    {
                        Servipunto.Auditoria.Libreria.LogErrores.Adicionar(Servipunto.Estacion.Libreria.Aplicacion.Conexion,
                            2, Convert.ToInt64(Session["IdSuceso"].ToString()),
                            ex.Message + " !ERROR APP! " + ex.StackTrace, " Error interno generando el reporte de Auditoria de usuarios. ");
                    }
                    catch (Exception exx)
                    {
                        lblError.Text += " El sistema no pudo almacenar el log de un error ocurrido en el sistema. Error Anterior: " + ex.Message + " ErrorPresente: " + exx.Message;
                        this.SetError(lblError.Text);

                    }
                    #endregion

                }
            }
        }
        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 15/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23657, Global.Idioma);
            lblTipoReporte.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(32, Global.Idioma);
            TipoReporte.Items[1].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(33, Global.Idioma);
            TipoReporte.Items[0].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(34, Global.Idioma);
            FechaDe.Items[0].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(940, Global.Idioma);
            lblFormato.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(35, Global.Idioma) + ":";
            lblInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(249, Global.Idioma) + ":";
            lblFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(253, Global.Idioma) + ":";
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(38, Global.Idioma);
            LinkButton1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
        }
        #endregion
    }
}
