using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubGraficaLecturas.
    /// </summary>
    public partial class SubGraficaLecturas : DataDynamics.ActiveReports.ActiveReport
    {

        #region Constructor de la Clase
        public SubGraficaLecturas()
        {
            InitializeComponent();
            Label.Text = Servipunto.Estacion.Libreria.Configuracion.PalabrasIdioma.Traduccion(2367, Global.Idioma);
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
            this.LoadLayout(this.GetType(), "Servipunto.Estacion.Web.Modules.Rpt.SubGraficaLecturas.rpx");
            this.ghGrafica = ((DataDynamics.ActiveReports.GroupHeader)(this.Sections["ghGrafica"]));
            this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
            this.gfGrafica = ((DataDynamics.ActiveReports.GroupFooter)(this.Sections["gfGrafica"]));
            this.ChartControl = ((DataDynamics.ActiveReports.ChartControl)(this.ghGrafica.Controls[0]));
            this.Label = ((DataDynamics.ActiveReports.Label)(this.ghGrafica.Controls[1]));
        }

    }
}
