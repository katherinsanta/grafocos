namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for SubRptResumenDiarioTanques.
    /// </summary>
    partial class SubRptResumenDiarioTanques
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SubRptResumenDiarioTanques));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox22 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox7 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox10 = new DataDynamics.ActiveReports.TextBox();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label27 = new DataDynamics.ActiveReports.Label();
            this.Label10 = new DataDynamics.ActiveReports.Label();
            this.Label13 = new DataDynamics.ActiveReports.Label();
            this.label25 = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.label26 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.line4 = new DataDynamics.ActiveReports.Line();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Height = 0.04166667F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox8,
            this.textBox5,
            this.textBox22,
            this.textBox1,
            this.TextBox7,
            this.TextBox10});
            this.detail.Height = 0.2604167F;
            this.detail.Name = "detail";
            // 
            // textBox8
            // 
            this.textBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.RightColor = System.Drawing.Color.Black;
            this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.TopColor = System.Drawing.Color.Black;
            this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.DataField = "Descripcion";
            this.textBox8.Height = 0.1875F;
            this.textBox8.Left = 1.125F;
            this.textBox8.Name = "textBox8";
            this.textBox8.OutputFormat = resources.GetString("textBox8.OutputFormat");
            this.textBox8.Style = "text-align: left; font-size: 8.25pt; ";
            this.textBox8.Text = "idTanque";
            this.textBox8.Top = 0F;
            this.textBox8.Width = 2.3125F;
            // 
            // pageFooter
            // 
            this.pageFooter.Height = 0F;
            this.pageFooter.Name = "pageFooter";
            // 
            // reportHeader1
            // 
            this.reportHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label,
            this.Line1,
            this.label1,
            this.label2,
            this.label11,
            this.label27,
            this.Label10,
            this.Label13,
            this.label25,
            this.line2,
            this.label26,
            this.line3,
            this.line4});
            this.reportHeader1.Height = 0.84375F;
            this.reportHeader1.Name = "reportHeader1";
            this.reportHeader1.Format += new System.EventHandler(this.reportHeader1_Format);
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
            this.Label.Left = 0.0625F;
            this.Label.Name = "Label";
            this.Label.Style = "text-align: left; font-weight: bold; font-size: 12pt; ";
            this.Label.Text = "VARIACION COMBUSTIBLES LIQUIDOS";
            this.Label.Top = 0F;
            this.Label.Width = 4.4375F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0F;
            this.Line1.Left = 0.0625F;
            this.Line1.LineWeight = 1F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.25F;
            this.Line1.Width = 13.4375F;
            this.Line1.X1 = 0.0625F;
            this.Line1.X2 = 13.5F;
            this.Line1.Y1 = 0.25F;
            this.Line1.Y2 = 0.25F;
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
            this.label1.Height = 0.1999998F;
            this.label1.HyperLink = null;
            this.label1.Left = 1.125F;
            this.label1.Name = "label1";
            this.label1.Style = "text-align: left; font-size: 8.25pt; ";
            this.label1.Text = "Producto";
            this.label1.Top = 0.3125F;
            this.label1.Width = 0.9375F;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0F;
            this.reportFooter1.Name = "reportFooter1";
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
            this.label2.Height = 0.1999998F;
            this.label2.HyperLink = null;
            this.label2.Left = 0.125F;
            this.label2.Name = "label2";
            this.label2.Style = "text-align: left; font-size: 8.25pt; ";
            this.label2.Text = "Fecha";
            this.label2.Top = 0.3125F;
            this.label2.Width = 0.9375F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.DataField = "Fecha";
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 0.125F;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "text-align: right; font-size: 8.25pt; ";
            this.textBox5.Text = "Fecha";
            this.textBox5.Top = 0F;
            this.textBox5.Width = 0.9375F;
            // 
            // textBox22
            // 
            this.textBox22.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.RightColor = System.Drawing.Color.Black;
            this.textBox22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.Border.TopColor = System.Drawing.Color.Black;
            this.textBox22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox22.DataField = "transito";
            this.textBox22.Height = 0.1875F;
            this.textBox22.Left = 3.5F;
            this.textBox22.Name = "textBox22";
            this.textBox22.OutputFormat = resources.GetString("textBox22.OutputFormat");
            this.textBox22.Style = "text-align: right; font-size: 8.25pt; ";
            this.textBox22.Text = "Transito";
            this.textBox22.Top = 0F;
            this.textBox22.Width = 0.75F;
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
            this.textBox1.DataField = "variacionTransito";
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 4.3125F;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "text-align: right; font-size: 8.25pt; ";
            this.textBox1.Text = "% Variacion";
            this.textBox1.Top = 0F;
            this.textBox1.Width = 0.625F;
            // 
            // TextBox7
            // 
            this.TextBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox7.DataField = "variacion_Diaria";
            this.TextBox7.Height = 0.188F;
            this.TextBox7.Left = 5.0625F;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.OutputFormat = resources.GetString("TextBox7.OutputFormat");
            this.TextBox7.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox7.Text = "Variación Diaria";
            this.TextBox7.Top = 0F;
            this.TextBox7.Width = 0.75F;
            // 
            // TextBox10
            // 
            this.TextBox10.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox10.DataField = "porcentaje_Variacion";
            this.TextBox10.Height = 0.188F;
            this.TextBox10.Left = 5.875F;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.OutputFormat = resources.GetString("TextBox10.OutputFormat");
            this.TextBox10.Style = "text-align: right; font-size: 8.25pt; ";
            this.TextBox10.Text = "Variación Acum.";
            this.TextBox10.Top = 0F;
            this.TextBox10.Width = 0.625F;
            // 
            // label11
            // 
            this.label11.Border.BottomColor = System.Drawing.Color.Black;
            this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.LeftColor = System.Drawing.Color.Black;
            this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.RightColor = System.Drawing.Color.Black;
            this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.TopColor = System.Drawing.Color.Black;
            this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Height = 0.1875F;
            this.label11.HyperLink = null;
            this.label11.Left = 4.3125F;
            this.label11.Name = "label11";
            this.label11.Style = "text-align: right; font-size: 8.25pt; ";
            this.label11.Text = "%";
            this.label11.Top = 0.5625F;
            this.label11.Width = 0.625F;
            // 
            // label27
            // 
            this.label27.Border.BottomColor = System.Drawing.Color.Black;
            this.label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.LeftColor = System.Drawing.Color.Black;
            this.label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.RightColor = System.Drawing.Color.Black;
            this.label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Border.TopColor = System.Drawing.Color.Black;
            this.label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label27.Height = 0.1875F;
            this.label27.HyperLink = null;
            this.label27.Left = 5.0625F;
            this.label27.Name = "label27";
            this.label27.Style = "text-align: right; font-size: 8.25pt; ";
            this.label27.Text = "GL";
            this.label27.Top = 0.5625F;
            this.label27.Width = 0.75F;
            // 
            // Label10
            // 
            this.Label10.Border.BottomColor = System.Drawing.Color.Black;
            this.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.LeftColor = System.Drawing.Color.Black;
            this.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.RightColor = System.Drawing.Color.Black;
            this.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Border.TopColor = System.Drawing.Color.Black;
            this.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label10.Height = 0.1875F;
            this.Label10.HyperLink = null;
            this.Label10.Left = 3.5F;
            this.Label10.Name = "Label10";
            this.Label10.Style = "text-align: right; font-size: 8.25pt; ";
            this.Label10.Text = "GL";
            this.Label10.Top = 0.5625F;
            this.Label10.Width = 0.75F;
            // 
            // Label13
            // 
            this.Label13.Border.BottomColor = System.Drawing.Color.Black;
            this.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.LeftColor = System.Drawing.Color.Black;
            this.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.RightColor = System.Drawing.Color.Black;
            this.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Border.TopColor = System.Drawing.Color.Black;
            this.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label13.Height = 0.1875F;
            this.Label13.HyperLink = null;
            this.Label13.Left = 5.875F;
            this.Label13.Name = "Label13";
            this.Label13.Style = "text-align: right; font-size: 8.25pt; ";
            this.Label13.Text = "%";
            this.Label13.Top = 0.5625F;
            this.Label13.Width = 0.625F;
            // 
            // label25
            // 
            this.label25.Border.BottomColor = System.Drawing.Color.Black;
            this.label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.LeftColor = System.Drawing.Color.Black;
            this.label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.RightColor = System.Drawing.Color.Black;
            this.label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.TopColor = System.Drawing.Color.Black;
            this.label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Height = 0.1875F;
            this.label25.HyperLink = null;
            this.label25.Left = 3.5F;
            this.label25.Name = "label25";
            this.label25.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.label25.Text = "Variación Transito";
            this.label25.Top = 0.3125F;
            this.label25.Width = 1.4375F;
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
            this.line2.Left = 3.5F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.5625F;
            this.line2.Width = 1.4375F;
            this.line2.X1 = 3.5F;
            this.line2.X2 = 4.9375F;
            this.line2.Y1 = 0.5625F;
            this.line2.Y2 = 0.5625F;
            // 
            // label26
            // 
            this.label26.Border.BottomColor = System.Drawing.Color.Black;
            this.label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.LeftColor = System.Drawing.Color.Black;
            this.label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.RightColor = System.Drawing.Color.Black;
            this.label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.TopColor = System.Drawing.Color.Black;
            this.label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Height = 0.1875F;
            this.label26.HyperLink = null;
            this.label26.Left = 5.0625F;
            this.label26.Name = "label26";
            this.label26.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; ";
            this.label26.Text = "Variación Operacional";
            this.label26.Top = 0.3125F;
            this.label26.Width = 1.4375F;
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0F;
            this.line3.Left = 5.0625F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0.5625F;
            this.line3.Width = 1.4375F;
            this.line3.X1 = 5.0625F;
            this.line3.X2 = 6.5F;
            this.line3.Y1 = 0.5625F;
            this.line3.Y2 = 0.5625F;
            // 
            // line4
            // 
            this.line4.Border.BottomColor = System.Drawing.Color.Black;
            this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.LeftColor = System.Drawing.Color.Black;
            this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.RightColor = System.Drawing.Color.Black;
            this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.TopColor = System.Drawing.Color.Black;
            this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Height = 0F;
            this.line4.Left = 0F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.8125F;
            this.line4.Width = 13.4375F;
            this.line4.X1 = 0F;
            this.line4.X2 = 13.4375F;
            this.line4.Y1 = 0.8125F;
            this.line4.Y2 = 0.8125F;
            // 
            // SubRptResumenDiarioTanques
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 6.59375F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.TextBox textBox8;
        private DataDynamics.ActiveReports.ReportHeader reportHeader1;
        private DataDynamics.ActiveReports.ReportFooter reportFooter1;
        private DataDynamics.ActiveReports.Label Label;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Label label1;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.Label label2;
        private DataDynamics.ActiveReports.TextBox textBox22;
        private DataDynamics.ActiveReports.TextBox textBox1;
        private DataDynamics.ActiveReports.TextBox TextBox7;
        private DataDynamics.ActiveReports.TextBox TextBox10;
        private DataDynamics.ActiveReports.Label label11;
        private DataDynamics.ActiveReports.Label label27;
        private DataDynamics.ActiveReports.Label Label10;
        private DataDynamics.ActiveReports.Label Label13;
        private DataDynamics.ActiveReports.Label label25;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.Label label26;
        private DataDynamics.ActiveReports.Line line3;
        private DataDynamics.ActiveReports.Line line4;
    }
}
