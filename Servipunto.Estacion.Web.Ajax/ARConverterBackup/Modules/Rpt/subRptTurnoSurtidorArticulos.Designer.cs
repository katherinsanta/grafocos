namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for subRptTurnoSurtidorArticulos.
    /// </summary>
    partial class subRptTurnoSurtidorArticulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(subRptTurnoSurtidorArticulos));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.txtCantidad = new DataDynamics.ActiveReports.TextBox();
            this.txtSubTotal = new DataDynamics.ActiveReports.TextBox();
            this.txtArticulo = new DataDynamics.ActiveReports.TextBox();
            this.GroupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.GroupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtCantidad,
            this.txtSubTotal,
            this.txtArticulo});
            this.Detail.Height = 0.25F;
            this.Detail.Name = "Detail";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Border.BottomColor = System.Drawing.Color.Black;
            this.txtCantidad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCantidad.Border.LeftColor = System.Drawing.Color.Black;
            this.txtCantidad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCantidad.Border.RightColor = System.Drawing.Color.Black;
            this.txtCantidad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCantidad.Border.TopColor = System.Drawing.Color.Black;
            this.txtCantidad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtCantidad.DataField = "Cantidad";
            this.txtCantidad.Height = 0.1875F;
            this.txtCantidad.Left = 2.0625F;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.OutputFormat = resources.GetString("txtCantidad.OutputFormat");
            this.txtCantidad.Style = "text-align: right; ";
            this.txtCantidad.Text = "Cantidad";
            this.txtCantidad.Top = 0F;
            this.txtCantidad.Width = 0.8125F;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtSubTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtSubTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTotal.Border.RightColor = System.Drawing.Color.Black;
            this.txtSubTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTotal.Border.TopColor = System.Drawing.Color.Black;
            this.txtSubTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtSubTotal.DataField = "Total";
            this.txtSubTotal.Height = 0.2F;
            this.txtSubTotal.Left = 2.9375F;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.OutputFormat = resources.GetString("txtSubTotal.OutputFormat");
            this.txtSubTotal.Style = "text-align: right; ";
            this.txtSubTotal.Text = "Total";
            this.txtSubTotal.Top = 0F;
            this.txtSubTotal.Width = 1.427167F;
            // 
            // txtArticulo
            // 
            this.txtArticulo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtArticulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtArticulo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtArticulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtArticulo.Border.RightColor = System.Drawing.Color.Black;
            this.txtArticulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtArticulo.Border.TopColor = System.Drawing.Color.Black;
            this.txtArticulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtArticulo.DataField = "Descripcion";
            this.txtArticulo.Height = 0.25F;
            this.txtArticulo.Left = 0.0625F;
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Style = "";// global::Servipunto.Estacion.Web.Ajax.Modules.Rpt.VentasTurnoMedio_.txtTurnoPie_OutputFormat;
            this.txtArticulo.Text = "Articulo";
            this.txtArticulo.Top = 0F;
            this.txtArticulo.Width = 1.9375F;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line,
            this.Label,
            this.label2,
            this.label3,
            this.label4});
            this.GroupHeader1.Height = 0.5625F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Line
            // 
            this.Line.Border.BottomColor = System.Drawing.Color.Black;
            this.Line.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.LeftColor = System.Drawing.Color.Black;
            this.Line.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.RightColor = System.Drawing.Color.Black;
            this.Line.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Border.TopColor = System.Drawing.Color.Black;
            this.Line.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line.Height = 0F;
            this.Line.Left = 0.02460633F;
            this.Line.LineWeight = 2F;
            this.Line.Name = "Line";
            this.Line.Top = 0.2952756F;
            this.Line.Width = 7.997046F;
            this.Line.X1 = 0.02460633F;
            this.Line.X2 = 8.021652F;
            this.Line.Y1 = 0.2952756F;
            this.Line.Y2 = 0.2952756F;
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
            this.Label.Height = 0.1875F;
            this.Label.HyperLink = null;
            this.Label.Left = 0.0625F;
            this.Label.Name = "Label";
            this.Label.Style = "font-weight: bold; ";
            this.Label.Text = "Reporte Articulos:";
            this.Label.Top = 0.0625F;
            this.Label.Width = 1.5625F;
            // 
            // label2
            // 
            this.label2.Border.BottomColor = System.Drawing.Color.Black;
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.LeftColor = System.Drawing.Color.Black;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.RightColor = System.Drawing.Color.Black;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.TopColor = System.Drawing.Color.Black;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Height = 0.1979167F;
            this.label2.HyperLink = null;
            this.label2.Left = 0F;
            this.label2.Name = "label2";
            this.label2.Style = "font-weight: bold; ";
            this.label2.Text = "Articulo";
            this.label2.Top = 0.32F;
            this.label2.Width = 1F;
            // 
            // label3
            // 
            this.label3.Border.BottomColor = System.Drawing.Color.Black;
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.LeftColor = System.Drawing.Color.Black;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.RightColor = System.Drawing.Color.Black;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.TopColor = System.Drawing.Color.Black;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Height = 0.1875F;
            this.label3.HyperLink = null;
            this.label3.Left = 2.125F;
            this.label3.Name = "label3";
            this.label3.Style = "font-weight: bold; ";
            this.label3.Text = "Cantidad";
            this.label3.Top = 0.3125F;
            this.label3.Width = 0.625F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.1875F;
            this.label4.HyperLink = null;
            this.label4.Left = 3.6875F;
            this.label4.Name = "label4";
            this.label4.Style = "font-weight: bold; ";
            this.label4.Text = "Total";
            this.label4.Top = 0.3125F;
            this.label4.Width = 0.625F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox1,
            this.textBox2,
            this.label1,
            this.line1,
            this.line2});
            this.GroupFooter1.Height = 0.375F;
            this.GroupFooter1.Name = "GroupFooter1";
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
            this.textBox1.DataField = "Cantidad";
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 2.0625F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "text-align: right; ";
            this.textBox1.SummaryGroup = "GroupHeader1";
            this.textBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox1.Text = "Cantidad";
            this.textBox1.Top = 0.125F;
            this.textBox1.Width = 0.8125F;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.DataField = "Total";
            this.textBox2.Height = 0.2F;
            this.textBox2.Left = 2.9375F;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "text-align: right; ";
            this.textBox2.SummaryGroup = "GroupHeader1";
            this.textBox2.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox2.Text = "Total";
            this.textBox2.Top = 0.125F;
            this.textBox2.Width = 1.427167F;
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
            this.label1.Height = 0.1875F;
            this.label1.HyperLink = null;
            this.label1.Left = 0F;
            this.label1.Name = "label1";
            this.label1.Style = "font-weight: bold; ";
            this.label1.Text = "Total";
            this.label1.Top = 0.0625F;
            this.label1.Width = 1.1875F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 2.0625F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.0625F;
            this.line1.Width = 0.8125F;
            this.line1.X1 = 2.0625F;
            this.line1.X2 = 2.875F;
            this.line1.Y1 = 0.0625F;
            this.line1.Y2 = 0.0625F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 2.9375F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.0625F;
            this.line2.Width = 1.4375F;
            this.line2.X1 = 2.9375F;
            this.line2.X2 = 4.375F;
            this.line2.Y1 = 0.0625F;
            this.line2.Y2 = 0.0625F;
            // 
            // subRptTurnoSurtidorArticulos
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.1965278F;
            this.PageSettings.Margins.Left = 0.1965278F;
            this.PageSettings.Margins.Right = 0.1965278F;
            this.PageSettings.Margins.Top = 0.1965278F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 8.052083F;
            this.Sections.Add(this.GroupHeader1);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GroupFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox txtCantidad;
        private DataDynamics.ActiveReports.TextBox txtSubTotal;
        private DataDynamics.ActiveReports.TextBox txtArticulo;
        private DataDynamics.ActiveReports.GroupHeader GroupHeader1;
        private DataDynamics.ActiveReports.Line Line;
        private DataDynamics.ActiveReports.Label Label;
        private DataDynamics.ActiveReports.GroupFooter GroupFooter1;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.Label label2;
        private DataDynamics.ActiveReports.Label label3;
        private DataDynamics.ActiveReports.Label label4;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.Line line2;
    }
}
