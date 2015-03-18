using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubGraficaVentasPorMes.
    /// </summary>
    public partial class SubGraficaVentasPorMes : DataDynamics.ActiveReports.ActiveReport3
    {

        public SubGraficaVentasPorMes()
        {
            InitializeComponent();
        }

        #region RefrescarGrafica
        public void RefrescarGrafica()
        {
            this.ChartControl.DataSource = this.DataSource;

            foreach (DataDynamics.ActiveReports.Chart.DataPoint dp in this.ChartControl.Series[0].Points)
            {
                dp.DisplayInLegend = true;
                //dp.LegendText = dp.XValue.ToString() + " " + String.Format("{0:C}",dp.YValues[0]);
                dp.LegendText = dp.XValue.ToString() + " " + dp.YValues[0].ToString();
            }
        }
        #endregion

        private void GroupFooter1_Format(object sender, System.EventArgs eArgs)
        {

        }
        public void InitializeReport()
        {
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubGraficaVentasPorMes.rpx");
            this.GroupHeader1 = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["GroupHeader1"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.GroupFooter1 = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["GroupFooter1"]));
            this.ChartControl = ((DataDynamics.ActiveReports.ChartControl)(this.GroupHeader1.Controls[0]));
            // Attach Report Events
            this.GroupFooter1.Format += new System.EventHandler(this.GroupFooter1_Format);
        }


    }
}
