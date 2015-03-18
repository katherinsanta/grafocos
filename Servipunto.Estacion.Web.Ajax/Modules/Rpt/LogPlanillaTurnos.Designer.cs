namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for LogPlanillaTurnos.
    /// </summary>
    partial class LogPlanillaTurnos
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LogPlanillaTurnos));
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.srptEncabezado = new DataDynamics.ActiveReports.SubReport();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.lblTituloFechas = new DataDynamics.ActiveReports.Label();
            this.lblFecha = new DataDynamics.ActiveReports.Label();
            this.lblHora = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.Label5 = new DataDynamics.ActiveReports.Label();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox2 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.lblAno = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPaginas = new DataDynamics.ActiveReports.TextBox();
            this.lblDe = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPagina = new DataDynamics.ActiveReports.TextBox();
            this.lblPagina = new DataDynamics.ActiveReports.Label();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.srptEncabezado,
            this.Label,
            this.lblTituloFechas,
            this.lblFecha,
            this.lblHora,
            this.Label3,
            this.Label4,
            this.Label5,
            this.Label6,
            this.label12,
            this.line2});
            this.pageHeader.Height = 1.73125F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
            // 
            // srptEncabezado
            // 
            this.srptEncabezado.CloseBorder = false;
            this.srptEncabezado.Height = 0.5905511F;
            this.srptEncabezado.Left = 2.14325F;
            this.srptEncabezado.Name = "srptEncabezado";
            this.srptEncabezado.Report = null;
            this.srptEncabezado.ReportName = "SubEncabezado";
            this.srptEncabezado.Top = 0F;
            this.srptEncabezado.Width = 5.536417F;
            // 
            // Label
            // 
            this.Label.Height = 0.2F;
            this.Label.HyperLink = null;
            this.Label.Left = 2.692708F;
            this.Label.Name = "Label";
            this.Label.Style = "font-size: 12pt; font-weight: bold; text-align: center";
            this.Label.Text = "Reporte Log Planilla Turno";
            this.Label.Top = 0.75F;
            this.Label.Width = 4.4375F;
            // 
            // lblTituloFechas
            // 
            this.lblTituloFechas.Height = 0.2F;
            this.lblTituloFechas.HyperLink = null;
            this.lblTituloFechas.Left = 2.692708F;
            this.lblTituloFechas.Name = "lblTituloFechas";
            this.lblTituloFechas.Style = "font-weight: bold; text-align: center";
            this.lblTituloFechas.Text = "Fecha & Fecha";
            this.lblTituloFechas.Top = 1F;
            this.lblTituloFechas.Width = 4.4375F;
            // 
            // lblFecha
            // 
            this.lblFecha.Height = 0.2F;
            this.lblFecha.HyperLink = null;
            this.lblFecha.Left = 8.078F;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Style = "";
            this.lblFecha.Text = "Fecha";
            this.lblFecha.Top = 0.677F;
            this.lblFecha.Width = 1.625F;
            // 
            // lblHora
            // 
            this.lblHora.Height = 0.2F;
            this.lblHora.HyperLink = null;
            this.lblHora.Left = 8.078F;
            this.lblHora.Name = "lblHora";
            this.lblHora.Style = "";
            this.lblHora.Text = "Hora";
            this.lblHora.Top = 0.8645F;
            this.lblHora.Width = 1.625F;
            // 
            // Label3
            // 
            this.Label3.Height = 0.1875F;
            this.Label3.HyperLink = null;
            this.Label3.Left = 1.298F;
            this.Label3.Name = "Label3";
            this.Label3.Style = "font-size: 8.25pt; font-weight: bold; text-align: left; ddo-char-set: 0";
            this.Label3.Text = "Isla";
            this.Label3.Top = 1.532F;
            this.Label3.Width = 1.3125F;
            // 
            // Label4
            // 
            this.Label4.Height = 0.1875F;
            this.Label4.HyperLink = null;
            this.Label4.Left = 2.671F;
            this.Label4.Name = "Label4";
            this.Label4.Style = "font-size: 8.25pt; font-weight: bold; text-align: left; ddo-char-set: 0";
            this.Label4.Text = "Turno";
            this.Label4.Top = 1.532F;
            this.Label4.Width = 1.4375F;
            // 
            // Label5
            // 
            this.Label5.Height = 0.2F;
            this.Label5.HyperLink = null;
            this.Label5.Left = 4.108501F;
            this.Label5.Name = "Label5";
            this.Label5.Style = "font-size: 8.25pt; font-weight: bold; text-align: left; ddo-char-set: 0";
            this.Label5.Text = "Usuario";
            this.Label5.Top = 1.532F;
            this.Label5.Width = 1.375F;
            // 
            // Label6
            // 
            this.Label6.Height = 0.1875F;
            this.Label6.HyperLink = null;
            this.Label6.Left = 5.483501F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "font-size: 8.25pt; font-weight: bold; text-align: left; ddo-char-set: 0";
            this.Label6.Text = "Acción";
            this.Label6.Top = 1.532F;
            this.Label6.Width = 1.6875F;
            // 
            // label12
            // 
            this.label12.Height = 0.1875F;
            this.label12.HyperLink = null;
            this.label12.Left = 0.1305001F;
            this.label12.Name = "label12";
            this.label12.Style = "font-size: 8.25pt; font-weight: bold; text-align: left; ddo-char-set: 0";
            this.label12.Text = "Hora";
            this.label12.Top = 1.5325F;
            this.label12.Width = 1.125F;
            // 
            // line2
            // 
            this.line2.Height = 0F;
            this.line2.Left = 0.131F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 1.458F;
            this.line2.Width = 11.875F;
            this.line2.X1 = 0.131F;
            this.line2.X2 = 12.006F;
            this.line2.Y1 = 1.458F;
            this.line2.Y2 = 1.458F;
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.TextBox,
            this.TextBox1,
            this.TextBox2,
            this.TextBox3,
            this.textBox9});
            this.detail.Height = 0.21875F;
            this.detail.Name = "detail";
            // 
            // TextBox
            // 
            this.TextBox.DataField = "Isla";
            this.TextBox.Height = 0.1875F;
            this.TextBox.Left = 1.293F;
            this.TextBox.Name = "TextBox";
            this.TextBox.OutputFormat = resources.GetString("TextBox.OutputFormat");
            this.TextBox.Style = "font-size: 8.25pt; text-align: left";
            this.TextBox.Text = "Isla";
            this.TextBox.Top = 0F;
            this.TextBox.Width = 1.4375F;
            // 
            // TextBox1
            // 
            this.TextBox1.DataField = "Turno";
            this.TextBox1.Height = 0.1875F;
            this.TextBox1.Left = 2.7305F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat");
            this.TextBox1.Style = "font-size: 8.25pt; text-align: left";
            this.TextBox1.Text = "Turno";
            this.TextBox1.Top = 0F;
            this.TextBox1.Width = 1.375F;
            // 
            // TextBox2
            // 
            this.TextBox2.DataField = "usuario";
            this.TextBox2.Height = 0.1875F;
            this.TextBox2.Left = 4.105502F;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.OutputFormat = resources.GetString("TextBox2.OutputFormat");
            this.TextBox2.Style = "font-size: 8.25pt; text-align: left";
            this.TextBox2.Text = "usuario";
            this.TextBox2.Top = 0F;
            this.TextBox2.Width = 1.375F;
            // 
            // TextBox3
            // 
            this.TextBox3.DataField = "accion";
            this.TextBox3.Height = 0.187F;
            this.TextBox3.Left = 5.493001F;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.OutputFormat = resources.GetString("TextBox3.OutputFormat");
            this.TextBox3.Style = "font-size: 8.25pt; text-align: left";
            this.TextBox3.Text = "accion";
            this.TextBox3.Top = 0F;
            this.TextBox3.Width = 5.552F;
            // 
            // textBox9
            // 
            this.textBox9.DataField = "Hora";
            this.textBox9.Height = 0.1875F;
            this.textBox9.Left = 0.1405001F;
            this.textBox9.Name = "textBox9";
            this.textBox9.OutputFormat = resources.GetString("textBox9.OutputFormat");
            this.textBox9.Style = "font-size: 8.25pt; text-align: left";
            this.textBox9.Text = "Hora";
            this.textBox9.Top = 0F;
            this.textBox9.Width = 1.1025F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label1,
            this.lblAno,
            this.Label2,
            this.txtNumeroPaginas,
            this.lblDe,
            this.txtNumeroPagina,
            this.lblPagina});
            this.pageFooter.Height = 0.5F;
            this.pageFooter.Name = "pageFooter";
            this.pageFooter.Format += new System.EventHandler(this.pageFooter_Format);
            // 
            // Label1
            // 
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-weight: bold; ddo-char-set: 1";
            this.Label1.Text = "Zencillo Módulo de Estación";
            this.Label1.Top = 0F;
            this.Label1.Width = 4.25F;
            // 
            // lblAno
            // 
            this.lblAno.Height = 0.2F;
            this.lblAno.HyperLink = null;
            this.lblAno.Left = 0.5625F;
            this.lblAno.Name = "lblAno";
            this.lblAno.Style = "font-size: 8.25pt; text-align: center";
            this.lblAno.Text = "año";
            this.lblAno.Top = 0.25F;
            this.lblAno.Width = 0.375F;
            // 
            // Label2
            // 
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-family: Arial; font-size: 8pt; ddo-char-set: 1";
            this.Label2.Text = "© Copyright             Zencillo de Software Ltda. Todos los Derechos Reservados." +
    "";
            this.Label2.Top = 0.25F;
            this.Label2.Width = 4.3125F;
            // 
            // txtNumeroPaginas
            // 
            this.txtNumeroPaginas.Height = 0.2F;
            this.txtNumeroPaginas.Left = 11.4375F;
            this.txtNumeroPaginas.Name = "txtNumeroPaginas";
            this.txtNumeroPaginas.Style = "text-align: center";
            this.txtNumeroPaginas.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPaginas.Text = "##";
            this.txtNumeroPaginas.Top = 0.1875F;
            this.txtNumeroPaginas.Width = 0.5054207F;
            // 
            // lblDe
            // 
            this.lblDe.Height = 0.2F;
            this.lblDe.HyperLink = null;
            this.lblDe.Left = 11.25F;
            this.lblDe.Name = "lblDe";
            this.lblDe.Style = "font-size: 8pt";
            this.lblDe.Text = "de";
            this.lblDe.Top = 0.1875F;
            this.lblDe.Width = 0.1668492F;
            // 
            // txtNumeroPagina
            // 
            this.txtNumeroPagina.Height = 0.2F;
            this.txtNumeroPagina.Left = 10.75F;
            this.txtNumeroPagina.Name = "txtNumeroPagina";
            this.txtNumeroPagina.Style = "text-align: center";
            this.txtNumeroPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtNumeroPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPagina.Text = "#";
            this.txtNumeroPagina.Top = 0.1875F;
            this.txtNumeroPagina.Width = 0.4542451F;
            // 
            // lblPagina
            // 
            this.lblPagina.Height = 0.2F;
            this.lblPagina.HyperLink = null;
            this.lblPagina.Left = 10.375F;
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Style = "font-size: 8pt";
            this.lblPagina.Text = "Pagina";
            this.lblPagina.Top = 0.1875F;
            this.lblPagina.Width = 0.375F;
            // 
            // groupHeader1
            // 
            this.groupHeader1.Height = 0F;
            this.groupHeader1.Name = "groupHeader1";
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // LogPlanillaTurnos
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 12.006F;
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
            "l; font-size: 10pt; color: Black", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
            "lic", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.SubReport srptEncabezado;
        private DataDynamics.ActiveReports.Label Label;
        private DataDynamics.ActiveReports.Label lblTituloFechas;
        private DataDynamics.ActiveReports.Label lblFecha;
        private DataDynamics.ActiveReports.Label lblHora;
        private DataDynamics.ActiveReports.Label Label3;
        private DataDynamics.ActiveReports.Label Label4;
        private DataDynamics.ActiveReports.Label Label5;
        private DataDynamics.ActiveReports.Label Label6;
        private DataDynamics.ActiveReports.Label label12;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.GroupHeader groupHeader1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.TextBox TextBox;
        private DataDynamics.ActiveReports.TextBox TextBox1;
        private DataDynamics.ActiveReports.TextBox TextBox2;
        private DataDynamics.ActiveReports.TextBox TextBox3;
        private DataDynamics.ActiveReports.TextBox textBox9;
        private DataDynamics.ActiveReports.Label Label1;
        private DataDynamics.ActiveReports.Label lblAno;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.TextBox txtNumeroPaginas;
        private DataDynamics.ActiveReports.Label lblDe;
        private DataDynamics.ActiveReports.TextBox txtNumeroPagina;
        private DataDynamics.ActiveReports.Label lblPagina;
    }
}
