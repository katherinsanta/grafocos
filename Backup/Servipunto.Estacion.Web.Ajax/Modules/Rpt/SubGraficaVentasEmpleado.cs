using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubGraficaVentasEmpleado.
    /// </summary>
    public partial class SubGraficaVentasEmpleado : DataDynamics.ActiveReports.ActiveReport
    {

        public SubGraficaVentasEmpleado()
        {
            InitializeComponent();
        }

        #region RefrescarGrafica
        public void RefrescarGrafica()
        {
            this.chartControl.DataSource = this.DataSource;

            foreach (DataDynamics.ActiveReports.Chart.DataPoint dp in this.chartControl.Series[0].Points)
            {
                dp.DisplayInLegend = true;
                dp.LegendText = dp.XValue.ToString() + " " + String.Format("{0:C}", dp.YValues[0]);
            }
        }
        #endregion

        private void GroupHeader1_Format(object sender, System.EventArgs eArgs)
        {

        }
    }
}
