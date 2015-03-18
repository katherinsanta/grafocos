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
    public partial class FiltroCalibración : System.Web.UI.Page
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


        protected void TipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if(TipoReporte.SelectedValue == "")
        }

        #region VerificarPermisos
        private bool VerificarPermisos()
        {
            const string modulo = "Reportes";
            const string opcion = "Auditoria";
            bool permiso;

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "Calibracion");

            if (!permiso)
            {
                this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.");
                this.pnlForm.Visible = false;
                return false;
            }

            return true;
        }
        #endregion


        public void InicializarForma() {
            this.lblReporte.Text = "<b>Calibration Report</b>";
            this.FechaInicio.SelectedDate = System.DateTime.Now;
            this.FechaFin.SelectedDate = System.DateTime.Now;
            this.TxtTurno.Text = "0";
         

        this.cboArticulo.DataSource = Servipunto.Estacion.Libreria.Articulos.RecuperarArticulos();        
        this.cboArticulo.DataBind();
        this.cboArticulo.Items.Insert(0, new ListItem("(ALL)", "0"));
        this.cboArticulo.SelectedValue = "0";
        }



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
                    if (TxtTurno.Text == "")
                        TxtTurno.Text = "0";

                     DataDynamics.ActiveReports.ActiveReport report = null;
                      

                         report = new Servipunto.Estacion.Web.Modules.Rpt.Calibracion(TipoReporte.SelectedValue ,TxtTurno.Text,cboArticulo.SelectedValue, Convert.ToDateTime ( fechaInicial), Convert.ToDateTime ( fechaFinal) );
                     
                            
                            Session["LastReport"] = report;
                    Session["Formato"] = rbFormato.SelectedValue;
                    Response.Redirect("../Visor/PDF.aspx", false);
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
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
        #region SetError
        private void SetError(string message)
        {
            this.lblError.Visible = true;
            this.lblError.Text = message;
        }
        #endregion

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            EjecutarReporte();
        }
        
        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 14/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void Traducir()
        {
            lblArticulo.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23657, Global.Idioma);
            TipoReporte.Items[0].Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(940, Global.Idioma);
            lblturno.Text = TipoReporte.Items[0].Text + ":";
            lblFormato.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(35, Global.Idioma) + ":";
            lblInicial.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(249, Global.Idioma) + ":";
            lblFinal.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(253, Global.Idioma) + ":";
            lblItem.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(1714, Global.Idioma) + ":";
            Label7.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(38, Global.Idioma);
            LinkButton1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(37, Global.Idioma);
        }
        #endregion
    }
}
