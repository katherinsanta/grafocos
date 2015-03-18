namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for ReporteFacturasCanastilla_.
    /// </summary>
    partial class ReporteFacturasCanastilla_
    {
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.PageFooter pageFooter;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

        #region ActiveReport Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ReporteFacturasCanastilla_));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.lblCompania = new DataDynamics.ActiveReports.Label();
            this.lblNombreReporte = new DataDynamics.ActiveReports.Label();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.lblCompania)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblCompania,
            this.lblNombreReporte});
            this.pageHeader.Height = 1.263889F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
            // 
            // lblCompania
            // 
            this.lblCompania.Border.BottomColor = System.Drawing.Color.Black;
            this.lblCompania.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCompania.Border.LeftColor = System.Drawing.Color.Black;
            this.lblCompania.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCompania.Border.RightColor = System.Drawing.Color.Black;
            this.lblCompania.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCompania.Border.TopColor = System.Drawing.Color.Black;
            this.lblCompania.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblCompania.Height = 0.25F;
            this.lblCompania.HyperLink = null;
            this.lblCompania.Left = 2.1875F;
            this.lblCompania.Name = "lblCompania";
            this.lblCompania.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; font-" +
                "family: Verdana; ";
            this.lblCompania.Text = "Compania";
            this.lblCompania.Top = 0F;
            this.lblCompania.Width = 6.5F;
            // 
            // lblNombreReporte
            // 
            this.lblNombreReporte.Border.BottomColor = System.Drawing.Color.Black;
            this.lblNombreReporte.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNombreReporte.Border.LeftColor = System.Drawing.Color.Black;
            this.lblNombreReporte.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNombreReporte.Border.RightColor = System.Drawing.Color.Black;
            this.lblNombreReporte.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNombreReporte.Border.TopColor = System.Drawing.Color.Black;
            this.lblNombreReporte.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblNombreReporte.Height = 0.1875F;
            this.lblNombreReporte.HyperLink = null;
            this.lblNombreReporte.Left = 2.125F;
            this.lblNombreReporte.Name = "lblNombreReporte";
            this.lblNombreReporte.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lblNombreReporte.Text = "REPORTE DE FACTURAS DE CANASTILLA";
            this.lblNombreReporte.Top = 0.3125F;
            this.lblNombreReporte.Width = 6.875F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 2F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.25F;
            this.pageFooter.Name = "pageFooter";
            // 
            // ReporteFacturasCanastilla_
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 11.5625F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.lblCompania)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNombreReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Label lblCompania;
        private DataDynamics.ActiveReports.Label lblNombreReporte;
    }
}
