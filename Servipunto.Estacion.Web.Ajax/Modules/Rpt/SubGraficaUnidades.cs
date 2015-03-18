using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubGraficaUnidades.
    /// </summary>
    public partial class SubGraficaUnidades : DataDynamics.ActiveReports.ActiveReport
    {

        #region Constructor de la clase
        public SubGraficaUnidades()
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
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubGraficaUnidades.rpx");
            this.ghGrafica = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghGrafica"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
            this.ChartControl = ((DataDynamics.ActiveReports.ChartControl)(this.ghGrafica.Controls[0]));
        }


    }
}
