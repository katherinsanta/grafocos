namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubReporteCombYCanastilla.
    /// </summary>
    partial class SubReporteCombYCanastilla
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SubReporteCombYCanastilla));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.txtCombYCanastilla = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCombYCanastilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0.01041667F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label1,
            this.txtCombYCanastilla});
            this.detail.Height = 0.3854167F;
            this.detail.Name = "detail";
            this.detail.Format += new System.EventHandler(this.detail_Format);
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.3125F;
            this.label1.HyperLink = null;
            this.label1.Left = 0F;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 0; font-weight: bold; font-size: 12pt; ";
            this.label1.Text = "TOTAL INGRESOS ESTACION";
            this.label1.Top = 0F;
            this.label1.Width = 4.125F;
            // 
            // txtCombYCanastilla
            // 
            this.txtCombYCanastilla.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCombYCanastilla.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCombYCanastilla.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCombYCanastilla.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCombYCanastilla.Border.RightColor = System.Drawing.Color.Black;
            this.txtCombYCanastilla.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCombYCanastilla.Border.TopColor = System.Drawing.Color.Black;
            this.txtCombYCanastilla.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCombYCanastilla.DataField = "ValorCombustibleCanastilla";
            this.txtCombYCanastilla.Height = 0.1875F;
            this.txtCombYCanastilla.Left = 5.0625F;
            this.txtCombYCanastilla.Name = "txtCombYCanastilla";
            this.txtCombYCanastilla.OutputFormat = resources.GetString("txtCombYCanastilla.OutputFormat");
            this.txtCombYCanastilla.Style = "ddo-char-set: 0; font-weight: bold; font-size: 12pt; ";
            this.txtCombYCanastilla.Text = "0";
            this.txtCombYCanastilla.Top = 0.0625F;
            this.txtCombYCanastilla.Width = 1.3125F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.01041667F;
            this.pageFooter.Name = "pageFooter";
            // 
            // SubReporteCombYCanastilla
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCombYCanastilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.TextBox txtCombYCanastilla;
    }
}
