using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for ResumenDiarioDetallado.
    /// </summary>
    public partial class ResumenDiarioDetallado : DataDynamics.ActiveReports.ActiveReport
    {
        DateTime _fechaInicial;
        DateTime _fechaFinal;
        int _Language=0;
        public ResumenDiarioDetallado(DateTime fechaInicial, DateTime fechaFinal, int Idioma)
        {
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            _Language = Idioma;
            InitializeComponent();
            if (Idioma == 1)
                TraducirReporte();
        }

        #region 
        private void pageHeader_Format(object sender, EventArgs e)
        {
            this.lblFecha.Text = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = "Time: " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = "Issue Date: " +
                this._fechaInicial.ToString("dd/MM/yyyy") + " and " + this._fechaFinal.ToString("dd/MM/yyyy");
                

            this.srptEncabezado.Report = new SubEncabezado();
            this.srptEncabezado.Report.DataSource = new DataDynamics.ActiveReports.DataSources.SqlDBDataSource();
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).ConnectionString = Servipunto.Estacion.Libreria.Aplicacion.Conexion.ConnectionString;
            ((DataDynamics.ActiveReports.DataSources.SqlDBDataSource)this.srptEncabezado.Report.DataSource).SQL = QueryEncabezado();
        }
        #endregion
        #region pageFooter_Format
        private void pageFooter_Format(object sender, EventArgs e)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }
        #endregion
        #region ConsultaEncabezado
        private string QueryEncabezado()
        {
            System.Text.StringBuilder sql = new System.Text.StringBuilder();

            sql.Append("Select");
            sql.Append(" Razon_Social,");
            sql.Append(" Nit,");
            sql.Append(" Nit_Dive");
            sql.Append(" From Dat_Gene");
            return sql.ToString();
        }
        #endregion

        private void GHVentasCombustible_Format(object sender, EventArgs e)
        {
            if (Label.Text == "Detailed Daily Transaction Summary")
                SRptVentasCombustible.Report = new SubRptResumenDiarioTVentasCombustible(_fechaInicial, _fechaFinal, 1);
            else
                SRptVentasCombustible.Report = new SubRptResumenDiarioTVentasCombustible(_fechaInicial, _fechaFinal, 0);
        }

        private void reportFooter1_Format(object sender, EventArgs e)
        {
            this.lblAno.Text = System.DateTime.Now.Year.ToString();
        }

        private void GHRVentasCanastilla_Format(object sender, EventArgs e)
        {
            if (Label.Text == "Detailed Daily Transaction Summary")
                SRptVentasCanastilla.Report = new SubRptResumenDiarioDTVentasCanastilla(_fechaInicial, _fechaFinal, 1);
            else
                SRptVentasCanastilla.Report = new SubRptResumenDiarioDTVentasCanastilla(_fechaInicial, _fechaFinal, 0);
        }

        private void GHRFormaPago_Format(object sender, EventArgs e)
        {
            if (Label.Text == "Detailed Daily Transaction Summary")
                SRptFormaPago.Report = new SubRptResumenDDiarioFormasPago(_fechaInicial, _fechaFinal, 1);
            else
                SRptFormaPago.Report = new SubRptResumenDDiarioFormasPago(_fechaInicial, _fechaFinal, 0);
        }

        private void GHRClientesCredito_Format(object sender, EventArgs e)
        {


        }

        private void GHRConsignacion_Format(object sender, EventArgs e)
        {
            if (Label.Text == "Detailed Daily Transaction Summary")
                SRptConsignacion.Report = new SubRptResumenDiarioDConsignaciones(_fechaInicial, _fechaFinal, 1);
            else
                SRptConsignacion.Report = new SubRptResumenDiarioDConsignaciones(_fechaInicial, _fechaFinal, 0);
        }

        private void GHRDescuadre_Format(object sender, EventArgs e)
        {
            if (Label.Text == "Detailed Daily Transaction Summary")
                SRptDescuadre.Report = new SubRptResumenDiarioDDescuadres(_fechaInicial, _fechaFinal, 1);
            else
                SRptDescuadre.Report = new SubRptResumenDiarioDDescuadres(_fechaInicial, _fechaFinal, 0);
        }

        private void GHROtrosIngresos_Format(object sender, EventArgs e)
        {
            if (Label.Text == "Detailed Daily Transaction Summary")
                SRptOtrosIngresos.Report = new SubRptResumenDiarioOtrosIngresos(_fechaInicial, _fechaFinal, 1);
            else
                SRptOtrosIngresos.Report = new SubRptResumenDiarioOtrosIngresos(_fechaInicial, _fechaFinal, 0);
        }

        private void GHRInventario_Format(object sender, EventArgs e)
        {
            if (Label.Text == "Detailed Daily Transaction Summary")
                subRptInventario.Report = new SubRptResumenDDiarioTanques(_fechaInicial, _fechaFinal, 1);
            else
                subRptInventario.Report = new SubRptResumenDDiarioTanques(_fechaInicial, _fechaFinal, 0);
        }

        private void GHRLecturas_Format(object sender, EventArgs e)
        {
            if (Label.Text == "Detailed Daily Transaction Summary")
                subRptLecturas.Report = new SubRptDLecturas(_fechaInicial, _fechaFinal, 1);
            else
                subRptLecturas.Report = new SubRptDLecturas(_fechaInicial, _fechaFinal, 0);
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 15/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void TraducirReporte()
        {
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23705, Global.Idioma);
            
            //PIE DE PAGINA
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
        }
        #endregion
    }

}
