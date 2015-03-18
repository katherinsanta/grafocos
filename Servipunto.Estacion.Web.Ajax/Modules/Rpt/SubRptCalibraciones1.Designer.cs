namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptCalibraciones1.
    /// </summary>
    partial class SubRptCalibraciones1
    {

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubRptCalibraciones1));
            this.ghPagos = new DataDynamics.ActiveReports.Detail();
            this.ghTotal = new DataDynamics.ActiveReports.GroupHeader();
            this.lblTituloFormasPago = new DataDynamics.ActiveReports.Label();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.txtFormaPago = new DataDynamics.ActiveReports.TextBox();
            this.gfPagos = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFormasPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // ghPagos
            // 
            this.ghPagos.ColumnSpacing = 0F;
            this.ghPagos.Height = 0.01041667F;
            this.ghPagos.Name = "ghPagos";
            // 
            // ghTotal
            // 
            this.ghTotal.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTituloFormasPago,
            this.Line3,
            this.Label,
            this.txtFormaPago});
            this.ghTotal.Height = 0.4895833F;
            this.ghTotal.Name = "ghTotal";
            this.ghTotal.Format += new System.EventHandler(this.ghTotal_Format);
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
            this.lblTituloFormasPago.Left = 0F;
            this.lblTituloFormasPago.Name = "lblTituloFormasPago";
            this.lblTituloFormasPago.Style = "font-weight: bold; font-size: 12pt; ";
            this.lblTituloFormasPago.Text = "Reporte de Calibraciones";
            this.lblTituloFormasPago.Top = 0F;
            this.lblTituloFormasPago.Width = 2.042323F;
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
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 0F;
            this.Label.Name = "Label";
            this.Label.Style = "text-align: right; font-weight: bold; ";
            this.Label.Text = "Total:";
            this.Label.Top = 0.25F;
            this.Label.Width = 0.5625F;
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
            this.txtFormaPago.DataField = "ValorFormaPago";
            this.txtFormaPago.Height = 0.2F;
            this.txtFormaPago.Left = 5.4375F;
            this.txtFormaPago.Name = "txtFormaPago";
            this.txtFormaPago.OutputFormat = resources.GetString("txtFormaPago.OutputFormat");
            this.txtFormaPago.Style = "";
            this.txtFormaPago.Text = "Forma de Pago";
            this.txtFormaPago.Top = 0.25F;
            this.txtFormaPago.Width = 1.820866F;
            // 
            // gfPagos
            // 
            this.gfPagos.Height = 0F;
            this.gfPagos.Name = "gfPagos";
            // 
            // SubRptCalibraciones1
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 7.322917F;
            this.Sections.Add(this.ghTotal);
            this.Sections.Add(this.ghPagos);
            this.Sections.Add(this.gfPagos);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFormasPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormaPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Detail ghPagos;
        private DataDynamics.ActiveReports.GroupHeader ghTotal;
        private DataDynamics.ActiveReports.Label lblTituloFormasPago;
        private DataDynamics.ActiveReports.Line Line3;
        private DataDynamics.ActiveReports.Label Label;
        private DataDynamics.ActiveReports.TextBox txtFormaPago;
        private DataDynamics.ActiveReports.GroupFooter gfPagos;
    }
}
