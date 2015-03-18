using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubGraficaVentasPorManguera.
    /// </summary>
    public partial class SubGraficaVentasPorManguera : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Constructor de la clase
        public SubGraficaVentasPorManguera()
        {
            InitializeComponent();
        }
        #endregion

        #region RefrescarGrafica
        public void RefrescarGrafica()
        {
            this.ChartControl.DataSource = this.DataSource;

            foreach (DataDynamics.ActiveReports.Chart.DataPoint dp in this.ChartControl.Series[0].Points)
            {
                dp.DisplayInLegend = true;
                dp.LegendText = dp.XValue.ToString() + " " + String.Format("{0:C}", dp.YValues[0]);
            }
        }
        #endregion
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubGraficaVentasPorManguera.rpx");
            this.ghGrafica = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghGrafica"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.fgGrafica = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["fgGrafica"]));
            this.ChartControl = ((DataDynamics.ActiveReports.ChartControl)(this.ghGrafica.Controls[0]));
        }
    }
}
