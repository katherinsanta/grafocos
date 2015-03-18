using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servipunto.Estacion.Web.Ajax.Modules.ReportesEstacion
{
    public partial class FiltroLogPlanilla : System.Web.UI.Page
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

            permiso = ((Libreria.Usuario)Session["Usuario"]).Permisos.Verificar(modulo, opcion, "ReporteLogPlanila");

            if (!permiso)
            {
                this.SetError("<b>Acceso Denegado.</b><br><br>Su cuenta de usuario no tiene privilegios suficientes para ingresar a esta página.");
                this.pnlForm.Visible = false;
                return false;
            }

            return true;
        }
        #endregion


        public void InicializarForma()
        {
            this.lblReporte.Text = "<b>Log Planilla Día </b>";
            txtFechaInicial.Text = DateTime.Today.ToString("dd-MM-yyyy");
         
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
                    fechaInicial = DateTime.Parse(txtFechaInicial.Text).ToString("yyyyMMdd");
                    fechaFinal = DateTime.Parse(txtFechaInicial.Text).ToString("yyyyMMdd");
                 
                    DataDynamics.ActiveReports.ActiveReport report = null;



                    SetError("ejecutando reporte: " + Convert.ToDateTime(txtFechaInicial.Text).ToString("dd-MM-yyyy"));

                    try
                    {
                        report = new Servipunto.Estacion.Web.Modules.Rpt.LogPlanillaTurnos(Convert.ToDateTime(txtFechaInicial.Text));
                    }
                    catch(Exception ex)
                    {
                        SetError("reporte error: " + ex.Message);
                        return;
                    }

                    if (report == null)
                    {
                        SetError("reporte en nulo: ");
                        return;
                    }

                    SetError("ejecuto reporte: " + Convert.ToDateTime(txtFechaInicial.Text).ToString("yyyyMMdd"));
               
                    Session["LastReport"] = report;
                    Session["Formato"] = "pdf";
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

            SetError("Ejecutando reporte");
            EjecutarReporte();
        }
        
    }
}