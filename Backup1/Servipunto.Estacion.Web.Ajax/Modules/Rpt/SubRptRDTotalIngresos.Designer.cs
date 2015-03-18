namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptRDTotalIngresos.
    /// </summary>
    partial class SubRptRDTotalIngresos
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SubRptRDTotalIngresos));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.lblTituloFormasPago = new DataDynamics.ActiveReports.Label();
            this.txtFormaPago = new DataDynamics.ActiveReports.TextBox();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFormasPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line3});
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
            // 
            // Line3
            // 
            this.Line3.Border.BottomColor = System.Drawing.Color.Black;
            this.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.LeftColor = System.Drawing.Color.Black;
            this.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.RightColor = System.Drawing.Color.Black;
            this.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Border.TopColor = System.Drawing.Color.Black;
            this.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line3.Height = 0F;
            this.Line3.Left = 0.03125F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0.578125F;
            this.Line3.Width = 7.96875F;
            this.Line3.X1 = 0.03125F;
            this.Line3.X2 = 8F;
            this.Line3.Y1 = 0.578125F;
            this.Line3.Y2 = 0.578125F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1});
            this.detail.Height = 0.21875F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // lblTituloFormasPago
            // 
            this.lblTituloFormasPago.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTituloFormasPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFormasPago.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTituloFormasPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFormasPago.Border.RightColor = System.Drawing.Color.Black;
            this.lblTituloFormasPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFormasPago.Border.TopColor = System.Drawing.Color.Black;
            this.lblTituloFormasPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFormasPago.Height = 0.2F;
            this.lblTituloFormasPago.HyperLink = null;
            this.lblTituloFormasPago.Left = 0.1875F;
            this.lblTituloFormasPago.Name = "lblTituloFormasPago";
            this.lblTituloFormasPago.Style = "font-weight: bold; font-size: 12pt; ";
            this.lblTituloFormasPago.Text = "Total  Ingresos";
            this.lblTituloFormasPago.Top = 0.0625F;
            this.lblTituloFormasPago.Width = 2.042323F;
            // 
            // txtFormaPago
            // 
            this.txtFormaPago.Border.BottomColor = System.Drawing.Color.Black;
            this.txtFormaPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFormaPago.Border.LeftColor = System.Drawing.Color.Black;
            this.txtFormaPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFormaPago.Border.RightColor = System.Drawing.Color.Black;
            this.txtFormaPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFormaPago.Border.TopColor = System.Drawing.Color.Black;
            this.txtFormaPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtFormaPago.DataField = "TotalOtrosIngresos";
            this.txtFormaPago.Height = 0.2F;
            this.txtFormaPago.Left = 4.8125F;
            this.txtFormaPago.Name = "txtFormaPago";
            this.txtFormaPago.OutputFormat = resources.GetString("txtFormaPago.OutputFormat");
            this.txtFormaPago.Style = "";
            this.txtFormaPago.Text = "Forma de Pago";
            this.txtFormaPago.Top = 0.0625F;
            this.txtFormaPago.Width = 1.820866F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtFormaPago,
            this.lblTituloFormasPago});
            this.groupHeader1.Height = 0.3645833F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0.01041667F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.DataField = "TotalOtrosIngresos";
            this.textBox1.Height = 0.2F;
            this.textBox1.Left = 4.75F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "";
            this.textBox1.Text = "Forma de Pago";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 1.820866F;
            // 
            // SubRptRDTotalIngresos
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 6.758366F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFormasPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Line Line3;
        private DataDynamics.ActiveReports.Label lblTituloFormasPago;
        private DataDynamics.ActiveReports.TextBox txtFormaPago;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.TextBox textBox1;
    }
}
