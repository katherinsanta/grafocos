namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubResumenDiarioDescuadrecito.
    /// </summary>
    partial class SubResumenDiarioDescuadrecito
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SubResumenDiarioDescuadrecito));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.lblTituloFormasPago = new DataDynamics.ActiveReports.Label();
            this.Line3 = new DataDynamics.ActiveReports.Line();
            this.txtFormaPago = new DataDynamics.ActiveReports.TextBox();
            this.txtEstado = new DataDynamics.ActiveReports.TextBox();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFormasPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormaPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0F;
            this.pageHeader.Name = "pageHeader";
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0F;
            this.detail.Name = "detail";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0.01041667F;
            this.pageFooter.Name = "pageFooter";
            // 
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblTituloFormasPago,
            this.Line3,
            this.txtFormaPago,
            this.txtEstado});
            this.groupHeader1.Height = 0.2708333F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
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
            this.lblTituloFormasPago.Text = "DESCUADRE DEL DIA";
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
            this.Line3.Left = 0.0625F;
            this.Line3.LineWeight = 1F;
            this.Line3.Name = "Line3";
            this.Line3.Top = 0.25F;
            this.Line3.Width = 7.9375F;
            this.Line3.X1 = 0.0625F;
            this.Line3.X2 = 8F;
            this.Line3.Y1 = 0.25F;
            this.Line3.Y2 = 0.25F;
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
            this.txtFormaPago.DataField = "descuadre";
            this.txtFormaPago.Height = 0.2F;
            this.txtFormaPago.Left = 6.125F;
            this.txtFormaPago.Name = "txtFormaPago";
            this.txtFormaPago.OutputFormat = resources.GetString("txtFormaPago.OutputFormat");
            this.txtFormaPago.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 9.75pt; ";
            this.txtFormaPago.Text = "Forma de Pago";
            this.txtFormaPago.Top = 0F;
            this.txtFormaPago.Width = 1.820866F;
            // 
            // txtEstado
            // 
            this.txtEstado.Border.BottomColor = System.Drawing.Color.Black;
            this.txtEstado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstado.Border.LeftColor = System.Drawing.Color.Black;
            this.txtEstado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstado.Border.RightColor = System.Drawing.Color.Black;
            this.txtEstado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstado.Border.TopColor = System.Drawing.Color.Black;
            this.txtEstado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtEstado.Height = 0.2F;
            this.txtEstado.Left = 4.25F;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.OutputFormat = resources.GetString("txtEstado.OutputFormat");
            this.txtEstado.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; ";
            this.txtEstado.Text = null;
            this.txtEstado.Top = 0F;
            this.txtEstado.Width = 1.820866F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // SubResumenDiarioDescuadrecito
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.125F;
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
            ((System.ComponentModel.ISupportInitialize)(this.txtEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.Label lblTituloFormasPago;
        private DataDynamics.ActiveReports.Line Line3;
        private DataDynamics.ActiveReports.TextBox txtFormaPago;
        private DataDynamics.ActiveReports.TextBox txtEstado;
    }
}
