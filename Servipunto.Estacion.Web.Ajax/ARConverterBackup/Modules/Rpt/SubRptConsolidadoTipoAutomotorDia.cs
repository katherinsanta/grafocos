using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptConsolidadoTipoAutomotorDia.
    /// </summary>
    public partial class SubRptConsolidadoTipoAutomotorDia : DataDynamics.ActiveReports.ActiveReport3
    {

        #region Constructor
        public SubRptConsolidadoTipoAutomotorDia()
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
    }
}
