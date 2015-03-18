using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Web.SessionState;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for ResumenDiarioTransacciones.
    /// </summary>
    public partial class ResumenDiarioTransacciones : DataDynamics.ActiveReports.ActiveReport3
    {
        #region Definicion de variables de la clase
        DateTime _fechaInicial;
        DateTime _fechaFinal;
        string _usuario;
        int _Language;
        #endregion
        #region Constructor de la Clase
        public ResumenDiarioTransacciones(DateTime fechaInicial, DateTime fechaFinal, string usuario, int Idioma)
        {
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            _usuario = usuario;
            _Language = Idioma;
            InitializeComponent();
            if (Idioma == 1)
                TraducirReporte();
        }
        #endregion
        #region pageHeader_Format
        private void pageHeader_Format(object sender, EventArgs e)
        {
            this.lblFecha.Text = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
            this.lblHora.Text = "Time: " + DateTime.Now.ToString("hh:mm tt");
            this.lblTituloFechas.Text = "Issue Date: " +
                this._fechaInicial.ToString("dd/MM/yyyy") + " And " + this._fechaFinal.ToString("dd/MM/yyyy");
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
        #region GHVentasCombustible_Format
        private void GHVentasCombustible_Format(object sender, EventArgs e)
        {
            if(_Language==1)
                this.SRptVentasCombustible.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumenDiarioTVentasCombustible(_fechaInicial, _fechaFinal, 1);
            else
                this.SRptVentasCombustible.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumenDiarioTVentasCombustible(_fechaInicial, _fechaFinal, 0);
        }
        #endregion
        #region GHFormaPago_Format
        private void GHFormaPago_Format(object sender, EventArgs e)
        {
            if(_Language==1)
                this.SRptFormaPago.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumenDiarioFormasPago(_fechaInicial, _fechaFinal, 1);
            else
                this.SRptFormaPago.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumenDiarioFormasPago(_fechaInicial, _fechaFinal, 0);
        }
        #endregion
        #region GHClienteCredito_Format
        private void GHClienteCredito_Format(object sender, EventArgs e)
        {
            if(_Language==1)
                this.SRptClientesCredito.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumindoDiarioClientesCredito(_fechaInicial, _fechaFinal, 1);
            else
                this.SRptClientesCredito.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumindoDiarioClientesCredito(_fechaInicial, _fechaFinal, 0);
        }
        #endregion
        #region GHConsignacion_Format
        private void GHConsignacion_Format(object sender, EventArgs e)
        {
            //this.SRptConsignacion.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumenDiarioConsignaciones(_fechaInicial, _fechaFinal);
        }
        #endregion
        #region GHDescuadre_Format
        private void GHDescuadre_Format(object sender, EventArgs e)
        {
            if(_Language==1)
                this.SRptDescuadre.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumenDiarioDescuadres(_fechaInicial, _fechaFinal, 1);
            else
                this.SRptDescuadre.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumenDiarioDescuadres(_fechaInicial, _fechaFinal, 0);
        }
        #endregion
        #region GHOtrosIngresos_Format
        private void GHOtrosIngresos_Format(object sender, EventArgs e)
        {
            //this.SRptOtrosIngresos.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumenDiarioOtrosIngresos(_fechaInicial, _fechaFinal);
        }
        #endregion
        #region GHRVentasCanastilla_Format
        private void GHRVentasCanastilla_Format(object sender, EventArgs e)
        {
            if(_Language==1)
                this.SRptVentasCanastilla.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumenDiarioTVentasCanastilla(_fechaInicial, _fechaFinal, 1);
            else
                this.SRptVentasCanastilla.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubRptResumenDiarioTVentasCanastilla(_fechaInicial, _fechaFinal, 0);

        }
        #endregion
        private void GHNumeroCarrosAtendidos_Format(object sender, EventArgs e)
        {
            // this.SRPTNumeroCarrosAtendidos.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubReporteNumeroCarrosAtendidos(_fechaInicial, _fechaFinal);
        }
        private void GRHCombYCanastilla_Format(object sender, EventArgs e)
        {
            if(_Language==1)
                this.SRPTCombyCanastilla.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubReporteCombYCanastilla(_fechaInicial, _fechaFinal, 1);
            else
                this.SRPTCombyCanastilla.Report = new Servipunto.Estacion.Web.Modules.Rpt.SubReporteCombYCanastilla(_fechaInicial, _fechaFinal, 0);
        }
        private void GHRInventario_Format(object sender, EventArgs e)
        {
            if(_Language==1)
                subRptInventario.Report = new SubRptResumenDiarioTanques(_fechaInicial, _fechaFinal, 1);
            else
                subRptInventario.Report = new SubRptResumenDiarioTanques(_fechaInicial, _fechaFinal, 0);
        }
        private void GHRLecturas_Format(object sender, EventArgs e)
        {
            if(_Language==1)
                subRptLecturas.Report = new SubRptLecturas(_fechaInicial, _fechaFinal, 1);
            else
                subRptLecturas.Report = new SubRptLecturas(_fechaInicial, _fechaFinal, 0);
        }

        private void GHRCalibraciones_Format(object sender, EventArgs e)
        {
            //SubRptCalibraciones.Report = new SubRptCalibraciones1(_fechaInicial, _fechaFinal);
        }

        private void GHRTotalOtrosIngresos_Format(object sender, EventArgs e)
        {
            //SRptOtrosIngresos.Report = new SubRptRDTotalIngresos(_fechaInicial, _fechaFinal);
        }

        private void GHRCalibraciones_Format_1(object sender, EventArgs e)
        {
            if(_Language==1)
                subRptCalibraciones.Report = new SubRptResumenDiarioCalibraciones(_fechaInicial, _fechaFinal, 1);
            else
                subRptCalibraciones.Report = new SubRptResumenDiarioCalibraciones(_fechaInicial, _fechaFinal, 0);
        }

        private void GHROtrosIngresos_Format(object sender, EventArgs e)
        {
            if(_Language==1)
                SubRptOtrosIngresos.Report = new SubRptOtrosIngresos(_fechaInicial, _fechaFinal, 1);
            else
                SubRptOtrosIngresos.Report = new SubRptOtrosIngresos(_fechaInicial, _fechaFinal, 0);

        }

        private void GHRTotalCalibracion_Format(object sender, EventArgs e)
        {
            //sybRptTotalCalibracion.Report = new SubRptCalibraciones1(_fechaInicial, _fechaFinal);
        }

        private void GHRFirmas_Format(object sender, EventArgs e)
        {

            lblUsuario.Text = _usuario;
           
            
        }

        private void GHRDescuadrecito_Format(object sender, EventArgs e)
        {
            if(_Language==1)
                subRptDescuadrecito.Report = new SubResumenDiarioDescuadrecito(_fechaInicial, _fechaFinal, 1);
            else
                subRptDescuadrecito.Report = new SubResumenDiarioDescuadrecito(_fechaInicial, _fechaFinal, 0);
        }

        #region Traduccion
        /// <summary>
        /// Metodo para aplicar traduccion a todo los objetos del formulario
        /// Modificacion : 14/02/2011
        /// Modificador : Miguel Cantor L.
        /// </summary>
        private void TraducirReporte()
        {
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23671, Global.Idioma);
            lblU.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(750, Global.Idioma);
            label4.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23672, Global.Idioma);
            label5.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(23673, Global.Idioma);
            //PIE DE PAGINA
            Label2.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2188, Global.Idioma);
            Label1.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2187, Global.Idioma);
            lblPagina.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2189, Global.Idioma);
            lblDe.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2190, Global.Idioma);
        }
        #endregion
    }
}
