namespace Servipunto.Estacion.Web.Modules.Rpt
{
    /// <summary>
    /// Summary description for VentasLecturas.
    /// </summary>
    partial class VentasLecturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasLecturas));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.ghTotal = new DataDynamics.ActiveReports.GroupHeader();
            this.gfTotal = new DataDynamics.ActiveReports.GroupFooter();
            this.lblHora = new DataDynamics.ActiveReports.Label();
            this.lblManguera = new DataDynamics.ActiveReports.Label();
            this.Line = new DataDynamics.ActiveReports.Line();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.lblFecha = new DataDynamics.ActiveReports.Label();
            this.srptEncabezado = new DataDynamics.ActiveReports.SubReport();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.lblTituloFechas = new DataDynamics.ActiveReports.Label();
            this.lblLecturasPorVentas = new DataDynamics.ActiveReports.Label();
            this.lbllecturaFinal = new DataDynamics.ActiveReports.Label();
            this.lblLecturaInicial = new DataDynamics.ActiveReports.Label();
            this.lblLecturaSurtidor = new DataDynamics.ActiveReports.Label();
            this.txtManguera = new DataDynamics.ActiveReports.TextBox();
            this.txtLecturaInicial = new DataDynamics.ActiveReports.TextBox();
            this.txtLecturaFinal = new DataDynamics.ActiveReports.TextBox();
            this.txtDiferenciaPorVentas = new DataDynamics.ActiveReports.TextBox();
            this.txtLecturaSurtidor = new DataDynamics.ActiveReports.TextBox();
            this.srptFormasPago = new DataDynamics.ActiveReports.SubReport();
            this.srptGrafica = new DataDynamics.ActiveReports.SubReport();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.TextBox1 = new DataDynamics.ActiveReports.TextBox();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.lblModulo = new DataDynamics.ActiveReports.Label();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.lblPagina = new DataDynamics.ActiveReports.Label();
            this.lblDe = new DataDynamics.ActiveReports.Label();
            this.lblAno = new DataDynamics.ActiveReports.Label();
            this.txtNumeroPagina = new DataDynamics.ActiveReports.TextBox();
            this.txtNumeroPaginas = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblManguera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLecturasPorVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbllecturaFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLecturaInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLecturaSurtidor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManguera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLecturaInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLecturaFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiferenciaPorVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLecturaSurtidor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txtManguera,
            this.txtLecturaInicial,
            this.txtLecturaFinal,
            this.txtDiferenciaPorVentas,
            this.txtLecturaSurtidor});
            this.Detail.Height = 0.25F;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblHora,
            this.lblManguera,
            this.Line,
            this.Line1,
            this.lblFecha,
            this.srptEncabezado,
            this.Label15,
            this.lblTituloFechas,
            this.lblLecturasPorVentas,
            this.lbllecturaFinal,
            this.lblLecturaInicial,
            this.lblLecturaSurtidor});
            this.PageHeader.Height = 1.552083F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.lblModulo,
            this.Label,
            this.lblPagina,
            this.lblDe,
            this.lblAno,
            this.txtNumeroPagina,
            this.txtNumeroPaginas});
            this.PageFooter.Height = 0.40625F;
            this.PageFooter.Name = "PageFooter";
            // 
            // ghTotal
            // 
            this.ghTotal.Height = 0F;
            this.ghTotal.Name = "ghTotal";
            // 
            // gfTotal
            // 
            this.gfTotal.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.srptFormasPago,
            this.srptGrafica,
            this.TextBox,
            this.TextBox1,
            this.Label1});
            this.gfTotal.Height = 2.832639F;
            this.gfTotal.Name = "gfTotal";
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
            this.lblHora.Left = 6.348428F;
            this.lblHora.Name = "lblHora";
            this.lblHora.Style = "";
            this.lblHora.Text = "Hora:";
            this.lblHora.Top = 0.8038382F;
            this.lblHora.Width = 1.181105F;
            // 
            // lblManguera
            // 
            this.lblManguera.Border.BottomColor = System.Drawing.Color.Black;
            this.lblManguera.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblManguera.Border.LeftColor = System.Drawing.Color.Black;
            this.lblManguera.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblManguera.Border.RightColor = System.Drawing.Color.Black;
            this.lblManguera.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblManguera.Border.TopColor = System.Drawing.Color.Black;
            this.lblManguera.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblManguera.Height = 0.2F;
            this.lblManguera.HyperLink = null;
            this.lblManguera.Left = 0.02460627F;
            this.lblManguera.Name = "lblManguera";
            this.lblManguera.Style = "text-align: center; ";
            this.lblManguera.Text = "Manguera";
            this.lblManguera.Top = 1.304134F;
            this.lblManguera.Width = 0.8858271F;
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
            this.Line.Left = 0F;
            this.Line.LineWeight = 2F;
            this.Line.Name = "Line";
            this.Line.Top = 1.279528F;
            this.Line.Width = 7.627952F;
            this.Line.X1 = 0F;
            this.Line.X2 = 7.627952F;
            this.Line.Y1 = 1.279528F;
            this.Line.Y2 = 1.279528F;
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
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 2F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 1.52559F;
            this.Line1.Width = 7.627952F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 7.627952F;
            this.Line1.Y1 = 1.52559F;
            this.Line1.Y2 = 1.52559F;
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
            this.lblFecha.Left = 6.348428F;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Style = "white-space: inherit; ";
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.Top = 0.5905511F;
            this.lblFecha.Width = 1.230315F;
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
            this.srptEncabezado.Left = 1.058069F;
            this.srptEncabezado.Name = "srptEncabezado";
            this.srptEncabezado.Report = null;
            this.srptEncabezado.ReportName = "SubEncabezado";
            this.srptEncabezado.Top = 0F;
            this.srptEncabezado.Width = 5.536417F;
            // 
            // Label15
            // 
            this.Label15.Border.BottomColor = System.Drawing.Color.Black;
            this.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.LeftColor = System.Drawing.Color.Black;
            this.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.RightColor = System.Drawing.Color.Black;
            this.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.TopColor = System.Drawing.Color.Black;
            this.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Height = 0.2F;
            this.Label15.HyperLink = null;
            this.Label15.Left = 1.230315F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.Label15.Text = "Comparativo Unidades Vendidas Vs Lectura Surtidor";
            this.Label15.Top = 0.7627952F;
            this.Label15.Width = 5.093504F;
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
            this.lblTituloFechas.Left = 1.058069F;
            this.lblTituloFechas.Name = "lblTituloFechas";
            this.lblTituloFechas.Style = "text-align: center; font-weight: bold; font-size: 12pt; ";
            this.lblTituloFechas.Text = "Titulo con las fechas";
            this.lblTituloFechas.Top = 1.008858F;
            this.lblTituloFechas.Width = 5.536417F;
            // 
            // lblLecturasPorVentas
            // 
            this.lblLecturasPorVentas.Border.BottomColor = System.Drawing.Color.Black;
            this.lblLecturasPorVentas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturasPorVentas.Border.LeftColor = System.Drawing.Color.Black;
            this.lblLecturasPorVentas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturasPorVentas.Border.RightColor = System.Drawing.Color.Black;
            this.lblLecturasPorVentas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturasPorVentas.Border.TopColor = System.Drawing.Color.Black;
            this.lblLecturasPorVentas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturasPorVentas.Height = 0.2F;
            this.lblLecturasPorVentas.HyperLink = null;
            this.lblLecturasPorVentas.Left = 5.856299F;
            this.lblLecturasPorVentas.Name = "lblLecturasPorVentas";
            this.lblLecturasPorVentas.Style = "text-align: right; ";
            this.lblLecturasPorVentas.Text = "Diferencia Por Ventas";
            this.lblLecturasPorVentas.Top = 1.304134F;
            this.lblLecturasPorVentas.Width = 1.673229F;
            // 
            // lbllecturaFinal
            // 
            this.lbllecturaFinal.Border.BottomColor = System.Drawing.Color.Black;
            this.lbllecturaFinal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbllecturaFinal.Border.LeftColor = System.Drawing.Color.Black;
            this.lbllecturaFinal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbllecturaFinal.Border.RightColor = System.Drawing.Color.Black;
            this.lbllecturaFinal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbllecturaFinal.Border.TopColor = System.Drawing.Color.Black;
            this.lbllecturaFinal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lbllecturaFinal.Height = 0.2F;
            this.lbllecturaFinal.HyperLink = null;
            this.lbllecturaFinal.Left = 2.042323F;
            this.lbllecturaFinal.Name = "lbllecturaFinal";
            this.lbllecturaFinal.Style = "text-align: right; ";
            this.lbllecturaFinal.Text = "Lectura Final";
            this.lbllecturaFinal.Top = 1.304134F;
            this.lbllecturaFinal.Width = 1.771653F;
            // 
            // lblLecturaInicial
            // 
            this.lblLecturaInicial.Border.BottomColor = System.Drawing.Color.Black;
            this.lblLecturaInicial.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturaInicial.Border.LeftColor = System.Drawing.Color.Black;
            this.lblLecturaInicial.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturaInicial.Border.RightColor = System.Drawing.Color.Black;
            this.lblLecturaInicial.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturaInicial.Border.TopColor = System.Drawing.Color.Black;
            this.lblLecturaInicial.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturaInicial.Height = 0.2F;
            this.lblLecturaInicial.HyperLink = null;
            this.lblLecturaInicial.Left = 0.9842521F;
            this.lblLecturaInicial.Name = "lblLecturaInicial";
            this.lblLecturaInicial.Style = "text-align: right; ";
            this.lblLecturaInicial.Text = "Lectura Inicial";
            this.lblLecturaInicial.Top = 1.304134F;
            this.lblLecturaInicial.Width = 1F;
            // 
            // lblLecturaSurtidor
            // 
            this.lblLecturaSurtidor.Border.BottomColor = System.Drawing.Color.Black;
            this.lblLecturaSurtidor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturaSurtidor.Border.LeftColor = System.Drawing.Color.Black;
            this.lblLecturaSurtidor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturaSurtidor.Border.RightColor = System.Drawing.Color.Black;
            this.lblLecturaSurtidor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturaSurtidor.Border.TopColor = System.Drawing.Color.Black;
            this.lblLecturaSurtidor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblLecturaSurtidor.Height = 0.2F;
            this.lblLecturaSurtidor.HyperLink = null;
            this.lblLecturaSurtidor.Left = 3.887795F;
            this.lblLecturaSurtidor.Name = "lblLecturaSurtidor";
            this.lblLecturaSurtidor.Style = "text-align: right; ";
            this.lblLecturaSurtidor.Text = "Diferencia de Lecturas";
            this.lblLecturaSurtidor.Top = 1.304134F;
            this.lblLecturaSurtidor.Width = 1.943898F;
            // 
            // txtManguera
            // 
            this.txtManguera.Border.BottomColor = System.Drawing.Color.Black;
            this.txtManguera.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtManguera.Border.LeftColor = System.Drawing.Color.Black;
            this.txtManguera.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtManguera.Border.RightColor = System.Drawing.Color.Black;
            this.txtManguera.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtManguera.Border.TopColor = System.Drawing.Color.Black;
            this.txtManguera.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtManguera.DataField = "Manguera";
            this.txtManguera.Height = 0.2F;
            this.txtManguera.Left = 0.04921272F;
            this.txtManguera.Name = "txtManguera";
            this.txtManguera.Style = "text-align: center; font-weight: bold; ";
            this.txtManguera.Text = "Manguera";
            this.txtManguera.Top = 0.0246063F;
            this.txtManguera.Width = 0.8120077F;
            // 
            // txtLecturaInicial
            // 
            this.txtLecturaInicial.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLecturaInicial.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaInicial.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLecturaInicial.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaInicial.Border.RightColor = System.Drawing.Color.Black;
            this.txtLecturaInicial.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaInicial.Border.TopColor = System.Drawing.Color.Black;
            this.txtLecturaInicial.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaInicial.DataField = "LectInicial";
            this.txtLecturaInicial.Height = 0.2F;
            this.txtLecturaInicial.Left = 0.9842521F;
            this.txtLecturaInicial.Name = "txtLecturaInicial";
            this.txtLecturaInicial.OutputFormat = resources.GetString("txtLecturaInicial.OutputFormat");
            this.txtLecturaInicial.Style = "text-align: right; ";
            this.txtLecturaInicial.Text = "Lectura Inicial";
            this.txtLecturaInicial.Top = 0.0246063F;
            this.txtLecturaInicial.Width = 1F;
            // 
            // txtLecturaFinal
            // 
            this.txtLecturaFinal.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLecturaFinal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaFinal.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLecturaFinal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaFinal.Border.RightColor = System.Drawing.Color.Black;
            this.txtLecturaFinal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaFinal.Border.TopColor = System.Drawing.Color.Black;
            this.txtLecturaFinal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaFinal.DataField = "LectFinal";
            this.txtLecturaFinal.Height = 0.2F;
            this.txtLecturaFinal.Left = 2.042323F;
            this.txtLecturaFinal.Name = "txtLecturaFinal";
            this.txtLecturaFinal.OutputFormat = resources.GetString("txtLecturaFinal.OutputFormat");
            this.txtLecturaFinal.Style = "text-align: right; ";
            this.txtLecturaFinal.Text = "Lectura Final";
            this.txtLecturaFinal.Top = 0.0246063F;
            this.txtLecturaFinal.Width = 1.771652F;
            // 
            // txtDiferenciaPorVentas
            // 
            this.txtDiferenciaPorVentas.Border.BottomColor = System.Drawing.Color.Black;
            this.txtDiferenciaPorVentas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiferenciaPorVentas.Border.LeftColor = System.Drawing.Color.Black;
            this.txtDiferenciaPorVentas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiferenciaPorVentas.Border.RightColor = System.Drawing.Color.Black;
            this.txtDiferenciaPorVentas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiferenciaPorVentas.Border.TopColor = System.Drawing.Color.Black;
            this.txtDiferenciaPorVentas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtDiferenciaPorVentas.DataField = "DifVentas";
            this.txtDiferenciaPorVentas.Height = 0.2F;
            this.txtDiferenciaPorVentas.Left = 5.856299F;
            this.txtDiferenciaPorVentas.Name = "txtDiferenciaPorVentas";
            this.txtDiferenciaPorVentas.OutputFormat = resources.GetString("txtDiferenciaPorVentas.OutputFormat");
            this.txtDiferenciaPorVentas.Style = "text-align: right; ";
            this.txtDiferenciaPorVentas.Text = "DiferenciaPorVentas";
            this.txtDiferenciaPorVentas.Top = 0.0246063F;
            this.txtDiferenciaPorVentas.Width = 1.722441F;
            // 
            // txtLecturaSurtidor
            // 
            this.txtLecturaSurtidor.Border.BottomColor = System.Drawing.Color.Black;
            this.txtLecturaSurtidor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaSurtidor.Border.LeftColor = System.Drawing.Color.Black;
            this.txtLecturaSurtidor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaSurtidor.Border.RightColor = System.Drawing.Color.Black;
            this.txtLecturaSurtidor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaSurtidor.Border.TopColor = System.Drawing.Color.Black;
            this.txtLecturaSurtidor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtLecturaSurtidor.DataField = "DifLects";
            this.txtLecturaSurtidor.Height = 0.2F;
            this.txtLecturaSurtidor.Left = 3.887795F;
            this.txtLecturaSurtidor.Name = "txtLecturaSurtidor";
            this.txtLecturaSurtidor.OutputFormat = resources.GetString("txtLecturaSurtidor.OutputFormat");
            this.txtLecturaSurtidor.Style = "text-align: right; ";
            this.txtLecturaSurtidor.Text = "L. Surtidor";
            this.txtLecturaSurtidor.Top = 0.02460628F;
            this.txtLecturaSurtidor.Width = 1.943898F;
            // 
            // srptFormasPago
            // 
            this.srptFormasPago.Border.BottomColor = System.Drawing.Color.Black;
            this.srptFormasPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptFormasPago.Border.LeftColor = System.Drawing.Color.Black;
            this.srptFormasPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptFormasPago.Border.RightColor = System.Drawing.Color.Black;
            this.srptFormasPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptFormasPago.Border.TopColor = System.Drawing.Color.Black;
            this.srptFormasPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptFormasPago.CloseBorder = false;
            this.srptFormasPago.Height = 0.3198819F;
            this.srptFormasPago.Left = 0.08710785F;
            this.srptFormasPago.Name = "srptFormasPago";
            this.srptFormasPago.Report = null;
            this.srptFormasPago.ReportName = "SubFormasPago";
            this.srptFormasPago.Top = 0.4655504F;
            this.srptFormasPago.Width = 5.511809F;
            // 
            // srptGrafica
            // 
            this.srptGrafica.Border.BottomColor = System.Drawing.Color.Black;
            this.srptGrafica.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptGrafica.Border.LeftColor = System.Drawing.Color.Black;
            this.srptGrafica.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptGrafica.Border.RightColor = System.Drawing.Color.Black;
            this.srptGrafica.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptGrafica.Border.TopColor = System.Drawing.Color.Black;
            this.srptGrafica.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.srptGrafica.CloseBorder = false;
            this.srptGrafica.Height = 1.885827F;
            this.srptGrafica.Left = 0.07381889F;
            this.srptGrafica.Name = "srptGrafica";
            this.srptGrafica.Report = null;
            this.srptGrafica.ReportName = "SubGraficaLecturas.rpx";
            this.srptGrafica.Top = 0.8971459F;
            this.srptGrafica.Width = 7.504923F;
            // 
            // TextBox
            // 
            this.TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Double;
            this.TextBox.DataField = "DifVentas";
            this.TextBox.Height = 0.2F;
            this.TextBox.Left = 5.875F;
            this.TextBox.Name = "TextBox";
            this.TextBox.OutputFormat = resources.GetString("TextBox.OutputFormat");
            this.TextBox.Style = "text-align: right; ";
            this.TextBox.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox.Text = "DiferenciaPorVentas";
            this.TextBox.Top = 0.025F;
            this.TextBox.Width = 1.722441F;
            // 
            // TextBox1
            // 
            this.TextBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox1.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Double;
            this.TextBox1.DataField = "DifLects";
            this.TextBox1.Height = 0.2F;
            this.TextBox1.Left = 3.875F;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.OutputFormat = resources.GetString("TextBox1.OutputFormat");
            this.TextBox1.Style = "text-align: right; ";
            this.TextBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.TextBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TextBox1.Text = "L. Surtidor";
            this.TextBox1.Top = 0.025F;
            this.TextBox1.Width = 1.943898F;
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
            this.Label1.Left = 2.0625F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "text-align: right; font-weight: bold; ";
            this.Label1.Text = "Total";
            this.Label1.Top = 0F;
            this.Label1.Width = 1.771653F;
            // 
            // lblModulo
            // 
            this.lblModulo.Border.BottomColor = System.Drawing.Color.Black;
            this.lblModulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModulo.Border.LeftColor = System.Drawing.Color.Black;
            this.lblModulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModulo.Border.RightColor = System.Drawing.Color.Black;
            this.lblModulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModulo.Border.TopColor = System.Drawing.Color.Black;
            this.lblModulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblModulo.Height = 0.2F;
            this.lblModulo.HyperLink = null;
            this.lblModulo.Left = 0F;
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Style = "font-weight: bold; ";
            this.lblModulo.Text = "Servipunto Módulo de Estación";
            this.lblModulo.Top = 0F;
            this.lblModulo.Width = 2.125F;
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
            this.Label.Style = "font-size: 8pt; ";
            this.Label.Text = "© Copyright           Zencillo de Software Ltda. Todos los Derechos Reservados." +
                "";
            this.Label.Top = 0.1875F;
            this.Label.Width = 4.330709F;
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
            this.lblPagina.Left = 6.120563F;
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Style = "font-size: 8pt; ";
            this.lblPagina.Text = "Pagina";
            this.lblPagina.Top = 0.1875F;
            this.lblPagina.Width = 0.375F;
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
            this.lblDe.Left = 6.955695F;
            this.lblDe.Name = "lblDe";
            this.lblDe.Style = "font-size: 8pt; ";
            this.lblDe.Text = "de";
            this.lblDe.Top = 0.1875F;
            this.lblDe.Width = 0.1668492F;
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
            this.lblAno.Left = 0.6250003F;
            this.lblAno.Name = "lblAno";
            this.lblAno.Style = "font-size: 8pt; ";
            this.lblAno.Text = "Año";
            this.lblAno.Top = 0.1875F;
            this.lblAno.Width = 0.375F;
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
            this.txtNumeroPagina.Left = 6.496063F;
            this.txtNumeroPagina.Name = "txtNumeroPagina";
            this.txtNumeroPagina.Style = "text-align: center; ";
            this.txtNumeroPagina.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtNumeroPagina.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPagina.Text = "#";
            this.txtNumeroPagina.Top = 0.1835629F;
            this.txtNumeroPagina.Width = 0.4542451F;
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
            this.txtNumeroPaginas.Left = 7.135826F;
            this.txtNumeroPaginas.Name = "txtNumeroPaginas";
            this.txtNumeroPaginas.Style = "text-align: center; ";
            this.txtNumeroPaginas.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtNumeroPaginas.Text = "##";
            this.txtNumeroPaginas.Top = 0.1722441F;
            this.txtNumeroPaginas.Width = 0.5167322F;
            // 
            // VentasLecturas
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.39375F;
            this.PageSettings.Margins.Left = 0.39375F;
            this.PageSettings.Margins.Right = 0.39375F;
            this.PageSettings.Margins.Top = 0.39375F;
            this.PageSettings.PaperHeight = 11F;
            this.PageSettings.PaperWidth = 8.5F;
            this.PrintWidth = 7.677083F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ghTotal);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.gfTotal);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.lblHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblManguera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTituloFechas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLecturasPorVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbllecturaFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLecturaInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLecturaSurtidor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtManguera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLecturaInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLecturaFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiferenciaPorVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLecturaSurtidor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPaginas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            // Attach Report Events
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            this.gfTotal.Format += new System.EventHandler(this.gfTotal_Format);
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);

        }
        #endregion

        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.TextBox txtManguera;
        private DataDynamics.ActiveReports.TextBox txtLecturaInicial;
        private DataDynamics.ActiveReports.TextBox txtLecturaFinal;
        private DataDynamics.ActiveReports.TextBox txtDiferenciaPorVentas;
        private DataDynamics.ActiveReports.TextBox txtLecturaSurtidor;
        private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.Label lblHora;
        private DataDynamics.ActiveReports.Label lblManguera;
        private DataDynamics.ActiveReports.Line Line;
        private DataDynamics.ActiveReports.Line Line1;
        private DataDynamics.ActiveReports.Label lblFecha;
        private DataDynamics.ActiveReports.SubReport srptEncabezado;
        private DataDynamics.ActiveReports.Label Label15;
        private DataDynamics.ActiveReports.Label lblTituloFechas;
        private DataDynamics.ActiveReports.Label lblLecturasPorVentas;
        private DataDynamics.ActiveReports.Label lbllecturaFinal;
        private DataDynamics.ActiveReports.Label lblLecturaInicial;
        private DataDynamics.ActiveReports.Label lblLecturaSurtidor;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
        private DataDynamics.ActiveReports.Label lblModulo;
        private DataDynamics.ActiveReports.Label Label;
        private DataDynamics.ActiveReports.Label lblPagina;
        private DataDynamics.ActiveReports.Label lblDe;
        private DataDynamics.ActiveReports.Label lblAno;
        private DataDynamics.ActiveReports.TextBox txtNumeroPagina;
        private DataDynamics.ActiveReports.TextBox txtNumeroPaginas;
        private DataDynamics.ActiveReports.GroupHeader ghTotal;
        private DataDynamics.ActiveReports.GroupFooter gfTotal;
        private DataDynamics.ActiveReports.SubReport srptFormasPago;
        private DataDynamics.ActiveReports.SubReport srptGrafica;
        private DataDynamics.ActiveReports.TextBox TextBox;
        private DataDynamics.ActiveReports.TextBox TextBox1;
        private DataDynamics.ActiveReports.Label Label1;
    }
}
