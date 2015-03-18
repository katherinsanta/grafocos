namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for ResumenDiarioDetallado.
    /// </summary>
    partial class ResumenDiarioDetallado
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ResumenDiarioDetallado));
            this.detail = new DataDynamics.ActiveReports.Detail();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.pageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.lblFecha = new DataDynamics.ActiveReports.Label();
            this.lblHora = new DataDynamics.ActiveReports.Label();
            this.lblTituloFechas = new DataDynamics.ActiveReports.Label();
            this.srptEncabezado = new DataDynamics.ActiveReports.SubReport();
            this.pageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.lblAno = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPaginas = new DataDynamics.ActiveReports.TextBox();
            this.lblDe = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPagina = new DataDynamics.ActiveReports.TextBox();
            this.lblPagina = new DataDynamics.ActiveReports.Label();
            this.GHVentasCombustible = new DataDynamics.ActiveReports.GroupHeader();
            this.SRptVentasCombustible = new DataDynamics.ActiveReports.SubReport();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.GHRVentasCanastilla = new DataDynamics.ActiveReports.GroupHeader();
            this.SRptVentasCanastilla = new DataDynamics.ActiveReports.SubReport();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            this.GRHCombYCanastilla = new DataDynamics.ActiveReports.GroupHeader();
            this.SRPTCombyCanastilla = new DataDynamics.ActiveReports.SubReport();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.groupFooter9 = new DataDynamics.ActiveReports.GroupFooter();
            this.GHRFormaPago = new DataDynamics.ActiveReports.GroupHeader();
            this.SRptFormaPago = new DataDynamics.ActiveReports.SubReport();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.groupFooter3 = new DataDynamics.ActiveReports.GroupFooter();
            this.GHRConsignacion = new DataDynamics.ActiveReports.GroupHeader();
            this.SRptConsignacion = new DataDynamics.ActiveReports.SubReport();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.groupFooter5 = new DataDynamics.ActiveReports.GroupFooter();
            this.GHRDescuadre = new DataDynamics.ActiveReports.GroupHeader();
            this.SRptDescuadre = new DataDynamics.ActiveReports.SubReport();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.groupFooter6 = new DataDynamics.ActiveReports.GroupFooter();
            this.GHROtrosIngresos = new DataDynamics.ActiveReports.GroupHeader();
            this.SRptOtrosIngresos = new DataDynamics.ActiveReports.SubReport();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.groupFooter7 = new DataDynamics.ActiveReports.GroupFooter();
            this.GHRInventario = new DataDynamics.ActiveReports.GroupHeader();
            this.subRptInventario = new DataDynamics.ActiveReports.SubReport();
            this.groupFooter8 = new DataDynamics.ActiveReports.GroupFooter();
            this.GHRLecturas = new DataDynamics.ActiveReports.GroupHeader();
            this.subRptLecturas = new DataDynamics.ActiveReports.SubReport();
            this.groupFooter10 = new DataDynamics.ActiveReports.GroupFooter();
            this.GHRCarrosAtendidos = new DataDynamics.ActiveReports.GroupHeader();
            this.subReport1 = new DataDynamics.ActiveReports.SubReport();
            this.groupFooter11 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.ColumnSpacing = 0F;
            this.detail.Height = 0F;
            this.detail.Name = "detail";
            // 
            // reportHeader1
            // 
            this.reportHeader1.Height = 0.25F;
            this.reportHeader1.Name = "reportHeader1";
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0.25F;
            this.reportFooter1.Name = "reportFooter1";
            this.reportFooter1.Format += new System.EventHandler(this.reportFooter1_Format);
            // 
            // pageHeader
            // 
            this.pageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label,
            this.lblFecha,
            this.lblHora,
            this.lblTituloFechas,
            this.srptEncabezado});
            this.pageHeader.Height = 1.395833F;
            this.pageHeader.Name = "pageHeader";
            this.pageHeader.Format += new System.EventHandler(this.pageHeader_Format);
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
            this.Label.Left = 2.5625F;
            this.Label.Name = "Label";
            this.Label.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.Label.Text = "Resumen Diario Detallado de Transacciones";
            this.Label.Top = 0.875F;
            this.Label.Width = 4.4375F;
            // 
            // lblFecha
            // 
            this.lblFecha.Border.BottomColor = System.Drawing.Color.Black;
            this.lblFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFecha.Border.LeftColor = System.Drawing.Color.Black;
            this.lblFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFecha.Border.RightColor = System.Drawing.Color.Black;
            this.lblFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFecha.Border.TopColor = System.Drawing.Color.Black;
            this.lblFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblFecha.Height = 0.2F;
            this.lblFecha.HyperLink = null;
            this.lblFecha.Left = 8F;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Style = "";
            this.lblFecha.Text = "Fecha";
            this.lblFecha.Top = 0.8125F;
            this.lblFecha.Width = 1.625F;
            // 
            // lblHora
            // 
            this.lblHora.Border.BottomColor = System.Drawing.Color.Black;
            this.lblHora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHora.Border.LeftColor = System.Drawing.Color.Black;
            this.lblHora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHora.Border.RightColor = System.Drawing.Color.Black;
            this.lblHora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHora.Border.TopColor = System.Drawing.Color.Black;
            this.lblHora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblHora.Height = 0.2F;
            this.lblHora.HyperLink = null;
            this.lblHora.Left = 8F;
            this.lblHora.Name = "lblHora";
            this.lblHora.Style = "";
            this.lblHora.Text = "Hora";
            this.lblHora.Top = 1F;
            this.lblHora.Width = 1.625F;
            // 
            // lblTituloFechas
            // 
            this.lblTituloFechas.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTituloFechas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFechas.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTituloFechas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFechas.Border.RightColor = System.Drawing.Color.Black;
            this.lblTituloFechas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFechas.Border.TopColor = System.Drawing.Color.Black;
            this.lblTituloFechas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTituloFechas.Height = 0.2F;
            this.lblTituloFechas.HyperLink = null;
            this.lblTituloFechas.Left = 2.5625F;
            this.lblTituloFechas.Name = "lblTituloFechas";
            this.lblTituloFechas.Style = "text-align: center; font-weight: bold; ";
            this.lblTituloFechas.Text = "Fecha & Fecha";
            this.lblTituloFechas.Top = 1.125F;
            this.lblTituloFechas.Width = 4.4375F;
            // 
            // srptEncabezado
            // 
            this.srptEncabezado.Border.BottomColor = System.Drawing.Color.Black;
            this.srptEncabezado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptEncabezado.Border.LeftColor = System.Drawing.Color.Black;
            this.srptEncabezado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptEncabezado.Border.RightColor = System.Drawing.Color.Black;
            this.srptEncabezado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptEncabezado.Border.TopColor = System.Drawing.Color.Black;
            this.srptEncabezado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptEncabezado.CloseBorder = false;
            this.srptEncabezado.Height = 0.5905511F;
            this.srptEncabezado.Left = 2.0625F;
            this.srptEncabezado.Name = "srptEncabezado";
            this.srptEncabezado.Report = null;
            this.srptEncabezado.ReportName = "SubEncabezado";
            this.srptEncabezado.Top = 0.1875F;
            this.srptEncabezado.Width = 5.536417F;
            // 
            // pageFooter
            // 
            this.pageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label1,
            this.Label2,
            this.lblAno,
            this.txtNumeroPaginas,
            this.lblDe,
            this.txtNumeroPagina,
            this.lblPagina});
            this.pageFooter.Height = 0.5159722F;
            this.pageFooter.Name = "pageFooter";
            this.pageFooter.Format += new System.EventHandler(this.pageFooter_Format);
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.2F;
            this.Label1.HyperLink = null;
            this.Label1.Left = 0.12F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 1; font-weight: bold; ";
            this.Label1.Text = "Servipunto Módulo de Estación";
            this.Label1.Top = 0F;
            this.Label1.Width = 4.25F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.2F;
            this.Label2.HyperLink = null;
            this.Label2.Left = 0.12F;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: Arial; ";
            this.Label2.Text = "© Copyright             Zencillo de Software Ltda. Todos los Derechos Reservado" +
                "s.";
            this.Label2.Top = 0.24F;
            this.Label2.Width = 4.3125F;
            // 
            // lblAno
            // 
            this.lblAno.Border.BottomColor = System.Drawing.Color.Black;
            this.lblAno.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAno.Border.LeftColor = System.Drawing.Color.Black;
            this.lblAno.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAno.Border.RightColor = System.Drawing.Color.Black;
            this.lblAno.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAno.Border.TopColor = System.Drawing.Color.Black;
            this.lblAno.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblAno.Height = 0.2F;
            this.lblAno.HyperLink = null;
            this.lblAno.Left = 0.68F;
            this.lblAno.Name = "lblAno";
            this.lblAno.Style = "text-align: center; font-size: 8.25pt; ";
            this.lblAno.Text = "año";
            this.lblAno.Top = 0.24F;
            this.lblAno.Width = 0.375F;
            // 
            // txtNumeroPaginas
            // 
            this.txtNumeroPaginas.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNumeroPaginas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPaginas.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNumeroPaginas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPaginas.Border.RightColor = System.Drawing.Color.Black;
            this.txtNumeroPaginas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPaginas.Border.TopColor = System.Drawing.Color.Black;
            this.txtNumeroPaginas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPaginas.Height = 0.2F;
            this.txtNumeroPaginas.Left = 9.24F;
            this.txtNumeroPaginas.Name = "txtNumeroPaginas";
            this.txtNumeroPaginas.Style = "text-align: center; ";
            this.txtNumeroPaginas.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPaginas.Text = "##";
            this.txtNumeroPaginas.Top = 0.32F;
            this.txtNumeroPaginas.Width = 0.5054207F;
            // 
            // lblDe
            // 
            this.lblDe.Border.BottomColor = System.Drawing.Color.Black;
            this.lblDe.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDe.Border.LeftColor = System.Drawing.Color.Black;
            this.lblDe.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDe.Border.RightColor = System.Drawing.Color.Black;
            this.lblDe.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDe.Border.TopColor = System.Drawing.Color.Black;
            this.lblDe.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblDe.Height = 0.2F;
            this.lblDe.HyperLink = null;
            this.lblDe.Left = 9.08F;
            this.lblDe.Name = "lblDe";
            this.lblDe.Style = "font-size: 8pt; ";
            this.lblDe.Text = "de";
            this.lblDe.Top = 0.32F;
            this.lblDe.Width = 0.1668492F;
            // 
            // txtNumeroPagina
            // 
            this.txtNumeroPagina.Border.BottomColor = System.Drawing.Color.Black;
            this.txtNumeroPagina.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPagina.Border.LeftColor = System.Drawing.Color.Black;
            this.txtNumeroPagina.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPagina.Border.RightColor = System.Drawing.Color.Black;
            this.txtNumeroPagina.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPagina.Border.TopColor = System.Drawing.Color.Black;
            this.txtNumeroPagina.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtNumeroPagina.Height = 0.2F;
            this.txtNumeroPagina.Left = 8.6F;
            this.txtNumeroPagina.Name = "txtNumeroPagina";
            this.txtNumeroPagina.Style = "text-align: center; ";
            this.txtNumeroPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtNumeroPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPagina.Text = "#";
            this.txtNumeroPagina.Top = 0.32F;
            this.txtNumeroPagina.Width = 0.4542451F;
            // 
            // lblPagina
            // 
            this.lblPagina.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPagina.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPagina.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPagina.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPagina.Border.RightColor = System.Drawing.Color.Black;
            this.lblPagina.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPagina.Border.TopColor = System.Drawing.Color.Black;
            this.lblPagina.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPagina.Height = 0.2F;
            this.lblPagina.HyperLink = null;
            this.lblPagina.Left = 8.24F;
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Style = "font-size: 8pt; ";
            this.lblPagina.Text = "Pagina";
            this.lblPagina.Top = 0.32F;
            this.lblPagina.Width = 0.375F;
            // 
            // GHVentasCombustible
            // 
            this.GHVentasCombustible.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SRptVentasCombustible,
            this.line1});
            this.GHVentasCombustible.Height = 1.09375F;
            this.GHVentasCombustible.Name = "GHVentasCombustible";
            this.GHVentasCombustible.Format += new System.EventHandler(this.GHVentasCombustible_Format);
            // 
            // SRptVentasCombustible
            // 
            this.SRptVentasCombustible.Border.BottomColor = System.Drawing.Color.Black;
            this.SRptVentasCombustible.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptVentasCombustible.Border.LeftColor = System.Drawing.Color.Black;
            this.SRptVentasCombustible.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptVentasCombustible.Border.RightColor = System.Drawing.Color.Black;
            this.SRptVentasCombustible.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptVentasCombustible.Border.TopColor = System.Drawing.Color.Black;
            this.SRptVentasCombustible.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptVentasCombustible.CloseBorder = false;
            this.SRptVentasCombustible.Height = 1F;
            this.SRptVentasCombustible.Left = 0.48F;
            this.SRptVentasCombustible.Name = "SRptVentasCombustible";
            this.SRptVentasCombustible.Report = null;
            this.SRptVentasCombustible.ReportName = "subReport1";
            this.SRptVentasCombustible.Top = 0.04F;
            this.SRptVentasCombustible.Width = 9.08F;
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
            this.line1.Left = 0.36F;
            this.line1.LineWeight = 3F;
            this.line1.Name = "line1";
            this.line1.Top = 0F;
            this.line1.Width = 9.320001F;
            this.line1.X1 = 0.36F;
            this.line1.X2 = 9.68F;
            this.line1.Y1 = 0F;
            this.line1.Y2 = 0F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // GHRVentasCanastilla
            // 
            this.GHRVentasCanastilla.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SRptVentasCanastilla,
            this.line7});
            this.GHRVentasCanastilla.Height = 1.09375F;
            this.GHRVentasCanastilla.Name = "GHRVentasCanastilla";
            this.GHRVentasCanastilla.Format += new System.EventHandler(this.GHRVentasCanastilla_Format);
            // 
            // SRptVentasCanastilla
            // 
            this.SRptVentasCanastilla.Border.BottomColor = System.Drawing.Color.Black;
            this.SRptVentasCanastilla.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptVentasCanastilla.Border.LeftColor = System.Drawing.Color.Black;
            this.SRptVentasCanastilla.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptVentasCanastilla.Border.RightColor = System.Drawing.Color.Black;
            this.SRptVentasCanastilla.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptVentasCanastilla.Border.TopColor = System.Drawing.Color.Black;
            this.SRptVentasCanastilla.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptVentasCanastilla.CloseBorder = false;
            this.SRptVentasCanastilla.Height = 1F;
            this.SRptVentasCanastilla.Left = 0.44F;
            this.SRptVentasCanastilla.Name = "SRptVentasCanastilla";
            this.SRptVentasCanastilla.Report = null;
            this.SRptVentasCanastilla.ReportName = "subReport1";
            this.SRptVentasCanastilla.Top = 0.04F;
            this.SRptVentasCanastilla.Width = 9.08F;
            // 
            // line7
            // 
            this.line7.Border.BottomColor = System.Drawing.Color.Black;
            this.line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.LeftColor = System.Drawing.Color.Black;
            this.line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.RightColor = System.Drawing.Color.Black;
            this.line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.TopColor = System.Drawing.Color.Black;
            this.line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Height = 0F;
            this.line7.Left = 0.32F;
            this.line7.LineWeight = 3F;
            this.line7.Name = "line7";
            this.line7.Top = 0F;
            this.line7.Width = 9.32F;
            this.line7.X1 = 0.32F;
            this.line7.X2 = 9.639999F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
            // 
            // groupFooter2
            // 
            this.groupFooter2.Height = 0F;
            this.groupFooter2.Name = "groupFooter2";
            // 
            // GRHCombYCanastilla
            // 
            this.GRHCombYCanastilla.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SRPTCombyCanastilla,
            this.line9});
            this.GRHCombYCanastilla.Height = 0.7388889F;
            this.GRHCombYCanastilla.Name = "GRHCombYCanastilla";
            // 
            // SRPTCombyCanastilla
            // 
            this.SRPTCombyCanastilla.Border.BottomColor = System.Drawing.Color.Black;
            this.SRPTCombyCanastilla.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRPTCombyCanastilla.Border.LeftColor = System.Drawing.Color.Black;
            this.SRPTCombyCanastilla.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRPTCombyCanastilla.Border.RightColor = System.Drawing.Color.Black;
            this.SRPTCombyCanastilla.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRPTCombyCanastilla.Border.TopColor = System.Drawing.Color.Black;
            this.SRPTCombyCanastilla.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRPTCombyCanastilla.CloseBorder = false;
            this.SRPTCombyCanastilla.Height = 0.5F;
            this.SRPTCombyCanastilla.Left = 0.4375F;
            this.SRPTCombyCanastilla.Name = "SRPTCombyCanastilla";
            this.SRPTCombyCanastilla.Report = null;
            this.SRPTCombyCanastilla.ReportName = "subReport1";
            this.SRPTCombyCanastilla.Top = 0.125F;
            this.SRPTCombyCanastilla.Width = 9.125F;
            // 
            // line9
            // 
            this.line9.Border.BottomColor = System.Drawing.Color.Black;
            this.line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.LeftColor = System.Drawing.Color.Black;
            this.line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.RightColor = System.Drawing.Color.Black;
            this.line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.TopColor = System.Drawing.Color.Black;
            this.line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Height = 0F;
            this.line9.Left = 0.25F;
            this.line9.LineWeight = 3F;
            this.line9.Name = "line9";
            this.line9.Top = 0.0625F;
            this.line9.Width = 9.3125F;
            this.line9.X1 = 0.25F;
            this.line9.X2 = 9.5625F;
            this.line9.Y1 = 0.0625F;
            this.line9.Y2 = 0.0625F;
            // 
            // groupFooter9
            // 
            this.groupFooter9.Height = 0.25F;
            this.groupFooter9.Name = "groupFooter9";
            // 
            // GHRFormaPago
            // 
            this.GHRFormaPago.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SRptFormaPago,
            this.line2});
            this.GHRFormaPago.Height = 1.1875F;
            this.GHRFormaPago.Name = "GHRFormaPago";
            this.GHRFormaPago.Format += new System.EventHandler(this.GHRFormaPago_Format);
            // 
            // SRptFormaPago
            // 
            this.SRptFormaPago.Border.BottomColor = System.Drawing.Color.Black;
            this.SRptFormaPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptFormaPago.Border.LeftColor = System.Drawing.Color.Black;
            this.SRptFormaPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptFormaPago.Border.RightColor = System.Drawing.Color.Black;
            this.SRptFormaPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptFormaPago.Border.TopColor = System.Drawing.Color.Black;
            this.SRptFormaPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptFormaPago.CloseBorder = false;
            this.SRptFormaPago.Height = 1F;
            this.SRptFormaPago.Left = 0.5F;
            this.SRptFormaPago.Name = "SRptFormaPago";
            this.SRptFormaPago.Report = null;
            this.SRptFormaPago.ReportName = "subReport1";
            this.SRptFormaPago.Top = 0.125F;
            this.SRptFormaPago.Width = 9.08F;
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
            this.line2.Left = 0.375F;
            this.line2.LineWeight = 3F;
            this.line2.Name = "line2";
            this.line2.Top = 0.0625F;
            this.line2.Width = 9.3125F;
            this.line2.X1 = 0.375F;
            this.line2.X2 = 9.6875F;
            this.line2.Y1 = 0.0625F;
            this.line2.Y2 = 0.0625F;
            // 
            // groupFooter3
            // 
            this.groupFooter3.Height = 0F;
            this.groupFooter3.Name = "groupFooter3";
            // 
            // GHRConsignacion
            // 
            this.GHRConsignacion.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SRptConsignacion,
            this.line4});
            this.GHRConsignacion.Height = 1.104167F;
            this.GHRConsignacion.Name = "GHRConsignacion";
            this.GHRConsignacion.Format += new System.EventHandler(this.GHRConsignacion_Format);
            // 
            // SRptConsignacion
            // 
            this.SRptConsignacion.Border.BottomColor = System.Drawing.Color.Black;
            this.SRptConsignacion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptConsignacion.Border.LeftColor = System.Drawing.Color.Black;
            this.SRptConsignacion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptConsignacion.Border.RightColor = System.Drawing.Color.Black;
            this.SRptConsignacion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptConsignacion.Border.TopColor = System.Drawing.Color.Black;
            this.SRptConsignacion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptConsignacion.CloseBorder = false;
            this.SRptConsignacion.Height = 1F;
            this.SRptConsignacion.Left = 0.48F;
            this.SRptConsignacion.Name = "SRptConsignacion";
            this.SRptConsignacion.Report = null;
            this.SRptConsignacion.ReportName = "subReport1";
            this.SRptConsignacion.Top = 0.04F;
            this.SRptConsignacion.Width = 9.08F;
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
            this.line4.Left = 0.36F;
            this.line4.LineWeight = 3F;
            this.line4.Name = "line4";
            this.line4.Top = 0F;
            this.line4.Width = 9.320001F;
            this.line4.X1 = 0.36F;
            this.line4.X2 = 9.68F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // groupFooter5
            // 
            this.groupFooter5.Height = 0F;
            this.groupFooter5.Name = "groupFooter5";
            // 
            // GHRDescuadre
            // 
            this.GHRDescuadre.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SRptDescuadre,
            this.line5});
            this.GHRDescuadre.Height = 1.039583F;
            this.GHRDescuadre.Name = "GHRDescuadre";
            this.GHRDescuadre.Format += new System.EventHandler(this.GHRDescuadre_Format);
            // 
            // SRptDescuadre
            // 
            this.SRptDescuadre.Border.BottomColor = System.Drawing.Color.Black;
            this.SRptDescuadre.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptDescuadre.Border.LeftColor = System.Drawing.Color.Black;
            this.SRptDescuadre.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptDescuadre.Border.RightColor = System.Drawing.Color.Black;
            this.SRptDescuadre.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptDescuadre.Border.TopColor = System.Drawing.Color.Black;
            this.SRptDescuadre.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptDescuadre.CloseBorder = false;
            this.SRptDescuadre.Height = 1F;
            this.SRptDescuadre.Left = 0.48F;
            this.SRptDescuadre.Name = "SRptDescuadre";
            this.SRptDescuadre.Report = null;
            this.SRptDescuadre.ReportName = "subReport1";
            this.SRptDescuadre.Top = 0.04F;
            this.SRptDescuadre.Width = 9.08F;
            // 
            // line5
            // 
            this.line5.Border.BottomColor = System.Drawing.Color.Black;
            this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.LeftColor = System.Drawing.Color.Black;
            this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.RightColor = System.Drawing.Color.Black;
            this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.TopColor = System.Drawing.Color.Black;
            this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Height = 0F;
            this.line5.Left = 0.36F;
            this.line5.LineWeight = 3F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 9.320001F;
            this.line5.X1 = 0.36F;
            this.line5.X2 = 9.68F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // groupFooter6
            // 
            this.groupFooter6.Height = 0F;
            this.groupFooter6.Name = "groupFooter6";
            // 
            // GHROtrosIngresos
            // 
            this.GHROtrosIngresos.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SRptOtrosIngresos,
            this.line6});
            this.GHROtrosIngresos.Height = 1.125F;
            this.GHROtrosIngresos.Name = "GHROtrosIngresos";
            this.GHROtrosIngresos.Format += new System.EventHandler(this.GHROtrosIngresos_Format);
            // 
            // SRptOtrosIngresos
            // 
            this.SRptOtrosIngresos.Border.BottomColor = System.Drawing.Color.Black;
            this.SRptOtrosIngresos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptOtrosIngresos.Border.LeftColor = System.Drawing.Color.Black;
            this.SRptOtrosIngresos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptOtrosIngresos.Border.RightColor = System.Drawing.Color.Black;
            this.SRptOtrosIngresos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptOtrosIngresos.Border.TopColor = System.Drawing.Color.Black;
            this.SRptOtrosIngresos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SRptOtrosIngresos.CloseBorder = false;
            this.SRptOtrosIngresos.Height = 1F;
            this.SRptOtrosIngresos.Left = 0.48F;
            this.SRptOtrosIngresos.Name = "SRptOtrosIngresos";
            this.SRptOtrosIngresos.Report = null;
            this.SRptOtrosIngresos.ReportName = "subReport1";
            this.SRptOtrosIngresos.Top = 0.04F;
            this.SRptOtrosIngresos.Width = 9.08F;
            // 
            // line6
            // 
            this.line6.Border.BottomColor = System.Drawing.Color.Black;
            this.line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.LeftColor = System.Drawing.Color.Black;
            this.line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.RightColor = System.Drawing.Color.Black;
            this.line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.TopColor = System.Drawing.Color.Black;
            this.line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Height = 0F;
            this.line6.Left = 0.36F;
            this.line6.LineWeight = 3F;
            this.line6.Name = "line6";
            this.line6.Top = 0F;
            this.line6.Width = 9.320001F;
            this.line6.X1 = 0.36F;
            this.line6.X2 = 9.68F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
            // 
            // groupFooter7
            // 
            this.groupFooter7.Height = 0F;
            this.groupFooter7.Name = "groupFooter7";
            // 
            // GHRInventario
            // 
            this.GHRInventario.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subRptInventario});
            this.GHRInventario.Height = 2.051389F;
            this.GHRInventario.Name = "GHRInventario";
            this.GHRInventario.Format += new System.EventHandler(this.GHRInventario_Format);
            // 
            // subRptInventario
            // 
            this.subRptInventario.Border.BottomColor = System.Drawing.Color.Black;
            this.subRptInventario.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subRptInventario.Border.LeftColor = System.Drawing.Color.Black;
            this.subRptInventario.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subRptInventario.Border.RightColor = System.Drawing.Color.Black;
            this.subRptInventario.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subRptInventario.Border.TopColor = System.Drawing.Color.Black;
            this.subRptInventario.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subRptInventario.CloseBorder = false;
            this.subRptInventario.Height = 1.6875F;
            this.subRptInventario.Left = 0.4375F;
            this.subRptInventario.Name = "subRptInventario";
            this.subRptInventario.Report = null;
            this.subRptInventario.ReportName = "subReport1";
            this.subRptInventario.Top = 0.1875F;
            this.subRptInventario.Width = 9.0625F;
            // 
            // groupFooter8
            // 
            this.groupFooter8.Height = 0F;
            this.groupFooter8.Name = "groupFooter8";
            // 
            // GHRLecturas
            // 
            this.GHRLecturas.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subRptLecturas});
            this.GHRLecturas.Height = 1.707639F;
            this.GHRLecturas.Name = "GHRLecturas";
            this.GHRLecturas.Format += new System.EventHandler(this.GHRLecturas_Format);
            // 
            // subRptLecturas
            // 
            this.subRptLecturas.Border.BottomColor = System.Drawing.Color.Black;
            this.subRptLecturas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subRptLecturas.Border.LeftColor = System.Drawing.Color.Black;
            this.subRptLecturas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subRptLecturas.Border.RightColor = System.Drawing.Color.Black;
            this.subRptLecturas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subRptLecturas.Border.TopColor = System.Drawing.Color.Black;
            this.subRptLecturas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subRptLecturas.CloseBorder = false;
            this.subRptLecturas.Height = 1.5F;
            this.subRptLecturas.Left = 0.4375F;
            this.subRptLecturas.Name = "subRptLecturas";
            this.subRptLecturas.Report = null;
            this.subRptLecturas.ReportName = "subReport1";
            this.subRptLecturas.Top = 0.0625F;
            this.subRptLecturas.Width = 9.0625F;
            // 
            // groupFooter10
            // 
            this.groupFooter10.Height = 0.02013889F;
            this.groupFooter10.Name = "groupFooter10";
            // 
            // GHRCarrosAtendidos
            // 
            this.GHRCarrosAtendidos.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.subReport1});
            this.GHRCarrosAtendidos.Height = 1.229167F;
            this.GHRCarrosAtendidos.Name = "GHRCarrosAtendidos";
            // 
            // subReport1
            // 
            this.subReport1.Border.BottomColor = System.Drawing.Color.Black;
            this.subReport1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.LeftColor = System.Drawing.Color.Black;
            this.subReport1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.RightColor = System.Drawing.Color.Black;
            this.subReport1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.Border.TopColor = System.Drawing.Color.Black;
            this.subReport1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.subReport1.CloseBorder = false;
            this.subReport1.Height = 1F;
            this.subReport1.Left = 0.4375F;
            this.subReport1.Name = "subReport1";
            this.subReport1.Report = null;
            this.subReport1.ReportName = "subReport1";
            this.subReport1.Top = 0.125F;
            this.subReport1.Width = 9.0625F;
            // 
            // groupFooter11
            // 
            this.groupFooter11.Height = 0F;
            this.groupFooter11.Name = "groupFooter11";
            // 
            // ResumenDiarioDetallado
            // 
            this.MasterReport = false;
            this.PageSettings.Gutter = 0.5F;
            this.PageSettings.Margins.Bottom = 0.5F;
            this.PageSettings.Margins.Left = 0.5F;
            this.PageSettings.Margins.Right = 0.5F;
            this.PageSettings.Margins.Top = 0.5F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Portrait;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 9.979167F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.pageHeader);
            this.Sections.Add(this.GHVentasCombustible);
            this.Sections.Add(this.GHRVentasCanastilla);
            this.Sections.Add(this.GRHCombYCanastilla);
            this.Sections.Add(this.GHRFormaPago);
            this.Sections.Add(this.GHRConsignacion);
            this.Sections.Add(this.GHRDescuadre);
            this.Sections.Add(this.GHROtrosIngresos);
            this.Sections.Add(this.GHRInventario);
            this.Sections.Add(this.GHRLecturas);
            this.Sections.Add(this.GHRCarrosAtendidos);
            this.Sections.Add(this.detail);
            this.Sections.Add(this.groupFooter11);
            this.Sections.Add(this.groupFooter10);
            this.Sections.Add(this.groupFooter8);
            this.Sections.Add(this.groupFooter7);
            this.Sections.Add(this.groupFooter6);
            this.Sections.Add(this.groupFooter5);
            this.Sections.Add(this.groupFooter3);
            this.Sections.Add(this.groupFooter9);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.groupFooter1);
            this.Sections.Add(this.pageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DataDynamics.ActiveReports.Detail detail;
        private DataDynamics.ActiveReports.ReportHeader reportHeader1;
        private DataDynamics.ActiveReports.ReportFooter reportFooter1;
        private DataDynamics.ActiveReports.PageHeader pageHeader;
        private DataDynamics.ActiveReports.Label Label;
        private DataDynamics.ActiveReports.Label lblFecha;
        private DataDynamics.ActiveReports.Label lblHora;
        private DataDynamics.ActiveReports.Label lblTituloFechas;
        private DataDynamics.ActiveReports.SubReport srptEncabezado;
        private DataDynamics.ActiveReports.PageFooter pageFooter;
        private DataDynamics.ActiveReports.Label Label1;
        private DataDynamics.ActiveReports.Label Label2;
        private DataDynamics.ActiveReports.Label lblAno;
        private DataDynamics.ActiveReports.TextBox txtNumeroPaginas;
        private DataDynamics.ActiveReports.Label lblDe;
        private DataDynamics.ActiveReports.TextBox txtNumeroPagina;
        private DataDynamics.ActiveReports.Label lblPagina;
        private DataDynamics.ActiveReports.GroupHeader GHVentasCombustible;
        private DataDynamics.ActiveReports.SubReport SRptVentasCombustible;
        private DataDynamics.ActiveReports.Line line1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter1;
        private DataDynamics.ActiveReports.GroupHeader GHRVentasCanastilla;
        private DataDynamics.ActiveReports.SubReport SRptVentasCanastilla;
        private DataDynamics.ActiveReports.Line line7;
        private DataDynamics.ActiveReports.GroupFooter groupFooter2;
        private DataDynamics.ActiveReports.GroupHeader GRHCombYCanastilla;
        private DataDynamics.ActiveReports.SubReport SRPTCombyCanastilla;
        private DataDynamics.ActiveReports.Line line9;
        private DataDynamics.ActiveReports.GroupFooter groupFooter9;
        private DataDynamics.ActiveReports.GroupHeader GHRFormaPago;
        private DataDynamics.ActiveReports.SubReport SRptFormaPago;
        private DataDynamics.ActiveReports.Line line2;
        private DataDynamics.ActiveReports.GroupFooter groupFooter3;
        private DataDynamics.ActiveReports.GroupHeader GHRConsignacion;
        private DataDynamics.ActiveReports.SubReport SRptConsignacion;
        private DataDynamics.ActiveReports.Line line4;
        private DataDynamics.ActiveReports.GroupFooter groupFooter5;
        private DataDynamics.ActiveReports.GroupHeader GHRDescuadre;
        private DataDynamics.ActiveReports.SubReport SRptDescuadre;
        private DataDynamics.ActiveReports.Line line5;
        private DataDynamics.ActiveReports.GroupFooter groupFooter6;
        private DataDynamics.ActiveReports.GroupHeader GHROtrosIngresos;
        private DataDynamics.ActiveReports.SubReport SRptOtrosIngresos;
        private DataDynamics.ActiveReports.Line line6;
        private DataDynamics.ActiveReports.GroupFooter groupFooter7;
        private DataDynamics.ActiveReports.GroupHeader GHRInventario;
        private DataDynamics.ActiveReports.SubReport subRptInventario;
        private DataDynamics.ActiveReports.GroupFooter groupFooter8;
        private DataDynamics.ActiveReports.GroupHeader GHRLecturas;
        private DataDynamics.ActiveReports.SubReport subRptLecturas;
        private DataDynamics.ActiveReports.GroupFooter groupFooter10;
        private DataDynamics.ActiveReports.GroupHeader GHRCarrosAtendidos;
        private DataDynamics.ActiveReports.SubReport subReport1;
        private DataDynamics.ActiveReports.GroupFooter groupFooter11;
    }
}
